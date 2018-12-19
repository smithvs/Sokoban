using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sokoban
{
    public class Painter
    {

        public int ElementSize { get; }
        public int OffsetX { get; }
        public int OffsetY { get; }

        public Painter(int wHeight, int wWidth, int mRowCount, int mColumnCount)
        {
            ElementSize = Math.Min(wHeight / (mRowCount + 2), wWidth / (mColumnCount + 2));
            OffsetY = (wWidth - mColumnCount * ElementSize) / 2;
            OffsetX = (wHeight - mRowCount * ElementSize) / 2;
        }

        

    }
}
