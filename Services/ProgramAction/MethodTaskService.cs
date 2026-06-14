using TaskManagerPro.Models;
using TaskManagerPro.Enums;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;

namespace TaskManagerPro.Services
{
    public class TaskService
    {
        private List<TaskItem> tasks;
        public TaskService()
        {
            tasks = new List<TaskItem>();
            LoadTasks();
        }

        public void AddTask()
        {
            int id = tasks.Any()? tasks.Max(t => t.Id) + 1: 1;

            Console.Write("Title: ");
            string title = Console.ReadLine() ?? "";

            Console.Write("Description: ");
            string description = Console.ReadLine() ?? "";

            Priority priority;

            Console.Write("Priority (Low, Medium, High): ");

            while (!Enum.TryParse(
                Console.ReadLine(),
                true,
                out priority))
            {
                Console.WriteLine("Invalid priority. Try again:");
            }
            
            TaskStat status;

            Console.Write("Status (Pending, InProgress, Completed): ");
            while (!Enum.TryParse(
                Console.ReadLine(),
                true,
                out status))
            {
                Console.WriteLine("Invalid status. Try again:");
            }

            DateTime deadline;

            Console.Write("Deadline (yyyy-MM-dd): ");

            while (!DateTime.TryParse(
                Console.ReadLine(),
                out deadline))
            {
                Console.WriteLine("Invalid date. Try again:");
            }

            TaskItem newTask = new TaskItem(id, title, description, priority, status, deadline);
            tasks.Add(newTask);
            Console.WriteLine("Task added successfully!");
        }
        public void ViewTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            Console.WriteLine("Tasks to see:");
            Console.WriteLine("1. See all tasks");
            Console.WriteLine("2. See tasks by status");
            Console.WriteLine("3. See tasks by priority");
            Console.Write("Which tasks would you like to see: ");
            int seeChoice;
            if(!int.TryParse(Console.ReadLine(), out seeChoice))
            {
                Console.WriteLine("Invalid choice. Please choose a number: ");
                return;
            }
            switch(seeChoice)
            {
                case 1:
                    foreach(TaskItem task in tasks)
                    {
                        ViewTask(task);
                    }
                break;
                case 2:
                    Console.WriteLine("See:");
                    Console.WriteLine("1. Overdue tasks");
                    Console.WriteLine("2. Pending tasks");
                    Console.WriteLine("3. Tasks in progress");
                    Console.WriteLine("4. Completed tasks");
                    int secondChoice;
                    if(!int.TryParse(Console.ReadLine(), out secondChoice))
                    {
                        Console.WriteLine("Invalid choice. Please choose a number: ");
                        return;
                    }
                    switch(secondChoice)
                    {
                        case 1:
                            ShowOverdueTasks();
                        break;
                        case 2:
                            ShowTasksByStatus(TaskStat.Pending);
                        break;
                        case 3:
                            ShowTasksByStatus(TaskStat.InProgress);
                        break;
                        case 4:
                            ShowTasksByStatus(TaskStat.Completed);
                        break;
                        default:
                        break;
                    }
                break;
                case 3:
                    Console.WriteLine("See:");
                    Console.WriteLine("1. Low prriority tasks");
                    Console.WriteLine("2. Meduim priority tasks");
                    Console.WriteLine("3. High priority tasks");
                    System.Console.Write("Which tasks would you like to see: ");
                    int thirdChoice;
                    if(!int.TryParse(Console.ReadLine(), out thirdChoice))
                    {
                        Console.WriteLine("Invalid choice. Please choose a number: ");
                        return;
                    }
                    switch(thirdChoice)
                    {
                        case 1:
                            ShowTasksByPriority(Priority.Low);
                        break;
                        case 2:
                            ShowTasksByPriority(Priority.Medium);
                        break;
                        case 3:
                            ShowTasksByPriority(Priority.High);
                        break;
                        default:
                        break;
                    }
                break;
                default:
                break;
            }
            
        }

