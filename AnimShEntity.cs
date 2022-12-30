using SquareGraphics;

namespace KosmiczniNajeźdźcy
{
    abstract class AnimShEntity : ShootingEntity
    {
        bool secGrapActive = false;
        SquareGraphic graphic2;
        public AnimShEntity(Point pos, SquareGraphic graphic, SquareGraphic graphic2, int pointVal) : base(pos, graphic, pointVal)
        {
            this.graphic2 = graphic2;
        }

        public override SquareGraphic Graphic
        {
            get
            {
                if (secGrapActive) return graphic2;
                else return base.Graphic;
            }
        }
        public override void MoveBy(int dx, int dy, bool checkBounds = true)
        {
            base.MoveBy(dx, dy, checkBounds);
            secGrapActive = !secGrapActive;
        }
        public override void MoveTo(int x, int y)
        {
            base.MoveTo(x, y);
            secGrapActive = !secGrapActive;
        }
    }
}
