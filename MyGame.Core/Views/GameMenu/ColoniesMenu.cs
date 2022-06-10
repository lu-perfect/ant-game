namespace MyGame.Core;

[Menu(name: "Информация о Колониях", ownerName: "Игровое меню")]
internal class ColoniesMenu : ConsoleMenu<ColoniesMenu>
{
    public ColoniesMenu(Action ownerAction) : base(ownerAction)
    { }

    protected override void InitMethods()
    {
        var colonies = AntGame.Colonies;

        Methods = new() { };

        foreach (var colony in colonies)
        {
            Methods.Add(($"Колония {colony.Name}", () => ShowColonyInfo(colony), false));
        }
    }

    public static ColoniesMenu Create() => new(
        () =>
        {
            Console.Clear();
            GameMenu.Create();
        }
    );

    public static void ShowColonyInfo(Colony colony)
    {
        Console.WriteLine(colony.SayAboutYou());
        Console.WriteLine();
        Console.WriteLine("Для возвращения в игровое меню, нажмите любую кнопку...");
        Console.ReadKey();
        Console.Clear();
        GameMenu.Create();
    }
}
