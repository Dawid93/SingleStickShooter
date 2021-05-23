using System;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : BaseManager<Timer>
{
	[SerializeField] private int timersCount;

	public override void Initialize()
	{
		base.Initialize();
		Timer.TimerCreate += AddUnit;
	}

	private void Update()
	{
		if (!isGameStarted)
			return;
		
		for (int i = 0; i < units.Count; i++)
		{
			if (units[i].IsFinished)
				units.Remove(units[i]);
			else
				units[i].Countdown(Time.deltaTime);
		}

		timersCount = units.Count;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		
		Timer.TimerCreate -= AddUnit;
	}
}