namespace MyGame.Core;

public record AntWarriorProps(
       string Name,
       double Health,
       double Protection,
       double Damage,
       int BitesCount,
       int TargetsCount) : InsectProps(Name, Health, Protection);
