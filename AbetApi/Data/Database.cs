using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;
using AbetApi.EFModels;
using AbetApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;

namespace AbetApi.Data
{
    // This class is a WIP. It will be used to house helper functions for interfacing with the database.
    public class Database
    {
        //This helper function clears all tables
        // If new tables are added, ensure they are made in to DbSet containers in the context object, and then add them to this function.
        public async static void WipeTables()
        {
            await using (var context = new ABETDBContext())
            {
                context.Courses.Clear();
                context.CourseOutcomes.Clear();
                context.Grades.Clear();
                context.Majors.Clear();
                context.MajorOutcomes.Clear();
                context.Sections.Clear();
                context.Semesters.Clear();
                context.Users.Clear();
                context.Roles.Clear();
                context.Surveys.Clear();
                context.StudentOutcomesCompleted.Clear();
                context.SaveChanges();
            }
        }

        public async void DropDatabase()
        {
            await using (var context = new ABETDBContext())
            {
                context.Database.EnsureDeleted();
            }
        }

        public void WIPDoStuff()
        {

            /*
            _ = Semester.AddSemester(new Semester("Spring", 2022));
            _ = Course.AddCourse("Spring", 2022, new Course("cas0231", "1030", "Something", "", false, "CSCE"));
            _ = Course.AddCourse("Spring", 2022, new Course("cas0231", "1040", "Something", "", false, "CSCE"));
            _ = Course.AddCourse("Spring", 2022, new Course("cas0231", "3600", "Whatever", "", false, "CSCE"));

            _ = Section.AddSection("Spring", 2022, "CSCE", "1030", new Section("cas0231", false, "001", 12));
            _ = Section.AddSection("Spring", 2022, "CSCE", "1030", new Section("cas0231", false, "002", 15));
            _ = Section.AddSection("Spring", 2022, "CSCE", "1030", new Section("cas0231", false, "003", 29));

            _ = Section.AddSection("Spring", 2022, "CSCE", "1040", new Section("cas0231", false, "001", 33));
            _ = Section.AddSection("Spring", 2022, "CSCE", "1040", new Section("cas0231", false, "002", 13));
            _ = Section.AddSection("Spring", 2022, "CSCE", "1040", new Section("cas0231", false, "003", 5));

            _ = Section.AddSection("Spring", 2022, "CSCE", "3600", new Section("cas0231", false, "001", 150));
            _ = Section.AddSection("Spring", 2022, "CSCE", "3600", new Section("cas0231", false, "002", 739));
            _ = Section.AddSection("Spring", 2022, "CSCE", "3600", new Section("cas0231", false, "003", 42));

            _ = CourseOutcome.CreateCourseOutcome("Spring", 2022, "CSCE", "1030", new CourseOutcome("1", "Some description 1"));
            _ = CourseOutcome.CreateCourseOutcome("Spring", 2022, "CSCE", "1030", new CourseOutcome("2", "Some description 2"));
            _ = CourseOutcome.CreateCourseOutcome("Spring", 2022, "CSCE", "1030", new CourseOutcome("3", "Some description 3"));

            _ = CourseOutcome.CreateCourseOutcome("Spring", 2022, "CSCE", "1040", new CourseOutcome("1", "Some description 1"));
            _ = CourseOutcome.CreateCourseOutcome("Spring", 2022, "CSCE", "1040", new CourseOutcome("2", "Some description 2"));
            _ = CourseOutcome.CreateCourseOutcome("Spring", 2022, "CSCE", "1040", new CourseOutcome("3", "Some description 3"));

            _ = CourseOutcome.CreateCourseOutcome("Spring", 2022, "CSCE", "3600", new CourseOutcome("1", "Some description 1"));
            _ = CourseOutcome.CreateCourseOutcome("Spring", 2022, "CSCE", "3600", new CourseOutcome("2", "Some description 2"));
            _ = CourseOutcome.CreateCourseOutcome("Spring", 2022, "CSCE", "3600", new CourseOutcome("3", "Some description 3"));

            _ = Major.AddMajor("Spring", 2022, "CS");
            _ = Major.AddMajor("Spring", 2022, "IT");

            _ = MajorOutcome.AddMajorOutcome("Spring", 2022, "CS", new MajorOutcome("1", "Accomplishes gud at computers"));
            _ = MajorOutcome.AddMajorOutcome("Spring", 2022, "CS", new MajorOutcome("2", "Accomplishes making type fast"));
            _ = MajorOutcome.AddMajorOutcome("Spring", 2022, "CS", new MajorOutcome("3", "Accomplishes websites"));

            _ = MajorOutcome.AddMajorOutcome("Spring", 2022, "IT", new MajorOutcome("1", "IT MO #1"));
            _ = MajorOutcome.AddMajorOutcome("Spring", 2022, "IT", new MajorOutcome("2", "IT MO #2"));
            _ = MajorOutcome.AddMajorOutcome("Spring", 2022, "IT", new MajorOutcome("3", "IT MO #3"));

            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "1030", "1", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "1030", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "1030", "2", "CS", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "1030", "3", "CS", "3");

            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "1040", "1", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "1040", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "1040", "2", "CS", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "1040", "3", "CS", "3");

            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "3600", "1", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "3600", "2", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "1040", "2", "CS", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Spring", 2022, "CSCE", "1040", "3", "CS", "3");

            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "001", "1", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "002", "1", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "003", "1", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "001", "2", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "002", "2", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "003", "2", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "001", "3", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "002", "3", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "003", "3", "CS", 10);

            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "001", "1", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "002", "1", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "003", "1", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "001", "2", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "002", "2", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "003", "2", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "001", "3", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "002", "3", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "003", "3", "CS", 10);

            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "001", "1", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "002", "1", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "003", "1", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "001", "2", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "002", "2", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "003", "2", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "001", "3", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "002", "3", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "003", "3", "CS", 10);

            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "001", "1", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "002", "1", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "003", "1", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "001", "2", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "002", "2", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "003", "2", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "001", "3", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "002", "3", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1030", "003", "3", "IT", 10);

            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "001", "1", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "002", "1", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "003", "1", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "001", "2", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "002", "2", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "003", "2", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "001", "3", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "002", "3", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "1040", "003", "3", "IT", 10);

            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "001", "1", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "002", "1", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "003", "1", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "001", "2", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "002", "2", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "003", "2", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "001", "3", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "002", "3", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Spring", 2022, "CSCE", "3600", "003", "3", "IT", 10);
            */
            //For testing the deep copy.
            //_ = Semester.AddSemester(new Semester("Fall", 2022));
            //Semester.DeepCopy("Fall", 2022, "Spring", 2022);

            /* ================= INFINITE LOOP & TEAM 27 ================= */

            WipeTables();

            // create a new semester
            _ = Semester.AddSemester(new Semester("Fall", 2022));

            // add majors to semester
            _ = Major.AddMajor("Fall", 2022, "CE");
            _ = Major.AddMajor("Fall", 2022, "CS");
            _ = Major.AddMajor("Fall", 2022, "IT");

            // add courses to semester
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1030", "Computer Science I", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1030", "Computer Science I", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1030", "Computer Science I", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1035", "Computer Programming I", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1040", "Computer Science II", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1045", "Computer Programming II", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "2100", "Foundations of Computing", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "2100", "Foundations of Computing", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "2100", "Foundations of Computing", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "2110", "Foundations of Data Structures", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "2110", "Foundations of Data Structures", "", false, "CSCE"));

