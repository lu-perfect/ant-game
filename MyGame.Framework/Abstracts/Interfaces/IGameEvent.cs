namespace MyGame.Framework;

public interface IGameEvent
{
    bool Started { get; }
    int Duration { get; }
    public int Left { get; }
    void Effect();
    void Start();
}
