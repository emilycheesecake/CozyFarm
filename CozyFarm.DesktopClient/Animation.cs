using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CozyFarm.DesktopClient
{
    internal class Animation
    {
        public Rectangle[] frameRects;
        public int currentFrame = 0, frameCount = 0;
        public float delay = 0, count = 0;

        /// <summary>
        /// Creates array of source rectangles corresponding to my 32x32 spritesheets
        /// </summary>
        /// <param name="x">X position of spritesheet row</param>
        /// <param name="y">Y position of spritesheet row</param>
        /// <param name="width">Width of spritesheet row</param>
        /// <param name="height">Height of spritesheet row</param>
        /// <param name="frames">Number of frames in spritesheet row</param>
        /// <param name="delay">Delay for frames in seconds</param>
        public Animation(int x, int y, int width, int height, int frames, float delay)
        {
            frameRects = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                frameRects[i] = new Rectangle(x + (32 * i), y, 32, 32);
            }
            this.delay = delay;
            frameCount = frames;
        }

        /// <summary>
        /// Update animation frame count
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            count += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (count >= delay)
            {
                if (currentFrame + 1 == frameCount)
                    currentFrame = 0;
                else
                    currentFrame++;

                count = 0;
            }
        }
    }
}
