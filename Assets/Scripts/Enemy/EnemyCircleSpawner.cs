using System;
using ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCircleSpawner : MonoBehaviour, IInitializable
{
	[SerializeField] private float circleRadius = 25f;
	[SerializeField] private Transform centerOfCircle;

	private DifficultySettings difficultySettings;
	private float elapsedTime = 0;
	private float timeToSpawn;
	private bool isGameStarted;

	public void Initialize()
	{
		GameController.GameStateChange += HandleGameStateChanged;
		difficultySettings = DifficultyController.Instance.CurrentDifficultySettings;
		timeToSpawn = difficultySettings.TimeToSpawn;
	}
	
	private void HandleGameStateChanged(GameStates state)
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

	private void Update()
	{
		if (!isGameStarted)
			return;

		elapsedTime += Time.deltaTime;
		
		if (elapsedTime >= timeToSpawn)
		{
			elapsedTime -= timeToSpawn;
			Spawn();
		}
	}

	private void Spawn()
	{
		var spawnPos = RandomSpawnPos();
		ObjectPooler.Instance.GetFromPool(Consts.EnemyTag, spawnPos, Quaternion.identity, null);
	}

	private Vector3 RandomSpawnPos()
	{
		var radians = Random.value * 360 * Mathf.Deg2Rad;

		var vertical = Mathf.Sin(radians);
		var horizontal = Mathf.Cos(radians);
		
		var spawnDir = new Vector3(horizontal, 0, vertical);
		var spawnPos = centerOfCircle.position + spawnDir * circleRadius;
		return spawnPos;
	}
}