using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    internal class PlayerCannon : ShootingEntity
    {
        static string graphicStr = "0\t0\t0\t0\t0\t1\t0\t0\t0\t0\t0\r\n0\t0\t0\t0\t1\t1\t1\t0\t0\t0\t0\r\n0\t0\t0\t0\t1\t1\t1\t0\t0\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n";

        static Color color = Color.Lime;
        Point gunExit = new Point(Convert.ToInt32(6.5*GameController.PixelSize),0);

        public PlayerCannon(Point pos) : base(pos, Entity.GetGraphicFromString(graphicStr, color, GameController.PixelSize), 0)
        {
            allowUpDownMove= false;
        }

        public override Point GunExit => gunExit;

        protected override int yBulletSpeed => -3;
    }
}
