using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    internal class Bullet : Entity
    {
        static string graphicStr = "1\r\n1\r\n";
        int ySpeed;
        int damage;

        public Bullet(int ySpeed, int x, int y, int damage, int size, Color color) : base(new Point(x,y), size, true, Entity.GetGraphicFromString(graphicStr, color, size))
        {
            this.ySpeed = ySpeed;
            this.damage= damage;
        }

        public override void Die()
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
