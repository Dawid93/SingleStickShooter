using System;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
	private List<Timer> timers;

	private void Awake()
	{
		Timer.TimerCreate += HandleCreateTimer;
		Timer.TimerStop += HandleStopTimer;
		
		timers = new List<Timer>();
	}

	private void Update()
	{
		foreach (var timer in timers)
		{
			timer.Countdown(Time.deltaTime);
		}
	}

	private void HandleCreateTimer(Timer timer)
	{
		timers.Add(timer);
	}

	private void HandleStopTimer(Timer timer)
	{
		timers.Remove(timer);
	}
}