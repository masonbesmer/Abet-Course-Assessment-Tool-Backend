﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using AbetApi.Data;

//! The EFModels namespace
/*! 
 * This namespace falls under the AbetAPI namespace, and is for EFModels.
 * The EFModels are generally called from the Controllers namespace, to 
 * provide the controllers functionality, ultimately giving endpoints/functionality
 * for the UI elements
 */
namespace AbetApi.EFModels
{
    //! The Semester Class
    /*! 
     * This class gets called by the SemesterController class
     * and provides functions to get and return data
     */
    public class Semester
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        //! The SemesterID setter/getter function
        /*! 
         * This is a single line dual function for setting and getting
         */
        public int SemesterId { get; set; }
        //! The Year setter/getter function
        /*! 
         * This is a single line dual function for setting and getting
         */
        public int Year { get; set; }
        //! The Term setter/getter function
        /*! 
         * This is a single line dual function for setting and getting
         */
        public string Term { get; set; }
        //string Session { get; set; } // Session is not required. All courses fall under the purview of spring/fall.
        [JsonIgnore]
        //! The Courses setter/getter function
        /*! 
         * This is a single line dual function for setting and getting
         */
        public ICollection<Course> Courses { get; set; }
        [JsonIgnore]
        //! The Majors setter/getter function
        /*! 
         * This is a single line dual function for setting and getting
         */
        public ICollection<Major> Majors { get; set; }

        //! Paramaterized Constructor
        /*! 
         * This constructor creates an empty semester.
         * You must add majors and courses afterwards
         * \param Term The Term (Fall/Spring) for the given semester
         * \param year The year for the given semester
         */
        public Semester(string Term, int year)
        {
            this.Term = Term;
            this.Year = year;
        }

        //! Constructor
        /*! 
         * This Constructor builds courses and majors for semester
         */
        Semester()
        {
            this.Courses = new List<Course>();
            this.Majors = new List<Major>();
        }

        //! The AddSemester Function
        /*! 
         * This function adds a semester to the database. It is an async Task to pass exceptions to the Controllers.SemesterController in Controllers.
         * It first sets the user id to 0 so that the entity framework will give it a primary key.
         * It then checks to see if the term of the semester is null. Then checks if the semester year 
         * is less than 1890. It formats the term string to a standard and opens a context with the database.
         * It then checks to see if the semester is already in the database and throws an exception if it is.
         * Otherwise, it is then added and then saves the changes.
         * \param semester This is a semester object to hold various data, such as year, term, courses, majors, outcomes, etc.
         */
        public async static Task AddSemester(Semester semester)
        {
            // Sets the user id to be 0, so entity framework will give it a primary key
            semester.SemesterId = 0;

            //Check the term is not null or empty.
            if (semester.Term == null || semester.Term == "")
            {
                throw new ArgumentException("The term cannot be empty.");
            }

            //Check the year is not before the establishment of the university.
            if (semester.Year < 1890)
            {
                throw new ArgumentException("The year cannot be empty, or less than the establishment date of UNT.");
            }

            //Format the term string to follow a standard.
            semester.Term = semester.Term[0].ToString().ToUpper() + semester.Term[1..].ToLower();

            //Opens a context with the database, makes changes, and saves the changes
            await using (var context = new ABETDBContext())
            {
                //Try to find the semester in the database.
                Semester duplicateSemester = context.Semesters.FirstOrDefault(p => p.Term == semester.Term && p.Year == semester.Year);

                //If the semester already exists in the database, then throw an exception.
                if(duplicateSemester != null)
                {
                    throw new ArgumentException("The semester you are trying to add already exists in the database.");
                }

                context.Semesters.Add(semester);
                context.SaveChanges();

                return;
            }
        } // AddSemester

        //! The GetSemester function
        /*! 
         * This function searches for a semester with the provided term and year and returns a semester object. 
         * It is an async Task<Semester> to pass exceptions and a semester object to the Controllers.SemesterController in Controllers.
         * It returns null if the item isn't found.
         * \param term The term (Spring/Fall) of the respective semester
         * \param year The year of the respective semester
         */
        public async static Task<Semester> GetSemester(string term, int year)
        {
            //Check the term is not null or empty.
            if (term == null || term == "")
            {
                throw new ArgumentException("The term cannot be empty.");
            }

            //Check the year is not before the establishment of the university.
            if (year < 1890)
            {
                throw new ArgumentException("The year cannot be empty, or less than the establishment date of UNT.");
            }

            //Format the term string to follow a standard.
            term = term[0].ToString().ToUpper() + term[1..].ToLower();

            //Try to find the specified semester.
            await using (var context = new ABETDBContext())
            {
                Semester semester = context.Semesters.FirstOrDefault(p => p.Term == term && p.Year == year);

                //If the specified semester does not exist, then throw an exception.
                if(semester == null)
                {
                    throw new ArgumentException("The specified semester does not exist in the databaase.");
                }

                return semester;
            }
        }

