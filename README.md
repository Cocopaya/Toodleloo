# Toodleloo

A simple console-based task management application built with C# and .NET 10.

## Features

- **Add Tasks**: Create new tasks with a title, due date, and associated project
- **View Tasks**: Display all tasks in a formatted table
- **Edit Tasks**: Update task details (title, due date, project)
- **Mark Complete**: Mark tasks as done
- **Delete Tasks**: Remove tasks from your list
- **Sort Tasks**: Sort by due date or project
- **Project Organization**: Organize tasks into projects

## Project Structure

- **Program.cs**: Main console application with the user interface loop
- **Task.cs**: Represents a task with title, due date, status, and project
- **Project.cs**: Represents a project to organize tasks
- **TaskManager.cs**: Manages collections of tasks and projects, provides core operations

## Getting Started

### Requirements

- .NET 10 or later
- C# language support

### Building

```bash
dotnet build
```

### Running

```bash
dotnet run
```

## Usage

The application presents a menu with the following options:

1. **Show Task List** - Display all tasks in a formatted table
2. **Add Task** - Create a new task (prompts for title, due date, and project)
3. **Edit Task** - Modify an existing task:
   - Update task details
   - Mark as done
   - Remove task
4. **Sort Tasks** - Organize tasks by due date or project
5. **Save and Quit** - Exit the application

### Date Format

When entering dates, use the format: `yyyy-mm-dd` (e.g., `2026-12-31`)

## Class Diagram

```
TaskManager (1) ----o (*) Task
TaskManager (1) ----o (*) Project
Task (*) ------> (1) Project
```

## Future Enhancements

- Data persistence (save/load tasks from file)
- Priority levels for tasks
- Task descriptions/notes
- Recurring tasks
- Filtering and searching
