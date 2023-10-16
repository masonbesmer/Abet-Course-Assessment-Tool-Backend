# Description
Each term, students and faculty enter data for each course they are enrolled in/teach in the CSE department. This data is used to assess the department courses for ABET accreditation. Near the end of the term, students are given a link where they assess their CSE courses based on pre-specified course outcomes. After the course is completed, instructors have data (including attachments) that are provided. Reports are provided to the department Undergrad Curriculum Committee and the Undergraduate Coordinator so that the courses can be assessed according to the course and relevant program outcomes. There is a current system, which is hard to use and hard to maintain. The program outcome mappings are obsolete due to ABET changes, so a new version is needed.

This is the _back-end_ for the Fall 2020 - Spring 2023 **UNT ABET Course Assessment Tool** project.

## Getting Started
This is a [.NET](https://dotnet.microsoft.com/en-US/) project written using C#. It uses Microsoft IIS Express to create and host a web server for the backend.

Download and unzip the project. Open the the AbetApi folder and click on the solution file (AbetApi.sln) to open in Microsoft Visual Studio 2019 or 2022.
You may need to set up your local environment variables before running. These are located in the `launchSettings.json` which would be located in the _Properties_ folder under _AbetApi_.
Secret configuration files are required not provided in this repository. You will need to manually set up the `appsettings.json` and `launchSettings.json` files that were provided to you.
To start the backend web server, in the ribbon, click the green arrow next to "IIS Express" to run. This will start the local IIS web server and the browser will open to a Swagger page with debug commands.

Now that the back-end web server is running, start the [front end](https://github.com/huynggg/Abet-Course-Assessment-Tool-Frontend). This should automatically launch [localhost:3000](http://localhost:3000).

This project uses [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) and MySQL Server for the database to connect to the backend. Download MySQL Installer Community to install and configure both MySQL applications at the same location. Make sure the root password set in the MySQL Server configuration is the same as the password in the file `appsettings.json`. That file is located in the AbetApi project within the AbetApi solution in Visual Studio.
**IMPORTANT**: To generate sample database information, scroll down within the Swagger panel and run the "Custom" endpoint, or navigate to the `/Custom` directory of the backend (i.e. `https://localhost:44372/Custom`)

In order to successfully login using your UNT credentials, you must be connected to a UNT network or the [UNT VPN](https://itss.untsystem.edu/sites/default/files/campus_vpn.pdf).
