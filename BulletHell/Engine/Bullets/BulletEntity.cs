using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletHell.Engine.MovementPatterns;
using BulletHell.Engine.MovementPatterns.Bullet;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine
{
    public class BulletEntity : BaseEntity
    {
        private bool alive = true;
        AbstractMovementPattern movementPattern;

        public BulletEntity(Texture2D entitySprite, Vector2 position, double movementSpeed, AbstractMovementPattern movementPattern, float scalar = 0.1f) : base(entitySprite, position, movementSpeed, scalar)
        {
            this.movementPattern = movementPattern;
        }

        public bool IsAlive
        {
            get { return alive; }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            movementPattern.Move(this.X, this.Y, gameTime, ref movementSpeed);
        }
    }
}
