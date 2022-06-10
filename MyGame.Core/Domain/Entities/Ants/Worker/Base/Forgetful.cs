namespace MyGame.Core;

public class AntWorkerBaseForgetful : AntWorkerBase, IHasModificator
{
    public AntWorkerBaseForgetful()
       : base("<Обычный-Забывчивый> Муравей-Рабочий", availableResourses: Resourse.Twig)
    { }

    public override void TakeResourse(Heap heap)
    {
        var foundResources = heap.GetResourses(_capacity, _availableResourses);

        for (int i = 0; i < _capacity; i++)
        {
            if (RandomHelper.GetInt32(2) == 0)
            {
                _resourses[i] = Resourse.Empty;
                heap.LeaveResourse(foundResources[i]);
            }
            else
            {
                _resourses[i] = foundResources[i];
            }
        }
    }

    public string[] ModificatorInfo()
    {
        return new[] { "может забыть взять ресурс из кучи" };
    }
}