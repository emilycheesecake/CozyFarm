﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient
{
    internal abstract class Entity
    {
        public abstract string Type { get; }
        public Vector2 Position { get; set; }
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch sb);
    }
}
