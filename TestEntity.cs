using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    internal class TestEntity : ShootingEntity
    {
        string graphicStr = "0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n0\t0\t0\t1\t0\t0\t0\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t0\t1\t1\t1\t0\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t0\t1\t1\t1\t1\t1\t1\t1\t0\t1\r\n1\t0\t1\t0\t0\t0\t0\t0\t1\t0\t1\r\n0\t0\t0\t1\t1\t0\t1\t1\t0\t0\t0\r\n";

        Point gunExit = new Point(0,0);

        public TestEntity(int x, int y, Color color)
        {
            pos = new Point(x, y);
            health = 1;
            pixelSize = 5;
            pointVal = 10;
            graphic = GetGraphicFromString(graphicStr, color);

        }

        public override Point GunExit => gunExit;


    }
}
