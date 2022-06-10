namespace MyGame.Core;

public class Heap : GameObject
{
    private readonly List<Insect> _visitors = new();

    private readonly Resourses _resources;

    public bool Exhausted => _resources.Count == 0;

    public Heap(string name) : base(new (name))
    {
        _resources = new();
    }

    public Heap(GameObjectProps props) : base(props) 
    {
        _resources = new();
    }

    public Heap(string name, ResoursesProps props) : base(new (name))
    {
        _resources = new(props);
    }

    public Resourse[] GetResourses(int capacity, Resourse findTypes)
    {
        var resourses = new Resourse[capacity];

        var availableResourses =
            Enum.GetValues(typeof(Resourse))
                .Cast<Resourse>()
                .Where(e => (findTypes & e) != 0)
                .ToArray();

        for (int i = 0; i < capacity; i++)
            resourses[i] = _resources.GetResourse(availableResourses);

        return resourses;
    }

    public void GetInsect<T>(T insect) where T : Insect, ICanGoToTheHeak
    {
        _visitors.Add(insect);
    }
    public void RemoveInsect<T>(T insect) where T : Insect, ICanGoToTheHeak
    {
        _visitors.Remove(insect);
    }

    public bool IHasVisitor<T>(T insect) where T : Insect
    {
        return _visitors.Contains(insect);
    }

    public override void Update()
    {
        var goInfos = new List<GoInfo>();
        var backInfos = new List<BackInfo>();

        var groups = _visitors
            .Select(
                (visitor) =>
                (colony: AntGame.Colonies.First((e) => e.HasInsect(visitor)), visitor)
            )
            .GroupBy((e) => e.colony)
            .ToArray();

        for (int i = 0; i < groups.Length; i++)
        {
            var group = groups[i];

            var colony = group.Key;

            var prev = new GoInfo(
                Colony: colony.Name,
                Heap: Name,
                Warrios: colony.WarriosCount,
                Workers: colony.WorkersCount,
                Special: colony.SpecialInsectsCount
            );

            var twings = colony.Resourses.TwigsCount;
            var pebblies = colony.Resourses.PebbliesCount;
            var leafs = colony.Resourses.LeafsCount;
            var dewdrops = colony.Resourses.DewdropsCount;

            goInfos.Add(prev);

            foreach (var insect in group.Select((e) => e.visitor))
            {
                if (insect is AntWarrior warrior)
                {
                    warrior.Attack(
                        groups
                            .Where((e) => e.Key != group.Key)
                            .SelectMany((e) => e)
                            .Select((e) => e.visitor)
                    );
                }

                if (insect is AntWorker worker)
                {
                    worker.TakeResourse(this);
                }

                if (insect is SpecialInsect special)
                {
                    special.Attack(
                       groups
                           .Where((e) => e.Key != group.Key)
                           .SelectMany((e) => e)
                           .Select((e) => e.visitor)
                   );
                }

                if (insect is Termite termite)
                {
                    termite.TakeResourse(this);
                }
            }

            var post = new BackInfo(
                Colony: colony.Name,
                TwigsCount: colony.Resourses.TwigsCount - twings, 
                PebbliesCount: colony.Resourses.PebbliesCount - pebblies, 
                LeafsCount: colony.Resourses.LeafsCount - leafs, 
                DewdropsCount: colony.Resourses.DewdropsCount - dewdrops,
                WarriosBack: colony.WarriosCount,
                WorkersBack: colony.WorkersCount,
                SpecialBack: colony.SpecialInsectsCount,
                WarriosLoss: colony.WarriosCount - prev.Warrios,
                WorkersLoss: colony.WorkersCount - prev.Workers,
                SpecialLoss: colony.SpecialInsectsCount - prev.Special,
                LarvaeInfo: colony.AntQueen is null ? "Королева мертва" : colony.AntQueen.ToString()
            );

            backInfos.Add(post);
        }

        if (AntGame.HikeInfo is not null)
        {
            AntGame.HikeInfo = new(goInfos.Concat(AntGame.HikeInfo.GoInfos).ToList(), backInfos.Concat(AntGame.HikeInfo.BackInfos).ToList());
        }
        else
        {
            AntGame.HikeInfo = new(goInfos, backInfos);
        }



        foreach (var visitor in _visitors.Where((e) => AntGame.Objects.Contains(e)).Select((e) => (ICanGoToTheHeak)e))
        {
            visitor.GoBack();
        }

        _visitors.Clear();
    }

    public void LeaveResourse(Resourse resourse)
    {
        _resources.AddResourse(resourse); 
    }

    public override string ToString() => $"{Name}: {(Exhausted ? "истощена" : _resources)}";
}
