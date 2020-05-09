using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Tank;
using TankGame.Enemy;

namespace TankGame.Bullet
{
    public class BulletController
    {
        public BulletController(BulletModel bulletModel, BulletView bulletView, Transform spawner, float damageValue)
        {
            BulletModel = bulletModel;
            Spawner = spawner;
            DamageValue = damageValue;
            BulletView = GameObject.Instantiate(bulletView, spawner.transform.position, spawner.transform.rotation);
            //Rigidbody rb = BulletView.GetComponent<Rigidbody>();
            //rb.velocity = spawner.transform.forward * BulletModel.Speed;
            BulletView.InitializeController(this);

            BulletView.SetBulletDetails(DamageValue);
            //BulletService.Instance.SetBulletCounter();
        }

        public void DestroyBulletView()
        {
            if (BulletView != null)
            {
                BulletService.Instance.DestroyView(this);
            }
        }

        public void Destroy()
        {
            if (BulletView != null)
            {
                BulletModel = null;
                BulletView.Destroy();
            }
        }
        public void Disable()
        {
            BulletView.Disable();
        }
        public void Enable(Transform spawner, float damage)
        {
            BulletView.Enable(spawner, damage);
        }

        //public void ApplyEnemyDamage(float damage, EnemyView enemyTank)
        //{
        //    HealthService.Instance.DeductEnemyHealth( enemyTank, damage);
        //}

        //public void ApplyPlayerDamage(float damage, TankView playerTank)
        //{
        //    HealthService.Instance.DeductPlayerHealth( playerTank, damage);
        //}

        public BulletModel BulletModel { get; set; }
        public Transform Spawner { get; }
        public float DamageValue { get; }
        public BulletView BulletView { get; }
    }
}