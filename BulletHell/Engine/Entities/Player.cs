using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace BulletHell.Engine
{
    public class PlayerEntity : BaseEntity
    {

        // Control Variables (Mouse, Keyboard, etc)
        private MouseState mouseState;
        private bool isReleased = true;

        private KeyboardState state;
        private Vector2 defaultScale;

        public delegate void CreateBulletEventHandler(float x, float y);
        public event CreateBulletEventHandler bulletCreated;

        public PlayerEntity(Texture2D entitySprite, Vector2 position, double movementSpeed, float scalar) : base(entitySprite, position, movementSpeed, scalar)
        {
        }
        
        protected virtual void OnBulletCreated()
        {
            // the width is divided by 2 so that the bullets appear in the middle of the sprite
            float nX = this.X;
            bulletCreated(nX, this.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
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
