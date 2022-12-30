using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquareGraphics;


namespace KosmiczniNajeźdźcy
{
    public abstract class Entity : IDrawable, IMovable
    {
        protected SquareGraphic graphic;
        public virtual SquareGraphic Graphic { get => graphic; set => graphic = value; }

        private Point pos;
        public Point Pos { get => pos;}
        private Point prevPos;
        protected bool colliderEnabled = true;
        protected bool allowUpDownMove = true;

        private bool isDead = false;
        public bool IsDead { get => isDead; }

        private bool isVisible = true;
        protected bool IsVisible
        {
            get => isVisible;
            set
            {
                if (value == false) doUndraw = true;
                isVisible = value;
            }
        }
        private bool doUndraw = false;
        protected bool DoUndraw
        {
            get => doUndraw;
            set
            {
                if (value == true) doUndraw = true;
            }
        }

        

        public Entity(Point pos, int pixelSize, bool allowUpDownMove, SquareGraphic graphic)
        {
            this.pos = pos;
            this.colliderEnabled = true;
            this.allowUpDownMove = allowUpDownMove;
            this.graphic = graphic;
            this.prevPos = pos;

        }

        virtual public void Refresh(Graphics g)
        {
            if (doUndraw)
            {
                doUndraw = false;
                Graphic.Draw(g, Pos, Color.Black);
            }
            if (IsVisible)
            {  
                if (prevPos != Pos)
                {
                    Graphic.Draw(g, prevPos, Color.Black);
                    prevPos = Pos;
                }
                Graphic.Draw(g, Pos);
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
                    if (!(x < 0 || x > 700 - Graphic.Size.Width))
                    {
                        pos.X = x;
                    }
                    if (!(!allowUpDownMove || y < 70 || y > 800 - Graphic.Size.Height))
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
            for (int i = 0; i < Graphic.squares.Count(); i++)
            {
                for (int j = 0; j < Graphic.squares[i].Count(); j++)
                {
                    if (Graphic.squares[i][j].Color != Color.Transparent && Graphic.squares[i][j].isInBounds(x,y,Pos.X,Pos.Y)) // if target pixel not transpartent (abscent) and is there
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        

    }
}
