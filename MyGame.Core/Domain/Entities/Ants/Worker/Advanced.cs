namespace MyGame.Core;

public class AntWorkerAdvanced : AntWorker
{
    public AntWorkerAdvanced()
       : base(
           new(
               Name: "<Продвинутый> Муравей-Рабочий",
               Health: 6,
               Protection: 2,
               Capacity: 2,
               AvailableResourses: Resourse.Twig))
    { }
}