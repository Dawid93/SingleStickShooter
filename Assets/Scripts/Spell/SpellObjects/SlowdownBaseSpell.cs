using ObjectPool;
using Spell;
using UnityEngine;

public class SlowdownBaseSpell : BaseSpellPoolObject
{
	private SpeedChangeSpellData speedChangeSpellData;
		
	public override void OnCreate(string poolTag, ObjectPooler objectPooler)
	{
		base.OnCreate(poolTag, objectPooler);
		speedChangeSpellData = spellData as SpeedChangeSpellData;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out ISpeedChangeable unit))
		{
			unit.ChangeSpeed(speedChangeSpellData.SpeedChangeFactor, speedChangeSpellData.EffectDuration);
		}
	}
}