using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace DrawingShape
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }
        public static void Main()
        {

            Drawing drawShape = new Drawing();
            ShapeKind kindToAdd = ShapeKind.Rectangle;

            new Window("Drawing Shape", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if(SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }
                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                //Start
                //Use this to draw shape
                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    if(kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle ShapeDrawn = new MyRectangle();
                        ShapeDrawn.X = SplashKit.MouseX();
                        ShapeDrawn.Y = SplashKit.MouseY();
                        drawShape.AddShape(ShapeDrawn);

                    }
                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle ShapeDrawn = new MyCircle();
                        ShapeDrawn.X = SplashKit.MouseX();
                        ShapeDrawn.Y = SplashKit.MouseY();
                        drawShape.AddShape(ShapeDrawn);
                    }
                    if (kindToAdd == ShapeKind.Line)
                    {
                        MyLine ShapeDrawn = new MyLine();
                        ShapeDrawn.X = SplashKit.MouseX();
                        ShapeDrawn.Y = SplashKit.MouseY();
                        drawShape.AddShape(ShapeDrawn);
                    }

                    Console.WriteLine("Mouse Left");

                }

                //End

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    drawShape.SelectedShapeAt(SplashKit.MousePosition());
                    Console.WriteLine("Mouse Right");
                }

                //Start
                //Additional Function
                if (SplashKit.KeyDown(KeyCode.EscapeKey))
                {
                    drawShape.ChangingShapeColor();
                    Console.WriteLine("ESC");
                }

                //End

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey) || SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
                    {
                        Console.WriteLine("Backspace");
                    }
                    if (SplashKit.KeyTyped(KeyCode.DeleteKey))
                    {
                        Console.WriteLine("Delete");
                    }
                    drawShape.RemoveShape();
                }


                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    drawShape.Background = SplashKit.RandomRGBColor(255);
                    Console.WriteLine("SpaceKey");
                }

                drawShape.Draw();

                SplashKit.RefreshScreen();

            }
            while (!SplashKit.WindowCloseRequested("Drawing Shape"));
        }
    }

}