        public void ViewTask(TaskItem task)
        {
            Console.WriteLine($"ID: {task.Id}");
            Console.WriteLine($"Title: {task.Title}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Priority: {task.Priority}");
            Console.WriteLine($"Status: {task.Status}");
            Console.WriteLine($"Deadline: {task.Deadline:yyyy-MM-dd}");
            Console.WriteLine("--------------------");
        }
        public void EditTask()
        {
            int taskId;
            Console.Write("Enter id: ");
            if(!int.TryParse(Console.ReadLine(), out taskId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }

            TaskItem? taskToEdit = tasks.FirstOrDefault(t => t.Id == taskId);

            if (taskToEdit == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }

            Console.WriteLine("Editing Task:");
            Console.WriteLine($"ID: {taskToEdit.Id}");
            Console.WriteLine($"Title: {taskToEdit.Title}");
            Console.WriteLine($"Description: {taskToEdit.Description}");
            Console.WriteLine($"Priority: {taskToEdit.Priority}");
            Console.WriteLine($"Status: {taskToEdit.Status}");
            Console.WriteLine($"Deadline: {taskToEdit.Deadline:yyyy-MM-dd}");

            Console.Write("New Title or leave blank to keep the current title:");
            string newTitle = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newTitle))
            {
                taskToEdit.Title = newTitle;
            }

