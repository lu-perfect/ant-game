namespace MyGame.Core;

public abstract class Ant : Insect
{
    protected Ant(InsectProps props) : base(props) { }

    public string SayAboutYou() => ToString();

    public AntQueen? MyQueen => AntGame.GetMyQueen(this);

    public override string ToString()
    {
        return $"{Name}: здоровье {_health} защита {_protection}\n" +
               $"Моя королева: {(MyQueen is null ? "мертва..." : MyQueen)}";
    }
}
