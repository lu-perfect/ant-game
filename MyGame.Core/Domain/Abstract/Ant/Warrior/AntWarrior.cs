namespace MyGame.Core;

public abstract class AntWarrior : Ant, ICanGoToTheHeak
{
    protected readonly double _initDamage;

    protected readonly int _bitesCount;
    protected readonly int _targetsCount;

    protected double _damage;

    public double Damage => _damage;

    protected AntWarrior(AntWarriorProps props) : base(props)
    {
        _initDamage = _damage = props.Damage;

        _bitesCount = props.BitesCount;
        _targetsCount = props.TargetsCount;
    }

    public override void TakeBuff(IBuff buff)
    {
        _damage = buff.ToWarriorFunc()?.Invoke(_initDamage) ?? _damage;
        base.TakeBuff(buff);
    }
    public override void ResetBuff()
    {
        _damage = _initDamage;
        base.ResetBuff();
    }

    protected void AttackInsects(IEnumerable<Insect> insects)
    {
        foreach (var insect in insects.Take(_targetsCount))
        {
            if (insect is Cricket || insect is Termite)
                continue;

            for (int i = 0; i < _bitesCount; i++)
            {
                insect.TakeDamage(_damage);
            }
        }
    }

    public virtual void Attack(IEnumerable<Insect> insects)
    {
        var enemies = insects.Where((insect) => insect.IEnemy(this));

        AttackInsects(enemies);
    }

    public void GoToTheHeak(Heap heap)
    {
        heap.GetInsect(this);
    }

    public void GoBack()
    {
        // nothing...
    }
}