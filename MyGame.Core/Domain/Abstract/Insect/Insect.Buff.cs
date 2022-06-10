namespace MyGame.Core;

public interface IInsectBuff : IBuff
{
    Func<double, double>? BuffProtection { get; }
}