public class Timer
{
    public float Interval { get; set; }
    public float Counter { get; set; }

    public Timer(float interval)
    {
        Interval = interval;
    }

    public bool UpdateCounter(float value)
    {
        Counter += value;
        if (Counter >= Interval)
        {
            Counter = 0;
            return true;
        }
        
        return false;
    }
}
