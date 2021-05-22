using System;
using UnityEngine;

public class SpellsContainer : MonoBehaviour
{
	[SerializeField] private SpellIcon spellIconPrefab;
	[SerializeField] private GameplaySpells spells;

	private void Awake()
	{
		CreateIcons();
	}

	private void CreateIcons()
	{
		CreateIcon(spells.FirstSpellController.SpellData);
		CreateIcon(spells.SecondSpellController.SpellData);
	}

	private void CreateIcon(BaseSpellData spell)
	{
		var icon = Instantiate(spellIconPrefab, transform);
		icon.SetImage(spell.SpellImage);
		icon.SetColor(spell.BackgroundImageColor, spell.FillImageColor);
		icon.SetFill(0);
	}
}