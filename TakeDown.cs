using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    internal class TakeDown
    {
        ShootingEntity killer;
        ShootingEntity victim;
        Tombstone tombstone = null;

        public TakeDown(ShootingEntity killer, ShootingEntity victim)
        {
            this.killer = killer;
            this.victim = victim;
        }

        public void DrawTombstone(Graphics g, Point pos)
        {
            if (tombstone == null)
            {
                tombstone = new Tombstone(victim.Graphic, pos);
            }
            tombstone.Refresh(g);
        }

        private class Tombstone : IDrawable
        {
            List<List<Square>> graphics;
            static readonly int size = 2;
            static readonly Color color = Color.DarkGray;
            private bool isVisible = true;
            Point pos;

            public Tombstone(List<List<Square>> sourceGraphics, Point pos)
            {
                graphics = new List<List<Square>>(sourceGraphics.Count());
                for (int x = 0; x < sourceGraphics.Count(); x++)
                {
                    for (int y = 0; y < sourceGraphics[x].Count(); y++)
                    {
                        if (sourceGraphics[x][y].Color == Color.Transparent)
                        {
                            graphics[x].Add(new Square(size, Color.Transparent, x, y));
                        }
                        else
                        {
                            graphics[x].Add(new Square(size, color, x, y));
                        }    
                    }
                }
                this.pos = pos;
            }
            public void Refresh(Graphics g)
            {
                for (int x = 0; x < graphics.Count(); x++)
                {
                    for (int y = 0; y < graphics[x].Count(); y++)
                    {
                        graphics[x][y].Draw(g, pos.X, pos.Y);
                    }
                }
            }

        }
    }

    
}
