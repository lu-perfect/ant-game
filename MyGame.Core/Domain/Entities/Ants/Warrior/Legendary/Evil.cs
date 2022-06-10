namespace MyGame.Core;

public class AntWarriorLegendaryEvil : AntWarriorLegendary, IHasModificator
{
    public AntWarriorLegendaryEvil()
        : base("<Легендарный-Дурной> Муравей-Воин", damage: 4 * 2)
    { }

    public override void Attack(IEnumerable<Insect> insects)
    {
        AttackInsects(insects);
    }

    public string[] ModificatorInfo() => new[]
        {
            "случайно атакует врагов или своих",
            "наносит двойной урон"
        };
}