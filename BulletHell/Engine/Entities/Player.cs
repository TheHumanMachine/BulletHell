using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BulletHell.Engine
{
    public class PlayerEntity : BaseEntity
    {

        // Control Variables (Mouse, Keyboard, etc)
        private MouseState mouseState;
        private bool isReleased = true;
        private bool isSlowed = false;
        private double defaultSpeed;
        private double slowMotionSpeed;

        private KeyboardState state;

        public delegate void CreateBulletEventHandler(float x, float y);
        public event CreateBulletEventHandler bulletCreated;

        public PlayerEntity(Texture2D entitySprite, float x, float y, double movementSpeed, float scalar) : base(entitySprite, x, y, movementSpeed, scalar)
        {
            this.defaultSpeed = movementSpeed;
            this.slowMotionSpeed = Math.Ceiling(movementSpeed / 2);
        }
        
        protected virtual void OnBulletCreated()
        {
            // the width is divided by 2 so that the bullets appear in the middle of the sprite
            bulletCreated(this.X + ((this.sprite.SpriteTexture.Width * 0.15f) / 2), this.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.LeftControl)) // enter slow mo mode
            {
                movementSpeed = slowMotionSpeed;
            }
            else
            {
                movementSpeed = defaultSpeed;  // Sike, keep it normal speed
            }
        
            // Move our sprite based on arrow keys being pressed:
            if (state.IsKeyDown(Keys.D))
                this.X += (int)Math.Ceiling(movementSpeed);
            if (state.IsKeyDown(Keys.A))
                this.X -= (int)Math.Ceiling(movementSpeed);
            if (state.IsKeyDown(Keys.W))
                this.Y -= (int)Math.Ceiling(movementSpeed);
            if (state.IsKeyDown(Keys.S))
                this.Y += (int)Math.Ceiling(movementSpeed);
            if (state.IsKeyDown(Keys.Space))
            {
                OnBulletCreated();
            }
        }
    }
}
