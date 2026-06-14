using TaskManagerPro.Models;
using TaskManagerPro.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerPro.Services;

public class Program
{
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
        
    }
}