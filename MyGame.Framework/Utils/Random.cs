using System.Security.Cryptography;
using System.Text;

namespace MyGame.Framework;

public static class RandomHelper
{
    public static int GetInt32(int toExclusive)
    {
        return RandomNumberGenerator.GetInt32(toExclusive);
    }
    public static int GetInt32(int fromInclusive, int toExclusive)
    {
        return RandomNumberGenerator.GetInt32(fromInclusive, toExclusive);
    }

    public static char GetRandomChar(int fromInclusive, int toExclusive)
    {
        return (char)GetInt32(fromInclusive, toExclusive);
    }

    public static string GetRandomString(int len = 5)
    {
        var builder = new StringBuilder(len);

        var offset = 'a';
        const int lettersOffset = 26;

        for (var i = 0; i < len; i++)
            builder.Append(GetRandomChar(offset, offset + lettersOffset));

        return builder.ToString().Capitalize();
    }
}