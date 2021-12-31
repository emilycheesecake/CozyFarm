using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CozyFarm.DesktopClient
{
    internal static class CozyConsole
    {
        public static bool Enabled = true;
        public static int MaxLines = 10;
        public static SpriteFont font;
        public static Queue<string> output = new Queue<string>();
        public static Vector2 Position = new Vector2(0, 0);

        public static void LoadContent(ContentManager c)
        {
            font = c.Load<SpriteFont>("testfont");
        }
        
        public static void Update(GameTime gameTime)
        {
            if(Enabled)
            {
                if (output.Count >= MaxLines)
                {
                    output.Dequeue();
                }
            }
        }

        public static void Draw(SpriteBatch sb)
        {
            if(Enabled)
            {
                int index = 0;
                foreach (string s in output)
                {
                    sb.DrawString(font, s, new Vector2(0, index * 16), Color.White);
                    index++;
                }
            }
        }

        public static void WriteLine(string s)
        {
            output.Enqueue(s);
        }
    }
}
