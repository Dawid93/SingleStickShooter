using System;
using ObjectPool;
using UnityEngine;

namespace Spell.SpellObjects
{
	public class OffensiveBaseSpell : BaseSpellPoolObject
	{
		private OffensiveSpellData offensiveSpellData;
		
		public override void OnCreate(string poolTag, ObjectPooler objectPooler)
		{
			base.OnCreate(poolTag, objectPooler);
			offensiveSpellData = spellData as OffensiveSpellData;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out UnitHealth unit))
			{
				unit.TakeDamage(offensiveSpellData.Damage);
			}
			
			if (other.gameObject.layer == Consts.BoundLayer)
				SelfReturn();
		}
	}
}