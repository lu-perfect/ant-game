namespace MyGame.Core;

public record AntQueenProps(
   string Name,
   double Health,
   double Protection,
   double Damage,
   Framework.Domain.Range GrowthCycle,
   Framework.Domain.Range FertilityRange) : InsectProps(Name, Health, Protection);
