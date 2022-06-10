namespace MyGame.Core;

public class AntWarriorLegendary : AntWarrior
{
    public AntWarriorLegendary()
        : base(
            new(
                Name: "<Легендарный> Муравей-Воин",
                Health: 10,
                Protection: 6,
                Damage: 4,
                BitesCount: 1,
                TargetsCount: 3))
    { }

    public AntWarriorLegendary(string name = "<Легендарный> Муравей-Воин", double damage = 4)
        : base(
            new(
                Name: name,
                Health: 10,
                Protection: 6,
                Damage: damage,
                BitesCount: 1,
                TargetsCount: 3))
    { }
}