using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    public abstract class Entity
    {
        protected int health;
        protected Point pos;
        protected int pixelSize;
        public Point Pos { get => pos; }

        protected int SizeX { get => graphic[0].Count() * (pixelSize+1); }
        protected int SizeY { get => graphic.Count() * (pixelSize+1); }
        protected bool coliderEnabled = true;
        protected bool allowUpDownMove = true;
        
        protected List<List<Square>> graphic = new List<List<Square>>();
        private Point prevPos;

        virtual public void Refresh(Graphics g)
        {
            if (prevPos.X != Pos.X || prevPos.Y != Pos.Y)
            {
                for (int x = 0; x < graphic.Count(); x++)
                {
                    for (int y = 0; y < graphic[x].Count(); y++)
                    {
                        graphic[x][y].UnDraw(g, prevPos.X, prevPos.Y);
                    }

                }
            }
            for (int x = 0; x < graphic.Count(); x++)
            {
                for (int y = 0; y < graphic[x].Count(); y++)
                {
                    graphic[x][y].Draw(g, Pos.X, Pos.Y);
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

        virtual public void ReciveDamage(int damage)
        {
            health -= damage;
            if (health <= 0)
            {
                this.Die();
            }
        }
        public abstract void Die();

        public bool isAt(int x, int y)
        {
            if (!coliderEnabled)
            {
                return false;
            }
            for (int i = 0; i < graphic.Count(); i++)
            {
                for (int j = 0; j < graphic[i].Count(); j++)
                {
                    if (graphic[i][j].isInBounds(x,y,Pos.X,Pos.Y))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected List<List<Square>> GetGraphicFromString(string str, Color color)
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
