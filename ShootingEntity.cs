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
        private float[] currentPos = new float[2];
        private float[] moveByVect= new float[2];
        public abstract Point GunExit
        {
            get;
        }
        internal override void Die()
        {
            this.graphic.Clear();
            this.coliderEnabled = false;
        }
        internal virtual Bullet Fire()
        {
            return new Bullet(-3, Pos.X + GunExit.X, Pos.Y + GunExit.Y, 1, Color.White);
        }


        public void GraduallyMoveTo(int x, int y, int steps)
        {
            desiredPos = new Point(x, y);
            currentPos[0] = pos.X; 
            currentPos[1] = pos.Y;
            isGraduallyMoving = true;
            

            moveByVect[0] = (desiredPos.X - currentPos[0]) / steps;
            moveByVect[1] = (desiredPos.Y - currentPos[1]) / steps;
        }

        public override void Refresh(Graphics g)
        {
            if (isGraduallyMoving)
            {
                if (desiredPos.X == Convert.ToInt32(currentPos[0]) && desiredPos.Y == Convert.ToInt32(currentPos[1]))
                {
                    isGraduallyMoving = false;
                }
                else
                {
                    currentPos[0] = currentPos[0] + moveByVect[0];
                    currentPos[1] = currentPos[1] + moveByVect[1];

                    this.MoveTo(Convert.ToInt32(currentPos[0]), Convert.ToInt32(currentPos[1]), false);
                }

            }

            base.Refresh(g);
        }
    }
}
