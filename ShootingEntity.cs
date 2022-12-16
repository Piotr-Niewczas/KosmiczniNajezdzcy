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
        private int[] desiredPos = new int[2];
        private float[] currentPos = new float[2];
        private float[] moveByVect= new float[2];
        public abstract int[] GunExit
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
            return new Bullet(-3, PosX + GunExit[0], PosY + GunExit[1], 1, Color.White);
        }


        public void GraduallyMoveTo(int x, int y, int steps)
        {
            desiredPos[0] = x;
            desiredPos[1] = y;
            currentPos[0] = this.posX; 
            currentPos[1] = this.posY;
            isGraduallyMoving = true;

            moveByVect[0] = (desiredPos[0] - currentPos[0]) / steps;
            moveByVect[1] = (desiredPos[1] - currentPos[1]) / steps;
        }

        public override void Refresh(Graphics g)
        {
            if (isGraduallyMoving)
            {
                if (desiredPos[0] == Convert.ToInt32(currentPos[0]) && desiredPos[1] == Convert.ToInt32(currentPos[1]))
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
