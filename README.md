# Best Restaurant

#### C#/.NET MVC website that allows students and administrators to keep records on courses and student enrollment.

#### By Sarah "Sasa" Schwartz, Andrew Philpott

---

## Table of Contents

1. [Description](#description)
2. [Setup/Installation Requirements](#installation-requirements)
3. [User Stories](#user-stories)
4. [Specifications](#specs)
5. [Known Bugs](#known-bugs)
6. [Technologies Used](#technologies-used)
7. [License](#license)

---

<details>
  <summary>WHAT WE WORKED ON 03.23.20</summary>
  
  - University Registrar initial set up linking courses and students with a many-to-many relationship
  - Adding in Departments with a one-to-many relationship to students and courses
  - Learning about data annotations to allow optional properties (e.g. when a student doesn't have a department yet)
  - Adding additional features of IsComplete to courses
</details>

## Description

C#/.NET MVC website that allows students and administrators to keep records on courses and student enrollment. This application allows you to create students and courses, and adjust student enrollment in each course. The website will prompt you to register an account and log in to view students and courses. Based on your identity (registrar vs. student vs. admin) you will be authorized to complete different tasks on the site. This project focuses on using .NET Core MVC, Authentication, Authorization, SQL databases/Migration, and one-to-many/many-to-many design for databases.

## Installation Requirements

- Clone the repository on Github
- Open the terminal on your desktop
- \$git clone "insert your cloned URL here"
- Change directory to the UniversityRegistrar directory, within the UniversityRegistrar.Solution directory
- \$dotnet restore
- Recreate our database structure with migration:
  - \$dotnet ef migrations add Initial
  - \$dotnet ef database update
- \$dotnet run
- The app should be hosted on http://localhost:5000/
- Use the app at this URL in the browser!

## User Stories

- As a registrar, I want to enter a student, so I can keep track of all students enrolled at this University. I should be able to provide a name and date of enrollment.
- As a registrar, I want to enter a course, so I can keep track of all of the courses the University offers. I should be able to provide a course name and a course number (ex. HIST100).
- As a registrar, I want to be able to assign students to a course, so that teachers know which students are in their course. A course can have many students and a student can take many courses at the same time.
- As a registrar, I want to be able to create departments. A student can be assigned to a department when they declare their major and a course can be assigned to a department when it is created.
- As a registrar, I want to be able to list out all of the courses or all of the students in a particular department, so that I can inform the counselors which departments need more students and which need more courses.
- As a registrar, I want to change a student's file to show that they have completed a course, so that I can see if they need to take the course again.
- As a registrar, I want to list out all of the courses a student has taken, so that I can see if they have met their degree requirements.
- As a registrar, I want to see how many students have not completed courses in any particular departments, so that I can tell the administration which departments need help.

## Known Bugs

- No known bugs

## Technologies Used

- C#
- .NET

### License

- This software is licensed under the MIT license.

Authorization

Administrator
-Add and remove departments
-Assign different Registrars to be responsible for different student levels??? (freshmen, sophomore...)

Registrar
-Add or remove students to different courses

Student
-"Wishlist" of the courses they want to be in
-Declare their major
-Add or remove

Parking lot
-Student maximum in each course
-Different views of pages for different users (e.g. Student edit looks different to student vs registrar)
