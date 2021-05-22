using System;
using System.Collections;
using System.Collections.Generic;
using ObjectPool;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Transform bulletPoint;

    public void Shoot()
    {
        ObjectPooler.Instance.GetFromPool(Consts.BulletTag, bulletPoint.transform.position, transform.rotation, null);
    }
}
