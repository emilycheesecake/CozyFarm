using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using CozyFarm.DesktopClient.Tilemap;
using CozyFarm.DesktopClient.Utilities;

namespace CozyFarm.DesktopClient
{
    internal class Player : Entity
    {
        public override string Type => "PLAYER";

        public int Speed = 100;
        public override Vector2 Position { get; set; } = new Vector2(0, 0);

        private GameStateManager _gsm;
        private Vector2 Velocity = new Vector2(0, 0);
        private TileSelector tileSelector;

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
            tileSelector = new TileSelector(_gsm);
            currentAnimation = walkDown;
        }

        public void LoadContent(ContentManager c)
        {
            playerSheet = c.Load<Texture2D>("characters/_greyscale/char_grey");
            tileSelector.LoadContent(c);
        }

        public override void Update(GameTime gameTime, InputManager inputManager)
        {
            Velocity = Vector2.Zero;

            if (inputManager.IsActionPressed("move_left"))
            {
                Velocity.X = -Speed;
                currentAnimation = walkLeft;
            }
            if (inputManager.IsActionPressed("move_right"))
            {
                Velocity.X = Speed;
                currentAnimation = walkRight;
            }
            if (inputManager.IsActionPressed("move_up"))
            {
                Velocity.Y = -Speed;
                currentAnimation = walkUp;
            }
            if (inputManager.IsActionPressed("move_down"))
            {
                Velocity.Y = Speed;
                currentAnimation = walkDown;
            }

            Position += Velocity  * (float)gameTime.ElapsedGameTime.TotalSeconds;

            //Only update animation when player is moving
            if(inputManager.IsMovementInput())
                currentAnimation.Update(gameTime);

            tileSelector.Update(gameTime, inputManager);

            //Makes camera smoothly follow player
            //Rounding to nearest int to prevent weird seams showing up in between tiles (i'll figure it out later maybe?)
            Vector2 FixedPosition = new Vector2(Position.X - 400, Position.Y - 240);
            _gsm.GetCamera().Move(Vector2.Round((FixedPosition - _gsm.GetCamera().Position) * (float)gameTime.ElapsedGameTime.TotalSeconds));

            //Keep camera within bounds of map
            if (_gsm.GetCamera().Position.X < 0) _gsm.GetCamera().Position = new Vector2(0, _gsm.GetCamera().Position.Y);
            if (_gsm.GetCamera().Position.X + Global.SCREEN_WIDTH > _gsm.GetCurrentMap().mapW * _gsm.GetCurrentMap().tileW) _gsm.GetCamera().Position = new Vector2(_gsm.GetCurrentMap().mapW * _gsm.GetCurrentMap().tileW, _gsm.GetCamera().Position.Y);
            
            if (_gsm.GetCamera().Position.Y < 0) _gsm.GetCamera().Position = new Vector2(_gsm.GetCamera().Position.X, 0);
            if (_gsm.GetCamera().Position.Y + Global.SCREEN_HEIGHT > _gsm.GetCurrentMap().mapH * _gsm.GetCurrentMap().tileH) _gsm.GetCamera().Position = new Vector2(_gsm.GetCamera().Position.X, _gsm.GetCurrentMap().mapH * _gsm.GetCurrentMap().tileH - Global.SCREEN_HEIGHT);
            
        }

        public override void Draw(SpriteBatch sb)
        {
            tileSelector.Draw(sb);
            sb.Draw(playerSheet, Position, currentAnimation.frameRects[currentAnimation.currentFrame], Color.White);
        }
    }
}
