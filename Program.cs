
using Toodleloo;
using Task = Toodleloo.Task;

TaskManager taskManager = new ();

bool exit = false;

while (!exit)
{
    Console.WriteLine("Welcome to Toodleloo.\nYou have x tasks to do and y tasks are done.\nWhat do you want to do?");
    Console.WriteLine("1. Show Task List\n2. Add Task\n3. Edit Task\n4. Save and Quit");
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
        case "4":
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
