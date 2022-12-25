using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace KosmiczniNajeźdźcy
{
    internal class TestEntity : AnimShEntity
    {
        static string graphicStr = "0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n0\t0\t0\t1\t0\t0\t0\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t0\t1\t1\t1\t0\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t0\t1\t1\t1\t1\t1\t1\t1\t0\t1\r\n1\t0\t1\t0\t0\t0\t0\t0\t1\t0\t1\r\n0\t0\t0\t1\t1\t0\t1\t1\t0\t0\t0\r\n";
        static string graphicStr2 = "0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n1\t0\t0\t1\t0\t0\t0\t1\t0\t0\t1\r\n1\t0\t1\t1\t1\t1\t1\t1\t1\t0\t1\r\n1\t1\t1\t0\t1\t1\t1\t0\t1\t1\t1\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n0\t1\t0\t0\t0\t0\t0\t0\t0\t1\t0\r\n";

        Point gunExit = new Point(6 * GameController.PixelSize+1, 8 * GameController.PixelSize+1);

        public TestEntity(Point pos, Color color) : 
            base(pos, Entity.GetGraphicFromString(graphicStr, color, GameController.PixelSize),Entity.GetGraphicFromString(graphicStr2, color, GameController.PixelSize), 10)
        {
        }

        public override Point GunExit => gunExit;
        protected override int yBulletSpeed => -3;

    }
}
