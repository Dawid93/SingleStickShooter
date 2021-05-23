using System;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour, IInitializable
{
	[SerializeField] private TextMeshProUGUI label;

	private int counter;
	
	public void Initialize()
	{
		counter = 0;
		label.SetText(counter.ToString());
		EnemyPoolObject.EnemyRemoved += HandleEnemyKill;
	}

	private void HandleEnemyKill(EnemyPoolObject enemy)
	{
		if (enemy.WasKilled)
		{
			counter++;
			label.SetText(counter.ToString());
		}
	}

	private void OnDestroy()
	{
		EnemyPoolObject.EnemyRemoved -= HandleEnemyKill;
	}
}