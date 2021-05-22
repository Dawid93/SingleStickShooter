using System;
using ObjectPool;
using Player;
using UnityEngine;

public class BulletPoolObject : BasePoolObject
{
	public static event Action<BulletPoolObject> BulletSpawn;
	public static event Action<BulletPoolObject> BulletRemoved;
	
	[SerializeField] private float bulletSpeed = 40f;
	[SerializeField] private float bulletDamage = 75f;
	[SerializeField] private UnitMove bulletMove;
	
	public override void OnSpawn()
	{
		BulletSpawn?.Invoke(this);
	}

	public override void OnReturn()
	{
		BulletRemoved?.Invoke(this);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out UnitHealth unit))
		{
			unit.TakeDamage(bulletDamage);
		}
		SelfReturn();
	}

	public void Move(float deltaTime)
	{
		bulletMove.MoveForward(bulletSpeed, deltaTime);
	}
}