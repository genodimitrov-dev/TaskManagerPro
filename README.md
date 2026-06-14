# Task Manager Pro

A console-based task management application built with C# and .NET.

## Features

### Task Management
- Add new tasks
- Edit existing tasks
- Remove tasks
- Mark tasks as completed

### Search & Filtering
- Search by ID
- Search by title
- Search by description
- Search by priority
- Search by status

### Task Views
- View all tasks
- View tasks by priority
- View tasks by status
- View overdue tasks
- View tasks due today
- View tasks due this week

### Statistics
- Total tasks
- Completed tasks
- Pending tasks
- In progress tasks
- Completion rate

### Data Persistence
- Automatic loading of tasks on startup
- JSON serialization
- JSON deserialization
- Local file storage

### Reporting
- Export tasks report to TXT file

---

## Technologies Used

- C#
- .NET
- LINQ
- System.Text.Json
- File I/O

---

## Concepts Demonstrated

### Object-Oriented Programming
- Classes
- Objects
- Constructors
- Properties
- Enums
- Encapsulation

### LINQ
- Where()
- FirstOrDefault()
- Any()
- Count()
- Max()
- OrderBy()
- ToList()

### Data Handling
- JSON Serialization
- JSON Deserialization
- File Management

### Input Validation
- int.TryParse()
- DateTime.TryParse()
- Enum.TryParse()

---

## Project Structure

```text
TaskManagerPro
│
├── Models
│   └── TaskItem.cs
│
├── Enums
│   ├── Priority.cs
│   └── TaskStat.cs
│
├── Services
│   └── TaskService.cs
│
├── Program.cs
│
└── tasks.json
```

---

## Example Menu

```text
1. Add Task
2. View Tasks
3. Search Task
4. Edit Task
5. Remove Task
6. Mark Task As Completed
7. Statistics
8. Show Tasks Due Today
9. Show Tasks Due This Week
10. Sort Tasks By Deadline
11. Export Tasks Report
0. Exit
```

---

## Future Improvements

- User authentication
- Categories and tags
- Task reminders
- SQLite database integration
- ASP.NET Web version
- GUI version with WPF or WinForms

---

## Author

Geno Dimitrov