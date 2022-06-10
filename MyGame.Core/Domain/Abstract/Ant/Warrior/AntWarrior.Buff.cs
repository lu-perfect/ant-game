namespace MyGame.Core;

public interface IAntWarriorBuff : IInsectBuff
{
    Func<double, double>? BuffDamage { get; }
}