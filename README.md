# Best Restaurant

#### C#/.NET MVC website that allows students and administrators to keep records on courses and student enrollment.

#### By Sarah "Sasa" Schwartz, Andrew Philpott

---

## Table of Contents

1. [Description](#description)
2. [Setup/Installation Requirements](#installation-requirements)
3. [Specifications](#specs)
4. [Known Bugs](#known-bugs)
5. [Technologies Used](#technologies-used)
6. [License](#license)

---

<details>
  <summary>WHAT WE WORKED ON 03.23.20</summary>
  
  - University Registrar initial set up linking courses and students with a many-to-many relationship
  - Adding in Departments with a one-to-many relationship to students and courses
  - Learning about data annotations to allow optional properties (e.g. when a student doesn't have a department yet)
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
