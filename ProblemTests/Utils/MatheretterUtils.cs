using System.Text;

public static class MatheretterUtils
{
    public static string CirclesCfgFromArray(int[][] array)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < array.Length; i++)
        {
            sb.AppendLine($"circle({array[i][0]}|{array[i][1]} {array[i][2]})");
        }

        return sb.ToString();
    }
}
