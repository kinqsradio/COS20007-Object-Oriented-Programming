using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace DrawingShape
{
    public class MyLine : Shape
    {
        private int _length;

        public MyLine(Color clr, int length) :base(clr)
        {
            _length = length;
        }

        public MyLine() : this(Color.RandomRGB(255), 100) { }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(COLOR, X, Y, X + _length,Y);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, X-2, Y-2, _length+5,5);

        }

        public override bool IsAt(Point2D p)
        {
            return SplashKit.PointOnLine(p, SplashKit.LineFrom(X, Y, X + _length,Y));
        }


    }
}

