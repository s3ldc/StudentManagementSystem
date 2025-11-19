# Student Management System (WinForms, C#)

**Student Management System** — a desktop application implemented with **Windows Forms** (C#) for managing student records, courses, marks and GPA calculations.  
This repository contains a Visual Studio solution with modular forms for adding, editing, searching, viewing students, entering marks, assigning courses and calculating GPA.

---

## Table of Contents

- [Features](#features)  
- [Tech stack](#tech-stack)  
- [Repository structure](#repository-structure)  
- [Prerequisites](#prerequisites)  
- [How to build & run](#how-to-build--run)  
- [Database setup](#database-setup)  
- [Usage / Quick test guide](#usage--quick-test-guide)  
- [Recommended improvements](#recommended-improvements)  
- [Contributing](#contributing)  
- [Contact](#contact)

---

## Features

- Add / edit / delete student records.  
- Search students by criteria.  
- Assign courses to students.  
- Enter marks and compute GPA (dedicated form).  
- View students list and per-student details.  
- Centralized `DatabaseHelper` helper for data access. :contentReference[oaicite:8]{index=8}

---

## Tech stack

- C# (.NET Framework / WinForms)  
- Visual Studio solution (`.sln`, `.csproj`)  
- Data persistence: (see **Database setup** below — App.config likely holds connection string). :contentReference[oaicite:9]{index=9}

---

## Repository structure

```
StudentManagementSystem/
├── AddStudentForm.cs
├── AddStudentForm.Designer.cs
├── EditStudentForm.cs
├── ViewStudentsForm.cs
├── SearchStudentForm.cs
├── EnterMarksForm.cs
├── AssignCourseForm.cs
├── CalculateGPAForm.cs
├── MainForm.cs
├── DatabaseHelper.cs
├── Program.cs
├── StudentManagementSystem.sln
├── StudentManagementSystem.csproj
├── packages.config
└── README.md
```

(Actual list of files in the repo — forms and helper files — visible in the project root). :contentReference[oaicite:10]{index=10}

---

## Prerequisites

- **Windows** (WinForms desktop app).  
- **Visual Studio** — recommended: Visual Studio 2019 or 2022 (Community / Professional / Enterprise) with the **.NET desktop development** workload installed.  
- **.NET Framework**: check `StudentManagementSystem.csproj` for the target framework. If unsure, open the `.csproj` in Visual Studio — the target is defined there. :contentReference[oaicite:11]{index=11}

Optional:
- SQL Server / LocalDB / SQL Server Express if the app uses a SQL database. See `App.config` for the connection string in the project root.

---

## How to build & run

1. **Clone the repository**
   ```bash
   git clone https://github.com/s3ldc/StudentManagementSystem.git
   cd StudentManagementSystem
   ```

2. **Open the solution**  
   Open `StudentManagementSystem.sln` in Visual Studio.

3. **Restore NuGet packages**  
   In Visual Studio: `Build` → `Restore NuGet Packages` (if prompted). Or right-click solution → `Restore NuGet Packages`.

4. **Set up the database** (see next section). Ensure connection string in `App.config` is correct.

5. **Build and run**  
   Press F5 (Debug) or Ctrl+F5 (Run without debugging). The main Windows Form should appear.

---

## Database setup

**Suggested steps to document here:**

1. If the app uses **SQL Server / LocalDB**:
   - Install SQL Server Express or use LocalDB (installed with Visual Studio).  
   - Create a database named `StudentManagementDB` (or name used in `App.config`).  
   - Run the provided SQL schema script (if available) or create tables:
     - `Students` (Id, FirstName, LastName, DOB, Email, Phone, etc.)
     - `Courses` (Id, Name, Credits, etc.)
     - `Enrollments` / `Marks` (StudentId, CourseId, Marks, Grade, etc.)
   - Update the connection string in `App.config` if needed.

2. If the app uses a **file-based DB** (SQLite or MDF):
   - Place the DB file in the `bin` folder or point the connection string to the correct path.

3. If no DB schema exists in the repo:
   - Provide a `scripts/` folder with `create_tables.sql` and sample data.

---

## Usage — quick test guide

After starting the app:

1. Open **Add Student** form and add a test student (fill required fields).  
2. Navigate to **View Students** to confirm the record appears.  
3. Use **Assign Course** to attach a course to the student.  
4. Open **Enter Marks**, give marks for a course, save.  
5. Open **Calculate GPA** for the student and confirm GPA calculation.  
6. Try **Search Student** by name or ID to ensure search works.

Document any exceptional behavior and include screenshots for each step in the repo under `/docs/images/`.

---

## Contributing

If you accept contributions, add a `CONTRIBUTING.md`. Suggested minimal policy:

1. Fork the repo.  
2. Create a branch `feature/<name>`.  
3. Implement changes and add tests.  
4. Submit a pull request with a clear description.

---

## Contact

Project maintainer: `s3ldc` (GitHub profile) — see repository for contact details. :contentReference[oaicite:12]{index=12}

