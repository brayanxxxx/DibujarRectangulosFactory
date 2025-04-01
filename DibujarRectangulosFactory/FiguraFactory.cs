public static class FiguraFactory
{
    public static Rectangulo CrearRectangulo(int x, int y, Color color)
    {
        return new Rectangulo(x, y, color);
    }
}