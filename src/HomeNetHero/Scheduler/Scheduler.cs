using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HomeNetHeroApp
{
    public class Scheduler : IScheduler
    {
        private readonly Dictionary<TimeSpan, Action> tasks;
        private bool isRunning;
        private Thread executionThread;

        public Scheduler()
        {
            tasks = new Dictionary<TimeSpan, Action>();
            isRunning = false;
            executionThread = null;
        }

        public void RegisterTask(TimeSpan interval, Action callback)
        {
            if (interval <= TimeSpan.Zero)
                throw new ArgumentException("Interval must be a positive time span.");

            if (callback == null)
                throw new ArgumentNullException(nameof(callback), "Callback handler cannot be null.");

            tasks[interval] = callback;
        }

        public void Start()
        {
            if (!isRunning)
            {
                isRunning = true;
                executionThread = new Thread(RunTasks);
                executionThread.Start();
            }
        }

        public void Stop()
        {
            if (isRunning)
            {
                isRunning = false;
                executionThread.Join();
                executionThread = null;
            }
        }

        public List<Action> GetAllActiveTasks()
        {
            return tasks.Values.ToList();
        }

        private void RunTasks()
        {
            var lastExecutionTimes = new Dictionary<TimeSpan, DateTime>();

            while (isRunning)
            {
                var currentTime = DateTime.Now;
                var currentTasks = new List<Action>(tasks.Values);

                foreach (var task in currentTasks)
                {
                    var interval = tasks.FirstOrDefault(x => x.Value == task).Key;

                    if (!lastExecutionTimes.ContainsKey(interval))
                        lastExecutionTimes[interval] = currentTime;

                    var lastExecutionTime = lastExecutionTimes[interval];

                    if (currentTime - lastExecutionTime >= interval)
                    {
                        try
                        {
                            task.Invoke();
                            lastExecutionTimes[interval] = currentTime;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error executing scheduled task: {ex.Message}");
                        }
                    }
                }

                Thread.Sleep(1000); // Sleep for 1 second before checking tasks again
            }
        }
    }
}
