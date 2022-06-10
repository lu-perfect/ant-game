namespace MyGame.Core;

public class AntWarriorBase : AntWarrior
{
    public AntWarriorBase()
        : base(
            new(
                Name: "<Обычный> Муравей-Воин",
                BitesCount: 1,
                TargetsCount: 1,
                Health: 1,
                Damage: 1,
                Protection: 0))
    { }
}