using System;
using ObjectPool;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCircleSpawner : MonoBehaviour
{
	[SerializeField] private DifficultySettings difficultySettings;
	[SerializeField] private float circleRadius = 25f;
	[SerializeField] private Transform centerOfCircle;

	private float elapsedTime = 0;

	private void Update()
	{
		elapsedTime += Time.deltaTime;
		if (elapsedTime >= .4f)
		{
			elapsedTime -= .4f;
			Spawn();
		}
	}

	private void Spawn()
	{
		var spawnPos = RandomSpawnPos();
		ObjectPooler.Instance.GetFromPool(Consts.EnemyTag, spawnPos, Quaternion.identity, null);
	}

	private Vector3 RandomSpawnPos()
	{
		var radians = Random.value * 360 * Mathf.Deg2Rad;

		var vertical = Mathf.Sin(radians);
		var horizontal = Mathf.Cos(radians);
		
		var spawnDir = new Vector3(horizontal, 0, vertical);
		var spawnPos = centerOfCircle.position + spawnDir * circleRadius;
		return spawnPos;
	}
}