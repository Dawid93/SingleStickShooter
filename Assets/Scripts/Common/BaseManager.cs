using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager<T> : MonoBehaviour, IInitializable
{
	protected List<T> units;
	protected bool isGameStarted;

	public virtual void Initialize()
	{
		GameController.GameStateChange += HandleGameStateChange;
		units = new List<T>();
	}

	private void HandleGameStateChange(GameStates state)
	{
		switch (state)
		{
			case GameStates.GameStart:
				isGameStarted = true;
				break;
			case GameStates.GameOver:
				isGameStarted = false;
				break;
		}
	}
	
	protected void AddUnit(T unit)
	{
		units.Add(unit);
	}

	protected void RemoveUnit(T unit)
	{
		units.Remove(unit);
	}

	protected virtual void OnDestroy()
	{
		GameController.GameStateChange -= HandleGameStateChange;
	}
}