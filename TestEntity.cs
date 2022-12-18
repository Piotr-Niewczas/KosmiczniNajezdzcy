using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace KosmiczniNajeźdźcy
{
    internal class TestEntity : ShootingEntity
    {
        static string graphicStr = "0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n0\t0\t0\t1\t0\t0\t0\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t0\t1\t1\t1\t0\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t0\t1\t1\t1\t1\t1\t1\t1\t0\t1\r\n1\t0\t1\t0\t0\t0\t0\t0\t1\t0\t1\r\n0\t0\t0\t1\t1\t0\t1\t1\t0\t0\t0\r\n";
        static int bulletDamage = 1;
        
        Point gunExit = new Point(0,0);

        public TestEntity(Point pos, Color color) : 
            base(1, pos, 5, true, Entity.GetGraphicFromString(graphicStr, color, 5), 10,bulletDamage)
        {
        }

        public override Point GunExit => gunExit;


    }
}
