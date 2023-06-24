using Shouldly;

public class Zigzag_Conversion
{
    [Theory]
    [InlineData("PAYPALISHIRING", 3, "PAHNAPLSIIGYIR")]
    [InlineData("PAYPALISHIRING", 4, "PINALSIGYAHRPI")]
    public void Test(string input, int numRows, string expected)
    {
        var s = new Solution();
        var result = s.Convert(input, numRows);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public string Convert(string s, int numRows)
    {
        var lastRowIdx = numRows - 1;
        var result = new char[s.Length];
        var writeInd = 0;

        var iterX = 0;
        var iterY = 0;
        var iterDiag = false;
        var iterIndex = 0;

        var tgtX = -1;
        var tgtY = 0;

        while (writeInd < s.Length)
        {
            if (iterY == tgtY)
            {
                if (tgtX < iterX)
                {
                    tgtX = iterX;
                    result[writeInd++] = s[iterIndex];
                }
            }
         

            if (!iterDiag)
            {
                iterY++;

                if (iterY == lastRowIdx)
                {
                    iterDiag = true;
                }
            }
            else
            {
                iterY--;
                iterX++;

                if (iterY == 0)
                {
                    iterDiag = false;
                }
            }

            iterIndex++;

            if (iterIndex == s.Length)
            {
                tgtY++;
                tgtX = -1;
                iterIndex = tgtY; //0?
                iterX = 0;
                iterY = tgtY;
                iterDiag = iterY == lastRowIdx;
            }
        }

        return new string(result);
    }
}
