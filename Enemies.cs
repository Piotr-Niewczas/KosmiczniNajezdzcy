using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    internal class EnemyCrab : AnimShEntity
    {
        static string graphicStr = "0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n0\t0\t0\t1\t0\t0\t0\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t0\t1\t1\t1\t0\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t0\t1\t1\t1\t1\t1\t1\t1\t0\t1\r\n1\t0\t1\t0\t0\t0\t0\t0\t1\t0\t1\r\n0\t0\t0\t1\t1\t0\t1\t1\t0\t0\t0\r\n";
        static string graphicStr2 = "0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n1\t0\t0\t1\t0\t0\t0\t1\t0\t0\t1\r\n1\t0\t1\t1\t1\t1\t1\t1\t1\t0\t1\r\n1\t1\t1\t0\t1\t1\t1\t0\t1\t1\t1\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n0\t1\t0\t0\t0\t0\t0\t0\t0\t1\t0\r\n";
        static Color color = Color.Aqua;
        Point gunExit = new Point(5*GameController.PixelSize, 8*GameController.PixelSize);

        public EnemyCrab(Point pos) :
            base(pos, Entity.GetGraphicFromString(graphicStr, color, GameController.PixelSize), Entity.GetGraphicFromString(graphicStr2, color, GameController.PixelSize), 20)
        {
        }

        public override Point GunExit => gunExit;

        protected override int yBulletSpeed => 3;
    }
    internal class EnemySquid : AnimShEntity
    {
        static string graphicStr = "0\t0\t0\t1\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t0\t1\t1\t0\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\r\n0\t0\t1\t0\t0\t1\t0\t0\r\n0\t1\t0\t1\t1\t0\t1\t0\r\n1\t0\t1\t0\t0\t1\t0\t1\r\n";
        static string graphicStr2 = "0\t0\t0\t1\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t0\t1\t1\t0\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\r\n0\t1\t0\t1\t1\t0\t1\t0\r\n1\t0\t0\t0\t0\t0\t0\t1\r\n0\t1\t0\t0\t0\t0\t1\t0\r\n";
        static Color color = Color.HotPink;
        Point gunExit = new Point(4 * GameController.PixelSize, 8 * GameController.PixelSize);

        public EnemySquid(Point pos) :
            base(pos, Entity.GetGraphicFromString(graphicStr, color, GameController.PixelSize), Entity.GetGraphicFromString(graphicStr2, color, GameController.PixelSize), 30)
        {
        }

        public override Point GunExit => gunExit;

        protected override int yBulletSpeed => 3;
    }
    internal class EnemyEclipse: AnimShEntity
    {
        static string graphicStr = "0\t0\t0\t0\t1\t1\t1\t1\t0\t0\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t0\t0\t1\t1\t0\t0\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n0\t0\t0\t1\t1\t0\t0\t1\t1\t0\t0\t0\r\n0\t0\t1\t1\t0\t1\t1\t0\t1\t1\t0\t0\r\n1\t1\t0\t0\t0\t0\t0\t0\t0\t0\t1\t1\r\n";
        static string graphicStr2 = "0\t0\t0\t0\t1\t1\t1\t1\t0\t0\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t0\t0\t1\t1\t0\t0\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n0\t0\t1\t1\t1\t0\t0\t1\t1\t1\t0\t0\r\n0\t1\t1\t0\t0\t1\t1\t0\t0\t1\t1\t0\r\n0\t0\t1\t1\t0\t0\t0\t0\t1\t1\t0\t0\r\n";
        static Color color = Color.BlueViolet;
        Point gunExit = new Point(6 * GameController.PixelSize, 8 * GameController.PixelSize);

        public EnemyEclipse(Point pos) :
            base(pos, Entity.GetGraphicFromString(graphicStr, color, GameController.PixelSize), Entity.GetGraphicFromString(graphicStr2, color, GameController.PixelSize), 10)
        {
        }

        public override Point GunExit => gunExit;

        protected override int yBulletSpeed => 3;
    }


}
