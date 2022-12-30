using SquareGraphics;

namespace KosmiczniNajeźdźcy
{
    internal class EnemyCrab : AnimShEntity
    {
        static readonly string graphicStr = "0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n0\t0\t0\t1\t0\t0\t0\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t0\t1\t1\t1\t0\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t0\t1\t1\t1\t1\t1\t1\t1\t0\t1\r\n1\t0\t1\t0\t0\t0\t0\t0\t1\t0\t1\r\n0\t0\t0\t1\t1\t0\t1\t1\t0\t0\t0\r\n";
        static readonly string graphicStr2 = "0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n1\t0\t0\t1\t0\t0\t0\t1\t0\t0\t1\r\n1\t0\t1\t1\t1\t1\t1\t1\t1\t0\t1\r\n1\t1\t1\t0\t1\t1\t1\t0\t1\t1\t1\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n0\t0\t1\t1\t1\t1\t1\t1\t1\t0\t0\r\n0\t0\t1\t0\t0\t0\t0\t0\t1\t0\t0\r\n0\t1\t0\t0\t0\t0\t0\t0\t0\t1\t0\r\n";
        public static readonly Color color = Color.Aqua;
        Point gunExit = new Point(5*GameController.PixelSize, 8*GameController.PixelSize);

        public EnemyCrab(int x, int y) :
            base(new Point(x,y), SquareGraphic.GetFromString(graphicStr, color, GameController.PixelSize), SquareGraphic.GetFromString(graphicStr2, color, GameController.PixelSize), 20)
        {
        }

        public override Point GunExit => gunExit;

        protected override int yBulletSpeed => 5;
    }
    internal class EnemySquid : AnimShEntity
    {
        static readonly string graphicStr = "0\t0\t0\t1\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t0\t1\t1\t0\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\r\n0\t0\t1\t0\t0\t1\t0\t0\r\n0\t1\t0\t1\t1\t0\t1\t0\r\n1\t0\t1\t0\t0\t1\t0\t1\r\n";
        static readonly string graphicStr2 = "0\t0\t0\t1\t1\t0\t0\t0\r\n0\t0\t1\t1\t1\t1\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t0\t1\t1\t0\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\r\n0\t1\t0\t1\t1\t0\t1\t0\r\n1\t0\t0\t0\t0\t0\t0\t1\r\n0\t1\t0\t0\t0\t0\t1\t0\r\n";
        public static readonly Color color = Color.HotPink;
        Point gunExit = new Point(4 * GameController.PixelSize, 8 * GameController.PixelSize);

        public EnemySquid(int x, int y) :
            base(new Point(x, y), SquareGraphic.GetFromString(graphicStr, color, GameController.PixelSize), SquareGraphic.GetFromString(graphicStr2, color, GameController.PixelSize), 30)
        {
        }

        public override Point GunExit => gunExit;

        protected override int yBulletSpeed => 5;
    }
    internal class EnemyEclipse: AnimShEntity
    {
        static readonly string graphicStr = "0\t0\t0\t0\t1\t1\t1\t1\t0\t0\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t0\t0\t1\t1\t0\t0\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n0\t0\t0\t1\t1\t0\t0\t1\t1\t0\t0\t0\r\n0\t0\t1\t1\t0\t1\t1\t0\t1\t1\t0\t0\r\n1\t1\t0\t0\t0\t0\t0\t0\t0\t0\t1\t1\r\n";
        static readonly string graphicStr2 = "0\t0\t0\t0\t1\t1\t1\t1\t0\t0\t0\t0\r\n0\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t0\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n1\t1\t1\t0\t0\t1\t1\t0\t0\t1\t1\t1\r\n1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\t1\r\n0\t0\t1\t1\t1\t0\t0\t1\t1\t1\t0\t0\r\n0\t1\t1\t0\t0\t1\t1\t0\t0\t1\t1\t0\r\n0\t0\t1\t1\t0\t0\t0\t0\t1\t1\t0\t0\r\n";
        public static readonly Color color = Color.BlueViolet;
        Point gunExit = new Point(6 * GameController.PixelSize, 8 * GameController.PixelSize);

        public EnemyEclipse(int x, int y) :
            base(new Point(x, y), SquareGraphic.GetFromString(graphicStr, color, GameController.PixelSize), SquareGraphic.GetFromString(graphicStr2, color, GameController.PixelSize), 10)
        {
        }

        public override Point GunExit => gunExit;

        protected override int yBulletSpeed => 5;
    }


}
