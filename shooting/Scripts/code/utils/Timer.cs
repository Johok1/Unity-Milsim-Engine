public class Timer
{
    public float Duration { get; private set; }
    public float TimeRemaining { get; private set; }
    public bool IsRunning { get; private set; }
    public bool IsFinished => !IsRunning && TimeRemaining <= 0f;

    public Timer(float duration)
    {
        Duration = duration;
        TimeRemaining = duration;
    }

    public void Start()
    {
        TimeRemaining = Duration;
        IsRunning = true;
    }

    public void Stop()
    {
        IsRunning = false;
    }

    public void Update(float deltaTime)
    {
        if (!IsRunning) return;

        TimeRemaining -= deltaTime;
        if (TimeRemaining <= 0f)
        {
            TimeRemaining = 0f;
            IsRunning = false;
        }
    }

    public void Reset()
    {
        TimeRemaining = Duration;
        IsRunning = true;
    }
}
