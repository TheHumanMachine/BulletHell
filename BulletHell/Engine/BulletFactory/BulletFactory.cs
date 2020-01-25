using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Engine.BulletFactory
{
    public class BulletFactory
    {
        Texture2D bulletSprite;
        List<BulletEntity> bulletList;

        public BulletFactory(Texture2D bulletSprite, List<BulletEntity> bulletList)
        {
            this.bulletSprite = bulletSprite;
            this.bulletList = bulletList;
        } 

        public void OnBulletCreated(double x, double y)
        {
            bulletList.Add(new BulletEntity(bulletSprite, x, y, 1));
        }


    }
}