            // add sections to courses
            _ = Section.AddSection("Fall", 2022, "CSCE", "1030", new Section("pls0112", false, "001", 120, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "1030", new Section("pls0112", false, "002", 120, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "1030", new Section("amm0813", false, "003", 130, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "1030", new Section("amm0813", false, "004", 94, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "1030", new Section("dr0702", false, "501", 25, false));

            _ = Section.AddSection("Fall", 2022, "CSCE", "1035", new Section("bj0141", false, "001", 32, false));

            _ = Section.AddSection("Fall", 2022, "CSCE", "1040", new Section("dmk0080", false, "001", 118, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "1040", new Section("dmk0080", false, "002", 118, false));

            _ = Section.AddSection("Fall", 2022, "CSCE", "1045", new Section("bm0756", false, "001", 32, false));

            _ = Section.AddSection("Fall", 2022, "CSCE", "2100", new Section("yl0340", false, "001", 75, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2100", new Section("yl0340", false, "002", 75, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2100", new Section("yl0340", false, "003", 68, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2100", new Section("hw0109", false, "004", 95, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2100", new Section("dr0702", false, "550", 40, false));

            _ = Section.AddSection("Fall", 2022, "CSCE", "2110", new Section("csc0168", false, "001", 110, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2110", new Section("csc0168", false, "002", 110, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2110", new Section("dr0702", false, "501", 40, false));

            // add major outcomes ** STUDENT OUTCOMES ** 
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CE", new MajorOutcome("1", "An ability to identify, formulate, and solve complex engineering problems by applying principles of engineering, science, and mathematics."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CE", new MajorOutcome("2", "An ability to apply engineering design to produce solutions that meet specified needs with consideration of public health, safety,and welfare, as well as global, cultural, social, environmental, and economic factors."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CE", new MajorOutcome("3", "An ability to communicate effectively with a range of audiences."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CE", new MajorOutcome("4", "An ability to recognize ethical and professional responsibilities in engineering situations and make informed judgments, which must consider the impact of engineering solutions in global, economic, environmental, and societal contexts."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CE", new MajorOutcome("5", "An ability to function effectively on a team whose members together provide leadership, create a collaborative and inclusive environment, establish goals, plan tasks, and meet objectives."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CE", new MajorOutcome("6", "An ability to develop and conduct appropriate experimentation, analyze and interpret data, and use engineering judgment to draw conclusions."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CE", new MajorOutcome("7", "An ability to acquire and apply new knowledge as needed, using appropriate learning strategies."));

            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("1", "An ability to analyze a complex computing problem and to apply principles of computing and other relevant disciplines to identify solutions."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("2", "An ability to design, implement, and evaluate a computing-based solution to meet a given set of computing requirements in the context of the program’s discipline."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("3", "An ability to communicate effectively in a variety of professional contexts."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("4", "An ability to recognize professional responsibilities and make informed judgements in computing practice based on legal and ethical principles."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("5", "An ability to function effectively as a member or leader of a team engaged in activities appropriate to the program’s discipline."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("6", "An ability to apply computer science theory and software development fundamentals to produce computing-based solutions."));

            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "IT", new MajorOutcome("1", "An ability to analyze a complex computing problem and to apply principles of computing and other relevant disciplines to identify solutions."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "IT", new MajorOutcome("2", "An ability to design, implement, and evaluate a computing-based solution to meet a given set of computing requirements in the context of the program’s discipline."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "IT", new MajorOutcome("3", "An ability to communicate effectively in a variety of professional contexts."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "IT", new MajorOutcome("4", "An ability to recognize professional responsibilities and make informed judgements in computing practice based on legal and ethical principles."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "IT", new MajorOutcome("5", "An ability to function effectively as a member or leader of a team engaged in activities appropriate to the program’s discipline."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "IT", new MajorOutcome("6", "An ability to identify and analyze user needs and to take them into account in the selection, creation, integration, evaluation, and administration of computing-based systems."));

            // add course outcome to course
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1030", new CourseOutcome("1", "Describe how a computer’s CPU, Main Memory, Secondary Storage and I/O work together to execute a computer program."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1030", new CourseOutcome("2", "Make use of a computer system’s hardware, editor(s), operating system, system software and network to build computer software and submit that software for grading."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1030", new CourseOutcome("3", "Describe algorithms to perform “simple” tasks such as numeric computation, searching and sorting, choosing among several options, string manipulation, and use of pseudo-random numbers in simulation of such tasks as rolling dice."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1030", new CourseOutcome("4", "Write readable, efficient and correct C/C++ programs that include programming structures such as assignment statements, selection statements, loops, arrays, pointers, console and file I/O, structures, command line arguments, both standard library and user-defined functions, and multiple header (.h) and code (.c or .cpp) files."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1030", new CourseOutcome("5", "Use commonly accepted practices and tools to find and fix runtime and logical errors in software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1030", new CourseOutcome("6", "Describe a software process model that can be used to develop significant applications composed of hundreds of functions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1030", new CourseOutcome("7", "Perform the steps necessary to edit, compile, link and execute C/C++ programs."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1035", new CourseOutcome("1", "Describe how a computer’s CPU, Main Memory, Secondary Storage, and I/O work together to execute a computer program."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1035", new CourseOutcome("2", "Make use of a computer system’s hardware, editor(s), operating system, system software, and network to build computer software and submit that software for grading."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1035", new CourseOutcome("3", "Describe algorithms to perform \"simple\" tasks such as numeric computation, searching and sorting, choosing among several options, string manipulation, and use of pseudo-random numbers in simulation of tasks such as rolling dice."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1035", new CourseOutcome("4", "Write readable, efficient, and correct programs that include programming structures such as assignment and selection statements, loops, lists, console and file I/O, command line arguments, and both standard library and user-defined functions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1035", new CourseOutcome("5", "Use commonly accepted practices and tools to find and fix syntax, runtime, and logical errors in software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1035", new CourseOutcome("6", "Describe a software process model that can be used to develop significant applications composed of hundreds of functions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1035", new CourseOutcome("7", "Perform the steps necessary to edit and execute programs."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1040", new CourseOutcome("1", "Write readable, efficient, and correct C++ programs for all programming constructs defined for Programming Fundamentals I plus dynamic memory allocation, bit manipulation operators, exceptions, classes and inheritance."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1040", new CourseOutcome("2", "Design and implement recursive algorithms in C/C++."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1040", new CourseOutcome("3", "Use common data structures and techniques such as stacks, queues, linked lists, trees and hashing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1040", new CourseOutcome("4", "Create programs using the Standard Template Library."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1040", new CourseOutcome("5", "Use a symbolic debugger to find and fix runtime and logical errors in C software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1040", new CourseOutcome("6", "Using a software process model, design and implement a significant software application in C++. Significant software in this context means a software application with at least five files, ten functions and a make file."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1040", new CourseOutcome("7", "Implement, compile and run C++ programs that includes classes, inheritance, virtual functions, function overloading and overriding, as well as other aspects of Polymorphism."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1045", new CourseOutcome("1", "Write readable, efficient, and correct programs for basic programming constructs plus dynamic memory allocation, bit manipulation operators, exceptions, classes, and inheritance."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1045", new CourseOutcome("2", "Design and implement recursive algorithms using a modern programming language."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1045", new CourseOutcome("3", "Use common data structures and techniques such as stacks, queues, linked lists, trees, and hashing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1045", new CourseOutcome("4", "Create programs using the appropriate libraries for the programming language."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1045", new CourseOutcome("5", "Use a symbolic debugger to find and fix runtime and logical errors in software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1045", new CourseOutcome("6", "Use a software process model to design and implement a significant software application in a modern programming language consisting of multiple files and functions and a make file."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1045", new CourseOutcome("7", "Implement, compile, and run programs that include classes, inheritance, virtual functions, function overloading and overriding, as well as other aspects of polymorphism."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2100", new CourseOutcome("1", "Define and use the basic operations of sets, functions, and relations."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2100", new CourseOutcome("2", "Define and demonstrate the basic properties of trees and graphs."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2100", new CourseOutcome("3", "Use elementary graph and tree algorithms including traversals and searches."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2100", new CourseOutcome("4", "Describe assertions in propositional logic form."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2100", new CourseOutcome("5", "Describe simple circuits, I/O, and satisfiability using Boolean logic."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2100", new CourseOutcome("6", "Use combinatorics and conditional probability in solving real-world problems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2100", new CourseOutcome("7", "Demonstrate a solid foundation in conceptual and formal models by describing loop structures in summation and/or product notation."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2100", new CourseOutcome("8", "Demonstrate an introductory knowledge of finite state machines."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2110", new CourseOutcome("1", "Demonstrate the ability to use Integrated Development Environments (IDE) and use formal debugging tools and techniques to develop C/C++ programs. "));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2110", new CourseOutcome("2", "Demonstrate the ability to develop unit tests and testing strategies for C/C++ programs."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2110", new CourseOutcome("3", "Demonstrate the ability to use code repositories for project development."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2110", new CourseOutcome("4", "Use abstraction in the design and implementation of algorithms, such as sorting and searching algorithms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2110", new CourseOutcome("5", "Design and implement programming solutions to problems in C or C++."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2110", new CourseOutcome("6", "Collaborate with other students in a team towards the design and development of programming solutions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2110", new CourseOutcome("7", "Use regular expressions in C/C++ programs to match patterns."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "2110", new CourseOutcome("8", "Use of hash tables in design of software."));

            // link major outcomes to course outcomes **STUDENT OUTCOME TO COURSE OUTCOME**
            // 1030 CE
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "3", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "4", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "1", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "2", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "5", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "6", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "7", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "4", "CE", "4");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "3", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "4", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "7", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "3", "CE", "7");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "4", "CE", "7");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "7", "CE", "7");
            // 1035 CE (same as 1030)
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "3", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "4", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "1", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "2", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "5", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "6", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "7", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "4", "CE", "4");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "3", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "4", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "7", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "3", "CE", "7");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "4", "CE", "7");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "7", "CE", "7");
            // 1040 CE
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "1", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "2", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "3", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "4", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "5", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "6", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "2", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "6", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "7", "CE", "2");
            // 1045 CE (same as 1040)
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "1", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "2", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "3", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "4", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "5", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "6", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "2", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "6", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "7", "CE", "2");
            // 2100 CE
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "1", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "2", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "6", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "3", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "5", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "3", "CE", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "5", "CE", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "3", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "4", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "5", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "7", "CE", "7");
            // 2110 CE
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "5", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "6", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "1", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "2", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "3", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "4", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "1", "CE", "5");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "2", "CE", "5");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "3", "CE", "5");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "4", "CE", "5");
            // 1030 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "3", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "4", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "2", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "5", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "6", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "7", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "3", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "4", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "7", "CS", "6");
            // 1035 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "3", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "4", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "2", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "5", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "6", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "7", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "3", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "4", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "7", "CS", "6");
            // 1040 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "2", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "5", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "3", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "4", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "6", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "7", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "2", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "3", "CS", "6");
            // 1045 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "2", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "5", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "3", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "4", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "6", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "7", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "2", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "3", "CS", "6");
            // 2100 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "1", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "2", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "4", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "5", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "7", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "8", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "3", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "6", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "7", "CS", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "3", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "6", "CS", "6");
            // 2110 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "4", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "7", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "8", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "4", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "5", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "1", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "2", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "3", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "5", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "6", "CS", "6");

            // 1030 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "3", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "1", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "2", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "5", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "6", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "7", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "3", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "4", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "7", "IT", "6");
            // 1035 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "3", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "1", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "2", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "5", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "6", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "7", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "3", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "4", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1035", "7", "IT", "6");
            // 1040 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "1", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "2", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "3", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "5", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "6", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "2", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "6", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "7", "IT", "2"); 
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "6", "IT", "6");
            // 1045 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "1", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "2", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "3", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "5", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "6", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "2", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "6", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "7", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1045", "6", "IT", "6");
            // 2100 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "1", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "2", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "5", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "8", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "3", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "6", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "7", "IT", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "3", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2100", "6", "IT", "6");
            // 2110 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "8", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "4", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "5", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "1", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "2", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "3", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "5", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "2110", "6", "IT", "6");

            //Adds Users
            _ = User.AddUser(new User("Curtis", "Chambers", "csc0168"));
            _ = User.AddUser(new User("Beilei", "Jiang", "bj0141"));
            _ = User.AddUser(new User("David", "Keathly", "dmk0080"));
            _ = User.AddUser(new User("Yuan", "Li", "yl0340"));
            _ = User.AddUser(new User("Amar", "Majarjan", "amm0813"));
            _ = User.AddUser(new User("Beddhu", "Murali", "bm0756"));
            _ = User.AddUser(new User("Diana", "Rabah", "dr0702"));
            _ = User.AddUser(new User("Pradhumna", "Shrestha", "pls0112"));
            _ = User.AddUser(new User("Haili", "Wang", "hw0109"));

            _ = User.AddUser(new User("Co", "Ordinator", "coordinator"));
            _ = User.AddUser(new User("Ad", "Min", "admin"));

            //Creates default roles
            _ = Role.CreateRole(new Role("Admin"));
            _ = Role.CreateRole(new Role("Coordinator"));
            _ = Role.CreateRole(new Role("Instructor"));
            _ = Role.CreateRole(new Role("Student"));

            //Gives admin access to:

            //Gives instructor access to:
            _ = Role.AddRoleToUser("csc0168", "Instructor");
            _ = Role.AddRoleToUser("bj0141", "Instructor");
            _ = Role.AddRoleToUser("dmk0080", "Instructor");
            _ = Role.AddRoleToUser("yl0340", "Instructor");
            _ = Role.AddRoleToUser("amm0813", "Instructor");
            _ = Role.AddRoleToUser("bm0756", "Instructor");
            _ = Role.AddRoleToUser("dr0702", "Instructor");
            _ = Role.AddRoleToUser("pls0112", "Instructor");
            _ = Role.AddRoleToUser("hw0109", "Instructor");
            _ = Role.AddRoleToUser("coordinator", "Coordinator");
            _ = Role.AddRoleToUser("admin", "Admin");

            //For testing the deep copy.
            //_ = Semester.AddSemester(new Semester("Spring", 2023));
            //Semester.DeepCopy("Spring", 2023, "Fall", 2022);

            /* ====== END ====== INFINITE LOOP & TEAM 27 ====== END ====== */

            /* ====== BEGIN ====== STORM SYSTEM & AGILE MINDS ====== BEGIN ====== */

            // WipeTables();

            // Try to complete an old course
            // _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1030", "Computer Science I", "", false, "CSCE"));
            // Grade(string Major, int A, int B, int C, int D, int F, int W, int I, int TotalStudents)
            // _ = Grade.SetGrades("Fall", 2022, "CSCE", "1030", "001", new List<Grade>(60));

            // create a new semester
            _ = Semester.AddSemester(new Semester("Fall", 2023));
			
			// add majors to semester
            _ = Major.AddMajor("Fall", 2023, "CE");
            _ = Major.AddMajor("Fall", 2023, "CS");
            _ = Major.AddMajor("Fall", 2023, "IT");
			
			// add courses to semester
			// _ = Course.AddCourse("Fall", 2023, new Course("coordinatorEUID", "CourseNumber", "DisplayName", "Coordinator Comment", isCourseCompleted, "Department"));
            _ = Course.AddCourse("Fall", 2023, new Course("coordinator", "1010", "Discovering Computer Science", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "1030", "Computer Science I", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "1035", "Computer Programming I", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "1040", "Computer Science II", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "1045", "Computer Programming II", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "2100", "Foundations of Computing", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "2110", "Foundations of Data Structures", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "2610", "Assembly Language and Computer Organization", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3010", "Signals and Systems", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3055", "IT Project Management", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3110", "Data Structures and Algorithms", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3201", "Applied Artificial Intelligence", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3220", "Human Computer Interfaces", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3420", "Internet Programming", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3444", "Software Engineering", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3530", "Introduction to Computer Networks", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3550", "Foundations of Cybersecurity", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3600", "Principles of Systems Programming", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3605", "Systems Administration", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3615", "Enterprise Systems Architecture and Design", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "3730", "Reconfigurable Logic", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4010", "Social Issues in Computing", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4110", "Algorithms", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4115", "Formal Languages, Automata, and Computability", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4205", "Introduction to Machine Learning", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4210", "Game Programming I", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4255", "CProgramming Math and Physics for Games", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4290", "Introduction to Natural Language Processing", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4350", "Fundamentals of Database Systems", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4355", "Database Administration", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4430", "Programming Languages", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4520", "Wireless Networks and Protocols", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4535", "Introduction to Network Administration", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4555", "Computer Forensics", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4560", "Secure Electronic Commerce", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4565", "Secure Software development", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4575", "Blockchain and Applications", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4600", "Introduction to Operating Systems", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4620", "Real-Time Operating Systems", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4810", "Bioinformatics Algorithms", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4901", "Software Development Capstone I", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4902", "Software Development Capstone II", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4905", "Information Technology Capstone I", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4907", "Cybersecurity Capstone I", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4910", "Computer Engineering Design I", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4920", "Cooperative Education in Computer Science and Engineering", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4925", "Information Technology Capstone II", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4930", "Topcis in Computer Science and Engineering", "", false, "CSCE"));


            // add sections to courses
            // _ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("InstructorEUID", IsSectionCompleted, "SectionNumber", NumberOfStudents));
            _ = Section.AddSection("Fall", 2023, "CSCE", "1010", new Section("dmk0080", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1010", new Section("dmk0080", false, "306", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1010", new Section("dmk0080", false, "307", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("pls0112", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("amm0813", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("amm0813", false, "003", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("pls0112", false, "004", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("dr0702", false, "501", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("amm0813", false, "340", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("amm0813", false, "342", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("amm0813", false, "341", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("amm0813", false, "343", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("pls0112", false, "336", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("pls0112", false, "339", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("pls0112", false, "332", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("pls0112", false, "335", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("amm0813", false, "334", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("amm0813", false, "338", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("amm0813", false, "333", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("amm0813", false, "337", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("pls0112", false, "344", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("pls0112", false, "347", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("pls0112", false, "348", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("pls0112", false, "345", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("dr0702", false, "551", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("dr0702", false, "550", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1035", new Section("hg0002", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1035", new Section("hg0002", false, "306", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1035", new Section("hg0002", false, "307", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1040", new Section("dmk0080", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1040", new Section("dmk0080", false, "315", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1040", new Section("dmk0080", false, "316", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1040", new Section("dmk0080", false, "309", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1040", new Section("dmk0080", false, "311", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1040", new Section("dmk0080", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1040", new Section("dmk0080", false, "310", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1040", new Section("dmk0080", false, "314", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1040", new Section("dmk0080", false, "313", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1040", new Section("dmk0080", false, "312", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1045", new Section("hg0002", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "1045", new Section("hg0002", false, "306", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "218", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("dr0702", false, "501", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "218", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "214", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "215", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "222", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "223", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("dr0702", false, "552", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "219", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "003", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "216", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "217", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2100", new Section("yl0340", false, "224", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("csc0168", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("csc0168", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("csc0168", false, "212", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("csc0168", false, "210", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("csc0168", false, "214", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("csc0168", false, "216", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("csc0168", false, "215", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("csc0168", false, "211", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("csc0168", false, "213", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("csc0168", false, "217", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("fi0003", false, "501", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2110", new Section("fi0003", false, "551", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2610", new Section("rjp0004", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2610", new Section("rjp0004", false, "003", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2610", new Section("rjp0004", false, "206", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2610", new Section("rjp0004", false, "208", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "2610", new Section("rjp0004", false, "210", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3010", new Section("ra0005", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3055", new Section("rmg0006", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3110", new Section("svp0007", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3110", new Section("xg0008", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3201", new Section("me0009", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3220", new Section("bm0756", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3420", new Section("gtj0010", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3420", new Section("rmg0006", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3444", new Section("hg0002", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3444", new Section("hg0002", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3530", new Section("ehf0011", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3530", new Section("rmg0006", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3550", new Section("mdh0012", false, "501", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3550", new Section("mdh0012", false, "551", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3550", new Section("jh0013", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3550", new Section("jh0013", false, "203", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3550", new Section("jh0013", false, "201", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3550", new Section("jh0013", false, "204", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3550", new Section("jh0013", false, "206", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("svp0007", false, "003", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("svp0007", false, "004", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("svp0007", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("csc0168", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("svp0007", false, "213", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("svp0007", false, "215", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("svp0007", false, "214", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("svp0007", false, "208", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("svp0007", false, "210", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("svp0007", false, "209", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("csc0168", false, "212", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3600", new Section("csc0168", false, "211", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3605", new Section("mdh0012", false, "501", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3615", new Section("csc0168", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3730", new Section("rjp0004", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3730", new Section("rjp0004", false, "201", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "3730", new Section("rjp0004", false, "202", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4010", new Section("me0009", false, "003", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4010", new Section("me0009", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4010", new Section("dr0702", false, "501", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4110", new Section("bm0014", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4110", new Section("bm0014", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4110", new Section("fi0003", false, "501", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4115", new Section("bm0014", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4205", new Section("zt0015", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4210", new Section("jd0016", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4210", new Section("jd0016", false, "201", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4210", new Section("jd0016", false, "202", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4210", new Section("jd0016", false, "204", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4255", new Section("jd0016", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4290", new Section("fh0017", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4350", new Section("fi0003", false, "501", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4350", new Section("jh0013", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4355", new Section("sws0018", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4430", new Section("bm0756", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4520", new Section("qy0019", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4535", new Section("ehf0011", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4555", new Section("ehf0011", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4560", new Section("az0020", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4565", new Section("lb0021", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4565", new Section("lb0021", false, "003", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4575", new Section("bm0756", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4600", new Section("jd0016", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4600", new Section("jh0013", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4620", new Section("bj0141", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4810", new Section("sb0022", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4810", new Section("sb0022", false, "401", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4901", new Section("wma0023", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4901", new Section("sal0024", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4902", new Section("dr0702", false, "501", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4902", new Section("wma0023", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4905", new Section("dmk0080", false, "001", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4907", new Section("pls0112", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4910", new Section("rjp0004", false, "002", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4910", new Section("pls0112", false, "003", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4920", new Section("dmk0080", false, "752", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4920", new Section("dmk0080", false, "721", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4925", new Section("dr0702", false, "501", 60, false));
			_ = Section.AddSection("Fall", 2023, "CSCE", "4930", new Section("sal0024", false, "001", 60, false));
			
			
			// add major outcomes ** STUDENT OUTCOMES ** 
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CE", new MajorOutcome("1", "An ability to identify, formulate, and solve complex engineering problems by applying principles of engineering, science, and mathematics."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CE", new MajorOutcome("2", "An ability to apply engineering design to produce solutions that meet specified needs with consideration of public health, safety,and welfare, as well as global, cultural, social, environmental, and economic factors."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CE", new MajorOutcome("3", "An ability to communicate effectively with a range of audiences."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CE", new MajorOutcome("4", "An ability to recognize ethical and professional responsibilities in engineering situations and make informed judgments, which must consider the impact of engineering solutions in global, economic, environmental, and societal contexts."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CE", new MajorOutcome("5", "An ability to function effectively on a team whose members together provide leadership, create a collaborative and inclusive environment, establish goals, plan tasks, and meet objectives."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CE", new MajorOutcome("6", "An ability to develop and conduct appropriate experimentation, analyze and interpret data, and use engineering judgment to draw conclusions."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CE", new MajorOutcome("7", "An ability to acquire and apply new knowledge as needed, using appropriate learning strategies."));

            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CS", new MajorOutcome("1", "An ability to analyze a complex computing problem and to apply principles of computing and other relevant disciplines to identify solutions."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CS", new MajorOutcome("2", "An ability to design, implement, and evaluate a computing-based solution to meet a given set of computing requirements in the context of the program’s discipline."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CS", new MajorOutcome("3", "An ability to communicate effectively in a variety of professional contexts."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CS", new MajorOutcome("4", "An ability to recognize professional responsibilities and make informed judgements in computing practice based on legal and ethical principles."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CS", new MajorOutcome("5", "An ability to function effectively as a member or leader of a team engaged in activities appropriate to the program’s discipline."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "CS", new MajorOutcome("6", "An ability to apply computer science theory and software development fundamentals to produce computing-based solutions."));

            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "IT", new MajorOutcome("1", "An ability to analyze a complex computing problem and to apply principles of computing and other relevant disciplines to identify solutions."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "IT", new MajorOutcome("2", "An ability to design, implement, and evaluate a computing-based solution to meet a given set of computing requirements in the context of the program’s discipline."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "IT", new MajorOutcome("3", "An ability to communicate effectively in a variety of professional contexts."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "IT", new MajorOutcome("4", "An ability to recognize professional responsibilities and make informed judgements in computing practice based on legal and ethical principles."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "IT", new MajorOutcome("5", "An ability to function effectively as a member or leader of a team engaged in activities appropriate to the program’s discipline."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2023, "IT", new MajorOutcome("6", "An ability to identify and analyze user needs and to take them into account in the selection, creation, integration, evaluation, and administration of computing-based systems."));
			
			// add course outcome to course
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("1", "Describe how a computer’s CPU, Main Memory, Secondary Storage and I/O work together to execute a computer program."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("2", "Make use of a computer system’s hardware, editor(s), operating system, system software and network to build computer software and submit that software for grading."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("3", "Describe algorithms to perform “simple” tasks such as numeric computation, searching and sorting, choosing among several options, string manipulation, and use of pseudo-random numbers in simulation of such tasks as rolling dice."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("4", "Write readable, efficient and correct C/C++ programs that include programming structures such as assignment statements, selection statements, loops, arrays, pointers, console and file I/O, structures, command line arguments, both standard library and user-defined functions, and multiple header (.h) and code (.c or .cpp) files."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("5", "Use commonly accepted practices and tools to find and fix runtime and logical errors in software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("6", "Describe a software process model that can be used to develop significant applications composed of hundreds of functions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("7", "Perform the steps necessary to edit, compile, link and execute C/C++ programs."));
			
			// link major outcomes to course outcomes **STUDENT OUTCOME TO COURSE OUTCOME**
            // 1030 CE
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "3", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "4", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "1", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "2", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "5", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "6", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "7", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "4", "CE", "4");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "3", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "4", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "7", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "3", "CE", "7");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "4", "CE", "7");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "7", "CE", "7");
            // 1035 CE (same as 1030)
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "3", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "4", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "1", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "2", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "5", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "6", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "7", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "4", "CE", "4");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "3", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "4", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "7", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "3", "CE", "7");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "4", "CE", "7");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "7", "CE", "7");
            // 1040 CE
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "1", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "2", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "3", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "4", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "5", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "6", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "2", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "6", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "7", "CE", "2");
            // 1045 CE (same as 1040)
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "1", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "2", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "3", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "4", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "5", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "6", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "2", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "6", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "7", "CE", "2");
            // 2100 CE
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "1", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "2", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "6", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "3", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "5", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "3", "CE", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "5", "CE", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "3", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "4", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "5", "CE", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "7", "CE", "7");
            // 2110 CE
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "5", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "6", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "7", "CE", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "1", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "2", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "3", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "4", "CE", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "1", "CE", "5");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "2", "CE", "5");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "3", "CE", "5");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "4", "CE", "5");
            // 1030 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "3", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "4", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "2", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "5", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "6", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "7", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "3", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "4", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "7", "CS", "6");
            // 1035 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "3", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "4", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "2", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "5", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "6", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "7", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "3", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "4", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "7", "CS", "6");
            // 1040 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "2", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "5", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "3", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "4", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "6", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "7", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "2", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "3", "CS", "6");
            // 1045 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "2", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "5", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "3", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "4", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "6", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "7", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "2", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "3", "CS", "6");
            // 2100 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "1", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "2", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "4", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "5", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "7", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "8", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "3", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "6", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "7", "CS", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "3", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "6", "CS", "6");
            // 2110 CS
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "4", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "7", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "8", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "4", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "5", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "1", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "2", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "3", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "5", "CS", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "6", "CS", "6");

            // 1030 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "3", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "1", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "2", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "5", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "6", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "7", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "3", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "4", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1030", "7", "IT", "6");
            // 1035 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "3", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "1", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "2", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "5", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "6", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "7", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "3", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "4", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1035", "7", "IT", "6");
            // 1040 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "1", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "2", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "3", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "5", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "6", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "2", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "6", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "7", "IT", "2"); 
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1040", "6", "IT", "6");
            // 1045 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "1", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "2", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "3", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "5", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "6", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "2", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "6", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "7", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "1045", "6", "IT", "6");
            // 2100 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "1", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "2", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "5", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "8", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "3", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "6", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "7", "IT", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "3", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2100", "6", "IT", "6");
            // 2110 IT
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "4", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "7", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "8", "IT", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "4", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "5", "IT", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "1", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "2", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "3", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "5", "IT", "6");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2023, "CSCE", "2110", "6", "IT", "6");
			
			//Adds Users (Commented users were already added in the Fall 2022 section)
			// _ = User.AddUser(new User("David", "Keathly", "dmk0080"));
			// _ = User.AddUser(new User("Pradhumna", "Shrestha", "pls0112"));
			// _ = User.AddUser(new User("Amar", "Majarjan", "amm0813"));
			// _ = User.AddUser(new User("Diana", "Rabah", "dr0702"));
			_ = User.AddUser(new User("Hadiseh", "Gooranorimi", "hg0002"));
			// _ = User.AddUser(new User("Yuan", "Li", "yl0340"));
            // _ = User.AddUser(new User("Curtis", "Chambers", "csc0168"));
			_ = User.AddUser(new User("Faridul", "Islam", "fi0003"));
			_ = User.AddUser(new User("Robin", "Pottathuparambil", "rjp0004"));
			_ = User.AddUser(new User("Robert", "Akl", "ra0005"));
			_ = User.AddUser(new User("Ryan", "Garlick", "rmg0006"));
			_ = User.AddUser(new User("Satya", "Parupudi", "svp0007"));
			_ = User.AddUser(new User("Xuan", "Guo", "xg0008"));
			_ = User.AddUser(new User("Moawia", "Eldow", "me0009"));
			// _ = User.AddUser(new User("Beddhu", "Murali", "bm0756"));
			_ = User.AddUser(new User("Gary", "James", "gtj0010"));
			_ = User.AddUser(new User("Ervin", "Frenzel", "ehf0011"));
			_ = User.AddUser(new User("Mark", "Hoffman", "mdh0012"));
			_ = User.AddUser(new User("Jacob", "Hochstetler", "jh0013"));
			_ = User.AddUser(new User("Bahareh", "Mokarramdorri", "bm0014"));
			_ = User.AddUser(new User("Zeenat", "Tariq", "zt0015"));
			_ = User.AddUser(new User("Jonathon", "Doran", "jd0016"));
			_ = User.AddUser(new User("Frederik", "Hartmann", "fh0017"));
			_ = User.AddUser(new User("Steven", "Smith", "sws0018"));
			_ = User.AddUser(new User("Qing", "Yang", "qy0019"));
			_ = User.AddUser(new User("Ali", "Zarafshani", "az0020"));
			_ = User.AddUser(new User("Lotfi", "Benothmane", "lb0021"));
			// _ = User.AddUser(new User("Beilei", "Jiang", "bj0141"));
			_ = User.AddUser(new User("Serdar", "Bozdag", "sb0022"));
			_ = User.AddUser(new User("Wajdi", "Aljedaani", "wma0023"));
			_ = User.AddUser(new User("Stephanie", "Ludi", "sal0024"));

            //_ = User.AddUser(new User("Co", "Ordinator", "coordinator"));
            //_ = User.AddUser(new User("Ad", "Min", "admin"));

            //Creates default roles (Already Created)
            // _ = Role.CreateRole(new Role("Admin"));
            // _ = Role.CreateRole(new Role("Coordinator"));
            // _ = Role.CreateRole(new Role("Instructor"));
            // _ = Role.CreateRole(new Role("Student"));

            _ = Role.CreateRole(new Role("Assistant"));

            //Gives admin access to:

            //Gives instructor access to:
            // _ = Role.AddRoleToUser("coordinator", "Coordinator");
            // _ = Role.AddRoleToUser("admin", "Admin");

            // Testing
            _ = Course.AddCourse("Fall", 2023, new Course("coordinator", "1234", "Introduction to Sleeping", "", false, "CSCE"));
            _ = Section.AddSection("Fall", 2023, "CSCE", "1234", new Section("instructor", false, "123", 60, false));
            _ = Section.AddSection("Fall", 2023, "CSCE", "1234", new Section("instructor", false, "321", 60, false));
            _ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("instructor", false, "777", 60, false));

            _ = User.AddUser(new User("Alcott", "Vincent", "vea0028"));
            _ = User.AddUser(new User("In", "Structor", "instructor"));
            _ = Role.AddRoleToUser("instructor", "Instructor");
            _ = Role.AddRoleToUser("vea0028", "Assistant");

            _ = Section.AddAssistantToSection("assistant", "Fall", 2023, "CSCE", "1030", "777");
            _ = Section.AddAssistantToSection("assistant", "Fall", 2023, "CSCE", "1234", "123");

            _ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4666", "Advanced Sleeping", "", false, "CSCE"));
            _ = Section.AddSection("Fall", 2023, "CSCE", "4666", new Section("instructor", false, "456", 60, false));
            _ = User.AddUser(new User("Rogers", "Matthew", "mar0468"));
            _ = Role.AddRoleToUser("mar0468", "Assistant");
            _ = Section.AddAssistantToSection("mar0468", "Fall", 2023, "CSCE", "4666", "456");
        }

        // This function is here to run arbitrary code from the database class
        // Currently, it's being used to test creating/editing data in the database
        public void DoStuff()
        {
            //Deleted all data from tables
            WipeTables();

            //Adds Users
            _ = User.AddUser(new User("Frits", "Odell", "feo0589"));
            _ = User.AddUser(new User("Clemente", "Sergei", "cas0231"));

            _ = User.EditUser("feo0589", new User("Scrappy", "Eagle", "feo0589"));

            _ = User.DeleteUser("cas0231");

            //NOTES: User Crud
            //User.AddUser(new User("Frits", "Odell", "cas0231"));
            //User.EditUser("cas0231", new User("Sponge", "Bob", "cas0231"));
            //User.DeleteUser("cas0231");
            //var result = User.GetUser("cas0231").Result;

            //Creates default roles
            _ = Role.CreateRole(new Role("Admin"));
            _ = Role.CreateRole(new Role("Coordinator"));
            _ = Role.CreateRole(new Role("Instructor"));
            _ = Role.CreateRole(new Role("Fellow"));
            _ = Role.CreateRole(new Role("FullTime"));
            _ = Role.CreateRole(new Role("Adjunct"));
            _ = Role.CreateRole(new Role("Student"));

            //Gives admin access to:
            _ = Role.AddRoleToUser("feo0589", "Admin");
            _ = Role.AddRoleToUser("cas0231", "Admin");

            //Gives instructor access to:
            _ = Role.AddRoleToUser("feo0589", "Instructor");
            _ = Role.AddRoleToUser("cas0231", "Instructor");

            //this returns a list of users by the entered roll
            //var adminListTask = Role.GetUsersByRole("Admin");
            //var adminList = adminListTask.Result;

            //Role.RemoveRoleFromUser("cas0231", "Admin");

            //Semester class testing
            /////////////////////////////////////////////////////////////////////////////////
            //Create
            _ = Semester.AddSemester(new Semester("Spring", 2022));
            _ = Semester.AddSemester(new Semester("Fall", 2022));
            _ = Semester.AddSemester(new Semester("Summer", 2022));
            _ = Semester.AddSemester(new Semester("Spring", 2023));
            _ = Semester.AddSemester(new Semester("Fall", 2023));
            _ = Semester.AddSemester(new Semester("Summer", 2023));
            //Read
            var springSemester = Semester.GetSemester("Spring", 2022);
            var fallSemester = Semester.GetSemester("Fall", 2022); // This won't work. It returns null when it can't find something
            //Update
            _ = Semester.EditSemester("Spring", 2022, new Semester("Winter", 2022));
            //Read (again)
            springSemester = Semester.GetSemester("Spring", 2022);
            fallSemester = Semester.GetSemester("Fall", 2022);
            //Delete
            //Semester.DeleteSemester("Fall", 2022);
            System.Console.WriteLine(""); //This is a placeholder for a debugger break point

            //Major class testing
            /////////////////////////////////////////////////////////////////////////////////
            _ = Major.AddMajor("Fall", 2022, "CS");
            _ = Major.AddMajor("Fall", 2022, "IT");
            _ = Major.AddMajor("Fall", 2022, "CYS");
            //var temp = Major.GetMajor("Fall", 2022, "CS");
            //temp = Major.GetMajor("Fall", 2022, "CSE"); // return null
            //Major.EditMajor("Fall", 2022, "CS", new Major("IT"));
            //Major.DeleteMajor("Fall", 2022, "IT");
            System.Console.WriteLine("");

            //MajorOutcome class testing
            /////////////////////////////////////////////////////////////////////////////////
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("1", "Accomplishes gud at computers"));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("2", "Accomplishes making type fast"));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("3", "Accomplishes websites"));
            var tempMajorOutcome = MajorOutcome.GetMajorOutcome("Fall", 2022, "CS", "2");
            _ = MajorOutcome.EditMajorOutcome("Fall", 2022, "CS", "3", new MajorOutcome("3", "Gud at spelung"));
            //MajorOutcome.DeleteMajorOutcome("Fall", 2022, "CS", "3");

            System.Console.WriteLine("");

            //Course class testing
            /////////////////////////////////////////////////////////////////////////////////
            _ = Course.AddCourse("Fall", 2022, new Course("cas0231", "3600", "Whatever", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("cas0231", "1040", "Something", "", false, "CSCE"));
            //var course = Course.GetCourse("Fall", 2022, "CSCE", "3600"); // This is an example of a get function that loads one of the lists
            //var tempSemester = Semester.GetSemester("Fall", 2022); // This is a dumb get function, that only returns exactly what you ask for without the lists

            //Course.EditCourse("Fall", 2022, "CSCE", "3600", new Course("cas0231", "2110", "It changed!", "", false, "CSCE"));
            //var course = Course.GetCourse("Fall", 2022, "CSCE", "2110");
            //course = Course.GetCourse("Fall", 2022, "BLEGH", "2110");
            //Course.DeleteCourse("Fall", 2022, "CSCE", "2110");

            //var temp = Semester.GetCourses("Fall", 2022);

            //Section class testing
            /////////////////////////////////////////////////////////////////////////////////
            _ = Section.AddSection("Fall", 2022, "CSCE", "3600", new Section("cas0231", false, "001", 150, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "3600", new Section("cas0231", false, "002", 739, false));
            _ = Section.AddSection("Fall", 2022, "CSCE", "3600", new Section("cas0231", false, "003", 42, false));
            //var temp = Course.GetSections("Fall", 2022, "CSCE", "3600");
            //var temp = Section.GetSection("Fall", 2022, "CSCE", "3600", "001");
            _ = Section.EditSection("Fall", 2022, "CSCE", "3600", "002", new Section("cas0231", true, "002", 140, false));
            _ = Section.DeleteSection("Fall", 2022, "CSCE", "3600", "001");


            //CourseOutcome class testing
            /////////////////////////////////////////////////////////////////////////////////
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "3600", new CourseOutcome("1", "Some description 1"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "3600", new CourseOutcome("2", "Some description 2"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1040", new CourseOutcome("1", "Some description 1"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1040", new CourseOutcome("2", "Some description 2"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2022, "CSCE", "1040", new CourseOutcome("2", "Some different description 2")); // This overwrites the other 2 for this course

            //CourseOutcome.AddMajorOutcome("Fall", 2022, "CSCE", "3600", "CS", "739");// These next 3 will not work
            //CourseOutcome.AddMajorOutcome("Fall", 2022, "CSCE", "3600", "CS", "22");
            //CourseOutcome.AddMajorOutcome("Fall", 2022, "CSCE", "1040", "CS", "42");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "2", "CS", "1"); // This one should work
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "3600", "1", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "3600", "2", "CS", "2");

            System.Console.WriteLine("");

            //CourseOutcome.DeleteCourseOutcome("Fall", 2022, "CSCE", "1040", "2");

            //CourseOutcome.RemoveLinkToMajorOutcome("Fall", 2022, "CSCE", "1040", "2", "CS", "2");

            System.Console.WriteLine(""); //This is a placeholder for a debugger break point
            //Testing for section grades in the section class
            /////////////////////////////////////////////////////////////////////
            //Grade.SetSectionGrade("Fall", 2022, "CSCE", "3600", "002", new Grade())
            List<Grade> grades = new List<Grade>();
            grades.Add(new Grade("CSCE", 1, 2, 3, 4, 5, 6, 7, 666));
            grades.Add(new Grade("EENG", 8, 9, 10, 11, 12, 13, 14, 999));
            _ = Grade.SetGrades("Fall", 2022, "CSCE", "3600", "002", grades);


            //Testing section for StudentOutcomesCompleted
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Fall", 2022, "CSCE", "3600", "002", "1", "CS", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Fall", 2022, "CSCE", "3600", "002", "2", "IT", 20);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Fall", 2022, "CSCE", "3600", "002", "1", "IT", 10);
            _ = StudentOutcomesCompleted.SetStudentOutcomesCompleted("Fall", 2022, "CSCE", "3600", "002", "2", "CS", 20);

            var temp = StudentOutcomesCompleted.GetStudentOutcomesCompleted("Fall", 2022, "CSCE", "3600", "002");

            //var eh = CourseOutcome.MapCourseOutcomeToMajorOutcome("Fall", 2022, "CSCE", "1040", "3", "CS").Result;
            System.Console.WriteLine(""); //This is a placeholder for a debugger break point


        }
    }
}
