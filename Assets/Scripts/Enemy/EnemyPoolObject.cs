using System;
using ObjectPool;
using Player;
using UnityEngine;

public class EnemyPoolObject : BasePoolObject
{
	public static event Action<EnemyPoolObject> EnemySpawn;
	public static event Action<EnemyPoolObject> EnemyRemoved;

	[SerializeField] private float speed = 1f;
	[SerializeField] private float damage = 50f;

	private Vector3 playerPos;

	public override void OnCreate(string poolTag, ObjectPooler objectPooler)
	{
		base.OnCreate(poolTag, objectPooler);
		playerPos = FindObjectOfType<PlayerController>().transform.position;
	}

	public override void OnSpawn()
	{
		RotateToTarget();
		EnemySpawn?.Invoke(this);
	}

	public override void OnReturn()
	{
		EnemyRemoved?.Invoke(this);
	}

	public void Move(float deltaTime)
	{
		transform.position += transform.forward * speed * deltaTime;
	}

	private void RotateToTarget()
	{
		transform.LookAt(new Vector3(playerPos.x, transform.position.y, playerPos.z));
	}
}