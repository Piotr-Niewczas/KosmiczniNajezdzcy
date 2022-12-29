﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    public class Square
    {
        int drawingSize;
        Color color;
        
        Point pos;
        public Square(int drawingSize, Color color, int x, int y)
        {
            this.drawingSize = drawingSize;
            this.Color = color;
            pos = new Point(x, y);
        }

        public Point Pos { get => pos; }
        public Color Color { get => color; set => color = value; }
        public int DrawingSize { get => drawingSize;}

        public void Draw(Graphics g, int offsetX, int offsetY)
        {
            ActualDraw(g, Color, offsetX, offsetY);
        }
        public void UnDraw(Graphics g, int offsetX, int offsetY)
        {
            ActualDraw(g, Color.Black, offsetX, offsetY);
        }
        private void ActualDraw(Graphics g, Color color, int offsetX, int offsetY)
        {
            if (drawingSize != 0)
            {
                SolidBrush myBrush = new SolidBrush(color);
                g.FillRectangle(myBrush, new Rectangle(Pos.X+offsetX, Pos.Y+offsetY, drawingSize, drawingSize));
                myBrush.Dispose();
            }
        }

        public bool isInBounds(int x, int y, int offsetX, int offsetY)
        {
            for (int i = 0; i < drawingSize; i++)
            {
                for (int j = 0; j < drawingSize; j++)
                {
                    if (x == Pos.X + offsetX + i && y == Pos.Y + offsetY + j)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
