namespace MyGame.Core;

public record SpecialInsectProps(
    string Name,
    double Health,
    double Damage, 
    int BitesCount,
    int TargetsCount,
    double Protection) : InsectProps(Name, Health, Protection);
