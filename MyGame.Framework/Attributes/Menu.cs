namespace MyGame;

[AttributeUsage(AttributeTargets.Class)]
public class MenuAttribute : Attribute
{
    public string MenuName { get; set; }
    public string OwnerName { get; set; }

    public MenuAttribute(string name, string ownerName)
    {
        MenuName = name;
        OwnerName = ownerName;
    }
}