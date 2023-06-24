using System.Runtime.Intrinsics.X86;

public class Rectangle_Area
{
    [Theory]
    [InlineData(
        -3,
        0,
        3,
        4,
        0,
        -1,
        9,
        2,
        45)]
    [InlineData(
        -2,
        -2,
        2,
        2,
        -2,
        -2,
        2,
        2,
        16)]
    [InlineData(
        -2,
        -2,
        2,
        2,
        3,
        3,
        4,
        4,
        17)]
    public void Test(
        int ax1,
        int ay1,
        int ax2,
        int ay2,
        int bx1,
        int by1,
        int bx2,
        int by2,
        int expected)
    {
        var s = new Solution();

        var result = s.ComputeArea(
            ax1,
            ay1,
            ax2,
            ay2,
            bx1,
            by1,
            bx2,
            by2);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public int ComputeArea(
        int ax1,
        int ay1,
        int ax2,
        int ay2,
        int bx1,
        int by1,
        int bx2,
        int by2)
    {
        var maxX1 = Math.Max(ax1, bx1);
        var minX2 = Math.Min(ax2, bx2);
        var width = minX2 - maxX1;

        var maxY1 = Math.Max(ay1, by1);
        var minY2 = Math.Min(ay2, by2);
        var height = minY2 - maxY1;

        var squareCommon = width * height;

        if (width < 0 || height < 0)
            squareCommon = 0;

        var squareA = (ax2 - ax1) * (ay2 - ay1);
        var squareeB = (bx2 - bx1) * (by2 - by1);

        return squareA + squareeB - squareCommon;
    }
}
