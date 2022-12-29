using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    abstract class ShootingEntity : Entity
    {
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
        public virtual Bullet Fire(Color bulletColor)
        {
            return new Bullet(yBulletSpeed, Pos.X + GunExit.X, Pos.Y + GunExit.Y, bulletDamage,GameController.PixelSize, bulletColor);
            
        }
    }
}
