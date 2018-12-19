using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    class Map
    {
        public IMapElement[,] map;

        public int Width { get { return map.GetLength(1); } }
        public int Height { get { return map.GetLength(0); } }

        public Position PlayerPosition { get; set; }
        public List<Box> Boxes { get; set; }

        public Player GetPlayer(int x, int y)
        {
            PlayerPosition = new Position(x, y);
            return new Player(x, y);
        }

        public void Create(List<string> mapTemplate)
        {
            map = MapCreator.Create(mapTemplate);
        }

        public void Draw(SpriteBatch spriteBatch, Painter p)
        {
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    if (!(map[i, j] is null))
                        map[i, j].Draw(spriteBatch, new Vector2(j * p.ElementSize + p.OffsetY, i * p.ElementSize + p.OffsetX), p);
            foreach (var box in Boxes)
                box.Draw(spriteBatch, new Vector2(box.Position.Y * p.ElementSize + p.OffsetY, box.Position.X * p.ElementSize + p.OffsetX), p);
        }

        public IMapElement this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Height || j < 0 || j >= Width)
                    throw new IndexOutOfRangeException();
                return map[i,j];
            }
            set
            {
                if (i < 0 || i >= Height || j < 0 || j >= Width)
                    throw new IndexOutOfRangeException();
                map[i, j] = value;
            }
        }

        public bool CorectPosition(Position position)
        {
            return ( position.X >= 0 && position.X < Height && position.Y >= 0 && position.Y < Width);
        }
    }
}
