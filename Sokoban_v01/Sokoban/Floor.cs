using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    class Floor:IMapElement
    {
        public static Texture2D Texture { get; private set; }

        public Position Position;
        public bool free = true;
        public Box box;

        public Floor(int x, int y)
        {
            Position = new Position(x, y);
        }

        public static void SetTexture(Texture2D texture)
        {
            Texture = texture;
        }

        public bool CanCome()
        {
            return free;
        }

        public Box GetBox()
        {
            return box;
        }

        public void SetBox(Box box)
        {

            free = (box == null);
            this.box = box;
        }

        public Position GetPosition()
        {
            return Position;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Painter p)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, p.ElementSize, p.ElementSize), Color.White);
        }

    }
}
