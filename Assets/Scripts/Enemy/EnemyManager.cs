using UnityEngine;

public class EnemyManager : BaseMoveManager<EnemyPoolObject>
{
	public override void Initialize()
	{
		base.Initialize();
		
		EnemyPoolObject.EnemySpawn += AddUnit;
		EnemyPoolObject.EnemyRemoved += RemoveUnit;
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		
		EnemyPoolObject.EnemySpawn -= AddUnit;
		EnemyPoolObject.EnemyRemoved -= RemoveUnit;
	}
}