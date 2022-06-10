namespace MyGame.Core;

public class AntWarriorLegendaryLeaderBuff : IAntWarriorBuff
{
    public Func<double, double>? BuffDamage => (init) => init + 1;

    public Func<double, double>? BuffProtection => null;
}