using SquareGraphics;

namespace KosmiczniNajeźdźcy
{
    internal class TestEntity : AnimShEntity
    {
        static readonly string graphicStr = "0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n0\t0\t0\t1\t0\t0\t0\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t0\t1\t1\t1\t0\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t0\t1\t1\t1\t1\t1\t1\t1\t0\t1\r\n1\t0\t1\t0\t0\t0\t0\t0\t1\t0\t1\r\n0\t0\t0\t1\t1\t0\t1\t1\t0\t0\t0\r\n";
        static readonly string graphicStr2 = "0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n1\t0\t0\t1\t0\t0\t0\t1\t0\t0\t1\r\n1\t0\t1\t1\t1\t1\t1\t1\t1\t0\t1\r\n1\t1\t1\t0\t1\t1\t1\t0\t1\t1\t1\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n0\t1\t0\t0\t0\t0\t0\t0\t0\t1\t0\r\n";

        Point gunExit = new Point(6 * GameController.PixelSize+1, 8 * GameController.PixelSize+1);

        public TestEntity(Point pos, Color color) : 
            base(pos, SquareGraphic.GetFromString(graphicStr, color, GameController.PixelSize), SquareGraphic.GetFromString(graphicStr2, color, GameController.PixelSize), 10)
        {
        }

        public override Point GunExit => gunExit;
        protected override int yBulletSpeed => -3;

    }
}
