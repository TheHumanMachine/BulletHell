
using BulletHell.Engine.MovementPatterns;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine.Entities.Enemies.EnemyFactories
{
    class GruntTwoFactory
    {
        private Texture2D defaultTexture;
        private float defaultTextureScalar;
        private double defaultMovementSpeed;
        private AbstractMovementPattern[] defaultMovementPatterns;


        public GruntTwoFactory(Texture2D defaultTexture, float defaultTextureScalar, double defaultMovementSpeed, AbstractMovementPattern[] movementPatterns)
        {
            // set up the defaults incase we don't want to worry about them when creating our enemies later.
            this.defaultTexture = defaultTexture;
            this.defaultTextureScalar = defaultTextureScalar;
            this.defaultMovementSpeed = defaultMovementSpeed;
            this.defaultMovementPatterns = movementPatterns;
        }

        public GruntTwo Create(float x, float y)
        {
            return new GruntTwo(defaultTexture, x, y, defaultMovementSpeed, defaultMovementPatterns, defaultTextureScalar);
        }

        public GruntTwo Create(float x, float y, AbstractMovementPattern[] movementPatterns)
        {
            return new GruntTwo(defaultTexture, x, y, defaultMovementSpeed, movementPatterns, defaultTextureScalar); ;
        }


    }
}
