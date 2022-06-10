namespace MyGame.Core;

public class Cricket : SpecialInsect, IHasModificator
{
    public Cricket()
        : base(new(
            Name: "Сверчок",
            Health: 29,
            Damage: 12,
            BitesCount: 1,
            TargetsCount: 3,
            Protection: 6
        ))
    { }

    public string[] ModificatorInfo() => new[]
    {
        "не может брать ресурсы;",
        "не может быть атакован войнами;",
        "атакует врагов(3 цели за раз и наносит 1 укус);",
        "игнорирует защиту и может наносить урон неуязвимым насекомым."
    };
}
