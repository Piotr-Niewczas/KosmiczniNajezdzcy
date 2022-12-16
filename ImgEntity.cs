using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosmiczniNajeźdźcy
{
    internal class ImgEntity
    {
        int x, y;
        public int X { get => x; }
        public int Y { get => y; }
        
        Bitmap img;
        public int Width { get => img.Width; }
        public int Height { get => img.Height;}

        public ImgEntity(int x, int y, Bitmap img)
        {
            this.x = x;
            this.y = y;
            this.img = img;
        }

        public virtual void Draw(PaintEventArgs e)
        {
            e.Graphics.DrawImage(img, x, y);
        }
    }
}
