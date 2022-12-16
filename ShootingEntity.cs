using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    abstract class ShootingEntity : Entity
    {
        private bool isGraduallyMoving = false;
        private Point desiredPos;
        private float[] currentfPos = new float[2];
        private float[] moveByVect= new float[2];
        protected int pointVal;

        public int PointVal => pointVal;

        public abstract Point GunExit
        {
            get;
        }
        public override void Die()
        {
            this.graphic.Clear();
            this.coliderEnabled = false;
        }
        public virtual Bullet Fire()
        {
            return new Bullet(-3, Pos.X + GunExit.X, Pos.Y + GunExit.Y, 1, Color.White);
        }


        public void GraduallyMoveTo(int x, int y, int steps)
        {
            desiredPos = new Point(x, y);
            currentfPos[0] = pos.X; 
            currentfPos[1] = pos.Y;
            isGraduallyMoving = true;
            

            moveByVect[0] = (desiredPos.X - currentfPos[0]) / steps;
            moveByVect[1] = (desiredPos.Y - currentfPos[1]) / steps;
        }

        public override void Refresh(Graphics g)
        {
            if (isGraduallyMoving)
            {
                if (desiredPos.X == Convert.ToInt32(currentfPos[0]) && desiredPos.Y == Convert.ToInt32(currentfPos[1]))
                {
                    isGraduallyMoving = false;
                }
                else
                {
                    currentfPos[0] = currentfPos[0] + moveByVect[0];
                    currentfPos[1] = currentfPos[1] + moveByVect[1];

                    this.MoveTo(Convert.ToInt32(currentfPos[0]), Convert.ToInt32(currentfPos[1]), false);
                }

            }

            base.Refresh(g);
        }
    }
}
