using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	private List<EnemyPoolObject> enemies;

	private void Awake()
	{
		enemies = new List<EnemyPoolObject>();
		EnemyPoolObject.EnemySpawn += AddEnemy;
		EnemyPoolObject.EnemyRemoved += RemoveEnemy;
	}

	private void FixedUpdate()
	{
		foreach (var enemy in enemies)
		{
			enemy.Move(Time.fixedDeltaTime);
		}
	}

	private void AddEnemy(EnemyPoolObject enemy)
	{
		enemies.Add(enemy);
	}

	private void RemoveEnemy(EnemyPoolObject enemy)
	{
		enemies.Remove(enemy);
	}
}