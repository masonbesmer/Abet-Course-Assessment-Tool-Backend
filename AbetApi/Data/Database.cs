using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.EntityFramework;
using AbetApi.EFModels;
using AbetApi.Data;
using Microsoft.EntityFrameworkCore;

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
            //_ = Course.AddCourse("Fall", 2022, new Course("amm0813", "1030", "Computer Science I", "", false, "CSCE")); // duplicate
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1030", "Computer Science I", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1035", "Computer Programming I", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1040", "Computer Science II", "", false, "CSCE"));
            //_ = Course.AddCourse("Fall", 2022, new Course("dmk0080", "1040", "Computer Science II", "", false, "CSCE")); // duplicate
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "1045", "Computer Programming II", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "2100", "Foundations of Computing", "", false, "CSCE"));
            //_ = Course.AddCourse("Fall", 2022, new Course("yl0340", "2100", "Foundations of Computing", "", false, "CSCE")); // duplicate
            //_ = Course.AddCourse("Fall", 2022, new Course("yl0340", "2100", "Foundations of Computing", "", false, "CSCE")); // duplicate
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "2100", "Foundations of Computing", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "2100", "Foundations of Computing", "", false, "CSCE"));
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "2110", "Foundations of Data Structures", "", false, "CSCE"));
            //_ = Course.AddCourse("Fall", 2022, new Course("csc0168", "2110", "Foundations of Data Structures", "", false, "CSCE")); // duplicate
            _ = Course.AddCourse("Fall", 2022, new Course("coordinator", "2110", "Foundations of Data Structures", "", false, "CSCE"));

            // add sections to courses
            _ = Section.AddSection("Fall", 2022, "CSCE", "1030", new Section("pls0112", false, "001", 120));
            _ = Section.AddSection("Fall", 2022, "CSCE", "1030", new Section("pls0112", false, "002", 120));
            _ = Section.AddSection("Fall", 2022, "CSCE", "1030", new Section("amm0813", false, "003", 130));
            _ = Section.AddSection("Fall", 2022, "CSCE", "1030", new Section("amm0813", false, "004", 94));
            _ = Section.AddSection("Fall", 2022, "CSCE", "1030", new Section("dr0702", false, "501", 25));

            _ = Section.AddSection("Fall", 2022, "CSCE", "1035", new Section("bj0141", false, "001", 32));

            _ = Section.AddSection("Fall", 2022, "CSCE", "1040", new Section("dmk0080", false, "001", 118));
            _ = Section.AddSection("Fall", 2022, "CSCE", "1040", new Section("dmk0080", false, "002", 118));

            _ = Section.AddSection("Fall", 2022, "CSCE", "1045", new Section("bm0756", false, "001", 32));

            _ = Section.AddSection("Fall", 2022, "CSCE", "2100", new Section("yl0340", false, "001", 75));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2100", new Section("yl0340", false, "002", 75));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2100", new Section("yl0340", false, "003", 68));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2100", new Section("hw0109", false, "004", 95));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2100", new Section("dr0702", false, "550", 40));

            _ = Section.AddSection("Fall", 2022, "CSCE", "2110", new Section("csc0168", false, "001", 110));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2110", new Section("csc0168", false, "002", 110));
            _ = Section.AddSection("Fall", 2022, "CSCE", "2110", new Section("dr0702", false, "501", 40));

            // add major outcomes
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CE", new MajorOutcome("1", "An ability to identify, formulate, and solve complex engineering problems by applying principles of engineering, science, and mathematics."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CE", new MajorOutcome("2", "An ability to acquire and apply new knowledge as needed, using appropriate learning strategies."));

            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("1", "Analyze a complex computing problem and to apply principles of computing and other relevant disciplines to identify solutions."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("2", "Design, implement, and evaluate a computing-based solution to meet a given set of computing requirements in the context of the program’s discipline."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "CS", new MajorOutcome("3", "Apply computer science theory and software development fundamentals to produce computing-based solutions."));

            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "IT", new MajorOutcome("1", "Analyze a complex computing problem and to apply principles of computing and other relevant disciplines to identify solutions."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "IT", new MajorOutcome("2", "Design, implement, and evaluate a computing-based solution to meet a given set of computing requirements in the context of the program’s discipline."));
            _ = MajorOutcome.AddMajorOutcome("Fall", 2022, "IT", new MajorOutcome("3", "Identify and analyze user needs and to take them into account in the selection, creation, integration, evaluation, and administration of computing-based systems."));

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

            // link major outcomes to course outcomes
            // HELP: how do you guys want to link these? do we need to ask for more info?
            //                                                courseOutcomeName ->|   mjr.   |<- majorOutcomeName
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "1", "CS", "1");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "1", "CS", "2");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "2", "CS", "3");
            _ = CourseOutcome.LinkToMajorOutcome("Fall", 2022, "CSCE", "1030", "3", "CS", "3");

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
            _ = Section.AddSection("Fall", 2022, "CSCE", "3600", new Section("cas0231", false, "001", 150));
            _ = Section.AddSection("Fall", 2022, "CSCE", "3600", new Section("cas0231", false, "002", 739));
            _ = Section.AddSection("Fall", 2022, "CSCE", "3600", new Section("cas0231", false, "003", 42));
            //var temp = Course.GetSections("Fall", 2022, "CSCE", "3600");
            //var temp = Section.GetSection("Fall", 2022, "CSCE", "3600", "001");
            _ = Section.EditSection("Fall", 2022, "CSCE", "3600", "002", new Section("cas0231", true, "002", 140));
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
