using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient
{
    internal class Player : Entity
    {
        public override string Type { get; } = "PLAYER";
        public Vector2 Velocity = new Vector2(0, 0);
        public int Speed = 5;

        Texture2D playerSheet;

        public Player()
        {
            
        }
        public void LoadContent(ContentManager c)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            if (inputManager.IsActionPressed("move_left"))
                Velocity.X = -Speed;
            if (inputManager.IsActionPressed("move_right"))
                Velocity.X = Speed;
            if (inputManager.IsActionPressed("move_up"))
                Velocity.Y = Speed;
            if (inputManager.IsActionPressed("move_down"))
                Velocity.Y = -Speed;

            Velocity *= (float)gameTime.ElapsedGameTime.TotalSeconds;
            Velocity.Normalize();
            Position += Velocity;
        }

        public override void Draw(SpriteBatch sb)
        {
            
        }
    }
}
