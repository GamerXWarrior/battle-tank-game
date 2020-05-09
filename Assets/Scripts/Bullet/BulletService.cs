using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TankGame.Event;


namespace TankGame.Bullet
{
    public class BulletService : MonoSingletonGeneric<BulletService>
    {
        public BulletScriptableObjectList bulletList;
        public List<BulletController> bullets = new List<BulletController>();
        public BulletView bulletView;
        private Vector3 spawnPos;
        private Quaternion spawnRot;
        private float bulletDamage;
        private int bulletCounter = 0;

        private BulletPoolService bulletPoolService;
        protected override void Awake()
        {
            bulletPoolService = GetComponent<BulletPoolService>();
            base.Awake();
        }

        public BulletController spawnBullet(Transform bulletSpawner, float bulletDamage)
        {
            //    this.spawnPos = bulletSpawner.position;
            //    this.spawnRot = bulletSpawner.rotation;

            BulletModel bulletModel = new BulletModel(bulletList.bulletScriptableObject[0]);
            //BulletController bullet = new BulletController(bulletModel, bulletView, bulletSpawner, bulletDamage);
            BulletController controller = bulletPoolService.GetBullet(bulletModel, bulletView, bulletSpawner, bulletDamage);
            controller.Enable(bulletSpawner, bulletDamage);
            bullets.Add(controller);
            SetBulletCounter();
            return controller;
        }

        public void DestroyView(BulletController controller)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (controller == bullets[i])
                {
                    //controller.Destroy();

                    controller.Disable();
                    bulletPoolService.ReturnItem(controller);
                    bullets[i] = null;
                }
            }
        }

        public void SetBulletCounter()
        {
            bulletCounter = PlayerPrefs.GetInt("FiredBullets", 0);
            bulletCounter++;
            EventService.Instance.OnBulletFired(bulletCounter);
            if (bulletCounter % 100 == 0)
            {
                EventService.Instance.OnBulletAchievment(bulletCounter);
            }
        }
    }
}