namespace MyGame.Core;

public class AntWorkerLegendaryCapricious : AntWorker, IHasModificator
{
    private bool _isCapricious = true;

    public AntWorkerLegendaryCapricious()
       : base(
           new(
               Name: "<Легендарный-Капризный> Муравей-Рабочий",
               Health: 10,
               Protection: 6,
               Capacity: 3,
               AvailableResourses: Resourse.Dewdrop | Resourse.Pebble))
    { }

    public string[] ModificatorInfo() => new[] { "игнорирует каждый 2й поход" };

    public override void GoToTheHeak(Heap heap)
    {
        if (!_isCapricious)
            base.GoToTheHeak(heap);

        _isCapricious = !_isCapricious;
    }
}
