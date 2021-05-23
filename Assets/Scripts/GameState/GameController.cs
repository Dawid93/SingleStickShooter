using System;
using System.Linq;
using Player;
using UnityEngine;

public class GameController : MonoBehaviour
{ 
	public static event Action<GameStates> GameStateChange;

	[SerializeField] private PlayerController playerController;
	
	private IInitializable[] initializables;

	private void Awake()
	{
		initializables = FindObjectsOfType<MonoBehaviour>().OfType<IInitializable>().ToArray();
		playerController.PlayerDead += HandlePlayerDead;
		Init();
		GameStateChange?.Invoke(GameStates.GameStart);
	}

	private void HandlePlayerDead()
	{
		GameStateChange?.Invoke(GameStates.GameOver);
	}

	private void Init()
	{
		foreach (var initializable in initializables)
		{
			initializable.Initialize();
		}
	}
}