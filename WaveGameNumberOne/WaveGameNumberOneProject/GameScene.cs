#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Sound;
#endregion

namespace WaveGameNumberOneProject
{
    public class GameScene : Scene
    {
        // Game sounds 
        private SoundInfo soundFire;
        private SoundInfo soundStart;
        private SoundInfo soundSuccess;

        // Collide entity
        public Entity CollideEntity { get; set; }

        // Game states 
        public enum GameState
        {
            Init,
            Game,
            CollideDynamic,
            Success
        }

        public GameState CurrentState { get; set; }

        protected override void CreateScene()
        {
            CurrentState = GameState.Init;

            RenderManager.BackgroundColor = Color.CornflowerBlue;

            // Add some default wall elements
            for (int i = 0; i < 10; i++)
            {
                var y = i < 3 
                    ? 0 
                    : i < 6
                    ? 1
                    : 2;

                EntityManager.Add(new Entity("Wall" + i)
                    .AddComponent(new Sprite("Content/Texture/BrownWall.wpk"))
                    .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                    .AddComponent(new RectangleCollider())
                    .AddComponent(new Transform2D()
                    {
                        X = WaveServices.Platform.ScreenWidth - (i % 3 * 32 + 32),
                        Y = WaveServices.Platform.ScreenHeight - (y * 32 + 32) 
                    }));
            }


            //Create Standard Ball
            var standardBall = new Entity("StandardBall")
                            .AddComponent(new Sprite("Content/Texture/BallStandard.wpk"))
                            .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
                            .AddComponent(new RectangleCollider())
                            .AddComponent(new Transform2D()
                            {
                                Origin = new Vector2(0.5f, 1),
                                X = WaveServices.Platform.ScreenWidth - 16,
                                Y = WaveServices.Platform.ScreenHeight - 96
                            })
                            .AddComponent(new BallBehavior(null, null));

            EntityManager.Add(standardBall);
        }
    }
}
