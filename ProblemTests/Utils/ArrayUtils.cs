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
}
