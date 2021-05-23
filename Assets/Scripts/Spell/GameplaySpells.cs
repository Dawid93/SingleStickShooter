using System;
using UnityEngine;

public class GameplaySpells : MonoBehaviour
{
	public BaseSpellController FirstBaseSpellController => firstBaseSpellController;
	public BaseSpellController SecondBaseSpellController => secondBaseSpellController;
	
	[SerializeField] private BaseSpellController firstBaseSpellController;
	[SerializeField] private BaseSpellController secondBaseSpellController;
}