using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    internal class Bullet : Entity
    {
        int ySpeed;
        int size;
        int damage;
        public Bullet(int ySpeed, int x, int y, int damage, Color color)
        {
            this.posX = x;
            this.posY = y;
            this.ySpeed = ySpeed;
            size = 5;
            graphic.Add(new List<Square> { new Square(size, color, 0, 0) });
            graphic.Add(new List<Square> { new Square(size, color, 0, 0+size) });
            this.damage = damage;
        }

        internal override void Die()
        {
            this.graphic.Clear();
            this.coliderEnabled = false;
        }
        public override void Refresh(Graphics g)
        {
            MoveBy(0, ySpeed, false);

            //if (PosY < -10 || PosY > 1000)
            //{

            //}
            base.Refresh(g);
        }
    }
}
