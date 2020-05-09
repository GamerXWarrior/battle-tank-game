using System.Collections;
using System.Collections.Generic;
using TankGame.Bullet;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class BulletPoolService : PoolingService<BulletController>
{
    private BulletModel model;
    private BulletView bulletPrefab;
    private Transform spawner;
    private float damage;

    public BulletController GetBullet(BulletModel bulletModel, BulletView bulletView, Transform spawner, float damageValue)
    {
        this.model = bulletModel;
        this.bulletPrefab = bulletView;
        this.spawner = spawner;
        this.damage = damageValue;
        return GetItem();
    }

    protected override BulletController CreateItem()
    {
        Debug.Log("Create Bullet");
        BulletController bulletController = new BulletController(model, bulletPrefab, spawner, damage);
        return bulletController;
    }
}
