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
        int bulletDamage;

        protected ShootingEntity(Point pos, int pixelSize, bool allowUpDownMove, List<List<Square>> graphic, int pointVal, int bulletDamage) : base(pos, pixelSize, allowUpDownMove, graphic)
        {
            this.pointVal = pointVal;
            this.bulletDamage = bulletDamage;
        }
        protected ShootingEntity(Point pos, List<List<Square>> graphic, int pointVal): this(pos,GameController.PixelSize,true,graphic, pointVal, 1) 
        { 
        }    

        public int PointVal => pointVal;

        public abstract Point GunExit
        {
            get;
        }
        protected abstract int yBulletSpeed { get; }
        protected override void Die()
        {
            base.Die();
            // add explosion ???
        }
        public virtual Bullet Fire(Color bulletColor)
        {
            return new Bullet(yBulletSpeed, Pos.X + GunExit.X, Pos.Y + GunExit.Y, bulletDamage,GameController.PixelSize, bulletColor);
            
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
