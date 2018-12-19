using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    class Wall : IMapElement
    {        
        public static Texture2D Texture { get; private set; }
        public Position Position;

        public Wall(int x, int y)
        {
            Position = new Position(x, y);
        }

        public static void SetTexture(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Painter p)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, p.ElementSize, p.ElementSize), Color.White);
        }

        public bool CanCome()
        {
            return false;
        }

        public Box GetBox()
        {
            return null;
        }

        public void SetBox(Box box)
        {
        }

        public Position GetPosition()
        {
            return Position;
        }
    }
}
