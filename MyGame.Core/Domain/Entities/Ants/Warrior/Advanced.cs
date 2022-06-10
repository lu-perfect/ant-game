namespace MyGame.Core;

public class AntWarriorAdvanced : AntWarrior
{
    public AntWarriorAdvanced()
        : base(
            new(
                Name: "<Продвинутый> Муравей-Воин",
                Health: 6,
                Protection: 2,
                Damage: 4,
                BitesCount: 1,
                TargetsCount: 2))
    { }
}