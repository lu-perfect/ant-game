namespace MyGame.Core;

internal static class IBuffExt
{
    public static Func<double, double>? ToInsectFunc(this IBuff buff)
    {
        if (buff is IInsectBuff e && e.BuffProtection is Func<double, double> func)
            return func;
        return null;
    }
    public static Func<double, double>? ToWarriorFunc(this IBuff buff)
    {
        if (buff is IAntWarriorBuff e && e.BuffDamage is Func<double, double> func)
            return func;
        return null;
    }
}
