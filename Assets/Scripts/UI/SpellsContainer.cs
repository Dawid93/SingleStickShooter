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
		CreateIcon(spells.FirstBaseSpellController);
		CreateIcon(spells.SecondBaseSpellController);
	}

	private void CreateIcon(BaseSpellController baseSpellController)
	{
		var spellData = baseSpellController.SpellData;
		
		var icon = Instantiate(spellIconPrefab, transform);
		icon.SetSpellController(baseSpellController);
		icon.SetImage(spellData.SpellImage);
		icon.SetColor(spellData.BackgroundImageColor, spellData.FillImageColor);
		icon.SetFill(0);
	}
}