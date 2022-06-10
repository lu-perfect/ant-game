namespace MyGame.Core;

internal static class ResoursesExt
{
    public static Resourse[] GetForced(this Resourse[] _resourses, int capacity)
    {
        var resourses = (Resourse[])_resourses.Clone();

        for (int i = 0; i < capacity; i++)
            _resourses[i] = Resourse.Empty;

        return resourses;
    }
}
