using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    internal class Square
    {
        int drawingSize;
        Color color;
        int x, y;
        public Square(int drawingSize, Color color, int x, int y)
        {
            this.drawingSize = drawingSize;
            this.color = color;
            this.X = x;
            this.Y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public void Draw(Graphics g, int offsetX, int offsetY)
        {
            ActualDraw(g, color, offsetX, offsetY);
        }
        public void UnDraw(Graphics g, int offsetX, int offsetY)
        {
            ActualDraw(g, Color.Transparent, offsetX, offsetY);
        }
        private void ActualDraw(Graphics g, Color color, int offsetX, int offsetY)
        {
            if (drawingSize != 0)
            {
                SolidBrush myBrush = new SolidBrush(color);
                g.FillRectangle(myBrush, new Rectangle(X+offsetX, Y+offsetY, drawingSize, drawingSize));
                myBrush.Dispose();
            }
        }
        public bool isInBounds(int x, int y, int offsetX, int offsetY)
        {
            for (int i = 0; i < drawingSize; i++)
            {
                for (int j = 0; j < drawingSize; j++)
                {
                    if (x == this.x + offsetX + i && y == this.y + offsetY + j)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
