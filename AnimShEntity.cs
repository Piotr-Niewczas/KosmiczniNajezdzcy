﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    abstract class AnimShEntity : ShootingEntity
    {
        bool secGrapActive = false;
        List<List<Square>> graphic2;
        public AnimShEntity(Point pos, List<List<Square>> graphic, List<List<Square>> graphic2, int pointVal) : base(pos, graphic, pointVal)
        {
            this.graphic2 = graphic2;
        }

        public override List<List<Square>> Pixels
        {
            get
            {
                if (secGrapActive) return graphic2;
                else return pixels;
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
