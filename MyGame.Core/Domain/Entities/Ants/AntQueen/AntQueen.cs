namespace MyGame.Core;

public class AntQueen : Ant
{
    private readonly double _damage;

    private readonly List<AntLarva> _larvae = new();

    private readonly Framework.Domain.Range _growthCycle;
    private readonly int _fertility;

    public AntQueen() : base(new(RandomHelper.GetRandomString(),
        Health: 19,
        Protection: RandomHelper.GetInt32(5, 8)))
    {
        _growthCycle = new Framework.Domain.Range(1, 5);
        _fertility = 0;
    }

    public AntQueen(AntQueenProps props) : base(props)
    {
        _damage = props.Damage;

        _growthCycle = props.GrowthCycle;
        _fertility = RandomHelper.GetInt32(props.FertilityRange.Start, props.FertilityRange.End + 1);
    }

    private void Grow()
    {
        foreach (var larva in _larvae.ToList())
            larva.Grow();

        if (_larvae.Count == 0)
        {
            for (int i = 0; i < RandomHelper.GetInt32(3, 10); i++)
            {
                _larvae.Add(new(
                    mother: this,
                    growthCycle: RandomHelper.GetInt32(_growthCycle.Start, _growthCycle.End + 1),
                    iCanBecomeAQueen: _fertility > 0
                ));
            }
        }
    }

    public override void Update() => Grow();

    public void KickMother(AntLarva larva)
    {
        _larvae.Remove(larva);

        var ant = (Ant)Activator.CreateInstance(larva.IAm)!;
        AntGame.Objects.Add(ant);

        if (ant is AntQueen newQueen)
        {
            if (RandomHelper.GetInt32(11) < 6)
            {
                newQueen.Disappear();
            }
            else
            {
                var newColony = new Colony(RandomHelper.GetRandomString());
                newColony.AddInhabitant(newQueen);

                AntGame.Objects.Add(newColony);
            }
        } 
        else
        {
            var colony = AntGame.GetMyColony(this);

            colony?.AddInhabitant(ant);
        }
    }

    public void Disappear() => Die();

    public override string ToString() => $"Королева <{Name}>, личинок: {_larvae.Count}";
}
