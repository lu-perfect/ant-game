namespace MyGame.Core;

public sealed partial class AntGame
{
    private static string? _title = null;

    private static int? _width = null;
    private static int? _height = null;

    private static int? _daysBeforeDrought = null;

    private static int _currentDay = 0;

    public static int CurrentDay => _currentDay;
    public static int DaysBeforeDrought
    {
        get
        {
            if (_daysBeforeDrought is null)
                throw new InvalidOperationException("game value: [days before drought] is not set");
            return (int)_daysBeforeDrought;
        }
        private set => _daysBeforeDrought = value;
    }

    internal static readonly List<GameObject> Objects = new();

    internal static readonly List<IGameEvent> Events = new();

    internal static IGameEvent? Event => Events.FirstOrDefault((e) => e.Started);

    public static bool IsEnded { get; private set; }

    internal static IEnumerable<Ant> Ants => Objects.Where((e) => e is Ant).Select((e) => (Ant)e);
    internal static IEnumerable<Colony> Colonies => Objects.Where((e) => e is Colony).Select((e) => (Colony)e);
    internal static IEnumerable<Heap> Heaps => Objects.Where((e) => e is Heap).Select((e) => (Heap)e);

    internal static Colony? GetMyColony<T>(T me) where T : Insect
    {
        return (Objects.Find((obj) => obj is Colony colony && colony.HasInsect(me)) as Colony);
    }
    internal static AntQueen? GetMyQueen<T>(T me) where T : Insect => GetMyColony(me)?.AntQueen;

    internal static void KillMe<T>(T me) where T : GameObject
    {
        Objects.Remove(me);

        if (me is Insect insect)
        {
            var heap = Heaps.FirstOrDefault((heap) => heap.IHasVisitor(insect));
            if (heap is not null && insect is ICanGoToTheHeak iCan)
                heap.RemoveInsect((dynamic)iCan);
        }
    }

    public static HikeInfo? HikeInfo { get; set; }

    public static string Title
    {
        get
        {
            if (_title is null)
                throw new InvalidOperationException("game title is not set");
            return _title;
        }
        private set => _title = value;
    }

    public static int Width
    {
        get
        {
            if (_width is null)
                throw new InvalidOperationException("game width is not set");
            return (int)_width;
        }
        private set => _width = value;
    }
    public static int Height
    {
        get
        {
            if (_height is null)
                throw new InvalidOperationException("game height is not set");
            return (int)_height;
        }
        private set => _height = value;
    }

    public static void OpenMainScreen()
    {
        MainMenu.Create();
    }

    public static void Run()
    {
        OpenMainScreen();
    }

    internal static void Start()
    {
        GameMenu.Create();
    }

    internal static void MoveNext()
    {
        HikeInfo = null;

        if (DaysBeforeDrought <= 0)
        {
            var colonies = Objects.Where((e) => e is Colony).Select((e) => (Colony)e);
            var max = colonies.Select((e) => e.Count).Max();
            var winner = colonies.First((e) => e.Count == max).Name;

            Console.Clear();
            Console.WriteLine("Конец игры");
            Console.WriteLine();
            Console.WriteLine($"Выжила колония: {winner}");
            Console.WriteLine();
            Console.WriteLine("Для возвращения в главное меню нажмите любую кнопку");

            Console.ReadKey();
            Console.Clear();
            MainMenu.Create();
        }

        DaysBeforeDrought -= 1;
        _currentDay += 1;

        var objects = new List<GameObject>();

        if (Event is null && RandomHelper.GetInt32(100) < 25)
        {
            var @event = Events.FirstOrDefault((e) => !e.Started);
            if (@event != null)
                @event.Start();
        }
        if (Event is not null)
            Event.Effect();

        foreach (GameObject obj in Objects)
        {
            if (obj is Heap)
            {
                objects.Add(obj);
            } 
            else
            {
                objects.Insert(0, obj);
            }
        }

        foreach (GameObject obj in objects)
        {
            obj.Update();
        }
    }
}
