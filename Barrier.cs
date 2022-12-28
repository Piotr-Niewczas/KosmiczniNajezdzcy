using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    internal class Barrier : Entity
    {
        static string graphicStr = "0\t0\t0\t0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\t0\t0\t0\r\n0\t0\t0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t0\t0\t0\t0\t0\t0\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t0\t0\t0\t0\t0\t0\t0\t0\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t0\t0\t0\t0\t0\t0\t0\t0\t0\t0\t1\t1\t1\t1\t1\r\n";
         

        public static readonly Color color = Color.Lime;
        public Barrier(Point pos, int pixelSize) : base(pos, pixelSize, false, Entity.GetGraphicFromString(graphicStr,color,pixelSize))
        {
            
        }

        public override int ReciveDamage(int bulletX, int bulletY)
        {
            ExplodeABit(bulletX, bulletY);
            return 1;
        }

        /// <summary>
        /// Makes parts of graphics transparent to show damage to barrier
        /// </summary>
        /// <param name="x">X where bullet hit</param>
        /// <param name="y">Y where bullet hit</param>
        /// <param name="inverted">Normal is bullet from the top</param>
        void ExplodeABit(int x, int y)
        {
            const int holeY = 8, holeX = 2;

            DoUndraw = true;
            bool inverted = false;
            if (y > Pos.Y)
            {
                inverted = true;
            }

            int squareX = 0, squareY = 0;
            for (int i = 0; i < Graphic.Count(); i++)
            {
                for (int j = 0; j < Graphic[i].Count(); j++)
                {
                    if (Graphic[i][j].Color != Color.Transparent && Graphic[i][j].isInBounds(x, y, Pos.X, Pos.Y)) 
                    {
                        squareX = j;
                        squareY = i;
                    }
                }
            }

            Random random= new Random();
            int multiplayer = 1;
            if (inverted) // if inverted change sign of operations
            {
                multiplayer = -1;
            }
            for (int yDelta = 0; yDelta <= holeY; yDelta++) // iterate through standard explosion hole
            {
                for (int xDelta = holeX * -1; xDelta <= holeX; xDelta++)
                {
                    DamageGraphic(squareX + (xDelta * multiplayer), squareY + (yDelta * multiplayer) + 1);
                }
            }
            for (int yDelta = 0; yDelta <= holeY; yDelta++) // iterate through walls
            {
                if (random.Next(0, 100) > 30)//left wall-1
                {
                    DamageGraphic(squareX - holeX - 1, squareY + (yDelta * multiplayer) + 1);
                }
                if (random.Next(0, 100) > 60)//left wall-2
                {
                    DamageGraphic(squareX - holeX - 2, squareY + (yDelta * multiplayer) + 1);
                }
                if (random.Next(0, 100) > 85)//left wall-3
                {
                    DamageGraphic(squareX - holeX - 3, squareY + (yDelta * multiplayer) + 1);
                }
                if (random.Next(0, 100) > 30)//right wall+1
                {
                    DamageGraphic(squareX + holeX + 1, squareY + (yDelta * multiplayer) + 1);
                }
                if (random.Next(0, 100) > 60)//right wall+2
                {
                    DamageGraphic(squareX + holeX + 2, squareY + (yDelta * multiplayer) + 1);
                }
                if (random.Next(0, 100) > 85)//right wall+3
                {
                    DamageGraphic(squareX + holeX + 3, squareY + (yDelta * multiplayer) + 1);
                }
            }
            int multiplayer2 = 1;
            if (!inverted)
            {
                multiplayer2 = 0;
            }
            for (int xDelta = holeX * -1; xDelta <= holeX; xDelta++)// damage the top
            {
                if (random.Next(0, 100) > 30)
                {
                    DamageGraphic(squareX+xDelta, squareY - holeY*multiplayer2 + 1 + 1*multiplayer);
                }
                if (random.Next(0, 100) > 60)
                {
                    DamageGraphic(squareX + xDelta, squareY - holeY * multiplayer2 + 1 + 2 * multiplayer);
                }
                if (random.Next(0, 100) > 85)
                {
                    DamageGraphic(squareX + xDelta, squareY - holeY * multiplayer2 + 1 + 2 * multiplayer);
                }
            }
        }
        void DamageGraphic(int x, int y)
        {
            if (x >= 0 && x < graphic[0].Count && y >= 0 && y < graphic.Count)
            {
                graphic[y][x].Color = Color.Transparent;
            }
        }
    }
}
