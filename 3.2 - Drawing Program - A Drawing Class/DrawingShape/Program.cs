using System;
using SplashKitSDK;

namespace DrawingShape
{
    public class Program
    {
        public static void Main()
        {

            Drawing drawShape = new Drawing();

            new Window("Drawing Shape", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();


                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    int x_pos = (int)SplashKit.MouseX();
                    int y_pos = (int)SplashKit.MouseY();
                    drawShape.AddShape(new Shape(x_pos, y_pos));
                    Console.WriteLine("Mouse Left");
                }

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

