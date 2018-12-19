using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    class Player
    {
        public static Texture2D Texture { get; private set; }
        public int moves=0;
        public int pushes=0;

        public Position Position;


        public Player(int x, int y)
        {
            Position = new Position(x, y);
        }

        public static void SetTexture(Texture2D texture)
        {
            Texture = texture;
        }

        public void Initialize()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Painter p, SpriteFont font)
        {
            string text = string.Format("Moves:{0}         Pushes:{1}", moves, pushes);
            spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y,p.ElementSize, p.ElementSize), new Rectangle(32, 32, 32, 32), Color.White);
            spriteBatch.DrawString(font, text, new Vector2(p.OffsetX, 10), Color.Red);
        }

    }
}
