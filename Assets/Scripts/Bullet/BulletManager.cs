using UnityEngine;

public class BulletManager : BaseMoveManager<BulletPoolObject>
{
    public override void Initialize()
    {
        base.Initialize();
		
        BulletPoolObject.BulletSpawn += AddUnit;
        BulletPoolObject.BulletRemoved += RemoveUnit;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        BulletPoolObject.BulletSpawn -= AddUnit;
        BulletPoolObject.BulletRemoved -= RemoveUnit;
    }
}
