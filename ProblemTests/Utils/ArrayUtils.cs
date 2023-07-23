using System.Text;

public static class ArrayUtils
{
    public static int[][] ArrayFromStr(string str)
    {
        str = str.Replace(" ", string.Empty).TrimStart('[').TrimEnd(']');

        if (string.IsNullOrEmpty(str))
            return Array.Empty<int[]>();

        var splited = str.Split('[', ']', StringSplitOptions.RemoveEmptyEntries);
        var result = new int[splited.Length][];

        for (var i = 0; i < splited.Length; i++)
        {
            var subArrayStr = splited[i];
            var parseStr = subArrayStr.TrimEnd(',').TrimEnd(']').Split(',');
            var subArr = parseStr.Select(int.Parse).ToArray();
            result[i] = subArr;
        }

        return result;
    }

    public static string ArrayToStr(int[][] arr)
    {
        return $"[{string.Join(",", arr.Select(x => $"[{string.Join(",", x)}]"))}]";
    }

    public static string ArrayToStr(int[] arr)
    {
        return $"[{string.Join(",", arr)}]";
    }

    public static char[][] CharArrayFromStr(string str)
    {
        str = str.Replace(" ", string.Empty).TrimStart('[').TrimEnd(']');

        if (string.IsNullOrEmpty(str))
            return Array.Empty<char[]>();

        var splited = str.Split('[', ']', StringSplitOptions.RemoveEmptyEntries);
        var result = new char[splited.Length][];

        for (var i = 0; i < splited.Length; i++)
        {
            var subArrayStr = splited[i];
            var parseStr = subArrayStr.TrimEnd(',').TrimEnd(']').Split(',');
            var subArr = parseStr.Select(x => char.Parse(x.Replace("'", string.Empty))).ToArray();
            result[i] = subArr;
        }

        return result;
    }

    public static string FormatArray<T>(T[,] dp, string s, string p)
    {
        var width = dp.GetLength(0);
        var height = dp.GetLength(1);

        var sb = new StringBuilder();

        for (int y = 0; y < height; y++)
        {
            sb.Append("[");

            for (int x = 0; x < width; x++)
            {
                sb.Append(dp[x, y]);
            }

            sb.Append("]");
            sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }

    public static string FormatArray<T>(T[][] dp)
    {
        var width = dp[0].Length;
        var height = dp.Length;

        var sb = new StringBuilder();

        for (int y = 0; y < height; y++)
        {
            sb.Append("[");

            for (int x = 0; x < width; x++)
            {
                if (x > 0)
                    sb.Append(" ");
                sb.Append(dp[y][x]);
            }

            sb.Append("]");
            sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}
