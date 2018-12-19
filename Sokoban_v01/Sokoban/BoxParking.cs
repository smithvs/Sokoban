using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    class BoxParking:IMapElement
    {

        public static Texture2D Texture { get; private set; }

        public Position Position;
        public bool HaveBox;
        public bool free = true;
        public Box box;

        public BoxParking(int x, int y)
        {
            Position = new Position(x, y);
        }

        public BoxParking()
        {
        }

        public static void SetTexture(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Painter p)
        {
            spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, p.ElementSize, p.ElementSize), Color.IndianRed);
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
            free = false;
            this.box = box;
        }

        public Position GetPosition()
        {
            return Position;
        }
    }
}
