# Description

Each term, students and faculty enter data for each course they are enrolled in/teach in the CSE department. This data is used to assess the department courses for ABET accreditation. Near the end of the term, students are given a link where they assess their CSE courses based on pre-specified course outcomes. After the course is completed, instructors have data (including attachments) that are provided. Reports are provided to the department Undergrad Curriculum Committee and the Undergraduate Coordinator so that the courses can be assessed according to the course and relevant program outcomes. There is a current system, which is hard to use and hard to maintain. The program outcome mappings are obsolete due to ABET changes, so a new version is needed.

This is the _back-end_ for the Fall 2020 - Spring 2022 UNT ABET Course Assessment Tool project.

## Getting Started
This is a [.NET]() project written using C#. It uses Microsoft IIS Express to create and host a web server for the backend.

Download and unzip the project. Open the the AbetApi folder and open the Solution file in Microsoft Visual Studio 2019/2022. When the project is loaded, in the ribbon, click the green arrow next to IIS Express. This will start the local IIS web server and the browser will open to a Swagger page with debug commands.

Now that the back end web server is running, start the [front end](https://github.com/huynggg/Abet-Course-Assessment-Tool-Frontend).
Open [http://localhost:3000](http://127.0.0.1:3000) in your browser to see the result.

This project uses MySQL Workbench and MySQL Server for the database to connect to the backend. Download MySQL Installer Community to install and configure both MySQL applications at the same location. Make sure the root password set in the MySQL Server configuration is the same as the password in the file appsettings.json. That file is located in the AbetApi folder within the backend.

In order to login after all of the above has been completed, you must be connected to a UNT network with their vpn to have sign in using your EUID and password.
