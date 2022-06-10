namespace MyGame.Core;

public class Resourses
{
    private readonly List<Resourse> _resources = new();

    public int TwigsCount    => _resources.Count((e) => e is Resourse.Twig);
    public int PebbliesCount => _resources.Count((e) => e is Resourse.Pebble);
    public int LeafsCount    => _resources.Count((e) => e is Resourse.Leaf);
    public int DewdropsCount => _resources.Count((e) => e is Resourse.Dewdrop);

    public int Count => _resources.Count;

    public Resourses() { }

    public Resourses(ResoursesProps props)
    {
        for (int i = 0; i < props.TwigsCount;    i++)
            _resources.Add(Resourse.Twig);
        for (int i = 0; i < props.PebbliesCount; i++)
            _resources.Add(Resourse.Pebble);
        for (int i = 0; i < props.LeafsCount;    i++)
            _resources.Add(Resourse.Leaf);
        for (int i = 0; i < props.DewdropsCount; i++)
            _resources.Add(Resourse.Dewdrop);
    }

    public void AddResourse(Resourse resourse) => _resources.Add(resourse);

    public Resourse GetResourse(Resourse[] findTypes)
    {
        if (Count == 0)
            return Resourse.Empty;

        if (findTypes.Contains(Resourse.Pebble) && PebbliesCount > 0)
        {
            _resources.Remove(Resourse.Pebble);
            return Resourse.Pebble;
        }

        if (findTypes.Contains(Resourse.Leaf) && LeafsCount > 0)
        {
            _resources.Remove(Resourse.Leaf);
            return Resourse.Leaf;
        }

        if (findTypes.Contains(Resourse.Twig) && TwigsCount > 0)
        {
            _resources.Remove(Resourse.Twig);
            return Resourse.Twig;
        }

        if (findTypes.Contains(Resourse.Dewdrop) && DewdropsCount > 0)
        {
            _resources.Remove(Resourse.Dewdrop);
            return Resourse.Dewdrop;
        }

        return Resourse.Empty;
    }

    public override string ToString()
    {
        return $"к = {PebbliesCount}, л = {LeafsCount}, в = {TwigsCount}, р = {DewdropsCount}";
    }
}
