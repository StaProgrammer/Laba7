using System;
class Program
{
    static void Main(string[] args)
    {
        TaskScheduler<string, int> scheduler = new TaskScheduler<string, int>(() => string.Empty, _ => { });

        while (true)
        {
            Console.WriteLine("Enter a task or 'exit' to quit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "exit")
                break;

            Console.WriteLine("Enter priority (an integer):");
            if (int.TryParse(Console.ReadLine(), out int priority))
            {
                var task = scheduler.taskPool.GetObject();
                task = input;
                scheduler.AddTask(task, priority);
                Console.WriteLine("Task added.");
            }
            else
            {
                Console.WriteLine("Invalid priority. Task not added.");
            }
        }

        while (scheduler.TaskCount > 0)
        {
            Console.WriteLine("Press Enter to execute the next task...");
            Console.ReadLine();
            scheduler.ExecuteNext(task => Console.WriteLine($"Executing task: {task}"));
        }
    }
}