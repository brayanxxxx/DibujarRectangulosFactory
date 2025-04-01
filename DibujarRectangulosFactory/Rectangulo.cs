// Clase Rectangulo

using DibujarRectangulosFactory;

public class Rectangulo : Figura
{
    public const int Width = 50;
    public const int Height = 30;

    public Rectangulo(int x, int y, Color color)
    {
        X = x;
        Y = y;
        Color = color;
    }

    public override Rectangle GetRectangle()
    {
        return new Rectangle(X, Y, Width, Height);
    }
}