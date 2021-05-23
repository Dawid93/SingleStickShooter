using System.Collections.Generic;
using ObjectPool;
using UnityEngine;

public class SpellManager : BaseManager<BaseSpellPoolObject>
{
	public override void Initialize()
	{
		base.Initialize();
		
		BaseSpellPoolObject.SpellCreate += AddUnit;
		BaseSpellPoolObject.SpellRemove += RemoveUnit;
	}

	private void FixedUpdate()
	{
		if (!isGameStarted)
			return;
		
		foreach (var unit in units)
		{
			unit.Move(Time.fixedDeltaTime);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		
		BaseSpellPoolObject.SpellCreate -= AddUnit;
		BaseSpellPoolObject.SpellRemove -= RemoveUnit;
	}
}