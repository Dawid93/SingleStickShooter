using System;
using ObjectPool;
using UnityEngine;

public class BulletPoolObject : BasePoolObject, IMoveable
{
	public static event Action<BulletPoolObject> BulletSpawn;
	public static event Action<BulletPoolObject> BulletRemoved;
	
	[SerializeField] private float bulletSpeed = 40f;
	[SerializeField] private float bulletDamage = 75f;
	[SerializeField] private UnitMove bulletMove;
	[SerializeField] private Rigidbody rBody;

	public override void OnCreate(string poolTag, ObjectPooler objectPooler)
	{
		base.OnCreate(poolTag, objectPooler);
		
		bulletMove.SetDefaultSpeed(bulletSpeed);
		bulletMove.SetRigidbody(rBody);
	}

	public override void OnSpawn()
	{
		rBody.WakeUp();
		BulletSpawn?.Invoke(this);
	}

	public override void OnReturn()
	{
		rBody.Sleep();
		BulletRemoved?.Invoke(this);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out UnitHealth unit))
			unit.TakeDamage(bulletDamage);
		SelfReturn();
	}

	public void Move()
	{
		bulletMove.UseVelocity();
	}

	public void StopMove()
	{
		bulletMove.ResetVelocity();
	}
}