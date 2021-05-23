using System;
using ObjectPool;
using UnityEngine;

public abstract class BaseSpellPoolObject : BasePoolObject
{
	public static event Action<BaseSpellPoolObject> SpellCreate;
	public static event Action<BaseSpellPoolObject> SpellRemove;
	
	[SerializeField] protected BaseSpellData spellData;
	[SerializeField] private UnitMove spellMove;
	[SerializeField] private Rigidbody rBody;

	private float speed;

	public override void OnCreate(string poolTag, ObjectPooler objectPooler)
	{
		base.OnCreate(poolTag, objectPooler);
		spellMove.SetRigidbody(rBody);
		GetComponent<MeshRenderer>().enabled = false;
		speed = spellData.MoveSpeed;
	}

	public override void OnSpawn()
	{
		spellMove.SetDefaultSpeed(speed);
		rBody.WakeUp();
		SpellCreate?.Invoke(this);
	}

	public override void OnReturn()
	{
		rBody.Sleep();
		SpellRemove?.Invoke(this);
	}

	public void Move(float deltaTime)
	{
		spellMove.MoveRigidbodyForward(deltaTime);
	}
}