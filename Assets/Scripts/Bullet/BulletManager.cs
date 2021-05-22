using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private List<BulletPoolObject> bullets;

    private void Awake()
    {
        bullets = new List<BulletPoolObject>();
        BulletPoolObject.BulletSpawn += AddNewBullet;
        BulletPoolObject.BulletRemoved += RemoveBullet;
    }

    private void Update()
    {
        foreach (var bullet in bullets)
        {
            bullet.Move(Time.deltaTime);
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
