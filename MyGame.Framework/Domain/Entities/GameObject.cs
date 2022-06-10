namespace MyGame.Framework.Domain;

public abstract class GameObject
{
    public readonly string Name;

    protected GameObject(GameObjectProps props)
    {
        Name = props.Name;
    }

    public virtual void Update() {}

    public override string ToString() => Name;
}
