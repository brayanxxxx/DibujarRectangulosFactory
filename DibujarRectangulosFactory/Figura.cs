public abstract class Figura
{
    public int X { get; set; }
    public int Y { get; set; }
    public Color Color { get; set; }
    public abstract Rectangle GetRectangle();
}