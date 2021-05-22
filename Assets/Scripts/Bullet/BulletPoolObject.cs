using System;
using ObjectPool;
using Player;
using UnityEngine;

public class BulletPoolObject : BasePoolObject
{
	public static event Action<BulletPoolObject> BulletSpawn;
	public static event Action<BulletPoolObject> BulletRemoved;
	
	[SerializeField] private float bulletSpeed = 40f;
	
	public override void OnSpawn()
	{
		BulletSpawn?.Invoke(this);
	}

	public override void OnReturn()
	{
		BulletRemoved?.Invoke(this);
	}

	public void Move(float deltaTime)
	{
		transform.position += transform.forward * bulletSpeed * deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out PlayerController playerController))
		{
			
		}
		SelfReturn();
	}
}