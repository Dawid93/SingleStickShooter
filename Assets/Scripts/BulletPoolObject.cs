using System;
using ObjectPool;
using UnityEngine;

public class BulletPoolObject : BasePoolObject
{
	public static event Action<BulletPoolObject> BulletSpawn;
	public static event Action<BulletPoolObject> BulletRemoved;
	
	[SerializeField] private float bulletSpeed = 40f;
	
	public override void OnSpawn()
	{
		throw new System.NotImplementedException();
	}

	public override void OnReturn()
	{
		throw new System.NotImplementedException();
	}
}