using MyGame.Core;

/// <summary>
/// Инициализация Игры 
/// </summary>
static void Init() => AntGame
    .Instance
    // Заголовок ( Консоли )
    .SetTitle("Ant Life")
    // Размеры игры 
    .SetWidth(140)
    .SetHeight(40)
    // Дней до засухи
    .SetDaysBeforeDrought(13)
    // Игровые События
    //.AddEvent(new HornetComeEvent())
    // Кучи
    .AddHeap("1", new(TwigsCount: 27, PebbliesCount: 15, LeafsCount: 30))
    .AddHeap("2", new(TwigsCount: 43))
    .AddHeap("3", new(TwigsCount: 36, LeafsCount: 15, DewdropsCount: 44))
    .AddHeap("4", new(TwigsCount: 27, PebbliesCount: 37))
    .AddHeap("5", new(TwigsCount: 19, PebbliesCount: 43, DewdropsCount: 41))
    //=== Колонии
    // Колония черных муравьев 
    .AddColony("Черные")
    .AddQueen(
        name: "Анна",
        health: 19,
        protection: 7,
        damage: 27,
        growthCycle: new(1, 5),
        fertilityRange: new(2, 5)
    )
    .AddInhabitants(10, new[]
    {
        typeof(AntWorkerBase),
        typeof(AntWorkerElite),
        typeof(AntWorkerLegendaryCapricious)
    })
    .AddInhabitants(5, new[]
    {
        typeof(AntWarriorBase),
        typeof(AntWarriorAdvanced),
        typeof(AntWarriorLegendaryLeader)
    })
    .AddInsect(new Cricket())
    .Build()
    // Колония Зеленых муравьев
    .AddColony("Зеленые")
    .AddQueen(
        name: "Гвендолина",
        health: 19,
        protection: 6,
        damage: 17,
        growthCycle: new(3, 4),
        fertilityRange: new(1, 4)
    )
    .AddInsect(new Termite())
    .AddInhabitants(18, new[]
    {
        typeof(AntWorkerSenior),
        typeof(AntWorkerAdvanced),
        typeof(AntWorkerBaseForgetful)
    })
    .AddInhabitants(9, new[]
    {
        typeof(AntWarriorLegendary),
        typeof(AntWarriorAdvanced),
        typeof(AntWarriorLegendaryEvil)
    })
    .Build();

Init();
AntGame.Run();