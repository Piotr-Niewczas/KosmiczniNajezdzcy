using SquareGraphics;

namespace KosmiczniNajeźdźcy
{
    internal class PlayerCannon : ShootingEntity
    {
        static string graphicStr = "0\t0\t0\t0\t0\t1\t0\t0\t0\t0\t0\r\n0\t0\t0\t0\t1\t1\t1\t0\t0\t0\t0\r\n0\t0\t0\t0\t1\t1\t1\t0\t0\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n";
        static new int pixelSize = 3;
        public readonly static Color color = Color.Lime;
        Point gunExit = new Point(Convert.ToInt32(6.5* pixelSize),0);

        public PlayerCannon(Point pos) : base(pos, SquareGraphic.GetFromString(graphicStr, color, pixelSize), 0)
        {
            allowUpDownMove = false;
        }

        public override Point GunExit => gunExit;

        protected override int yBulletSpeed => -3;
    }
}
