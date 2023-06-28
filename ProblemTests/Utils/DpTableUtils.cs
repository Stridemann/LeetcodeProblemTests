using System.Text;

public static class DpTableUtils
{
    //DpTableUtils.FormatDp(dp, s, p)
    public static string FormatDp(bool[,] dp, string s, string p)
    {
        var width = dp.GetLength(0);
        var height = dp.GetLength(1);

        var sb = new StringBuilder();

        for (int y = 0; y < height; y++)
        {
            if (y == 0)
            {
                sb.Append(" ");
                sb.Append("1");
            }
            else
                sb.Append(p[y - 1]);

            for (int x = 0; x < width; x++)
            {
                if (y == 0)
                {
                    if(x > 0)
                        sb.Append(s[x - 1]);

                    continue;
                }

                sb.Append(dp[x, y].ToString().Replace("True", "1").Replace("False", "0"));
            }

            sb.Append(Environment.NewLine);
        }

        return sb.ToString();
    }
}
