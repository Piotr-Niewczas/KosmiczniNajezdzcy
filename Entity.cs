using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    public abstract class Entity : IDrawable, IMovable
    {
        protected Point pos;
        protected int pixelSize;
        public Point Pos { get => pos; }
        private Point prevPos;
        protected int SizeX { get => Graphic[0].Count() * (pixelSize+1); }
        protected int SizeY { get => Graphic.Count() * (pixelSize+1); }
        protected bool coliderEnabled = true;
        protected bool isVisible = true;
        protected bool doUndraw = false;
        protected bool allowUpDownMove = true;
        
        protected List<List<Square>> graphic = new List<List<Square>>();
        public virtual List<List<Square>> Graphic => graphic;

        public Entity(Point pos, int pixelSize, bool allowUpDownMove, List<List<Square>> graphic)
        {
            this.pos = pos;
            this.pixelSize = pixelSize;
            this.coliderEnabled = true;
            this.allowUpDownMove = allowUpDownMove;
            this.graphic = graphic;
            this.prevPos = pos;
        }

        ~Entity()
        {
            Die();
        }

        private void Draw(Graphics g, Point pos)
        {
            for (int x = 0; x < Graphic.Count(); x++)
            {
                for (int y = 0; y < Graphic[x].Count(); y++)
                {
                    Graphic[x][y].Draw(g, pos.X, pos.Y);
                }
            }
        }
        private void Undraw(Graphics g, Point pos)
        {
            for (int x = 0; x < Graphic.Count(); x++)
            {
                for (int y = 0; y < Graphic[x].Count(); y++)
                {
                    Graphic[x][y].UnDraw(g, pos.X, pos.Y);
                }

            }
        }

        virtual public void Refresh(Graphics g)
        {
            if (isVisible)
            {
                if (prevPos.X != Pos.X || prevPos.Y != Pos.Y)
                {
                    Undraw(g, prevPos);
                }
                Draw(g, Pos);
            }
            else
            {
                if (doUndraw)
                {
                    doUndraw = false;
                    Undraw(g, pos);
                }
            }       
        }

        public void MoveTo(int x, int y)
        {
            MoveTo(x, y, true);
        }

        protected void MoveTo(int x, int y, bool checkBounds)
        {
            if (checkBounds)
            {
                if (!(x < 0 || x > 700 - SizeX))
                {
                    prevPos.X = x;
                    pos.X = x;
                }
                if (!(!allowUpDownMove || y < 70 || y > 800 - SizeY))
                {
                    prevPos.Y = y;
                    pos.Y = y;
                }
            }
            else
            {
                if (allowUpDownMove)
                {
                    prevPos.Y = y;
                    pos.Y = y;
                }
                prevPos.X = x;
                pos.X = x;
            }
        }

        public void MoveBy(int dx, int dy, bool checkBounds = true)
        {
            MoveTo(this.Pos.X + dx, this.Pos.Y + dy, checkBounds);
        }

        virtual public void ReciveDamage()
        {
            this.Die();
        }
        protected virtual void Die() 
        { 
            isVisible = false;
            doUndraw = true;
            coliderEnabled = false;
        }

        public bool isAt(int x, int y)
        {
            if (!coliderEnabled)
            {
                return false;
            }
            for (int i = 0; i < Graphic.Count(); i++)
            {
                for (int j = 0; j < Graphic[i].Count(); j++)
                {
                    if (Graphic[i][j].isInBounds(x,y,Pos.X,Pos.Y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected static List<List<Square>> GetGraphicFromString(string str, Color color, int pixelSize)
        {
            List<List<Square>> tmp = new List<List<Square>>();
            List<string> rows = str.Split("\r\n").ToList();
            int x = 0;
            foreach (var row in rows)
            {
                int y = 0;
                List<string> cols = row.Split("\t").ToList();
                List<Square> squareCols = new List<Square>();
                foreach (var col in cols)
                {
                    Color tmpColor;
                    if (col == "1")
                    {
                        tmpColor = color;
                    }
                    else
                    {
                        tmpColor = Color.Transparent;
                    }
                    Square tmpSquare = new Square(pixelSize+1, tmpColor, y + y * pixelSize, x + x * pixelSize);
                    squareCols.Add(tmpSquare);
                    y++;
                }
                tmp.Add(squareCols);
                x++;
            }

            

            return tmp;
        }

    }
}
