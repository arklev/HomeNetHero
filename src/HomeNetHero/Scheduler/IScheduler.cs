namespace HomeNetHeroApp
{
    public interface IScheduler
    {
        void RegisterTask(TimeSpan interval, Action callback);
        void Start();
        void Stop();
        List<Action> GetAllActiveTasks();
    }
}
