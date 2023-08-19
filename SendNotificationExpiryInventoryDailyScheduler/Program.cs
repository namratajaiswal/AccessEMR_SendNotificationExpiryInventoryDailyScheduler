using SendNotificationExpiryInventoryDailyScheduler.Models;
using SendNotificationExpiryInventoryDailyScheduler.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SendNotificationExpiryInventoryDailyScheduler
{
    class Program
    {
        private static CancellationTokenSource tokenSource;
        static void Main(string[] args)
        {
            tokenSource = new CancellationTokenSource();

            var repository = new SchedulerReposiotry();
            Task<JsonModel> scheduledTask = repository.PostAsync(tokenSource.Token);

            scheduledTask.ContinueWith(task =>
            {
                JsonModel response = task.Result;
                //Console.WriteLine((response.Message));
                Environment.Exit(0);
            },
                TaskContinuationOptions.OnlyOnRanToCompletion);

            scheduledTask.ContinueWith(
                HandleError,
                TaskContinuationOptions.OnlyOnFaulted);

            scheduledTask.ContinueWith(
                HandleCancellation,
                TaskContinuationOptions.OnlyOnCanceled);

            HandleExit();

            Console.ReadLine();
        }

        private static void HandleError(Task<JsonModel> task)
        {
            Console.WriteLine("\nThere was a problem retrieving data");
            Environment.Exit(1);
            Console.ReadLine();
        }

        private static void HandleCancellation(Task<JsonModel> task)
        {
            Console.WriteLine("\nThe operation was canceled");
            Environment.Exit(0);
            Console.ReadLine();
        }

        private static void HandleExit()
        {
            while (true)
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.X:
                        tokenSource.Cancel();
                        break;
                    case ConsoleKey.Q:
                        Console.WriteLine();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Waiting...");
                        break;
                }
        }
    }
}
