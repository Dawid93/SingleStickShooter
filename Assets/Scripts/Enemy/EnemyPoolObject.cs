using System;
using ObjectPool;
using UnityEngine;

public class EnemyPoolObject : BasePoolObject
{
	public static event Action<EnemyPoolObject> EnemySpawn;
	public static event Action<EnemyPoolObject> EnemyRemoved;

	[SerializeField] private float speed = 1f;
	[SerializeField] private float damage = 50f;

	public override void OnSpawn()
	{
		EnemySpawn?.Invoke(this);
	}

	public override void OnReturn()
	{
		EnemyRemoved?.Invoke(this);
	}
}