namespace MyGame.Core;

internal static class InsectFactory
{
    private static readonly List<Type> _larvaTypes = new()
    {
        typeof(AntWorkerAdvanced),
        typeof(AntWorkerBase),
        typeof(AntWorkerBaseForgetful),
        typeof(AntWorkerElite),
        typeof(AntWorkerLegendaryCapricious),
        typeof(AntWorkerSenior),
        typeof(AntWarriorAdvanced),
        typeof(AntWarriorBase),
        typeof(AntWarriorLegendary),
        typeof(AntWarriorLegendaryEvil),
        typeof(AntWarriorLegendaryLeader),
    };

    public static Type GetRandomLarvaType() => _larvaTypes[RandomHelper.GetInt32(_larvaTypes.Count)];
}
