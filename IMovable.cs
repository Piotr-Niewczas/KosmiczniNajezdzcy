using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    internal interface IMovable
    {
        void MoveTo(int x, int y);
        void MoveBy(int dx, int dy, bool checkBounds = true);
    }
}