        //COULD GIVE INDICATION OF NO SEMESTERS LISTED
        //! The GetSemesters function
        /*! 
         * This function returns all semesters in the Semester table from the database.
         * It is an async Task<List<Semester>> to pass exceptions and a list of semester objects to the Controllers.SemesterController in Controllers.
         */
        public static async Task<List<Semester>> GetSemesters()
        {
            await using (var context = new ABETDBContext())
            {
                return context.Semesters.ToList();
            }
        } // GetSemesters

        //! The EditSemester function
        /*! 
         * This function finds a semester by term and year, and updates the semester to the values of the provided semester object.
         * Note: This function may need to also include editing courses and majors in the future, but it's not here currently that 
         * data will need to have its own dedicated functions for editing.
         * It is an async Task to pass exceptions to the Controllers.SemesterController in Controllers.
         * It first checks to make sure the semester term is not null and that the year is greater than 1890. It then checks to make sure
         * the new input term is not null and that the new input year is also greater than 1890. It formats the term strings to the standard
         * and checks to make sure the semester to be edited exists (otherwise throws an exception). After this, it checks to see if the
         * new semester info is a duplicate and throws an exception if it is. Otherwise the changes are made and saved.
         * \param term The term (Spring/Fall) of the respective semester
         * \param year The year of the respective semester
         * \param NewValue A semester object to provide new values to an old semester object
         */
        public static async Task EditSemester(string term, int year, Semester NewValue)
        {
            //Check that the term of the semester to be edited is not null or empty.
            if (term == null || term == "")
            {
                throw new ArgumentException("The term for which semester to edit cannot be empty.");
            }

            //Check that the year is not before the establishment of the university.
            if (year < 1890)
            {
                throw new ArgumentException("The year for which semester to edit cannot be empty, or less than the establishment date of UNT.");
            }

            //Check that the new term is not null or empty.
            if (NewValue.Term == null || NewValue.Term == "")
            {
                throw new ArgumentException("The new term cannot be empty.");
            }

            //Check that the new year is not before the establishment of the university.
            if (NewValue.Year < 1890)
            {
                throw new ArgumentException("The new year cannot be empty, or less than the establishment date of UNT.");
            }

            //Format the term strings to follow a standard.
            term = term[0].ToString().ToUpper() + term[1..].ToLower();
            NewValue.Term = NewValue.Term[0].ToString().ToUpper() + NewValue.Term[1..].ToLower();

            await using (var context = new ABETDBContext())
            {
                //Try to find the specified semester to be edited.
                Semester semester = context.Semesters.FirstOrDefault(p => p.Term == term && p.Year == year);

                //If the semester specified to edit does not exist, then throw an exception.
                if (semester == null)
                {
                    throw new ArgumentException("The specified semester does not exist in the database.");
                }

                //Try to find the new semester information in the database.
                Semester duplicateSemester = context.Semesters.FirstOrDefault(p => p.Term == NewValue.Term && p.Year == NewValue.Year);

                //If we do find the new information then that is a duplicate and we don't allow duplicates.
                if (duplicateSemester != null)
                {
                    throw new ArgumentException("That semester already exists in the database.");
                }

                //Copy new values of semester over to the semester that's being edited
                semester.Term = NewValue.Term;
                semester.Year = NewValue.Year;

                context.SaveChanges();
            }
        }

        //! The DeleteSemester function
        /*! 
         * This function finds a semester and deletes it.. Anybody calling this function should make sure you want to call this function. Deletions are final.
         * It is an async Task to pass exceptions to the Controllers.SemesterController in Controllers.
         * First checks to make sure the semester term is not null and that the year is greater than 1890 (otherwise throws exceptions). It formats the term string
         * to a standard, and tries to find the semester to delete (throws an exception otherwise). If found, it deletes it and saves the changes.
         * \param Term The Term (Fall/Spring) for the given semester
         * \param year The year for the given semester
         */
        public async static Task DeleteSemester(string term, int year)
        {
            //Check that the term of the semester is not null or empty.
            if (term == null || term == "")
            {
                throw new ArgumentException("The term for which semester to delete cannot be empty.");
            }

            //Check that the year is not before the establishment of the university.
            if (year < 1890)
            {
                throw new ArgumentException("The year for which semester to delete cannot be empty, or less than the establishment date of UNT.");
            }

            //Format the term string to follow a standard.
            term = term[0].ToString().ToUpper() + term[1..].ToLower();

            await using (var context = new ABETDBContext())
            {
                //Try to find the specified semester.
                Semester semester = context.Semesters.FirstOrDefault(p => p.Term == term && p.Year == year);

                //If the specified semester does not exist, then throw an exception.
                if(semester == null)
                {
                    throw new ArgumentException("The semester specified to delete does not exist in the database.");
                }

                context.Remove(semester);
                context.SaveChanges();
            }
        } // DeleteSemester


