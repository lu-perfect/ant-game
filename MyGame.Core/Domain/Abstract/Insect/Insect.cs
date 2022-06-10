namespace MyGame.Core;

public abstract class Insect : GameObject
{
    protected readonly double _initProtection;
    protected readonly double _initHealth;

    protected double _health;
    protected double _protection;

    public double Health
    {
        get => _health;
        private set
        {
            if (value <= 0)
                Die();

            _health = value;
        }
    }
    public double Protection
    {
        get => _protection;
        private set
        {
            if (_protection < 0)
                throw new ArgumentOutOfRangeException(nameof(Protection));

            _protection = value;
        } 
    }

    protected Insect(InsectProps props) : base(props)
    {
        _initHealth     = _health     = props.Health;
        _initProtection = _protection = props.Protection;
    }

    protected Colony? MyColony => AntGame.GetMyColony(this);
    public bool IEnemy(Insect stranger) => MyColony is not null && !MyColony.HasInsect(stranger);

    public virtual void TakeBuff(IBuff buff)
    {
       _protection = buff.ToInsectFunc()?.Invoke(_initProtection) ?? _protection;
    }
    public virtual void ResetBuff()
    {
        _protection = _initProtection;
    }

    public virtual void TakeDamage(double damage, bool breaksProtection = false)
    {
        var finalDamage = damage;

        if (!breaksProtection)
            finalDamage -= _protection;

        if (finalDamage > 0)
            Health -= finalDamage;
    }

    protected void Die()
    {
        MyColony?.IAmDie(this);

        AntGame.KillMe(this);
    }
}
