using System;
using UnityEditor;
using UnityEngine;

namespace Spell
{
	[CreateAssetMenu(fileName = "SpeedChangeSpell", menuName = "Spells/MoveSpeedSpell", order = 0)]
	public class SpeedChangeSpellData : BaseSpellData
	{
		public float SpeedChangeFactor => speedChangeFactor;
		public float EffectDuration => effectDuration;
		
		[SerializeField] private float speedChangeFactor;
		[SerializeField] private float effectDuration;

		private void OnValidate()
		{
			spellType = SpellTypes.MoveSpeedModify;
		}
	}
}