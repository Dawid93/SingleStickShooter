using System;
using TMPro;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI label;

	private int counter;
	
	private void Awake()
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
}