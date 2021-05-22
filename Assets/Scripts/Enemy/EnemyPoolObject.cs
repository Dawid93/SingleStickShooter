using System;
using ObjectPool;
using Player;
using UnityEngine;

public class EnemyPoolObject : BasePoolObject
{
	public static event Action<EnemyPoolObject> EnemySpawn;
	public static event Action<EnemyPoolObject> EnemyRemoved;
	
	public bool WasKilled { get; private set; }

	[SerializeField] private UnitHealth enemyHealth;
	[SerializeField] private UnitMove enemyMove;
	[SerializeField] private float speed = 1f;
	[SerializeField] private float damage = 50f;

	private static DifficultySettings currentDifficultySettings;

	private Vector3 playerPos;
	private float maxHealth;

	public override void OnCreate(string poolTag, ObjectPooler objectPooler)
	{
		if (currentDifficultySettings == null)
			currentDifficultySettings = DifficultyController.Instance.CurrentDifficultySettings;
		
		base.OnCreate(poolTag, objectPooler);
		playerPos = FindObjectOfType<PlayerController>().transform.position;
	}

	public override void OnSpawn()
	{
		RotateToTarget();
		WasKilled = false;
		enemyHealth.SetHealth(currentDifficultySettings.EnemyHealth);
		enemyHealth.Dead += HandleDead;
		EnemySpawn?.Invoke(this);
	}

	public override void OnReturn()
	{
		EnemyRemoved?.Invoke(this);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out UnitHealth unit))
		{
			unit.TakeDamage(damage);
			SelfReturn();
		}
	}

	public void Move(float deltaTime)
	{
		enemyMove.MoveForward(speed, deltaTime);
	}

	private void RotateToTarget()
	{
		transform.LookAt(new Vector3(playerPos.x, transform.position.y, playerPos.z));
	}

	private void HandleDead()
	{
		WasKilled = true;
		SelfReturn();
	}
}