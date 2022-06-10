namespace MyGame.Core;

public sealed partial class AntGame
{
    public AntGame SetTitle(string value)
    {
        Title = value;

        return this;
    }

    public AntGame SetWidth(int value)
    {
        Width = value;

        return this;
    }

    public AntGame SetHeight(int value)
    {
        Height = value;

        return this;
    }

    public AntGame SetDaysBeforeDrought(int value)
    {
        DaysBeforeDrought = value;

        return this;
    }

    public AntGame AddEvent(IGameEvent @event)
    {
        Events.Add(@event);

        return this;
    }

    public AntGame AddHeap(Heap heap)
    {
        Objects.Add(heap);

        return this;
    }

    public AntGame AddHeap(string name, ResoursesProps props)
    {
        Objects.Add(new Heap(name, props));

        return this;
    }

    public ColonyBuilder AddColony(Colony colony)
    {
        Objects.Add(colony);

        return new (colony);
    }

    public ColonyBuilder AddColony(string name)
    {
        var colony = new Colony(name);

        Objects.Add(colony);

        return new(colony);
    }
}
