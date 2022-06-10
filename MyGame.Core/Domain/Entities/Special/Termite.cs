namespace MyGame.Core;

public class Termite : SpecialInsect, IHasModificator
{
    private bool _lazarusEffectUsed = false;

    private const int _capacity = 2;

    private readonly Resourse[] _resourses = new Resourse[_capacity];

    private readonly Resourse _availableResourses = Resourse.Twig;

    public Termite()
        : base(new(
            Name: "Термит",
            Health: 24,
            Damage: 7,
            BitesCount: 2,
            TargetsCount: 3,
            Protection: 8
        ))
    { }

    public void Heal()
    {
        _health = _initHealth;
    }

    public override void TakeDamage(double damage, bool breaksProtection = false)
    {
        var finalDamage = damage;

        if (!breaksProtection)
            finalDamage -= _protection;

        if (finalDamage > 0)
            _health -= finalDamage;

        if (_health <= 0)
        {
            if (_lazarusEffectUsed)
            {
                Die();
            }
            else
            {
                _lazarusEffectUsed = true;
            }
        }
    }

    public virtual void TakeResourse(Heap heap)
    {
        var foundResources = heap.GetResourses(_capacity, _availableResourses);

        for (int i = 0; i < _capacity; i++)
            _resourses[i] = foundResources[i];
    }

    public override void GoBack()
    {
        if (Health > 0)
            MyColony.TakeResourses(_resourses.GetForced(_capacity));
    }

    public string[] ModificatorInfo() => new[]
    {
        "может брать ресурсы(2 ресурса: веточка);",
        "не может быть атакован войнами;",
        "атакует врагов(3 цели за раз и наносит 2 укуса);",
        "здоровье восстанавливается после похода;",
        "может пережить 1 любой укус.",
    };
}
