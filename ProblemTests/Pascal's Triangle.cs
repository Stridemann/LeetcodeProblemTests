public class Pascal_s_Triangle
{
    [Theory]
    [InlineData(3)]
    public void Test(int input)
    {
        var s = new Solution();
        var result = s.GetRow(input);
    }
}

public class Solution
{
public IList<IList<int>> Generate(int numRows)
{
    var result = new List<IList<int>>();
    int[] prevLine = null;

    for (var lineInd = 0; lineInd < numRows; lineInd++)
    {
        var line = new int[lineInd + 1];
        result.Add(line);

        for (var i = 1; i <= lineInd; i++)
        {
            if (lineInd == i || i == 0)
            {
                line[i] = 1;
            }
            else
            {
                line[i] = prevLine[i - 1] + prevLine[i];
            }
        }

        prevLine = line;
    }

    return result;
}
}

//public class Solution
//{
//public IList<int> GetRow(int rowIndex)
//{
//    var line = new int[rowIndex + 1];
//    line[0] = 1;

//    for (var lineInd = 1; lineInd <= rowIndex; lineInd++)
//    {
//        for (var i = lineInd; i >= 1; i--)
//        {
//            line[i] = line[i - 1] + line[i];
//        }
//    }

//    return line;
//}
//}