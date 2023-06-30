// See https://aka.ms/new-console-template for more information

using HomeNetHeroApp;

Console.WriteLine("Start");
Scheduler scheduler = new Scheduler();

scheduler.RegisterTask(TimeSpan.FromSeconds(10), () =>
{
   WebHookDemo webHookDemo = new WebHookDemo();
    _ = webHookDemo.SendNotificationAsync();
});

scheduler.Start();

while (scheduler.GetAllActiveTasks().Count > 0)
{
    Thread.Sleep(1000);
}

Console.WriteLine("End");