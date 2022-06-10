namespace MyGame.Core;

public class HornetComeEvent : IGameEvent
{
    public int Duration { get; private set; } = 6;
    public int Left { get; private set; }

    public bool Started { get; private set; }

    public void Start()
    {
        Left = Duration;
        Started = true;
    }

    public void Effect()
    {
        if (Left == 0)
            Started = false;

        var colonies = AntGame.Colonies.ToArray();
        var colony = colonies[RandomHelper.GetInt32(colonies.Length)];

        colony.Genocide();

        Left -= 1;

        if (Left == 0)
        {
            Left = Duration;
            Duration = 0;
            Started = false;
        }
    }

    public override string ToString() => "<Шершень>: в случайной колонии популяция муравьев уменьшается в 2 раза";
}
