using System;
using UnityEngine;

namespace Spell.SpellObjects
{
	public class OffensiveSpell : SpellPoolObject
	{
		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out UnitHealth unit))
			{
			}
		}
	}
}