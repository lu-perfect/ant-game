namespace MyGame.Core;

public class Colony : GameObject
{
    public Resourses Resourses => _resources;

    private readonly Resourses _resources = new();
    private readonly List<Insect> _inhabitants = new();

    public int Count => _resources.Count;

    public Colony(string name) : base(new (name)) { }
    public Colony(GameObjectProps props) : base(props) { }

    public AntQueen? AntQueen => (AntQueen?)_inhabitants.Find((e) => e is AntQueen);

    public int WarriosCount => _inhabitants.Count((e) => e is AntWarrior);
    public int WorkersCount => _inhabitants.Count((e) => e is AntWorker);
    public int SpecialInsectsCount => _inhabitants.Count((e) => e is SpecialInsect);

    public void AddInhabitant<T>(T insect) where T : Insect => _inhabitants.Add(insect);
    public void IAmDie<T>(T insect) where T : Insect => _inhabitants.Remove(insect);

    public bool HasInsect<T>(T insect) where T : Insect => _inhabitants.Contains(insect);

    public void Genocide()
    {
        var ants = _inhabitants.ToList().Where((e) => e is Ant);
        foreach (var ant in ants.Take(ants.Count() / 2))
        {
            _inhabitants.Remove(ant);
            AntGame.KillMe(ant);
        }
    }

    public void UseAura(IBuff buff)
    {
        foreach (var insect in _inhabitants)
            insect.TakeBuff(buff);
    }

    public void ResetAura()
    {
        foreach (var insect in _inhabitants)
            insect.ResetBuff();
    }

    public override void Update()
    {
        foreach (var insect in _inhabitants)
        {
            if (insect is AntQueen queen)
            {
                // already implement in class
            } 
            else
            {
                var randomHeap = AntGame.Heaps.Where((e) => !e.Exhausted).FirstOrDefault();
                if (randomHeap is null)
                    continue;

                if (insect is ICanGoToTheHeak heakInsect)
                    heakInsect.GoToTheHeak(randomHeap);
            }
        }
    }

    public void TakeResourses(Resourse[] resourses)
    {
        foreach (var resourse in resourses)
            _resources.AddResourse(resourse);
    }

    public string SayAboutYou() => ToString();

    public void Die()
    {
        AntGame.KillMe(this);

    }

    public string Population()
    {
        var workers = _inhabitants.Count((e) => e is AntWorker);
        var warriors = _inhabitants.Count((e) => e is AntWarrior);
        var specials = _inhabitants.Count((e) => e is SpecialInsect);

        return $"Популяция {_inhabitants.Count}: " +
               $"рабочих={workers}, воинов={warriors}, особых={specials}";
    }

    private string PrintInsectTypeInfo<T>() where T : Insect, new()
    {
        var instance = new T();

        var count = _inhabitants.Count((e) => e is T);

        if (count == 0) return "";

        var type = instance.Name;

        var health = $"здоровье={instance.Health}";
        var protection = $", защита={instance.Protection}";

        var damage = "";
        var modificator = "";

        if (instance is AntWarrior w)
            damage = $", урон={w.Damage}";

        if (instance is SpecialInsect s)
            damage = $", урон={s.Damage}";

        if (instance is IHasModificator i)
        {
            var info = i.ModificatorInfo();
            modificator = info.Length == 0
                ? $"\n\n--- Модификатор: {info[0]}"
                : "\n\nМодификаторы:\n" + string.Join("\n", info.Select((e) => $"--- {e}"));
        }

        return @$"Тип: {type}

--- Параметры: {health}{protection}{damage}{modificator}
--- Количество: {count}
";
    }

    public override string ToString()
    {
        return @$"Колония «{Name}»

--- {(AntQueen is null ? "Королева мертва" : AntQueen)}

--- Ресурсы: {_resources}

## Рабочие 

{PrintInsectTypeInfo<AntWorkerAdvanced>()} 
{PrintInsectTypeInfo<AntWorkerBase>()}
{PrintInsectTypeInfo<AntWorkerBaseForgetful>()}
{PrintInsectTypeInfo<AntWorkerElite>()}
{PrintInsectTypeInfo<AntWorkerLegendaryCapricious>()}
{PrintInsectTypeInfo<AntWorkerSenior>()}
## Воины

{PrintInsectTypeInfo<AntWarriorAdvanced>()}
{PrintInsectTypeInfo<AntWarriorBase>()}
{PrintInsectTypeInfo<AntWarriorLegendary>()}
{PrintInsectTypeInfo<AntWarriorLegendaryEvil>()}
{PrintInsectTypeInfo<AntWarriorLegendaryLeader>()}
## Особые 
{PrintInsectTypeInfo<Termite>()}
{PrintInsectTypeInfo<Cricket>()}";
    }
}
