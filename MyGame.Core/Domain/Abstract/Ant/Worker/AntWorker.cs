namespace MyGame.Core;

public abstract class AntWorker : Ant, ICanGoToTheHeak
{
    protected readonly Resourse[] _resourses;

    protected readonly Resourse _availableResourses;
    protected readonly int _capacity;

    protected AntWorker(AntWorkerProps props) : base(props)
    {
        _availableResourses = props.AvailableResourses;
        _capacity = props.Capacity;

        _resourses = new Resourse[_capacity];
    }

    public virtual void TakeResourse(Heap heap)
    {
        var foundResources = heap.GetResourses(_capacity, _availableResourses);

        for (int i = 0; i < _capacity; i++)
        {
            _resourses[i] = foundResources[i];
        }
    }

    public override void TakeDamage(double damage, bool breaksProtection = false)
    {
        Die();
    }

    public Resourse[] GiveResources()
    {
        var resourses = (Resourse[])_resourses.Clone();

        for (int i = 0; i < _capacity; i++)
        {
            _resourses[i] = Resourse.Empty;
        }

        return resourses;
    }

    public virtual void GoToTheHeak(Heap heap)
    {
        heap.GetInsect(this);
    }

    public void GoBack()
    {
        if (Health > 0)
            MyColony?.TakeResourses(GiveResources());
    }
}
