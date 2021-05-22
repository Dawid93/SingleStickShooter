using System;
using UnityEngine;


[CreateAssetMenu(fileName = "OffensiveSpellData", menuName = "Spells/OffensiveSpell", order = 0)]
public class OffensiveSpellData : BaseSpellData
{
	public float Damage => damage;
	[SerializeField] private float damage;

	private void OnValidate()
	{
		spellType = SpellTypes.Offensive;
	}
}