            Console.Write("New Description or leave blank to keep current description: ");
            string newDescription = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newDescription))
            {
                taskToEdit.Description = newDescription;
            }

            Priority newPriority;
            Console.Write("New Priority (Low, Medium, High) or leave blank to keep current priority: ");
            string newInput = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newInput))
            {
                while(!Enum.TryParse(newInput, true, out newPriority))
                {
                    Console.Write("Invalid priority. Try again: ");
                    newInput = Console.ReadLine();
                }
                taskToEdit.Priority = newPriority;
            }

            TaskStat newStatus;
            Console.Write("New Status (Pending, InProgress, Completed) or leave blank to keep current status: ");
            string newStatInput = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newStatInput))
            {
                while(!Enum.TryParse(newStatInput, true, out newStatus))
                {
                    Console.Write("Invalid status. Try again: ");
                    newStatInput = Console.ReadLine() ?? "";
                }
            }

            DateTime newDeadline;
            Console.Write("New deadline (yyyy-MM-dd) or leave blank to keep current deadline: ");
            string newDeadlineInput = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(newDeadlineInput))
            {
                if(DateTime.TryParse(newDeadlineInput, out newDeadline))
                {
                taskToEdit.Deadline = newDeadline;
                }
                else
                {
                    Console.WriteLine("Invalid deadline.");
                }
            }
            Console.WriteLine("Task edited successfully. Edited task: ");
            ViewTask(taskToEdit);
        }
        public void RemoveTask()
        {
            int taskId;
            Console.Write("Enter id: ");
            if(!int.TryParse(Console.ReadLine(), out taskId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }
            TaskItem? taskToRemove = tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToRemove == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }
            ViewTask(taskToRemove);
            Console.Write("Are you sure you want to remove this task?(Yes/No): ");
            string choice = Console.ReadLine() ?? "";
            if(choice.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                tasks.Remove(taskToRemove);
                Console.WriteLine("Task removed successfully!");
            }
            else
            {
                Console.WriteLine("Task not removed.");
            }

        }
        public void SearchTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.");
                return;
            }
            Console.WriteLine("Search task by:");
            Console.WriteLine("1. ID");
            Console.WriteLine("2. Title/word/phrase");
            Console.WriteLine("3. Priority");
            Console.WriteLine("4. Status");
            Console.Write("Choose number search task: ");
            int searchChoice ;
            if(!int.TryParse(Console.ReadLine(), out searchChoice))
            {
                Console.WriteLine("Invalid choice. Please choose a number: ");
                return;
            }
            switch(searchChoice)
            {
                case 1:
                    int searchTaskId;
                    Console.Write("Enter id: ");
                    if(!int.TryParse(Console.ReadLine(), out searchTaskId))
                    {
                        Console.WriteLine("Invalid ID. Please enter a valid integer.");
                        return;
                    }
                    TaskItem? taskToSearch = tasks.FirstOrDefault(t => t.Id == searchTaskId);
                    if (taskToSearch == null)
                    {
                        Console.WriteLine("Task not found.");
                        return;
                    }
                    ViewTask(taskToSearch);
                break;
                case 2:
                    string searchTerm;
                    Console.Write("Enter title/word/phrase: ");
                    searchTerm = Console.ReadLine()??"";
                    List<TaskItem> foundTasks = tasks.Where(t => t.Title.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)|| t.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                    if(!foundTasks.Any())
                    {
                        Console.WriteLine("No tasks found.");
                        break;
                    }
                    Console.WriteLine($"Found {foundTasks.Count} task(s).");
                    foreach(TaskItem task in foundTasks)
                    {
                        ViewTask(task);
                    }
                break;
                case 3:
                    Priority searchPriority;
                    Console.Write("Enter priority(Low, Medium, High): ");
                    if(!Enum.TryParse(Console.ReadLine(), true, out searchPriority))
                    {
                        Console.WriteLine("Invalid priority:");
                        break;
                    }
                    List<TaskItem> foundTasksPr = tasks.Where(t => t.Priority == searchPriority).ToList();
                    if(!foundTasksPr.Any())
                    {
                        Console.WriteLine("No tasks found.");
                        break;
                    }
                    Console.WriteLine($"Found {foundTasksPr.Count} task(s).");
                    foreach(TaskItem task in foundTasksPr)
                    {
                        ViewTask(task);
                    }
                break;
                case 4:
                    TaskStat searchStatus;
                    Console.Write("Enter status(Pending, InProgress, Completed): ");
                    if(!Enum.TryParse(Console.ReadLine(), true, out searchStatus))
                    {
                        Console.WriteLine("Invalid status:");
                        break;
                    }
                    List<TaskItem> foundTasksStat = tasks.Where(t => t.Status == searchStatus).ToList();
                    if(!foundTasksStat.Any())
                    {
                        Console.WriteLine("No tasks found.");
                        break;
                    }
                    Console.WriteLine($"Found {foundTasksStat.Count} task(s).");
                    foreach(TaskItem task in foundTasksStat)
                    {
                        ViewTask(task);
                    }
                break;
                default:
                Console.WriteLine("Invalid choice.");
                break;
            }

        } 
        public void ShowOverdueTasks()
        {
            List<TaskItem> overdueTasks = tasks.Where(t =>t.Deadline < DateTime.Now &&t.Status != TaskStat.Completed).ToList();

            if (!overdueTasks.Any())
            {
                Console.WriteLine("No overdue tasks.");
                return;
            }

            Console.WriteLine($"Found {overdueTasks.Count} overdue task(s).");

            foreach (TaskItem task in overdueTasks)
            {
                ViewTask(task);
            }
        }
        public void ShowTasksByStatus(TaskStat status)
        {
            List<TaskItem> tasksToShow =tasks.Where(t => t.Status == status).ToList();
            if (!tasksToShow.Any())
            {
                Console.WriteLine("No tasks found.");
                return;
            }
            foreach(TaskItem task in tasksToShow)
            {
                ViewTask(task);
            }
        }
        public void ShowTasksByPriority(Priority priority)
        {
            List<TaskItem> tasksToShowP =tasks.Where(t => t.Priority == priority).ToList();
            if (!tasksToShowP.Any())
            {
                Console.WriteLine("No tasks found.");
                return;
            }
            foreach(TaskItem task in tasksToShowP)
            {
                ViewTask(task);
            }
        }
        public void SaveTasks()
        {
            string json = JsonSerializer.Serialize(tasks,new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText("tasks.json", json);

            Console.WriteLine("Tasks saved successfully.");
        }
        public void LoadTasks()
        {
            if (!File.Exists("tasks.json"))
            {
                Console.WriteLine("No save file found.");
                return;
            }

            string json =
                File.ReadAllText("tasks.json");

            List<TaskItem>? loadedTasks =
                JsonSerializer.Deserialize<List<TaskItem>>(json);

            if (loadedTasks != null)
            {
                tasks = loadedTasks;
            }

            Console.WriteLine("Tasks loaded successfully.");
        }
        public void MarkAsCompleted()
        {
            int markId;
            Console.Write("Enter task's id: ");
            if(!int.TryParse(Console.ReadLine(), out markId))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer.");
                return;
            }
            TaskItem? needToComplete = tasks.FirstOrDefault(t => t.Id == markId);
            if (needToComplete == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }
            if (needToComplete.Status == TaskStat.Completed)
            {
                Console.WriteLine("Task is already completed.");
                return;
            }

            needToComplete.Status = TaskStat.Completed;

            SaveTasks();

            Console.WriteLine("Task marked as completed.");

        }

    }

}