using TaskManagerPro.Enums;

namespace TaskManagerPro.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Priority Priority { get; set; }

        public TaskStat Status { get; set; }

        public DateTime Deadline { get; set; }

        public TaskItem()
        {
        }

        public TaskItem(int id, string title, string description, Priority priority,TaskStat status, DateTime deadline)
        {
            Id = id;
            Title = title;
            Description = description;
            Priority = priority;
            Status = status;
            Deadline = deadline;
        }
    }
    
}