using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;

namespace WaveGameNumberOneProject
{
    class BallBehavior : Behavior
    {
        private Dictionary<Entity, RectangleCollider> staticElements;
        private Dictionary<Entity, RectangleCollider> dynamicElements;

        private Entity target;
        private RectangleCollider targetCollider;

        [RequiredComponent]
        public Transform2D currentPosition;

        public BallBehavior(Dictionary<Entity, RectangleCollider> staticElements, Dictionary<Entity, RectangleCollider> dynamicElements)
            : base("BallBehavior")
        {
            this.currentPosition = null;
            this.staticElements = staticElements;
            this.dynamicElements = dynamicElements;
        }

        protected override void Update(TimeSpan gameTime)
        {
            // Check target
            if (currentPosition.X == targetCollider.Center.X
                && currentPosition.Y == targetCollider.Center.Y)
            {
                //TODO: Let owner scene know that the map is successfully finished
            }

            // Check dynamicElements
            Entity collideEntity = dynamicElements.FirstOrDefault(entity => entity.Value.Intersects(currentPosition.Rectangle, true)).Key;

            if (collideEntity != null)
            {
                (Owner.Scene as GameScene).CurrentState = GameScene.GameState.CollideDynamic;
                (Owner.Scene as GameScene).CollideEntity = collideEntity;
            }

            // Move ball
            var state = WaveServices.Input.GyroscopeState;

            // Move ball by gyroscope

        }
    }
}
