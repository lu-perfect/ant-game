using System.Reflection;

namespace MyGame.Framework;

public abstract class ConsoleMenu<T> where T : class
{
    protected List<(string name, Action method, bool isNotUpdated)> Methods = new();

    public int SelectedItem { get; private set; }

    public string Name { get; protected set; } = string.Empty;

    public string OwnerName { get; protected set; } = string.Empty;

    protected ConsoleMenu()
    {
        Console.CursorVisible = false;

        InitMethods();
    }

    protected abstract void InitMethods();

    protected ConsoleMenu(Action ownerAction, string name, string owner) : this()
    {
        OwnerName = owner;
        Name = name;

        Methods.Add((OwnerName, ownerAction, false));

        Paint();
        ListenKeyboard();
    }

    public ConsoleMenu(Action ownerAction) : this()
    {
        var menuData = typeof(T).GetCustomAttribute(typeof(MenuAttribute), false) as MenuAttribute;

        OwnerName = menuData!.OwnerName;
        Name = menuData.MenuName;

        Methods.Add((OwnerName, ownerAction, false));

        Paint();
        ListenKeyboard();
    }

    protected void ListenKeyboard()
    {
        while (true)
        {
            var key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.Enter:
                    var (name, method, isNotUpdated) = Methods[SelectedItem];
                    if (isNotUpdated)
                    {
                        method();
                    } 
                    else
                    {
                        Console.Clear();
                        Console.CursorVisible = true;
                        method();
                        Console.CursorVisible = false;
                        Paint();
                    }
                    
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.UpArrow:
                    DrawItem();
                    Move(key);
                    DrawItem(true);
                    break;
            }
        }
    }

    protected void Paint()
    {
        Console.WriteLine($"<< {Name} >>\n\n");

        for (int i = 0; i < Methods.Count; i++)
        {
            DrawItem(withPrefix: i == SelectedItem, i);
        }
    }

    protected void DrawItem(bool withPrefix = false, int? index = null)
    {
        var i = index is not null ? index.Value : SelectedItem;

        var methodName = Methods[i].name;
        i += 2;

        if (methodName == OwnerName)
        {
            Console.WriteLine();
            i++;
        }

        Console.SetCursorPosition(0, i);

        Console.WriteLine((withPrefix ? $"-> {methodName}": $"{methodName}   "));
    }

    protected void Move(ConsoleKey key)
    {
        var start = 0;
        var end = Methods.Count - 1;

        SelectedItem = key == ConsoleKey.DownArrow
            ? SelectedItem == end ? start : SelectedItem + 1
            : SelectedItem == start ? end : SelectedItem - 1;
    }
}