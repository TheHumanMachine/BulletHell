
using BulletHell.Engine.MovementPatterns;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine.Entities.Enemies.EnemyFactories
{
    class BasicEnemyFactory
    {
        private Texture2D defaultTexture;
        private float defaultTextureScalar;
        private double defaultMovementSpeed;
        private AbstractMovementPattern[] defaultMovementPatterns;


        public BasicEnemyFactory(Texture2D defaultTexture, float defaultTextureScalar, double defaultMovementSpeed, AbstractMovementPattern[] movementPatterns)
        {
            // set up the defaults incase we don't want to worry about them when creating our enemies later.
            this.defaultTexture = defaultTexture;
            this.defaultTextureScalar = defaultTextureScalar;
            this.defaultMovementSpeed = defaultMovementSpeed;
            this.defaultMovementPatterns = movementPatterns;
        }

        public EnemyEntity Create(float x, float y)
        {
            return new EnemyEntity(defaultTexture, x, y, defaultMovementSpeed, defaultMovementPatterns, defaultTextureScalar);
        }

        public EnemyEntity Create(float x, float y, AbstractMovementPattern[] movementPatterns)
        {
            return new EnemyEntity(defaultTexture, x, y, defaultMovementSpeed, movementPatterns, defaultTextureScalar); ;
        }


    }
}
