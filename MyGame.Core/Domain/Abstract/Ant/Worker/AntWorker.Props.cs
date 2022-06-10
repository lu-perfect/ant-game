namespace MyGame.Core;

public record AntWorkerProps(
      string Name,
      double Health,
      double Protection,
      int Capacity,
      Resourse AvailableResourses) : InsectProps(Name, Health, Protection);
