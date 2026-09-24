
using System.Runtime.InteropServices;
using Toodleloo;
using Task = Toodleloo.Task;

TaskManager taskManager = new ();

bool exit = false;

while (!exit)
{
    int totalTasks = taskManager.Tasks.Count;
    int completedTasks = taskManager.Tasks.Count(t => t.Status == Task.TaskStatus.Done);
    Console.Clear();
    Console.WriteLine("Welcome to Toodleloo.\nYou have {0} tasks to do and {1} tasks are done.\nWhat do you want to do?", totalTasks, completedTasks);
    Console.WriteLine("\n1. Show Task List\n2. Add Task\n3. Edit Task\n4. Sort Tasks\n5. Save and Quit");
    string choice = Console.ReadLine() ?? "";

    switch (choice)
    {
        case "1":
            taskManager.ShowTasks();
            break;
        case "2":
            Console.WriteLine("\nAdd Task\n");
            Console.WriteLine("Title:");
            string title = Console.ReadLine() ?? "";
            Console.WriteLine("Due date (yyyy-mm-dd):");
            DateTime dueDate = DateTime.Parse(Console.ReadLine() ?? "");
            Console.WriteLine("Project: ");
            string projectName = Console.ReadLine() ?? "";
            Project? project = taskManager.GetOrCreateProject(projectName);
            Task task = new(title, dueDate, project);
            taskManager.AddTask(task);
            break;
        case "3":
            Console.WriteLine("\nEdit Task\n");
            Console.WriteLine("Choose a Task to edit:");
            for (int i = 0; i < taskManager.Tasks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {taskManager.Tasks[i].Title}");
            }
            Task taskToEdit = taskManager.Tasks[int.Parse(Console.ReadLine() ?? "") - 1];
            Console.WriteLine("What do you want to edit?");
            Console.WriteLine("\n1. Update\n2. Mark as Done\n3. Remove");
            string editChoice = Console.ReadLine() ?? "";
            switch (editChoice)
            {
                case "1":
                    Console.WriteLine("What do you want to update?");
                    Console.WriteLine("Update title? Y/N");
                    string updateTitle = Console.ReadLine() ?? "";
                    if (updateTitle.ToLower() == "y")
                    {
                        Console.WriteLine("Enter new title:");
                        taskToEdit.Title = Console.ReadLine() ?? "";
                    }
                    Console.WriteLine("Update the due date? Y/N");
                    string updateDueDate = Console.ReadLine() ?? "";
                    if (updateDueDate.ToLower() == "y")
                    {
                        Console.WriteLine("Enter new due date (yyyy-mm-dd):");
                        taskToEdit.DueDate = DateTime.Parse(Console.ReadLine() ?? "");
                    }
                    Console.WriteLine("Update Project? Y/N");
                    string updateProject = Console.ReadLine() ?? "";
                    if (updateProject.ToLower() == "y")
                    {
                        Console.WriteLine("Enter new project name:");
                        string editProjectName = Console.ReadLine() ?? "";
                        Project? editProject = taskManager.GetOrCreateProject(editProjectName);
                        taskToEdit.Project = editProject;
                    }
                    break;
                case "2":
                    taskToEdit.Status = Task.TaskStatus.Done;
                    break;
                case "3":
                    taskManager.Tasks.Remove(taskToEdit);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
            break;
        case "4":
            taskManager.SortTasks();
            break;
        case "5":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }

    if (exit) break;

    Console.Write("\n(Press Enter to continue)...");
    Console.ReadLine();
}
