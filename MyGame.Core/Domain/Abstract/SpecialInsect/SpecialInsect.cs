namespace MyGame.Core;

public class SpecialInsect : Insect, ICanGoToTheHeak
{
    protected readonly double _damage;

    protected readonly int _bitesCount;
    protected readonly int _targetsCount;

    public double Damage => _damage;

    protected SpecialInsect(SpecialInsectProps props) : base(props)
    {
        _damage = props.Damage;

        _bitesCount   = props.BitesCount;
        _targetsCount = props.TargetsCount; 
    }

    public virtual void Attack(IEnumerable<Insect> insects)
    {
        var enemies = insects.Where((insect) => insect.IEnemy(this)).Take(_targetsCount);

        foreach (var enemy in enemies)
        {
            for (int i = 0; i < _bitesCount; i++)
            {
                enemy.TakeDamage(_damage, breaksProtection: true);
            }
        }
    }

    public void GoToTheHeak(Heap heap)
    {
        heap.GetInsect(this);
    }
    public virtual void GoBack() { }
}
