using System;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour, IInitializable
{
	private List<Timer> timers;
	
	[SerializeField] private int timersCount;

	public void Initialize()
	{
		Timer.TimerCreate += HandleCreateTimer;
		
		timers = new List<Timer>();
	}

	private void Update()
	{
		for (int i = 0; i < timers.Count; i++)
		{
			if (timers[i].IsFinished)
				timers.Remove(timers[i]);
			else
				timers[i].Countdown(Time.deltaTime);
		}

		timersCount = timers.Count;
	}

	private void HandleCreateTimer(Timer timer)
	{
		timers.Add(timer);
	}
}