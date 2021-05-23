using System;

public class Timer
{
	public static event Action<Timer> TimerCreate;
	public static event Action<Timer> TimerStop;
	public event Action TimerUpdate;

	public bool IsFinished { get; private set; }
	private Action Complete { get; }
	private float Time { get; }

	private float ellapsedTime;

	public Timer(float time, Action onComplete)
	{
		Time = time;
		ellapsedTime = 0;
		Complete = onComplete;
		IsFinished = false;
		TimerCreate?.Invoke(this);
	}

	public void StopTimer()
	{
		if (IsFinished)
			return;
		
		IsFinished = true;
		TimerStop?.Invoke(this);
	}

	public void Countdown(float deltaTime)
	{
		if (IsFinished)
			return;

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
		if (IsFinished)
			return;
		ellapsedTime = 0;
	}

	public float GetNormalizedTime()
	{
		if (IsFinished)
			return 1;
		return ellapsedTime / Time;
	}
}