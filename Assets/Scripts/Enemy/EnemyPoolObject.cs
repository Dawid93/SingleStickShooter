using System;
using ObjectPool;
using UnityEngine;

public class EnemyPoolObject : BasePoolObject, ISpeedChangeable
{
	public static event Action<EnemyPoolObject> EnemySpawn;
	public static event Action<EnemyPoolObject> EnemyRemoved;
	
	public bool WasKilled { get; private set; }

	[SerializeField] private UnitHealth enemyHealth;
	[SerializeField] private UnitMove enemyMove;
	[SerializeField] private MaterialColorModifier materialModifier;
	[SerializeField] private float speed = 1f;
	[SerializeField] private float damage = 50f;

	private static DifficultySettings currentDifficultySettings;

	private Vector3 playerPos;
	private float maxHealth;
	private Timer timer;

	public override void OnCreate(string poolTag, ObjectPooler objectPooler)
	{
		base.OnCreate(poolTag, objectPooler);
		
		if (currentDifficultySettings == null)
			currentDifficultySettings = DifficultyController.Instance.CurrentDifficultySettings;

		materialModifier.Setup(GetComponent<Renderer>());
		playerPos = FindObjectOfType<PlayerController>().transform.position;
		
		enemyHealth.Dead += HandleDead;
	}

	public override void OnSpawn()
	{
		enemyMove.SetDefaultSpeed(speed);
		RotateToTarget();
		WasKilled = false;
		enemyHealth.SetHealth(currentDifficultySettings.EnemyHealth);
		materialModifier.SetColor(EnemyColorRandomizer.GetRandomColor());
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
			Debug.Log($"Other name {other.name}");
			unit.TakeDamage(damage);
			SelfReturn();
		}
	}

	public void Move(float deltaTime)
	{
		enemyMove.MoveTransformForward(deltaTime);
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

	public void ChangeSpeed(float factorModifier, float duration)
	{
		if (timer == null)
		{
			timer = new Timer(duration, OnTimerComplete);
			enemyMove.ChangeSpeed(factorModifier);
		}
		else
			timer.ResetTimer();
	}

	private void OnTimerComplete()
	{
		timer = null;
		enemyMove.ResetSpeed();
	}
}