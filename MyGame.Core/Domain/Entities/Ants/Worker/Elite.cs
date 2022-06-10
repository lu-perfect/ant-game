namespace MyGame.Core;

public class AntWorkerElite : AntWorker
{
    public AntWorkerElite()
       : base(
           new(
               Name: "<Элитный> Муравей-Рабочий",
               Health: 8,
               Protection: 4,
               Capacity: 2,
               AvailableResourses: Resourse.Twig | Resourse.Dewdrop))
    { }
}