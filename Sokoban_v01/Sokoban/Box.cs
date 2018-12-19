using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class Box
    {
        public static Texture2D Texture { get; private set; }

        public Position Position;
        public bool InParking;

        public Box(int x, int y, IMapElement entity)
        {
            if (entity is Wall)
                throw new ArgumentException("Box can't stay in Wall");
            if (entity is BoxParking)
            {
                InParking = true;
            }
            entity.SetBox(this);

            Position = new Position(x, y);
        }

        public static void SetTexture(Texture2D texture)
        {
            Texture = texture;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Painter p)
        {           
            spriteBatch.Draw(Texture, new Rectangle((int)position.X, (int)position.Y, p.ElementSize, p.ElementSize), InParking?Color.LightGreen:Color.White);
        }
    }
}
