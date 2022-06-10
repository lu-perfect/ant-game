namespace MyGame.Core;

internal class GameMenu : ConsoleMenu<GameMenu>
{
    public GameMenu() : base() 
    {
        OwnerName = "Закончить игру";
        Name = $"Дней до засухи: {AntGame.DaysBeforeDrought}";

        Methods.Add((OwnerName, () =>
        {
            Console.Clear();
            MainMenu.Create();
        }, false));

        Paint();
        ListenKeyboard();
    }

    public static GameMenu Create() => new();

    protected override void InitMethods()
    {
        Methods = new()
        {
            ("Начать следующий день", () => MoveNextDate(), true),
            ("Узнать информацию об игровой ситуации", () => ShowGameState(), false),
            ("Узнать информацию о походе", () => ShowStepResult(), false),
            ("Узнать информацию о муравьях", () => ShowAntsMenu(), false),
            ("Узнать информацию о колонии", () => ShowColoniesMenu(), false),
        };
    }

    public void MoveNextDate()
    {
        Console.CursorVisible = true;
        AntGame.MoveNext();
        Name = $"Дней до засухи: {AntGame.DaysBeforeDrought}";
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
        Console.Write($"<< {Name} >>\n");
    }

    private static void ScreenWithBack(Action callback)
    {
        callback();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Для возвращения в главное меню нажмите любую кнопку");

        Console.ReadKey();
        Console.Clear();
        Create();
    }


    public static void ShowGameState()
    {
        ScreenWithBack(() =>
        {
            Console.Write(@$"День {AntGame.CurrentDay} (до засухи осталось {AntGame.DaysBeforeDrought} дней)

{string.Join("\n\n", AntGame.Colonies.Select((e) => @$"{e.Name}: 

--- {(e.AntQueen is null ? "Королева мертва" : e.AntQueen)}

--- Ресурсы: {e.Resourses}

--- {e.Population()};"))}

{string.Join("\n\n", AntGame.Heaps)}{(AntGame.Event is not null 
    ? $"\n\nГлобальный эффект: {AntGame.Event} (в течение еще {AntGame.Event.Left} дней)" 
    : "")}");
});
    }

    public static void ShowStepResult()
    {
        ScreenWithBack(() =>
        {
            if (AntGame.HikeInfo is not null)
            {
                Console.WriteLine(@$"Начало дня:

{string.Join("\n\n", AntGame.HikeInfo.GoInfos.Select((e) => e.ToString()))}
Конец дня:

{string.Join("\n\n", AntGame.HikeInfo.BackInfos.Select((e) => e.ToString()))}");
            }
            else
            {
                Console.WriteLine("Походов еще не было");
            }
        });
    }

    public static void ShowAntsMenu() => AntsMenu.Create();

    public static void ShowColoniesMenu() => ColoniesMenu.Create();
}
