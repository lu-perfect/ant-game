namespace MyGame.Core;

[Menu(name: "Главное меню", ownerName: "Выйти")]
internal class MainMenu : ConsoleMenu<MainMenu>
{
    public MainMenu(Action ownerAction) : base(ownerAction)
    {}

    public static MainMenu Create() => new(
        () => Environment.Exit(0)
    );

    protected override void InitMethods()
    {
         Methods = new ()
        {
            ("Начать Игру", () => BeginGame(), false),
            ("Автор", () => About(), false),
        };
    }

    public static void BeginGame()
    {
        AntGame.Start();
    }

    private static void ScreenWithBack(Action callback)
    {
        callback();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Для возвращения в главное меню нажмите любую кнопку");

        Console.ReadKey();
        Console.Clear();
        AntGame.OpenMainScreen();
    }

    public static void About()
    {
        ScreenWithBack(() =>
        {
            Console.WriteLine("Симулятор <Муравьиная жизнь>");
            Console.WriteLine();
            Console.WriteLine("Автор: Лукашев Никита Иванович <lu.perfect>");
            Console.WriteLine("Группа: БСБО-06-21");
        });
    }
}