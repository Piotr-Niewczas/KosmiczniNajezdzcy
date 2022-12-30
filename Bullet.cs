using SquareGraphics;

namespace KosmiczniNajeźdźcy
{
    internal class Bullet : Entity
    {
        static string graphicStr = "1\r\n1\r\n1\r\n";
        int ySpeed;
        int damage;

        public Bullet(int ySpeed, int x, int y, int damage, int size, Color color) : base(new Point(x,y), size, true, SquareGraphic.GetFromString(graphicStr, color, size))
        {
            this.ySpeed = ySpeed;
            this.damage= damage;
        }

        public override void Refresh(Graphics g)
        {
            MoveBy(0, ySpeed, false);
            base.Refresh(g);
        }
    }
}
