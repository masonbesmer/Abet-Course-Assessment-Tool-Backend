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
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4255", "Programming Math and Physics for Games", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4290", "Introduction to Natural Language Processing", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4350", "Fundamentals of Database Systems", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4355", "Database Administration", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4430", "Programming Languages", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4520", "Wireless Networks and Protocols", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4535", "Introduction to Network Administration", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4555", "Computer Forensics", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4560", "Secure Electronic Commerce", "", false, "CSCE"));
			_ = Course.AddCourse("Fall", 2023, new Course("coordinator", "4565", "Secure Software Developement", "", false, "CSCE"));
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
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1010", new CourseOutcome("1", "Students will practice and enhance their creative abilities within the development of software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1010", new CourseOutcome("2", "Students will use abstraction to reduce information and detail in order to facilitate focus on relevant topics. In software this typically occurs both in designing algorithms and creating modules within their programs."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1010", new CourseOutcome("3", "Students will access and summarize available data to create information and evaluate information to create knowledge."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1010", new CourseOutcome("4", "Students will develop, evaluate and use algorithms in defining solutions to computational problems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1010", new CourseOutcome("5", "Students will create software that enables problem solving, human expression and creation of knowledge."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1010", new CourseOutcome("6", "Students will both describe how the internet pervades modern computing and make effective and ethical use of the internet in solving problems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1010", new CourseOutcome("7", "Students will recognize, discuss and describe the global impacts of computing."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1020", new CourseOutcome("1", "Understand programming and problem solving."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1020", new CourseOutcome("2", "Understand and be able to develop algorithms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1020", new CourseOutcome("3", "Be able to develop, design and implement simple computer programs."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1020", new CourseOutcome("4", "Understand how to perform basic debugging of existing programs."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1020", new CourseOutcome("5", "Understand functions and parameter passing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1020", new CourseOutcome("6", "Be able to do numeric (algebraic) and string based computation."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("1", "Describe how a computer’s CPU, Main Memory, Secondary Storage and I/O work together to execute a computer program."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("2", "Make use of a computer system’s hardware, editor(s), operating system, system software and network to build computer software and submit that software for grading."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("3", "Describe algorithms to perform “simple” tasks such as numeric computation, searching and sorting, choosing among several options, string manipulation, and use of pseudo-random numbers in simulation of such tasks as rolling dice."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("4", "Write readable, efficient and correct C/C++ programs that include programming structures such as assignment statements, selection statements, loops, arrays, pointers, console and file I/O, structures, command line arguments, both standard library and user-defined functions, and multiple header (.h) and code (.c or .cpp) files."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("5", "Use commonly accepted practices and tools to find and fix runtime and logical errors in software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("6", "Describe a software process model that can be used to develop significant applications composed of hundreds of functions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1030", new CourseOutcome("7", "Perform the steps necessary to edit, compile, link and execute C/C++ programs."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1035", new CourseOutcome("1", "Describe how a computer’s CPU, Main Memory, Secondary Storage, and I/O work together to execute a computer program."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1035", new CourseOutcome("2", "Make use of a computer system’s hardware, editor(s), operating system, system software, and network to build computer software and submit that software for grading."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1035", new CourseOutcome("3", "Describe algorithms to perform “simple” tasks such as numeric computation, searching and sorting, choosing among several options, string manipulation, and use of pseudorandom numbers in simulation of tasks such as rolling dice."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1035", new CourseOutcome("4", "Write readable, efficient, and correct programs that include programming structures such as assignment and selection statements, loops, lists, console and file I/O, command line arguments, and both standard library and user-defined functions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1035", new CourseOutcome("5", "Use commonly accepted practices and tools to find and fix syntax, runtime, and logical errors in software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1035", new CourseOutcome("6", "Describe a software process model that can be used to develop significant applications composed of hundreds of functions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1035", new CourseOutcome("7", "Perform the steps necessary to edit and execute programs."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1040", new CourseOutcome("1", "Write readable, efficient, and correct C++ programs for all programming constructs defined for Programming Fundamentals I plus dynamic memory allocation, bit manipulation operators, exceptions, classes and inheritance."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1040", new CourseOutcome("2", "Design and implement recursive algorithms in C/C++."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1040", new CourseOutcome("3", "Use common data structures and techniques such as stacks, queues, linked lists, trees and hashing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1040", new CourseOutcome("4", "Create programs using the Standard Template Library."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1040", new CourseOutcome("5", "Use a symbolic debugger to find and fix runtime and logical errors in C software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1040", new CourseOutcome("6", "Using a software process model, design and implement a significant software application in C++. Significant software in this context means a software application with at least five files, ten functions and a make file."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1040", new CourseOutcome("7", "Implement, compile and run C++ programs that includes classes, inheritance, virtual functions, function overloading and overriding, as well as other aspects of Polymorphism."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1045", new CourseOutcome("1", "Write readable, efficient, and correct programs for basic programming constructs plus dynamic memory allocation, bit manipulation operators, exceptions, classes, and inheritance."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1045", new CourseOutcome("2", "Design and implement recursive algorithms using a modern programming language."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1045", new CourseOutcome("3", "Use common data structures and techniques such as stacks, queues, linked lists, trees, and hashing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1045", new CourseOutcome("4", "Create programs using the appropriate libraries for the programming language."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1045", new CourseOutcome("5", "Use a symbolic debugger to find and fix runtime and logical errors in software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1045", new CourseOutcome("6", "Use a software process model to design and implement a significant software application in a modern programming language consisting of multiple files and functions and a make file."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "1045", new CourseOutcome("7", "Implement, compile, and run programs that include classes, inheritance, virtual functions, function overloading and overriding, as well as other aspects of polymorphism."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2100", new CourseOutcome("1", "Demonstrate a solid foundation in conceptual and formal models by describing loop structures in summation and/or product notation."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2100", new CourseOutcome("2", "Use abstraction in the design and implementation of algorithms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2100", new CourseOutcome("3", "Design programming solutions to “simple” problems and implement those designs in C or C++."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2100", new CourseOutcome("4", "Apply big-Oh notation to evaluate and compare algorithms and programs."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2100", new CourseOutcome("5", "Use combinatorics and conditional probability in solving real-world problems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2100", new CourseOutcome("6", "Define the basic operations of sets, functions, relations, trees and graphs."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2100", new CourseOutcome("7", "Demonstrate an introductory knowledge of formal languages by using regular expressions, deterministic finite automata and non-deterministic finite automata to describe patterns in strings."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2110", new CourseOutcome("1", "Use of graph data structures in design of software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2110", new CourseOutcome("2", "Use of table data structures in design of software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2110", new CourseOutcome("3", "Use of set data structures in design of software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2110", new CourseOutcome("4", "Use of C++ classes to implement graphs, sets and relational data structures."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2110", new CourseOutcome("5", "Use of context-free grammars to describe patterns."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2110", new CourseOutcome("6", "The ability to describe assertions in propositional logic form."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2110", new CourseOutcome("7", "Use of amortized analysis to evaluate efficiency of data structure such as splay trees and O(1) expansion of tables."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2610", new CourseOutcome("1", "Understand the role of the different classes and components in a computer system and the interface between software and hardware in a computer system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2610", new CourseOutcome("2", "Apply metrics to evaluate performance of a computer system using clock rate and clock cycles per instruction (CPI). Understand the different aspects of execution times reported when program complete their execution."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2610", new CourseOutcome("3", "Understand instruction set choices and write assembly language programs for simple C code and codes that include procedures."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2610", new CourseOutcome("4", "Perform integer and floating point calculations using computer arithmetic algorithms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2610", new CourseOutcome("5", "Describe the organization of a simple processor with data path and control path for simple instructions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "2610", new CourseOutcome("6", "Describe the requirement of memory hierarchy and evaluate the performance of different cache organizations."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3010", new CourseOutcome("1", "Understand the mathematical descriptions of continuous-time (CT) and discrete-time (DT) signals."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3010", new CourseOutcome("2", "Understand the characteristics and properties of real systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3010", new CourseOutcome("3", "Analyze signals and systems in both the time and frequency domain."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3010", new CourseOutcome("4", "Gain experience with CT and DT Fourier series."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3010", new CourseOutcome("5", "Apply the properties of the Fourier transform, Laplace transform and z-transform to real systems."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3020", new CourseOutcome("1", "Analyze the frequency response of communication systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3020", new CourseOutcome("2", "Represent continuous-time signals by samples."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3020", new CourseOutcome("3", "Determine the energy and power spectral density of signals."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3020", new CourseOutcome("4", "Plot pole-zero diagrams."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3020", new CourseOutcome("5", "Design analog and digital filters."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3030", new CourseOutcome("1", "Differentiate between different types of parallel and distributed systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3030", new CourseOutcome("2", "Understand heterogeneous systems and accelerators."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3030", new CourseOutcome("3", "Write parallel programs for shared memory and GPU based systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3030", new CourseOutcome("4", "Analyze speed up achieved by parallel implementations of applications."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3030", new CourseOutcome("5", "Tune parallel programs to improve their performance."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3030", new CourseOutcome("6", "Apply parallel algorithms to solve matrix, graph, searching and sorting problems."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3055", new CourseOutcome("1", "Demonstrate the use of good project management techniques and tools in the development of a management plan for an IT project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3055", new CourseOutcome("2", "Demonstrate an understanding of the unique management requirements of different types of IT Systems projects."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3055", new CourseOutcome("3", "Develop a management plan and budget for an IT project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3055", new CourseOutcome("4", "Demonstrate an understanding of team management and conflict resolution skills through a number of small management projects."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3055", new CourseOutcome("5", "Create a system lifecycle document for a sample problem including all components using the Unified Modeling Language."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3110", new CourseOutcome("1", "Understand time complexity of algorithms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3110", new CourseOutcome("2", "Be able to solve recurrence relations."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3110", new CourseOutcome("3", "Understand and be able to analyze the performance of data structures for searching, including balanced trees, hash tables, and priority queues."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3110", new CourseOutcome("4", "Apply graphs in the context of data structures, including different representations, and analyze the usage of different data structures in the implementation of elementary graph algorithms including depth-first search, breadth-first search, topological ordering, Prim's algorithm, and Kruskal's algorithm."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3110", new CourseOutcome("5", "Be able to code the above-listed algorithms."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3201", new CourseOutcome("1", "Communicate effectively about the strategies, tools, and frameworks commonly used in application of AI."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3201", new CourseOutcome("2", "Extend tutorials and debug code to adapt available code to novel tasks."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3201", new CourseOutcome("3", "Perform valid machine learning predictions on tabular data sets."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3201", new CourseOutcome("4", "Link the limitations in the variety, quantity, or quality of available data common limitations in developed AI systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3201", new CourseOutcome("5", "Identify which problems likely have off-the-shelf solutions, which can be solved through reasonable effort, and which are challenging, open problems."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3210", new CourseOutcome("1", "Understand Lisp data types, internal functions, advanced Lisp objects and abstractions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3210", new CourseOutcome("2", "Understand the design principles of artificial intelligence."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3210", new CourseOutcome("3", "Understand basic principles of Search, two player games and neural networks."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3210", new CourseOutcome("4", "Understand one or more application in Artificial Intelligence."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3214", new CourseOutcome("1", "Use a high-level programming language to build and evaluate different machine learning models."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3214", new CourseOutcome("2", "Manage data collection, visualizing, preprocessing, and partitioning for machine learning applications."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3214", new CourseOutcome("3", "Analyze problems and craft appropriate solutions using existing products, API’s and other tools in combination with custom development as required."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3214", new CourseOutcome("4", "Create graphical user interface (GUI) and web applications for AI."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3214", new CourseOutcome("5", "Store code’s history and collaborate with others using code repositories and other collaboration tools."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3214", new CourseOutcome("6", "Properly document, share and explain problem solutions to collaborators and potential clients."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3220", new CourseOutcome("1", "Demonstrate knowledge of the contemporary best practices for user interface design."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3220", new CourseOutcome("2", "Perform the different phases of the interface design process."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3220", new CourseOutcome("3", "Demonstrate knowledge of user modeling and show how these models affect the design of an interface. "));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3220", new CourseOutcome("4", "Demonstrate that they can design and develop a computer-user interface using appropriate techniques."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3220", new CourseOutcome("5", "Perform different types of evaluations of interfaces."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3410", new CourseOutcome("1", "C++ : Be able to develop, design and implement simple computer programs. Java : Understand the format and use of objects. PHP : Understand process of executing a PHP-based script on a webserver. .NET : Display proficiency in C# by building stand-alone applications in the .NET framework using C#. Android Programming : Understand the existing state of mobile app development via researching existing apps, meeting with industry professionals, and formulating new ideas."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3410", new CourseOutcome("2", "C++ : Understand functions and parameter passing. Java : Understand basic input/output methods and their use. PHP : Be able to develop a form containing several fields and be able to process the data provided on the form by a user in a PHP-based script. .NET : Create distributed data-driven applications using the .NET Framework, C#, SQL Server and ADO.NET. Android Programming : Display proficiency in coding on a mobile programming platform."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3410", new CourseOutcome("3", "C++ : Be able to do numeric (algebraic) and string-based computation. Java : Understand object inheritance and its use. PHP : Understand basic PHP syntax for variable use, and standard language constructs, such as conditionals and loops. .NET : Create web-based distributed applications using C#, ASP.NET, SQL Server and ADO.NET. Android Programming : Understand the limitations and features of developing for mobile devices."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3410", new CourseOutcome("4", "C++ : Understand object-oriented design and programming. Java : Understand development of JAVA applets vs. JAVA applications. PHP : Understand the syntax and use of PHP object-oriented classes. .NET : Utilize DirectX libraries in the .NET environment to implement 2D and 3D animations and game-related graphic displays and audio. Android Programming : Create a complete Mobile app with a significant programming component, involving the sensors and hardware features of the phone."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3410", new CourseOutcome("5", "C++ : Understand dynamic memory allocation and pointers. Java : Understand the use of various system libraries. PHP : Understand the syntax and functions available to deal with file processing for files on the server as well as processing web URLs. .NET : Utilize XML in the .NET environment to create Web Service-based applications and components. Android Programming : Understand the economics and features of the app marketplace by offering the app for download."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3410", new CourseOutcome("6", "C++ : Be able to design, implement, and test relatively large C++ programs. PHP : Understand the paradigm for dealing with form-based data, both from the syntax of HTML forms, and how they are accessed inside a PHP-based script."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3420", new CourseOutcome("1", "Perform different types of evaluations of interfaces."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3420", new CourseOutcome("2", "Demonstrate knowledge of and proficiency in basic techniques for web-based design."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3420", new CourseOutcome("3", "Demonstrate knowledge of programming techniques for a web application."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3420", new CourseOutcome("4", "Demonstrate knowledge of collecting and processing information obtained through an Internet application, including integration with data storage."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3420", new CourseOutcome("5", "Develop web-based interactive functionality to process user data on the server-side."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3444", new CourseOutcome("1", "Use UML for design, such as use cases and class diagrams."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3444", new CourseOutcome("2", "Conduct software testing, such as validation, integration, and unit testing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3444", new CourseOutcome("3", "Conduct usability testing, such as heuristic evaluations."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3444", new CourseOutcome("4", "Participate in peer reviews such as code inspections."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3444", new CourseOutcome("5", "Communicate software product and process results in oral and written form."));

            // 3450 No Course Outcomes

            // 3520 Course Outcomes Pending

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3530", new CourseOutcome("1", "Understand a conceptual view of the role of computers in communications."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3530", new CourseOutcome("2", "Understand communication protocols in the Internet."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3530", new CourseOutcome("3", "Be able to do fundamental network programming."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3530", new CourseOutcome("4", "Understand different network architecture."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3530", new CourseOutcome("5", "Recognize the role of application protocols."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3530", new CourseOutcome("6", "Understand different routing and forwarding protocols."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3550", new CourseOutcome("1", "Understand common security terminology, threats, vulnerabilities, and security design principles."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3550", new CourseOutcome("2", "Understand basic cryptography concepts, and specific commonly used algorithms and protocols."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3550", new CourseOutcome("3", "Understand common program vulnerabilities, and secure programming techniques."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3550", new CourseOutcome("4", "Understand formal security models, including Bell-LaPadula (MLS), Biba, and Chinese Wall security."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3550", new CourseOutcome("5", "Understand basic network security issues and controls."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3550", new CourseOutcome("6", "Understand administrative issues in security, such as planning, security policies, and risk analysis."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3550", new CourseOutcome("7", "Understand privacy concepts and data anonymization."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3550", new CourseOutcome("8", "Obtain hands-on experience in using common security tools, such as firewalls, intrusion detection systems, and port scanning software."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3560", new CourseOutcome("1", "Examine different layers of the computer system and identify their operations and connections with the other layers."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3560", new CourseOutcome("2", "Describe and analyze the vulnerabilities in computer system layers including operating system, applications, hypervisors, storage, etc."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3560", new CourseOutcome("3", "Demonstrate how to detect and prevent existing vulnerabilities in a computer system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3560", new CourseOutcome("4", "Analyze and address/mitigate the detected vulnerabilities in hardware modules."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3560", new CourseOutcome("5", "Incorporate various defense techniques to protect a computer system."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3600", new CourseOutcome("1", "Write robust, efficient, readable and correct system software using the C programming language."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3600", new CourseOutcome("2", "Demonstrate an understanding of processes and threads by developing applications using multiple processes and multi-threaded activities in a Linux environment."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3600", new CourseOutcome("3", "Demonstrate an understanding of deadlocks and synchronization through the development of application(s) that utilize a variety of mutual exclusion mechanisms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3600", new CourseOutcome("4", "Develop shell scripts and utilities that demonstrate an understanding of memory, file and process management and interaction, including concepts such as virtual memory and disk scheduling."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3600", new CourseOutcome("5", "Create a Linux-based application that utilizes inter-process communication mechanisms such as pipes and sockets to communicate information between independently running processes on one or multiple platforms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3600", new CourseOutcome("6", "Demonstrate an understanding of the use and interaction among compilers, macro processors, assemblers, linkers and loaders through their use in creating the applications described in previous outcomes."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3605", new CourseOutcome("1", "Identify and analyze user needs."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3605", new CourseOutcome("2", "Structure user requirements in the selection, creation, evaluation and administration of computer-based systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3605", new CourseOutcome("3", "Demonstrate an understanding of the principles of computer systems maintenance by providing and maintaining computers for users with a wide range of computing needs and abilities."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3605", new CourseOutcome("4", "Design various hardware components such as switches, routers, load balancers, wireless controllers and network management platforms to provide network services that support interaction among computer-based systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3605", new CourseOutcome("5", "Effectively integrate IT-Based solutions into the user environment."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3610", new CourseOutcome("1", "Design ALUs to perform integer and floating point arithmetic including addition, subtraction, multiplication and division."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3610", new CourseOutcome("2", "Design a simple single-cycle processor using Hardware Description Language (HDL)."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3610", new CourseOutcome("3", "Design a simple processor pipeline."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3610", new CourseOutcome("4", "Design a co-processor."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3610", new CourseOutcome("5", "Apply compiler techniques to improve program performance."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3610", new CourseOutcome("6", "Evaluate cache memories and various cache design alternatives."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3610", new CourseOutcome("7", "Demonstrate understanding of input-output systems and interrupts by writing simple interrupt handlers."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3612", new CourseOutcome("1", "Understand the differences between embedded computing systems and general purpose computing systems, including constraints on performance, energy consumption, memory and physical dimensions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3612", new CourseOutcome("2", "Able to specify embedded systems using UML or other high level abstract models."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3612", new CourseOutcome("3", "Able to use modern micro-controllers, including programming and interfacing such micro-controllers."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3612", new CourseOutcome("4", "Understand the use of DSP processors and other Application Specific processors."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3612", new CourseOutcome("5", "Understand trade-offs associated with using micro-controllers, DSPs, ASICs and FPGAs to meet embedded system requirements."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3615", new CourseOutcome("1", "Demonstrate an understanding of the multiple layers of abstraction in modern computer systems and the interface between software and hardware."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3615", new CourseOutcome("2", "Evaluate the hardware requirements for at IT System and select the proper architecture and components necessary to satisfy the requirements."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3615", new CourseOutcome("3", "Evaluate the software requirements for an IT System, and define a software architecture to satisfy the requirements."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3615", new CourseOutcome("4", "Demonstrate an understanding of the use of UML and analysis and design patterns in the development of a system design."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3615", new CourseOutcome("5", "Demonstrate understanding of design and development methodologies and architectural paradigms through laboratory assignments and a class project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3615", new CourseOutcome("6", "Demonstrate communication skills that will enable clear reasoning and logical descriptions of problems and solutions in the design, implementation and management of large-scale IT Systems."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3730", new CourseOutcome("1", "Students will understand the concept of reconfigurable logic."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3730", new CourseOutcome("2", "Students will know how FPGA (most popular reconfigurable device) is designed."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3730", new CourseOutcome("3", "Have an overall view of Computer Aided Design (CAD) for FPGA."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3730", new CourseOutcome("4", "Understand specific algorithms utilized in technology mapping, placement and routing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3730", new CourseOutcome("5", "Learn how to use the hardware description language -- VHDL to simulate and synthesis digital circuit system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3730", new CourseOutcome("6", "Capable of using commercial CAD tools to design and simulate digital circuits."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3850", new CourseOutcome("1", "Understand the interdisciplinary nature of computational life sciences."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3850", new CourseOutcome("2", "Develop software applications for computational problems in a programming language preferred by computational life science practitioners."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3850", new CourseOutcome("3", "Understand the axioms and basic theorems of probability and conditional probability as applied in life science problems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3850", new CourseOutcome("4", "Learn the fundamentals of agent and mobile agent systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3850", new CourseOutcome("5", "Learn to evaluate various high performance computer architectures in terms of metrics related to performance."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "3850", new CourseOutcome("6", "Understand the fundamental concepts in Visualization including applications in computational life science problems."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4010", new CourseOutcome("1", "Demonstrate an awareness of the social responsibilities in all areas of computing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4010", new CourseOutcome("2", "Explain the need for professional ethics."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4010", new CourseOutcome("3", "Generate an effective written communication incorporating a topic related to social and ethical issues in computing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4010", new CourseOutcome("4", "Demonstrate team work skills on a project for a topic related to a social or ethical issue in computing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4010", new CourseOutcome("5", "Demonstrate knowledge of contemporary issues in computing."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4011", new CourseOutcome("1", "Demonstrate an awareness of the social responsibilities in all areas of computing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4011", new CourseOutcome("1", "Explain the need for professional ethics."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4011", new CourseOutcome("1", "Generate an effective written communication incorporating a topic related to social and ethical issues in computing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4011", new CourseOutcome("1", "Demonstrate team work skills on a project for a topic related to a social or ethical issue in computing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4011", new CourseOutcome("1", "Demonstrate knowledge of contemporary issues in computing."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4050", new CourseOutcome("1", "Understand Symmetric and Asymmetric encryption systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4050", new CourseOutcome("2", "Understand various block cipher modes."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4050", new CourseOutcome("3", "Demonstrate knowledge of standard symmetric encryption systems, such as, DES and AES."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4050", new CourseOutcome("4", "Demonstrate knowledge of standard asymmetric encryption systems, such as, RSA."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4050", new CourseOutcome("5", "Demonstrate knowledge of common cryptography applications, such as, KERBEROS, PGP, and PKI Systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4050", new CourseOutcome("6", "Understand hash functions and message authentication codes."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4110", new CourseOutcome("1", "Be able to analyze the time and space complexity of a nontrivial algorithm, using mathematical tools, and prove/justify the correctness."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4110", new CourseOutcome("2", "Understand the Divide and Conquer, Greedy, and Dynamic Programming strategies for algorithmic design."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4110", new CourseOutcome("3", "Be familiar with the algorithms for Matrix Multiplication (Strassen's), Activity Selection, Knapsack, Shortest Paths (single source, and all pairs), Minimum Spanning Tree (Prim's and Kruskal's), Matrix Chain, and Longest Common Subsequence problems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4110", new CourseOutcome("4", "Be exposed to approximation algorithms for solving NP-hard problems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4110", new CourseOutcome("5", "Be able to determine and measure the efficiency of a given algorithm, in practice, through different possible implementations, and by testing on suitable data sets."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4110", new CourseOutcome("6", "Be able to communicate clearly and precisely in writing about the theoretical analysis of an algorithm and its efficiency in practice."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4115", new CourseOutcome("1", "Convert a regular expression to an equivalent NFA or DFA."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4115", new CourseOutcome("2", "Apply the pumping lemma for regular languages to prove that a given non-regular language is, in fact not regular."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4115", new CourseOutcome("3", "Apply the pumping lemma for context-free languages to prove that, given a grammar, G, that is not context-free that G, in fact, is not context-free."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4115", new CourseOutcome("4", "Prove that any context-free grammar, G, can be converted to a pushdown automata that accepts the same language as G."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4115", new CourseOutcome("5", "Describe the concept of undecidability, give an example of an undecidable language, UL, and prove that UL is undecidable."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4115", new CourseOutcome("6", "Demonstrate that a \"real\" computer can be simulated by a Turing machine."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4115", new CourseOutcome("7", "Demonstrate the concept of NP-completeness, give an example of an NP-complete problem NPCP, and prove that NPCP is NP-complete."));

            // 4160 Course Outcomes Pending

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4200", new CourseOutcome("1", "Demonstrate understanding of core concepts in text-based information retrieval techniques, such as inverted indexes, vector space model, and TF-IDF term weighting."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4200", new CourseOutcome("2", "Demonstrate understanding of Boolean retrieval models. Show how Boolean queries can be processed and how to optimize query processing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4200", new CourseOutcome("3", "Demonstrate understanding of linguistic modules used in document preprocessing and how to process queries that have spelling errors and other imprecise matches to the vocabulary used in the document collection. "));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4200", new CourseOutcome("4", "Demonstrate understanding of ranked retrieval models and a number of algorithms for constructing the inverted index from a text collection."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4200", new CourseOutcome("5", "Design and implement a complete information retrieval system and evalute its performance by applying the learned knowledge. "));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4201", new CourseOutcome("1", "Use and create programs that demonstrate understanding of search algorithms: depth first, breadth first, A*, Hill-climbing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4201", new CourseOutcome("2", "Implement programs that demonstrate understanding of two-person games."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4201", new CourseOutcome("3", "Demonstrate understanding of knowledge-based systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4201", new CourseOutcome("4", "Demonstrate basic principles of computing different machine learning algorithms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4201", new CourseOutcome("5", "Use and create programs that show understanding of machine learning techniques (decision trees)."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4205", new CourseOutcome("1", "Use and create programs that demonstrate understanding of search algorithms: depth first, breadth first, A*, Hill-climbing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4205", new CourseOutcome("2", "Implement programs that demonstrate understanding of two-person games."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4205", new CourseOutcome("3", "Demonstrate understanding of knowledge-based systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4205", new CourseOutcome("4", "Demonstrate basic principles of computing different machine learning algorithms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4205", new CourseOutcome("5", "Use and create programs that show understanding of machine learning techniques (decision trees)."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4210", new CourseOutcome("1", "Be familiar with Windows programming."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4210", new CourseOutcome("2", "Be able to use Visual C++."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4210", new CourseOutcome("3", "Be able to use the Microsoft Direct3D SDK."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4210", new CourseOutcome("4", "Be able to program a 3D billboard game."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4210", new CourseOutcome("5", "Be able to work in a team with other programmers using version control."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4210", new CourseOutcome("6", "Be able to code one or more aspects of a game, including graphics, sound, and gameplay."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4220", new CourseOutcome("1", "Knowledge of the basic techniques of 3D game programming."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4220", new CourseOutcome("2", "Experience working with a commercial grade game engine."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4220", new CourseOutcome("3", "Ability to program a 3D game."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4220", new CourseOutcome("4", "Ability to use more than one revision control system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4220", new CourseOutcome("5", "Experience with programming using a very large code base."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4230", new CourseOutcome("1", "Analyze, modify and implement existing computer graphics algorithms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4230", new CourseOutcome("2", "Design and implement new computer graphics algorithms that are effective and efficient."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4230", new CourseOutcome("3", "Develop and apply knowledge of computer graphics hardware effectively in the design and implementation of graphics algorithms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4230", new CourseOutcome("4", "Create computer graphics applications using standard graphics libraries and products, including OpenGL."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4230", new CourseOutcome("5", "Use basic matrix and vector operations and related concepts from linear algebra in the design and development of graphics algorithms and applications."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4240", new CourseOutcome("1", "Demonstrate understanding of the basic concepts of image acquisition, sampling, and quantization."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4240", new CourseOutcome("2", "Demonstrate understanding of the color spaces and color transformation."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4240", new CourseOutcome("3", "Demonstrate understanding of spatial and frequency filtering techniques."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4240", new CourseOutcome("4", "Demonstrate understanding of the fundamental image enhancement algorithms such as histogram modification and edge detection."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4240", new CourseOutcome("5", "Develop writing and presentation skills to communicate digital image processing related topics."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4250", new CourseOutcome("1", "Ability to perform a literature search for academic game development articles."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4250", new CourseOutcome("2", "Ability to formulate a game development related project using forward-looking academic articles."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4250", new CourseOutcome("3", "Ability to devise metrics for measuring the viability of a game development related project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4250", new CourseOutcome("4", "Experience with writing code for and evaluating those metrics."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4250", new CourseOutcome("5", "Experience with interpreting and pitching the results to a game development team."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4255", new CourseOutcome("1", "Demonstrate knowledge of linear algebra applied to computer games and graphics."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4255", new CourseOutcome("2", "Demonstrate knowledge of geometry applied to computer games and graphics."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4255", new CourseOutcome("3", "Demonstrate a basic understanding of mechanics sufficient to understand and solve problems involving bodies in motion."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4255", new CourseOutcome("4", "Construct discrete implementations from continuous mathematical models demonstrating knowledge of numerical methods and programming paradigms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4255", new CourseOutcome("5", "Demonstrate competency in the writing and testing of math and physics-related code for computer games."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4290", new CourseOutcome("1", "Define and evaluate regular expressions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4290", new CourseOutcome("2", "Understand n-grams, language models and smoothing techniques."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4290", new CourseOutcome("3", "Understand and solve the problem of part-of-speech tagging."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4290", new CourseOutcome("4", "Understand Hidden Markov Models and the Viterbi algorithm."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4290", new CourseOutcome("5", "Define formal grammars and recognize the language accepted by a grammar."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4290", new CourseOutcome("6", "Understand basic syntactic parsing algorithms (CKY, Early, etc.) and statistical parsing."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4290", new CourseOutcome("7", "Understand some problems in computational semantics, for example, semantic role labeling, lexical semantics, word sense disambiguation."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4290", new CourseOutcome("8", "Familiarity with knowledge-based and statistical approaches in NLP."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4300", new CourseOutcome("1", "Understand the holistic view of data science and its impact on science, engineering, and industry (aka markets)."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4300", new CourseOutcome("2", "What is Big Data and what is data science, and the challenges and opportunities for improving outcomes."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4300", new CourseOutcome("3", "Use big data tools to obtain, assess, and prepare data for analysis."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4300", new CourseOutcome("4", "Articulate key advances in contemporary data science and describe the skillsets needed to be successful ni a data science career."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4300", new CourseOutcome("5", "Manage collections of data, create automated processes for analysis, use collaborative tools, and rapidly report quantitative findings."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4300", new CourseOutcome("6", "Gain hands-on experience with cloud-based services, computing architectures, and parallel and distributed computing environments."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4300", new CourseOutcome("7", "Be comfortable in using Jupyter Notebook and mpi4py programming tools and command line environments."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4300", new CourseOutcome("8", "Apply data, software development, and computing to address data science challenges ni both industry and academic research areas. These include model selection and validation, predictive modeling, and parameter tuning."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4350", new CourseOutcome("1", "Analyze a problem to determine its data requirements."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4350", new CourseOutcome("2", "Create a database that satisfies the given data requirements."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4350", new CourseOutcome("3", "Store, maintain and access data in a database using SQL."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4350", new CourseOutcome("4", "Understand and demonstrate how B+-tree and hashing speed data access."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4350", new CourseOutcome("5", "Understand and use the theory of functional dependencies for DB design."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4355", new CourseOutcome("1", "Install, configure and tune a database."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4355", new CourseOutcome("2", "Maintain and administer servers and server groups."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4355", new CourseOutcome("3", "Manage and optimize schemas, tables, indexes and views."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4355", new CourseOutcome("4", "Create logins, configure permissions, assign roles and perform essential security tasks."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4355", new CourseOutcome("5", "Provide adequate backup and recovery strategies and maintenance."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4355", new CourseOutcome("6", "Develop scripts to automate much of the data administration necessary."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4357", new CourseOutcome("1", "Discuss current database technologies and analyze the security architecture of typical database systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4357", new CourseOutcome("2", "Describe the operating context of databases, evaluate the associated risks and vulnerabilities, and identify mitigation corresponding techniques."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4357", new CourseOutcome("3", "Develop a security strategy and solution for securing databases."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4357", new CourseOutcome("4", "Manage database security at the application level."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4357", new CourseOutcome("5", "Conduct a database audit for security, privacy, and reliability."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4357", new CourseOutcome("6", "Design, develop, test, and document secure database applications."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4380", new CourseOutcome("1", "Be familiar with key data visualization and data pre-processing methods"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4380", new CourseOutcome("2", "Be able to confidently apply both supervised and unsupervised methods across a wide range of real-world scenarios"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4380", new CourseOutcome("3", "Gain a fundamental understanding of time series prediction"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4380", new CourseOutcome("4", "Understand the basic principles of spatial data mining and its applications"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4380", new CourseOutcome("5", "Gain in depth experience in applying a major language used in data mining"));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4430", new CourseOutcome("1", "Identify and describe the key components of programming language processors (i.e., compilers and interpreters)."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4430", new CourseOutcome("2", "Identify and describe the key concepts of object-oriented programming languages, including inheritance, reflection, and polymorphism."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4430", new CourseOutcome("3", "Identify and describe the key concepts of functional programming languages, including recursion, higher-order functions, polymorphism, type inference and infinite data objects."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4430", new CourseOutcome("4", "Identify and describe the key concepts of logic programming languages, including unification, backtracking, and the closed world assumption."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4430", new CourseOutcome("5", "Identify and describe the key concepts of event driven programming, including event listeners."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4430", new CourseOutcome("6", "Identify and describe the key concepts of concurrent programming, including threads."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4440", new CourseOutcome("1", "Demonstrate an understanding of the characteristics of real-time systems and the key issues and challenges in the design of real-time software, including meeting deadlines, execution predictability, space and energy limitations."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4440", new CourseOutcome("2", "Apply the development methodology for real-time systems and compute the trade offs between hard and soft real-time systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4440", new CourseOutcome("3", "Demonstrate the use of the real-time UML in modeling a real-time software system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4440", new CourseOutcome("4", "Gain experience with schedule validation techniques and how these techniques differ between hard and soft deadlines in real-time systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4440", new CourseOutcome("5", "Evaluate the timing, synchronization and fault tolerance issues of real-time software development."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4460", new CourseOutcome("1", "Demonstrate understanding of fundamental testing concepts that are required to verify and validate software products."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4460", new CourseOutcome("2", "Demonstrate knowledge of different types of testing techniques such as structural (white-box) and functional (black-box) testing techniques."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4460", new CourseOutcome("3", "Demonstrate knowledge of different levels of software testing that can be applied to different software development phases (e.g., unit, integration, system, and acceptance testing)."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4460", new CourseOutcome("4", "Demonstrate understanding of recent advances in software testing techniques by reading recent research papers and present them in class."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4460", new CourseOutcome("5", "Design, conduct, analyze, and write up empirical studies of software engineering techniques."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4510", new CourseOutcome("1", "Calculate path loss, bit error rate and channel capacity in various wireless channel conditions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4510", new CourseOutcome("2", "Model various analog and digital modulation techniques mathematically as well as demonstrate their applications."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4510", new CourseOutcome("3", "Describe advanced multiplexing techniques such as spread spectrum and OFDMA including their advantages, disadvantages and applications."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4510", new CourseOutcome("4", "Design channel coding schemes for error control."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4510", new CourseOutcome("5", "Describe the architecture and physical and MAC layers of Wireless LANs, Wireless PANs and cellular networks including 4G and LTE."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4520", new CourseOutcome("1", "Basic operation of a cellular network."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4520", new CourseOutcome("2", "Understanding basic operation of different network elements of a cellular network."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4520", new CourseOutcome("3", "Basic understanding of soft and hard handoff."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4520", new CourseOutcome("4", "Basic understanding of function of interfaces between BTS, BSC, MSC and PSTN."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4520", new CourseOutcome("5", "Understanding basic issues related to supporting QoS in voice and data services in cellular networks."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4520", new CourseOutcome("6", "Understanding the basic operation of 4G networks and interworking of wireless and wireline networks."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4530", new CourseOutcome("1", "Demonstrate an Understanding of Common Network Terminology, Concepts and Design Principles."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4530", new CourseOutcome("2", "Demonstrate an understanding of the different types of Networks and their characteristics."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4530", new CourseOutcome("3", "Demonstrate an understanding of Network Design trade-offs."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4530", new CourseOutcome("4", "Obtain hands-on experience in the design and testing of networks and appropriate tools."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4535", new CourseOutcome("1", "Demonstrate understanding of IP addressing, sub-netting and networks configuration but configuring and setting up a network across a heterogeneous group of computers."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4535", new CourseOutcome("2", "Describe network planning and design of local-area-network (LAN) and wide-area-network (WAN) networks."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4535", new CourseOutcome("3", "Describe quality of service (QoS) parameters and how they relate to network availability."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4535", new CourseOutcome("4", "Configure, operate and troubleshoot routing protocols such as Open-Shortest-Path-First (OSPF) and Border-Gate-Protocol (BGP)."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4535", new CourseOutcome("5", "Install and configure simple network security tools such as Intrusion-Prevention-System (IPS), Intrusion-Detection-System (IDS), firewalls and virus scanners."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4535", new CourseOutcome("6", "Evaluate network performance both by simulation and by designing, gathering, and analyzing experiments."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4540", new CourseOutcome("1", "Understand the basic operation of the TCP protocol."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4540", new CourseOutcome("2", "Understand the fundermental issues in flow and congestion control."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4540", new CourseOutcome("3", "Demonstrate the basic operation of TCP-based real-time protocols."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4540", new CourseOutcome("4", "Demonstrate the basic operation of TCP-based non-real-time protocols."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4540", new CourseOutcome("5", "Demonstrate the appropriate procedures for developing a new application."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4555", new CourseOutcome("1", "Demonstrate general knowledge and comprehension of computer forensics and computer investigations."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4555", new CourseOutcome("2", "Describe and explain the Windows, Macintosh, and Unix/Linux operating systems data storage and methodologies."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4555", new CourseOutcome("3", "Describe and explain the methods used for digital evidence control, processing crime and incident scenes, and data acquisition for computer forensic analysis."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4555", new CourseOutcome("4", "Demonstrate knowledge and comprehension of basic tools and techniques used in the field of computer forensics sciences."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4555", new CourseOutcome("5", "Describe and explain writing investigation reports and being an expert witness."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4560", new CourseOutcome("1", "Knowledge of and experience with secure web development, with exposure to at least three current technologies (such as XML, Perl, PHP, ASP, JSP, JavaScript, etc.)"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4560", new CourseOutcome("2", "Knowledge of how cryptography can be used to support confidentiality and integrity of electronic transmissions and transactions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4560", new CourseOutcome("3", "Knowledge of electronic transaction and payment systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4560", new CourseOutcome("4", "Knowledge of Public Key Infrastructure (PKI) settings and trust models, with specific systems such as X.509 certificates and PGP\\'s decentralized web of trust."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4560", new CourseOutcome("5", "Familiarity with basic network and system security, and the ability to set up a typical electronic commerce setting of networks and hosts."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4560", new CourseOutcome("6", "Familiarity with business, legal, and ethical issues related to electronic commerce, and the interaction of these issues with technical issues."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4565", new CourseOutcome("1", "Describe software based exploits and attacks."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4565", new CourseOutcome("2", "Apply the principles of designing secure systems to build a real system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4565", new CourseOutcome("3", "Discuss software assurance assessment and management issues."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4565", new CourseOutcome("4", "Compare and contrast system security assurance, system functionality assurance, and operational assurance."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4565", new CourseOutcome("5", "Design and analyze code with security in mind."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4565", new CourseOutcome("6", "Use tools to detect software based vulnerabilities and attacks."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4570", new CourseOutcome("1", "Discuss major privacy and security challenges faced by organizations, groups, and individuals."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4570", new CourseOutcome("2", "Describe current security and privacy paradigms."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4570", new CourseOutcome("3", "Evaluate security and privacy practices and create solutions to privacy issues."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4570", new CourseOutcome("4", "Develop physical, administrative, and technical security and privacy controls."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4570", new CourseOutcome("5", "Apply and promote ethical standards of practice for information privacy."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4575", new CourseOutcome("1", "Describe the basic operation of blockchaining and smart contracts, including the underlying technology of transactions, blocks, proof of work, and consensus building."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4575", new CourseOutcome("2", "Design and implement a smart contract."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4575", new CourseOutcome("3", "Use tools to deploy and test a smart contract as part of a blockchain application."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4575", new CourseOutcome("4", "Conduct performance analysis of a smart contract."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4600", new CourseOutcome("1", "Use the principles of processes and threads for abstraction of real-world events."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4600", new CourseOutcome("2", "Formulate solutions for mutual exclusion and process synchronization."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4600", new CourseOutcome("3", "Understand the concept of deadlock to develop deadlock free systems of processes."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4600", new CourseOutcome("4", "Understand principles of memory and resource management."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4600", new CourseOutcome("5", "Identify different process scheduling paradigms and utilize them in system development."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4600", new CourseOutcome("6", "Develop fundamental security features to protect systems and data."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4610", new CourseOutcome("1", "Apply metrics to evaluate performance and power requirements of modern computer systems. Represent performance using arithmetic, harmonic and geometric means."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4610", new CourseOutcome("2", "Understand Amdahl’s law as applied to a single core and multicore systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4610", new CourseOutcome("3", "Design a pipelined processor to meet design specifications."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4610", new CourseOutcome("4", "Design an out-of-order and speculative processor to improve performance."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4610", new CourseOutcome("5", "Understand cache memory performance issues."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4610", new CourseOutcome("6", "Understand cache memory issues in multicore systems include cache coherency management."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4610", new CourseOutcome("7", "Understand hardware support for concurrency including multithreading, locks and barriers."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4620", new CourseOutcome("1", "Understand the differences between general purpose and real-time operating systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4620", new CourseOutcome("2", "Understand multithreading in real-time environment."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4620", new CourseOutcome("3", "Understand task and thread scheduling in real-time operating systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4620", new CourseOutcome("4", "Understand memory management in real-time systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4620", new CourseOutcome("5", "Be able to program using system proved timers, signals, mutual exclusion, semaphores, message queues and exception handlers."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4620", new CourseOutcome("6", "Be able to program real-time applications to run in a realistic operating environment."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4650", new CourseOutcome("1", "Given a context-free grammar, build SLR(1), LR(1) and LALR(1) parse tables for that grammar."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4650", new CourseOutcome("2", "Given a context-free grammar, an LR parse table and an input string, show the steps of the parse."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4650", new CourseOutcome("3", "Given a language specification for an imperative language, build a parser for the language using tools such as lex and yacc."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4650", new CourseOutcome("4", "Integrate semantic actions into the above parser to construct a symbol table, perform type checking, and generate intermediate code."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4650", new CourseOutcome("5", "Given a control-flow graph with intermediate 3-address code within each basic block, show the improved control-flow graph after hand-optimizing for common subexpression elimination, copy propagation, and dead code removal."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4655", new CourseOutcome("1", "Students will develop a good understanding of basic compiler analysis and optimization techniques."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4655", new CourseOutcome("2", "Students will sharpen their skills in comparing and evaluating different compiler techniques with the intent of choosing among several techniques for inclusion into a production compiler."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4655", new CourseOutcome("3", "Students will develop their skill in adding to existing software."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4655", new CourseOutcome("4", "Students will be able to design, implement and write about experimental compiler research in a professional manner."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4655", new CourseOutcome("5", "Students will develop skills in professional oral presentation of their work."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4730", new CourseOutcome("1", "Understand the concept of MOS transistor."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4730", new CourseOutcome("2", "Understand the operational characteristics of MOS transistor."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4730", new CourseOutcome("3", "Understand the Power dissipation mechanisms in MOS transistor."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4730", new CourseOutcome("4", "Understand the transistor-level realization of Boolean functions."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4730", new CourseOutcome("5", "Able to use CAD tools to design and simulate digital circuits."));

            // 4750 No Course Outcomes

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4810", new CourseOutcome("1", "Learn the principles of Molecular Biology and Genetics"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4810", new CourseOutcome("2", "Understand the concepts of DNA structure and encoding"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4810", new CourseOutcome("3", "Understand the Central Dogma of Biology (DNA->RNA->Protein)"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4810", new CourseOutcome("4", "Understand the importance of Bioethics"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4810", new CourseOutcome("5", "Learn basic Perl programming"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4810", new CourseOutcome("6", "Understand computational complexity of Bioinformatics problems"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4810", new CourseOutcome("7", "Learn fundamental computational tasks/algorithms of Bioinformatics"));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4810", new CourseOutcome("8", "Learn about NCBI and available Bioinformatics tools"));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4820", new CourseOutcome("1", "Understand the interdisciplinary nature of Computational Epidemiology."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4820", new CourseOutcome("2", "Understand the principles of Epidemiology and its challenges to identify the cause of outbreaks."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4820", new CourseOutcome("3", "Understand the fundamentals of mathematical outbreak models and their interpretation."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4820", new CourseOutcome("4", "Understand the basics of computational modeling and simulation."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4820", new CourseOutcome("5", "Learn the fundamental study designs in epidemiology."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4820", new CourseOutcome("6", "Understand the difficulties of communicating among researchers in an interdisciplinary setting."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4820", new CourseOutcome("7", "Learn to present Public Health related information and study results."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4901", new CourseOutcome("1", "Gather and refine user functional requirements and other functional and non-functional requirements and constraints for a large scale software system and create a software requirements specification document."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4901", new CourseOutcome("2", "Perform software analysis and design tasks using recognized software methods to create a preliminary design specification for software based on a requirements specification."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4901", new CourseOutcome("3", "Utilize project management principles, skills and tools in creating the requirements and preliminary design specifications."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4901", new CourseOutcome("4", "Create a test plan plan using appropriate testing strategies and techniques for a large scale software project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4901", new CourseOutcome("5", "Utilize configuration management, project management and design tools in the course of the project."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4905", new CourseOutcome("1", "Gather and refine user functional requirements and other functional and non-functional requirements and constraints for a large scale information system, and create a system requirements specification document."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4905", new CourseOutcome("2", "Perform system analysis and design tasks using recognized software engineering methods to create a preliminary design specification for a system based on a requirements specification."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4905", new CourseOutcome("3", "Utilize software project management principles, skills and tools in creating the requirements and preliminary design specifications."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4905", new CourseOutcome("4", "Create a project management plan, including a schedule and budget for a large scale information systems project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4905", new CourseOutcome("5", "Utilize configuration management, project management and design tools in the course of the project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4905", new CourseOutcome("6", "Understand the classification and characteristics of large computing systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4905", new CourseOutcome("7", "Demonstrate the ability to perform common systems installation, integration, maintenance, and administration tasks."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4907", new CourseOutcome("1", "Gather and refine user functional requirements and other functional and non-functional requirements and constraints for a large-scale secure information system and create a system requirements specification document."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4907", new CourseOutcome("2", "Perform system analysis and design tasks using recognized cybersecurity principles and practices to create a preliminary design specification for a secure system based on a requirements specification."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4907", new CourseOutcome("3", "Utilize project management principles, skills, and tools in creating the requirements and preliminary design specifications."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4907", new CourseOutcome("4", "Create a project management plan, including a schedule and budget for a large-scale secure information systems project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4907", new CourseOutcome("5", "Utilize configuration management, project management, and design tools in the course of the project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4907", new CourseOutcome("6", "Analyze and maintain appropriate project artifacts to reflect inclusive security design and societal impact for the project sponsors, users, and other stakeholders."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4910", new CourseOutcome("1", "Gather and refine user functional requirements and other functional and non-functional requirements and constraints for a large scale processor-based system and create a system requirements specification document."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4910", new CourseOutcome("2", "Perform system analysis and design tasks using recognized software and systems engineering methods to create a preliminary design specification for a system based on a requirements specification."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4910", new CourseOutcome("3", "Utilize project management principles, skills and tools in creating the requirements and preliminary design specifications."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4910", new CourseOutcome("4", "Create a project management plan, including a schedule and budget for a large scale information systems project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4910", new CourseOutcome("5", "Utilize configuration management, project management and design tools in the course of the project."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4915", new CourseOutcome("1", "Create a detailed systems design and implementation plan using standard engineering tools and methodology."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4915", new CourseOutcome("2", "Implement the design for a processor-based system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4915", new CourseOutcome("3", "Create a test plan and series of test procedures for a project and execute the procedures against the components created."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4915", new CourseOutcome("4", "Create a delivery and maintenance plan for the system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4915", new CourseOutcome("5", "Utilize configuration management, project management and design tools in the course of the project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4915", new CourseOutcome("6", "Create a lifecycle plan for the system developed."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4925", new CourseOutcome("1", "Create a detailed systems design and implementation plan using standard software engineering tools and methodology."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4925", new CourseOutcome("2", "Implement the design for a large scale information system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4925", new CourseOutcome("3", "Create a test plan and series of test procedures for a project and execute the procedures against the components created."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4925", new CourseOutcome("4", "Create a delivery and maintenance plan for a large scale information system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4925", new CourseOutcome("5", "Utilize configuration management, project management and design tools in the course of the project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4925", new CourseOutcome("6", "Create a lifecycle plan for the information system developed."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4925", new CourseOutcome("7", "Understand the classification and characteristics of large computing systems."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4925", new CourseOutcome("8", "Demonstrate the ability to perform common systems installation, integration, maintenance, and administration tasks."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4925", new CourseOutcome("9", "Demonstrate the ability to plan and execute the deployment of an IT system or components into a client environment."));

            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4927", new CourseOutcome("1", "Create a detailed systems design and implementation plan using standard applicable tools and methodologies."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4927", new CourseOutcome("2", "Implement the design for a large-scale secure information system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4927", new CourseOutcome("3", "Create a test plan and series of test procedures for a project and execute the procedures against the components created."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4927", new CourseOutcome("4", "Create a delivery and maintenance plan for a large scale secure information system."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4927", new CourseOutcome("5", "Utilize configuration management, project management, and design tools in the course of the project."));
            _ = CourseOutcome.CreateCourseOutcome("Fall", 2023, "CSCE", "4927", new CourseOutcome("6", "Create a lifecycle plan for the secure system developed."));



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
            _ = Section.AddSection("Fall", 2023, "CSCE", "1030", new Section("instructor", false, "888", 60, false));

            _ = User.AddUser(new User("Alcott", "Vincent", "vea0028"));
            _ = User.AddUser(new User("In", "Structor", "instructor"));
            _ = Role.AddRoleToUser("instructor", "Instructor");
            _ = User.AddUser(new User("A", "ssistant", "assistant"));
            _ = Role.AddRoleToUser("assistant", "Assistant");
            _ = Role.AddRoleToUser("vea0028", "Assistant");

            _ = Section.AddAssistantToSection("assistant", "Fall", 2023, "CSCE", "1030", "001");

            _ = Section.AddAssistantToSection("assistant", "Fall", 2023, "CSCE", "1030", "777");
            _ = Section.AddAssistantToSection("assistant", "Fall", 2023, "CSCE", "1030", "888");
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
