using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19Map
{
    public class DefaultMarkRender : IMarkRender
    {
        public void RenderMark(Mark mark, Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.DarkRed),
                mark.LocalPosition.X, mark.LocalPosition.Y,
                mark.Size.Width, mark.Size.Height);
        }
    }
}
