	using UnityEngine;

public class SpellManager : BaseMoveManager<BaseSpellPoolObject>
{
	public override void Initialize()
	{
		base.Initialize();
		
		BaseSpellPoolObject.SpellCreate += AddUnit;
		BaseSpellPoolObject.SpellRemove += RemoveUnit;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		
		BaseSpellPoolObject.SpellCreate -= AddUnit;
		BaseSpellPoolObject.SpellRemove -= RemoveUnit;
	}
}