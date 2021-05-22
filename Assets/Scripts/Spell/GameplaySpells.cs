using System;
using UnityEngine;

public class GameplaySpells : MonoBehaviour
{
	public SpellController FirstSpellController => firstSpellController;
	public SpellController SecondSpellController => secondSpellController;
	
	[SerializeField] private SpellController firstSpellController;
	[SerializeField] private SpellController secondSpellController;
}