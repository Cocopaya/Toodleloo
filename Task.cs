using System;
using System.Collections.Generic;
using System.Text;

namespace Toodleloo
{
    internal class Task(string title, DateTime dueDate, Project project)
    {
        public enum TaskStatus
        {
            ToDo,
            Done
        }
        public string Title { get; set; } = title;
        public DateTime DueDate { get; set; } = dueDate;
        public TaskStatus Status { get; set; } = TaskStatus.ToDo;
        public Project Project { get; set; } = project;

    }
}
