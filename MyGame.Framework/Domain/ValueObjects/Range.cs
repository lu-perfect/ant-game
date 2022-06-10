namespace MyGame.Framework.Domain;

public readonly struct Range
{
    public readonly int Start;
    public readonly int End;

    public Range(int start, int end)
    {
        if (start > end)
            throw new ArgumentException("начальное значение не может быть меньше конечного");

        Start = start; 
        End = end; 
    }
}
