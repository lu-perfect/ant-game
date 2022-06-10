namespace MyGame.Core;

public class AntWorkerBase : AntWorker
{
    public AntWorkerBase()
       : base(
           new(
               Name: "<Обычный> Муравей-Рабочий",
               Health: 1,
               Protection: 0,
               Capacity: 1,
               AvailableResourses: Resourse.Pebble))
    { }

    public AntWorkerBase(
        string name = "<Обычный> Муравей-Рабочий",
        Resourse availableResourses = Resourse.Pebble)
       : base(
           new(
               Name: name,
               Health: 1,
               Protection: 0,
               Capacity: 1,
               AvailableResourses: availableResourses))
    { }
}