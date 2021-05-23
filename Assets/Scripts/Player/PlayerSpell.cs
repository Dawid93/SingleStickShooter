using UnityEngine;

public class PlayerSpell : MonoBehaviour
{
	[SerializeField] private GameplaySpells gameplaySpells;
	[SerializeField] private Transform spawnPoint;

	public void UseFirstSpell()
	{
		gameplaySpells.FirstBaseSpellController.UseSpell(spawnPoint.position, transform.rotation);
	}

	public void UseSecondSpell()
	{
		gameplaySpells.SecondBaseSpellController.UseSpell(spawnPoint.position, transform.rotation);
	}
}