using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace CozyFarm.DesktopClient
{
    internal class Player
    {
        public int Speed = 2;
        public Vector2 Position = new Vector2(0, 0);

        private GameStateManager _gsm;

        #region Player Animations
        Texture2D playerSheet;

        public Animation walkDown = new Animation(0, 0, 256, 32, 8, 0.2f);
        public Animation walkUp = new Animation(0, 32, 256, 32, 8, 0.2f);
        public Animation walkRight = new Animation(0, 64, 256, 32, 8, 0.2f);
        public Animation walkLeft = new Animation(0, 96, 256, 32, 8, 0.2f);

        public Animation currentAnimation;
        #endregion

        public Player(GameStateManager gsm)
        {
            _gsm = gsm;
            currentAnimation = walkDown;

            
        }
        public void LoadContent(ContentManager c)
        {
            playerSheet = c.Load<Texture2D>("characters/_greyscale/char_grey");
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            if (inputManager.IsActionPressed("move_left"))
            {
                Position.X -= Speed;
                currentAnimation = walkLeft;
            }
            if (inputManager.IsActionPressed("move_right"))
            {
                Position.X += Speed;
                currentAnimation = walkRight;
            }
            if (inputManager.IsActionPressed("move_up"))
            {
                Position.Y -= Speed;
                currentAnimation = walkUp;
            }
            if (inputManager.IsActionPressed("move_down"))
            {
                Position.Y += Speed;
                currentAnimation = walkDown;
            }

            currentAnimation.Update(gameTime);

            //Makes camera smoothly follow player
            //Rounding to nearest int to prevent weird seams showing up in between tiles (i'll figure it out later maybe?)
            Vector2 FixedPosition = new Vector2(Position.X - 400, Position.Y - 240);
            _gsm.GetCamera().Move(Vector2.Round((FixedPosition - _gsm.GetCamera().Position) * (float)gameTime.ElapsedGameTime.TotalSeconds));
            
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Begin(transformMatrix: _gsm.GetCamera().GetViewMatrix());
            sb.Draw(playerSheet, Position, currentAnimation.frameRects[currentAnimation.currentFrame], Color.White);
            sb.End();
        }
    }
}
