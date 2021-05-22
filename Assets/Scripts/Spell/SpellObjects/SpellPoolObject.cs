using System;
using ObjectPool;
using UnityEngine;

public abstract class SpellPoolObject : BasePoolObject
{
	public static event Action<SpellPoolObject> SpellCreate;
	public static event Action<SpellPoolObject> SpellRemove;
	
	[SerializeField] private BaseSpellData spellData;
	[SerializeField] private UnitMove spellMove;

	private float speed;

	public override void OnCreate(string poolTag, ObjectPooler objectPooler)
	{
		base.OnCreate(poolTag, objectPooler);
		speed = spellData.MoveSpeed;
	}

	public override void OnSpawn()
	{
		spellMove.SetDefaultSpeed(speed);
		SpellCreate?.Invoke(this);
	}

	public override void OnReturn()
	{
		SpellRemove?.Invoke(this);
	}

	public void Move(float deltaTime)
	{
		spellMove.MoveForward(deltaTime);
	}
}