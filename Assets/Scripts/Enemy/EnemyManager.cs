using UnityEngine;

public class EnemyManager : BaseManager<EnemyPoolObject>
{
	public override void Initialize()
	{
		base.Initialize();
		
		EnemyPoolObject.EnemySpawn += AddUnit;
		EnemyPoolObject.EnemyRemoved += RemoveUnit;
	}

	private void FixedUpdate()
	{
		if (!isGameStarted)
			return;
		
		foreach (var unit in units)
		{
			unit.Move(Time.fixedDeltaTime);
		}
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		
		EnemyPoolObject.EnemySpawn -= AddUnit;
		EnemyPoolObject.EnemyRemoved -= RemoveUnit;
	}
}