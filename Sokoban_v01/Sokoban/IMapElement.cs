using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public interface IMapElement
    {
        void Draw(SpriteBatch spriteBatch, Vector2 position, Painter painter);
        bool CanCome();
        Box GetBox();
        void SetBox(Box box);
        Position GetPosition();
    }
}
