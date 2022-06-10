namespace MyGame.Core;

[Menu(name: "Информация о Муравьях", ownerName: "Игровое меню")]
internal class AntsMenu : ConsoleMenu<AntsMenu>
{
    public AntsMenu(Action ownerAction) : base(ownerAction)
    {}

    protected override void InitMethods()
    {
        var ants = AntGame.Ants;

        Methods = new() { };

        foreach (var ant in ants)
        {
            Methods.Add(($"Муравей {ant.Name}", () => ShowAntInfo(ant), false));
        }
    }

    public static AntsMenu Create() => new(
        () =>
        {
            Console.Clear();
            GameMenu.Create();
        }    
    );

    public static void ShowAntInfo(Ant ant)
    {
        Console.WriteLine(ant.SayAboutYou());
        Console.WriteLine();
        Console.WriteLine("Для возвращения в игровое меню, нажмите любую кнопку...");
        Console.ReadKey();
        Console.Clear();
        GameMenu.Create();
    }
}
