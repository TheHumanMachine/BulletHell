﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Engine.BulletFactory
{
    public class BulletFactory
    {
        private Texture2D bulletSprite;
        private List<BulletEntity> bulletList;
        private Queue<BulletEntity> bulletCache;
        private BulletEntity cahedBullet;
        private List<BulletEntity> recycleBin;

        private int cacheLimit = 100;

        public BulletFactory(Texture2D bulletSprite, List<BulletEntity> bulletList)
        {
            this.bulletSprite = bulletSprite;
            this.bulletList = bulletList;
            this.bulletCache = new Queue<BulletEntity>();
            this.recycleBin = new List<BulletEntity>();
            for (int i =0; i < cacheLimit; i++)
            {
                bulletCache.Enqueue(new BulletEntity(bulletSprite, 0, 0, 1));
            }
        } 
        
        public void RecycleBullets()
        {
            // Add the bullet back to the cache
            foreach (var bullet in bulletList)
            {
                if ( !bullet.IsAlive )
                {
                    // The bullet is no longer visible to the player and should be recycled 
                    recycleBin.Add(bullet);
                }
            }
            bulletList = bulletList.Except(recycleBin).ToList();

            recycleBin.ForEach(o => bulletCache.Enqueue(o));
           
            recycleBin.Clear();
        }

        public void OnBulletCreated(double x, double y)
        {
            if(bulletCache.Count > 0)
            {
                cahedBullet = bulletCache.Dequeue();
                cahedBullet.X = x;
                cahedBullet.Y = y;
                bulletList.Add(cahedBullet);
            }
            else
            {
                bulletList.Add(new BulletEntity(bulletSprite, x, y, 1));
            }
        }


    }
}
