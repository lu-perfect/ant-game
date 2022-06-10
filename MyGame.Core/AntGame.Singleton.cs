namespace MyGame.Core;

public sealed partial class AntGame
{
    private static readonly object _lock = new();
    private static volatile AntGame _instance = new();
    
    private AntGame() { }
    public static AntGame Instance
    {
        get
        {
            if (_instance is not null)
                return _instance;

            lock (_lock)
            {
                return _instance ??= new();
            }
        }
    }
}