        //! The GetCourses function
        /*! 
         * This function gets courses related to a term and year of a semester.
         * It first checks to see if the semester term is null and that the year is greater than 1890 (throws and exception otherwise).
         * It then formats the term spring to a standard and checks if the semester exists (throws an exception otherwise). It then retrieves the courses
         * and passes them back to the controller in a list.
         * \param Term The Term (Fall/Spring) for the given semester
         * \param year The year for the given semester
         */
        public static async Task<List<Course>> GetCourses(string term, int year)
        {
            //Check that the term of the semester is not null or empty..
            if (term == null || term == "")
            {
                throw new ArgumentException("The term for which semester's courses to display cannot be empty.");
            }

            //Check that the year is not before the establishment of the university.
            if (year < 1890)
            {
                throw new ArgumentException("The year for which semester's courses to display cannot be empty, or less than the establishment date of UNT.");
            }

            //Format the term string to follow a standard.
            term = term[0].ToString().ToUpper() + term[1..].ToLower();

            await using (var context = new ABETDBContext())
            {
                //Try to find the specified semester.
                Semester semester = context.Semesters.FirstOrDefault(p => p.Term == term && p.Year == year);

                //Throw an exception if the semester specified does not exist.
                if(semester == null)
                {
                    throw new ArgumentException("The semester specified does not exist in the database.");
                }

                context.Entry(semester).Collection(semester => semester.Courses).Load();

                return semester.Courses.ToList();
            }
        }

        //! The GetCoursesCompleted function
        /*! 
         * This function gets the completion status of each course in a semester and returns it as a dictionary of (string) course numbers associated with (boolean) course completion status.
         * It first checks to see if the semester term is null and that the year is greater than 1890 (throws and exception otherwise).
         * It then formats the term spring to a standard and checks if the semester exists (throws an exception otherwise). It then retrieves the courses
         * and iterates through them to check if all sections of the course have been completed.
         * \param Term The Term (Fall/Spring) for the given semester
         * \param year The year for the given semester
         */
        public static async Task<Dictionary<string, bool>> GetCoursesCompleted(string term, int year)
        {
            Dictionary<string, bool> DictOfCourseCompletion = new Dictionary<string, bool>();

            //Check that the term of the semester is not null or empty..
            if (term == null || term == "")
            {
                throw new ArgumentException("The term for which semester's courses to display cannot be empty.");
            }

            //Check that the year is not before the establishment of the university.
            if (year < 1890)
            {
                throw new ArgumentException("The year for which semester's courses to display cannot be empty, or less than the establishment date of UNT.");
            }

            //Format the term string to follow a standard.
            term = term[0].ToString().ToUpper() + term[1..].ToLower();

            await using (var context = new ABETDBContext())
            {
                //Try to find the specified semester.
                Semester semester = context.Semesters.FirstOrDefault(p => p.Term == term && p.Year == year);

                //Throw an exception if the semester specified does not exist.
                if (semester == null)
                {
                    throw new ArgumentException("The semester specified does not exist in the database.");
                }

                context.Entry(semester).Collection(semester => semester.Courses).Load();

                foreach (Course course in semester.Courses.ToList())
                {
                    context.Entry(course).Collection(course => course.Sections).Load();

                    bool CourseCompleted = true;

                    foreach (Section section in course.Sections.ToList())
                    {
                        // If ANY section is not submitted, then the course is counted as incomplete.
                        if (section.IsFormSubmitted == false)
                        {
                            CourseCompleted = false;
                            break;
                        }
                    }

                    DictOfCourseCompletion.Add(course.CourseNumber, CourseCompleted);
                }

                return DictOfCourseCompletion;
            }
        }

        //The deep copy function is for bringing over data from previous semesters, so that personnel entering data don't have to enter the same data for hundreds of courses/sections manually
        //It should copy semesters, courses, sections, section outcomes, majors, major outcomes
        //This function takes a new semester and reads old semester data in to it
        //Any time you add something new to the overall data structure, you'll need to make sure this gets updated appropriately.

