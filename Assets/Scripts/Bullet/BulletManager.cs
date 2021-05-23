using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : BaseManager<BulletPoolObject>
{
    public override void Initialize()
    {
        base.Initialize();
		
        BulletPoolObject.BulletSpawn += AddUnit;
        BulletPoolObject.BulletRemoved += RemoveUnit;
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
        BulletPoolObject.BulletSpawn -= AddUnit;
        BulletPoolObject.BulletRemoved -= RemoveUnit;
    }
}
