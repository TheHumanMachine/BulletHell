using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Engine
{
    public class PlayerEntity : BaseEntity
    {

        // Control Variables (Mouse, Keyboard, etc)
        private MouseState mouseState;
        private bool isReleased = true;

        private KeyboardState state;
        private int height = 100;
        private int width = 100; // We are assuming the sprite will always be a square 

        public delegate void CreateBulletEventHandler(double x, double y);
        public event CreateBulletEventHandler bulletCreated;

        public PlayerEntity(Texture2D entitySprite, double x, double y, double movementSpeed) : base(entitySprite, x, y, movementSpeed)
        {

        }
        
        protected virtual void OnBulletCreated()
        {
            // the width is divided by 2 so that the bullets appear in the middle of the sprite
            bulletCreated(this.X + width / 2, this.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(entitySprite, new Rectangle((int)this.X, (int)this.Y, width, height), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && isReleased)
            {
                isReleased = false;
            }

            if (mouseState.LeftButton == ButtonState.Released)
            {
                isReleased = true;
            }

            state = Keyboard.GetState();

            // Move our sprite based on arrow keys being pressed:
            if (state.IsKeyDown(Keys.D))
                this.X += 10;
            if (state.IsKeyDown(Keys.A))
                this.X -= 10;
            if (state.IsKeyDown(Keys.W))
                this.Y -= 10;
            if (state.IsKeyDown(Keys.S))
                this.Y += 10;
            if (state.IsKeyDown(Keys.Space))
            {
                OnBulletCreated();
            }
        }
    }
}
