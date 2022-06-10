namespace MyGame.Core;

public class AntWorkerSenior : AntWorker
{
    public AntWorkerSenior()
       : base(
           new(
               Name: "<Старший> Муравей-Рабочий",
               Health: 2,
               Protection: 1,
               Capacity: 1,
               AvailableResourses: Resourse.Leaf | Resourse.Twig))
    { }
}
