using System;
using UnityEngine;

public class GameTimer : MonoBehaviour, IInitializable
{
	public float GameTime { get; private set; }

	private bool isGameStarted;
	public void Initialize()
	{
		GameController.GameStateChange += HandleGameStateChanged;
	}

	private void HandleGameStateChanged(GameStates state)
	{
		switch (state)
		{
			case GameStates.GameStart:
				isGameStarted = true;
				GameTime = 0;
				break;
			case GameStates.GameOver:
				isGameStarted = false;
				break;
		}
	}

	private void Update()
	{
		if (!isGameStarted)
			return;

		GameTime += Time.deltaTime;
	}

	private void OnDestroy()
	{
		GameController.GameStateChange -= HandleGameStateChanged;
	}
}