using System;
using System.Collections.Generic;
using System.Text;

namespace Toodleloo
{
    internal class TaskManager
    {
        public List<Task> Tasks = [];
        public List<Project> Projects = [];
        public Project GetOrCreateProject(string name)
        {
            var project = Projects.FirstOrDefault(p =>
                p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (project == null)
            {
                project = new Project(name);
                Projects.Add(project);
            }
            return project;
        }
        public void AddProject(Project project)
        {
            if (Projects.Contains(project))
                throw new ArgumentException("Project already exists.");
            Projects.Add(project);
        }

        public void AddTask(Task task)
        {
            if (string.IsNullOrWhiteSpace(task.Title))
                throw new ArgumentException("Title cannot be empty.");
            if (task.Project != null && !Projects.Contains(task.Project))
                throw new ArgumentException("Project does not exist.");
            Tasks.Add(task);
        }
        public void SortTasks()
        {
            Console.WriteLine("\nSort by:");
            Console.WriteLine("1. Due Date");
            Console.WriteLine("2. Project");
            string choice = Console.ReadLine() ?? "";
            switch (choice)
            {
                case "1":
                    Tasks.Sort((x, y) => x.DueDate.CompareTo(y.DueDate));
                    break;
                case "2":
                    Tasks.Sort((x, y) => string.Compare(x.Project.Name, y.Project.Name, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    Console.WriteLine("Invalid choice. Showing unsorted tasks.");
                    break;
            }
        }

        public void ShowTasks()
        {
            
            Console.WriteLine("\nTask List");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("Title".PadRight(15) + "Due Date".PadRight(15) + "Status".PadRight(15) + "Project");
            Console.WriteLine("-------------------------------------------------------------------------");


            foreach (var task in Tasks)
            {
                Console.WriteLine($"{task.Title}".PadRight(15) + $"{task.DueDate:yyyy-MM-dd}".PadRight(15) + $"{task.Status}".PadRight(15) + $"{task.Project.Name}".PadRight(15));
            }
        }
    }
}
