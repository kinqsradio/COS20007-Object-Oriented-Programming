using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace DrawingShape
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle(Color clr, int radius) : base(clr)
        {
            _radius = radius;
        }

        public MyCircle() : this(Color.RandomRGB(255), 50) { }

        public override void Draw()
        {
            if (Selected)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(COLOR, X, Y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            //c^2 = a^2 + b^2
            //c = square root(a^2 + b^2)
            double a = (double)(pt.X - X);
            double b = (double)(pt.Y - Y);
            if (Math.Sqrt(a * a + b * b) < _radius)
            {
                return true;
            }return false;
        }


    }
}

