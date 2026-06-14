using TaskManagerPro.Models;
using TaskManagerPro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Services;

namespace TaskManagerPro
{
    public class Program
    {
        static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===== TASK MANAGER PRO =====");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Edit tasks");
            Console.WriteLine("4. Remove tasks");
            Console.WriteLine("5. Search tasks");
            Console.WriteLine("6. Save tasks");
            Console.WriteLine("7. Mark task as completed");
            Console.WriteLine("8. Show statistics");
            Console.WriteLine("9. Export tasks report");
            Console.WriteLine("0. Exit");
        }

        public static void Main(string[] args)
        {
            TaskService taskService = new TaskService();

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                ShowMenu();
                Console.Write("\nChoose option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice.");
                    Pause();
                    continue;
                }

                Console.Clear();

                switch (choice)
                {
                    case 1:
                        taskService.AddTask();
                        break;

                    case 2:
                        taskService.ViewTasks();
                        break;

                    case 3:
                        taskService.SearchTask();
                        break;

                    case 4:
                        taskService.EditTask();
                        break;

                    case 5:
                        taskService.RemoveTask();
                        break;

                    case 6:
                        taskService.MarkAsCompleted();
                        break;

                    case 7:
                        taskService.ShowStatistics();
                        break;

                    case 8:
                        taskService.ShowDueTodayTasks();
                        break;

                    case 9:
                        taskService.ShowDueThisWeekTasks();
                        break;
                    case 0:
                        isRunning = false;
                    break;
                }
                if (isRunning)
                {
                    Pause();
                }

            }
        }
    }
    
}