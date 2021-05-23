using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour, IInitializable
{
    private List<BulletPoolObject> bullets;

    public void Initialize()
    {
        bullets = new List<BulletPoolObject>();
        BulletPoolObject.BulletSpawn += AddNewBullet;
        BulletPoolObject.BulletRemoved += RemoveBullet;
    }

    private void FixedUpdate()
    {
        foreach (var bullet in bullets)
        {
            bullet.Move(Time.fixedDeltaTime);
        }
    }

    private void AddNewBullet(BulletPoolObject bullet)
    {
        bullets.Add(bullet);
    }
    
    private void RemoveBullet(BulletPoolObject bullet)
    {
        bullets.Remove(bullet);
    }
}
