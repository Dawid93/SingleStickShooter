using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour, IInitializable
{
	private List<BaseSpellPoolObject> spells;

	public void Initialize()
	{
		spells = new List<BaseSpellPoolObject>();
		BaseSpellPoolObject.SpellCreate += AddSpell;
		BaseSpellPoolObject.SpellRemove += RemoveSpell;
	}

	private void FixedUpdate()
	{
		foreach (var spell in spells)
		{
			spell.Move(Time.fixedDeltaTime);
		}
	}

	private void AddSpell(BaseSpellPoolObject spell)
	{
		spells.Add(spell);
	}

	private void RemoveSpell(BaseSpellPoolObject spell)
	{
		spells.Remove(spell);
	}
}