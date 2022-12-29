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
        public int SizeX { get => Pixels[0].Count() * (pixelSize+1) +1; } // +1 accounts for the last pixel
        public int SizeY { get => Pixels.Count() * (pixelSize+1) +1; }
        protected bool colliderEnabled = true;
        protected bool allowUpDownMove = true;
        
        protected List<List<Square>> pixels = new List<List<Square>>();
        public virtual List<List<Square>> Pixels => pixels;

        private bool isDead = false;
        public bool IsDead { get => isDead; }

        private bool isVisible = true;
        protected bool IsVisible { 
            get => isVisible; 
            set 
            {
                if(value == false) doUndraw = true;
                isVisible = value; 
            } 
        }
        private bool doUndraw = false;
        protected bool DoUndraw
        {
            get => doUndraw;
            set
            {
                if(value == true) doUndraw = true;
            }
        }

        

        public Entity(Point pos, int pixelSize, bool allowUpDownMove, List<List<Square>> pixels)
        {
            this.pos = pos;
            this.pixelSize = pixelSize;
            this.colliderEnabled = true;
            this.allowUpDownMove = allowUpDownMove;
            this.pixels = pixels;
            this.prevPos = pos;

        }


        private void Draw(Graphics g, Point pos)
        {
            for (int x = 0; x < Pixels.Count(); x++)
            {
                for (int y = 0; y < Pixels[x].Count(); y++)
                {
                    Pixels[x][y].Draw(g, pos.X, pos.Y);
                }
            }
        }
        private void Undraw(Graphics g, Point pos)
        {
            for (int x = 0; x < Pixels.Count(); x++)
            {
                for (int y = 0; y < Pixels[x].Count(); y++)
                {
                    Pixels[x][y].UnDraw(g, pos.X, pos.Y);
                }

            }
        }

        virtual public void Refresh(Graphics g)
        {
            if (IsVisible)
            {
                if (doUndraw)
                {
                    doUndraw = false;
                    Undraw(g, Pos);
                }
                if (prevPos != Pos)
                {
                    Undraw(g, prevPos);
                    prevPos = Pos;
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

        public virtual void MoveTo(int x, int y)
        {
            MoveTo(x, y, true);
        }

        protected void MoveTo(int x, int y, bool checkBounds)
        {
            if (!IsDead)
            {
                if (checkBounds)
                {
                    prevPos = Pos;
                    if (!(x < 0 || x > 700 - SizeX))
                    {
                        pos.X = x;
                    }
                    if (!(!allowUpDownMove || y < 70 || y > 800 - SizeY))
                    {
                        pos.Y = y;
                    }
                }
                else
                {
                    if (allowUpDownMove)
                    {
                        pos.Y = y;
                    }
                    pos.X = x;
                }
            }  
        }

        public virtual void MoveBy(int dx, int dy, bool checkBounds = true)
        {
            MoveTo(this.Pos.X + dx, this.Pos.Y + dy, checkBounds);
        }


        /// <summary>
        /// Deals damage to entity
        /// </summary>
        /// <param name="bulletX"></param>
        /// <param name="bulletY"></param>
        /// <returns>0 when fatal damage, 1 if not</returns>
        virtual public int ReciveDamage(int bulletX, int bulletY)
        {
            this.Die();
            return 0;
        }
        public int ReciveDamage()
        {
            return ReciveDamage(0, 0);
        }
        protected void Die() 
        { 
            IsVisible = false;
            colliderEnabled = false;
            isDead = true;
        }

        /// <summary>
        /// Is part of entity at this location
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>True if is</returns>
        public bool IsAt(int x, int y)
        {
            if (!colliderEnabled)
            {
                return false;
            }
            for (int i = 0; i < Pixels.Count(); i++)
            {
                for (int j = 0; j < Pixels[i].Count(); j++)
                {
                    if (Pixels[i][j].Color != Color.Transparent && Pixels[i][j].isInBounds(x,y,Pos.X,Pos.Y)) // if target pixel not transpartent (abscent) and is there
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Generates 2D Square graphic from provided string
        /// </summary>
        /// <param name="str">String from Excel</param>
        /// <param name="color">Color of all squares</param>
        /// <param name="pixelSize">Size of each square</param>
        /// <returns>2D List of squares</returns>
        protected static List<List<Square>> GetGraphicFromString(string str, Color color, int pixelSize)
        {
            List<List<Square>> tmp = new List<List<Square>>();
            List<string> rows = str.Split("\r\n").ToList();
            int x = 0;
            foreach (var row in rows)
            {     
                if (row != "")
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
                        Square tmpSquare = new Square(pixelSize + 1, tmpColor, y + y * pixelSize, x + x * pixelSize);
                        squareCols.Add(tmpSquare);
                        y++;
                    }
                    tmp.Add(squareCols);
                    x++;
                }            
            }
            return tmp;
        }

    }
}
