namespace MyGame;

public static class StringsExtensions
{
    public static string Capitalize(this string value) => string.Concat(
        value[0].ToString().ToUpper(), 
        value.ToLower().AsSpan(1)
    );
}
