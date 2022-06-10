namespace MyGame.Core;

[AttributeUsage(AttributeTargets.Class)]
public class Aura : Attribute
{
    public readonly IBuff Buff;

    public Aura(Type type)
    {
        if (!typeof(IBuff).IsAssignableFrom(type))
            throw new ArgumentException();

        Buff = (IBuff)Activator.CreateInstance(type)!;
    }
}