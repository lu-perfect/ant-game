using System.Security.Cryptography;

namespace MyGame.Core;

public class ColonyBuilder
{
    private readonly Colony _colony;

    public ColonyBuilder(Colony colony)
    {
        _colony = colony;
    }

    public ColonyBuilder AddQueen(
        string name,
        double health,
        double protection,
        double damage,
        Framework.Domain.Range growthCycle,
        Framework.Domain.Range fertilityRange)
    {
        var queen = new AntQueen(new(
                    Name: name,
                    Health: health,
                    Protection: protection,
                    Damage: damage,
                    GrowthCycle: growthCycle,
                    FertilityRange: fertilityRange
                ));

        _colony.AddInhabitant(queen);
        AntGame.Objects.Add(queen);

        return this;
    }

    public ColonyBuilder AddInsect(Insect insect)
    {
        _colony.AddInhabitant(insect);

        return this;
    }

    public ColonyBuilder AddInhabitants(int count, Type[] types)
    {
        for (int i = 0; i < count; i++)
        {
            var type = types[RandomNumberGenerator.GetInt32(types.Length)];
            var ant = (Insect)Activator.CreateInstance(type)!;
            AntGame.Objects.Add(ant);
            _colony.AddInhabitant(ant);
        }

        return this;
    }

    public AntGame Build() => AntGame.Instance;
}
