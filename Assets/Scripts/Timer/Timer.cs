using System;

public class Timer
{
	public static event Action<Timer> TimerCreate;
	public event Action TimerUpdate;
	public static event Action<Timer> TimerStop;
	private Action Complete { get; }
	private float Time { get; }
	private float ellapsedTime;

	public Timer(float time, Action onComplete)
	{
		Time = time;
		ellapsedTime = 0;
		Complete = onComplete;
		TimerCreate?.Invoke(this);
	}

	public void StopTimer()
	{
		TimerStop?.Invoke(this);
	}

	public void Countdown(float deltaTime)
	{
		ellapsedTime += deltaTime;
		TimerUpdate?.Invoke();

		if (ellapsedTime >= Time)
		{
			Complete?.Invoke();
			StopTimer();
		}
	}

	public void ResetTimer()
	{
		ellapsedTime = 0;
	}

	public float GetNormalizedTime()
	{
		return ellapsedTime / Time;
	}
}