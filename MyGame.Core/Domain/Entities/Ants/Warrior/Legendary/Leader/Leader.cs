namespace MyGame.Core;

[Aura(typeof(AntWarriorLegendaryLeaderBuff))]
public class AntWarriorLegendaryLeader : AntWarriorLegendary, IHasModificator
{
    public AntWarriorLegendaryLeader()
        : base("<Легендарный-Лидер> Муравей-Воин")
    { }

    public string[] ModificatorInfo() => new[] { "урон всех воинов увеличен на 1" };
}