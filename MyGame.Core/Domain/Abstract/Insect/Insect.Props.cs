namespace MyGame.Core;

public record InsectProps(
    string Name,
    double Health,
    double Protection) : GameObjectProps(Name);