        //FIXME - This is not done yet. Don't rely on it. It doesn't have an endpoint in a controller yet.
        public static async Task DeepCopy(string newTerm, int newYear, string previousTerm, int previousYear)
        {
            //Semester error handling

            //Check that the term of the semester is not null or empty..
            if (newTerm == null || newTerm == "" || previousTerm == null || previousTerm == "")
            {
                throw new ArgumentException("The term for which semester's courses to display cannot be empty.");
            }

            //Check that the year is not before the establishment of the university.
            if (newYear < 1890 || previousYear < 1890)
            {
                throw new ArgumentException("The year for which semester's courses to display cannot be empty, or less than the establishment date of UNT.");
            }

            //Format the term string to follow a standard.
            newTerm = newTerm[0].ToString().ToUpper() + newTerm.Substring(1);
            previousTerm = previousTerm[0].ToString().ToUpper() + previousTerm.Substring(1);

            await using (var context = new ABETDBContext())
            {
                //Try to find the specified new  and old semesters.
                Semester newSemester = context.Semesters.FirstOrDefault(p => p.Term == newTerm && p.Year == newYear);
                Semester previousSemester = context.Semesters.FirstOrDefault(p => p.Term == previousTerm && p.Year == previousYear);

                //Throw an exception if the semester specified does not exist.
                if (newSemester == null || previousSemester == null)
                {
                    throw new ArgumentException("The semester specified does not exist in the database.");
                }

                //Moving forward, this function will assume that the new semester is completely empty
                //It will copy all relevant data from the old semester.
                //FIXME - will probably need error handling in case they did manually add something, but the deep copy tries to add a duplicate
                //Note - There is a lot of re-scanning over things here, but I wrote it that way so it was easier to read and know what's going on. It doesn't need to be hyper-performant because it only happens once a semester.

                //Load courses and majors
                context.Entry(previousSemester).Collection(previousSemester => previousSemester.Courses).Load();
                context.Entry(previousSemester).Collection(previousSemester => previousSemester.Majors).Load();

                //copies all the courses
                foreach (var course in previousSemester.Courses)
                {
                    Course tempCourse = new Course(course.CoordinatorEUID, course.CourseNumber, course.DisplayName, course.CoordinatorComment, course.IsCourseCompleted, course.Department);
                    tempCourse.CourseId = 0;
                    context.Courses.Add(tempCourse);
                    newSemester.Courses.Add(tempCourse);
                }

                //Loads all sections
                foreach(var course in previousSemester.Courses)
                {
                    context.Entry(course).Collection(course => course.Sections).Load();
                }

                //Copies all sections
                foreach(var course in previousSemester.Courses)
                {
                    foreach(var section in course.Sections)
                    {
                        //This hard codes all section student totals to 0, because this data doesn't carry over to the next semester
                        await Section.AddSection(newTerm, newYear, course.Department, course.CourseNumber, new Section(section.InstructorEUID, section.IsSectionCompleted, section.SectionNumber, 0, false));
                    }
                }

                //Copies all the majors
                foreach (var major in previousSemester.Majors)
                {
                    Major tempMajor = new Major(major.Name);
                    tempMajor.MajorId = 0;
                    context.Majors.Add(tempMajor);
                    newSemester.Majors.Add(tempMajor);
                }

                //Load all course outcomes and major outcomes
                foreach (var course in previousSemester.Courses)
                {
                    context.Entry(course).Collection(course => course.CourseOutcomes).Load();
                }
                foreach (var major in previousSemester.Majors)
                {
                    context.Entry(major).Collection(major => major.MajorOutcomes).Load();
                }

                //Copies all major outcomes
                foreach(var major in previousSemester.Majors)
                {
                    foreach(var majorOutcome in major.MajorOutcomes)
                    {
                        await MajorOutcome.AddMajorOutcome(newTerm, newYear, major.Name, new MajorOutcome(majorOutcome.Name, majorOutcome.Description));
                    }
                }

                //Copies all course outcomes
                foreach(var course in previousSemester.Courses)
                {
                    foreach(var courseOutcome in course.CourseOutcomes)
                    {
                        await CourseOutcome.CreateCourseOutcome(newTerm, newYear, course.Department, course.CourseNumber, new CourseOutcome(courseOutcome.Name, courseOutcome.Description));
                    }
                }
                
                //load the mapped majoroutcomes, link them

                foreach(var course in previousSemester.Courses)
                {
                    foreach(var courseOutcome in course.CourseOutcomes)
                    {
                        //load the mapped major outcomes, link them
                        System.Console.WriteLine("");
                    }
                }


                context.SaveChanges();
                return;
            }
        }
    }
    /*
        As of November 17th, 2021, the current semester catalogue is:
            Fall 2021
                8W1 Session
                8W2 Session
            Spring 2022
                3W1 Session  (Side note: This is the winter semester)
                8W1 Session
                8W2 Session
            Summer 2022
                3W1 Session
                8W1 Session
                8W2 Session
                5W1 Session
                10W Session
                5W2 Session
     */
}
