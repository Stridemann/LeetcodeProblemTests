using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using static Solution;

public class Trapping_Rain_Water_II
{
    [Theory]
    [InlineData(
        "["
        + "[1,4,3,1,3,2],"
        + "[3,2,1,3,2,4],"
        + "[2,3,3,2,3,1]]",
        4)]
    [InlineData(
        "["
        + "[1,1,1],"
        + "[1,0,1],"
        + "[1,1,1]]",
        1)]
    [InlineData(
        "["
        + "[2,2,2],"
        + "[2,0,2],"
        + "[2,2,2]]",
        2)]
    [InlineData(
        "["
        + "[2,2,2],"
        + "[2,1,2],"
        + "[2,2,2]]",
        1)]
    [InlineData(
        "["
        + "[3,3,3],"
        + "[3,0,3],"
        + "[3,3,3]]",
        3)]
    [InlineData(
        "["
        + "[3,3,3],"
        + "[3,1,3],"
        + "[3,3,3]]",
        2)]
    [InlineData(
        "["
        + "[3,3,3],"
        + "[3,2,3],"
        + "[3,3,3]]",
        1)]
    [InlineData(
        "["
        + "[4,4,4],"
        + "[4,0,4],"
        + "[4,4,4]]",
        4)]
    [InlineData(
        "["
        + "[4,4,4],"
        + "[4,1,4],"
        + "[4,4,4]]",
        3)]
    [InlineData(
        "["
        + "[0,0,0,0,0,0],"
        + "[0,2,2,2,2,0],"
        + "[0,2,1,1,2,0],"
        + "[0,2,2,2,2,0],"
        + "[0,0,0,0,0,0],"
        + "]",
        2)]
    [InlineData(
        "["
        + "[3,3,3,3,3],"
        + "[3,2,2,2,3],"
        + "[3,2,1,2,3],"
        + "[3,2,2,2,3],"
        + "[3,3,3,3,3]]",
        10)]
    [InlineData(
        "["
        + "[9,9,9,9,9,9,8,9,9,9,9],"
        + "[9,0,0,0,0,0,1,0,0,0,9],"
        + "[9,0,0,0,0,0,0,0,0,0,9],"
        + "[9,0,0,0,0,0,0,0,0,0,9],"
        + "[9,9,9,9,9,9,9,9,9,9,9]]",
        215)]
    [InlineData(
        "["
        + "[9,9,9,9,9,9,9,9,9,9,9],"
        + "[9,0,0,0,0,0,0,0,0,0,9],"
        + "[9,0,0,0,0,0,0,0,0,0,9],"
        + "[9,0,0,0,0,0,0,0,0,0,9],"
        + "[9,9,9,9,9,9,9,9,9,9,9]]",
        243)]
    [InlineData(
        "["
        + "[14,17,18,16,14,16],"
        + "[17, 3,10, 2, 3, 8],"
        + "[11,10, 4, 7, 1, 7],"
        + "[13, 7, 2, 9 ,8,10],"
        + "[13, 1, 3, 4, 8, 6],"
        + "[20, 3, 3, 9,10, 8]]",
        25)]
    public void Test(string heightMapStr, int expected)
    {
        var heightMap = ArrayUtils.ArrayFromStr(heightMapStr);
        var s = new Solution();
        var result = s.TrapRainWater(heightMap);
        result.ShouldBe(expected);
    }
}

public partial class Solution
{
    private Bitmap _bitmap;

    protected void DebugDraw(int slice)
    {
        if (_bitmap == null)
        {
            var max = _heightMap.SelectMany(x => x).Max() + 1;
            _bitmap = new Bitmap(_width, _length * max);
        }

        for (int z = 0; z < _length; z++)
        {
            for (int x = 0; x < _width; x++)
            {
                ref Solution.CellData cellData = ref _grid[x, z];

                var zDraw = z + _length * slice;

                if (cellData.IsRemovedWater)
                {
                    _bitmap.SetPixel(x, zDraw, Color.BlueViolet);
                    cellData.IsWall = true;
                    cellData.IsRemovedWater = false;
                }
                else if (cellData.IsEmpty)
                    _bitmap.SetPixel(x, zDraw, Color.White);
                else if (cellData.IsWall)
                    _bitmap.SetPixel(x, zDraw, Color.OrangeRed);
                else if (cellData.IsBox)
                    _bitmap.SetPixel(x, zDraw, Color.DarkOliveGreen);
                else if (cellData.IsWater)
                    _bitmap.SetPixel(x, zDraw, Color.DodgerBlue);
                else
                    _bitmap.SetPixel(x, zDraw, Color.Black);
            }
        }

        _bitmap.Save(@"C:\Users\Stridemann\Desktop\dbgAlgo.png");
    }
}

public partial class Solution
{
    public struct CellData
    {
        public static int ProcessMarkerCounter = 1;
        public int ProcessedMarker;
        public bool IsEmpty;
        public bool IsWater;
        public bool IsWall;
        public bool IsBox;
        public bool IsRemovedWater; //For debug purposes
    }

    //[DebuggerDisplay("[{X},{Z}]")]
    private struct Point
    {
        public int X;
        public int Z;

        public Point(int x, int z)
        {
            X = x;
            Z = z;
        }
    }

    //[DebuggerDisplay("{Pos}={Level}")]
    private struct OrderedPile : IComparable<OrderedPile>
    {
        public Point Pos;
        public int Level;

        public OrderedPile(Point pos, int level)
        {
            Pos = pos;
            Level = level;
        }

        public int CompareTo(OrderedPile other)
        {
            return Level.CompareTo(other.Level);
        }
    }

    private CellData[,] _grid;
    private int _width;
    private int _length;
    private int[][] _heightMap;

    public int TrapRainWater(int[][] heightMap)
    {
        _heightMap = heightMap;
        _width = heightMap[0].Length;
        _length = heightMap.Length;
        _grid = new CellData[_width, _length];

        const int INIT_LEVEL = 1;
        var emptyQueue = new Queue<Point>();

        for (int z = 0; z < _length; z++)
        {
            emptyQueue.Enqueue(new Point(0, z));
            emptyQueue.Enqueue(new Point(_width - 1, z));
        }

        for (int x = 1; x < _width - 1; x++)
        {
            emptyQueue.Enqueue(new Point(x, 0));
            emptyQueue.Enqueue(new Point(x, _length - 1));
        }

        var orderedPiles = new List<OrderedPile>();

        while (emptyQueue.TryDequeue(out var point))
        {
            var x = point.X;
            var z = point.Z;
            ref CellData cellData = ref _grid[x, z];

            if (cellData.ProcessedMarker == CellData.ProcessMarkerCounter)
                continue;
            cellData.ProcessedMarker = CellData.ProcessMarkerCounter;

            var height = heightMap[z][x];
            var isWall = height >= INIT_LEVEL;

            if (isWall)
            {
                cellData.IsWall = true;

                //wall can disappear and destroy the water on this level
                if (height >= INIT_LEVEL)
                    orderedPiles.Add(new OrderedPile(new Point(x, z), height));
            }
            else
            {
                cellData.IsEmpty = true;

                if (x > 0)
                {
                    emptyQueue.Enqueue(new Point(x - 1, z));
                }

                if (x < _width - 1)
                {
                    emptyQueue.Enqueue(new Point(x + 1, z));
                }

                if (z > 0)
                {
                    emptyQueue.Enqueue(new Point(x, z - 1));
                }

                if (z < _length - 1)
                {
                    emptyQueue.Enqueue(new Point(x, z + 1));
                }
            }
        }

        var initialWaterAmount = 0;

        for (int z = 1; z < _length - 1; z++)
        {
            for (int x = 1; x < _width - 1; x++)
            {
                ref CellData cellData = ref _grid[x, z];

                if (cellData.ProcessedMarker == CellData.ProcessMarkerCounter)
                    continue;
                cellData.ProcessedMarker = CellData.ProcessMarkerCounter;
                //here will can be only WATER or BOX tiles

                var height = heightMap[z][x];
                var isBox = height >= INIT_LEVEL;

                if (isBox)
                {
                    cellData.IsBox = true;

                    //box can turn into a water
                    if (height >= INIT_LEVEL)
                        orderedPiles.Add(new OrderedPile(new Point(x, z), height));
                }
                else
                {
                    cellData.IsWater = true;
                    initialWaterAmount++;
                }
            }
        }
        
        var curWater = initialWaterAmount;
        var totalWater = initialWaterAmount;
        var prevLevel = 0;
        CellData.ProcessMarkerCounter++;

        foreach (var grouping in orderedPiles.GroupBy(x => x.Level).OrderBy(x => x.Key))
        {
            var levelDiff = grouping.Key - prevLevel - 1;

            if (levelDiff >= 1)
                totalWater += levelDiff * curWater;

            foreach (var orderedPile in grouping)
            {
                ref CellData cellData = ref _grid[orderedPile.Pos.X, orderedPile.Pos.Z];

                if (cellData.IsWall) //wall is destroyed. Check water around and destroy it
                {
                    #region Remove Water

                    CellData.ProcessMarkerCounter++;
                    TryRemoveWaterAroundCell(orderedPile, ref curWater);

                    #endregion

                    //TODO: mark around boxes as a wall
                    Box2Wall(orderedPile.Pos.X, orderedPile.Pos.Z);
                }
                else if (cellData.IsBox) //box disapper, now it is a water
                {
                    cellData.IsBox = false;
                    cellData.IsWater = true;
                    curWater++;
                }
            }
            
            prevLevel = grouping.Key;
            totalWater += curWater;
        }

        return totalWater;
    }

    private void TryRemoveWaterAroundCell(OrderedPile orderedPile, ref int curWater)
    {
        var waterRemoveQueue = new Queue<Point>();
        var x = orderedPile.Pos.X;
        var z = orderedPile.Pos.Z;

        if (x > 0)
        {
            waterRemoveQueue.Enqueue(new Point(x - 1, z));
        }

        if (x < _width - 1)
        {
            waterRemoveQueue.Enqueue(new Point(x + 1, z));
        }

        if (z > 0)
        {
            waterRemoveQueue.Enqueue(new Point(x, z - 1));
        }

        if (z < _length - 1)
        {
            waterRemoveQueue.Enqueue(new Point(x, z + 1));
        }

        while (waterRemoveQueue.TryDequeue(out var possibleWaterPoint))
        {
            ref CellData cell2Data = ref _grid[possibleWaterPoint.X, possibleWaterPoint.Z];

            if (cell2Data.ProcessedMarker == CellData.ProcessMarkerCounter)
                continue;
            cell2Data.ProcessedMarker = CellData.ProcessMarkerCounter;

            if (cell2Data.IsWater)
            {
                cell2Data.IsWater = false;
                cell2Data.IsRemovedWater = true;
                curWater--;
                x = possibleWaterPoint.X;
                z = possibleWaterPoint.Z;

                if (x > 0)
                {
                    waterRemoveQueue.Enqueue(new Point(x - 1, z));
                }

                if (x < _width - 1)
                {
                    waterRemoveQueue.Enqueue(new Point(x + 1, z));
                }

                if (z > 0)
                {
                    waterRemoveQueue.Enqueue(new Point(x, z - 1));
                }

                if (z < _length - 1)
                {
                    waterRemoveQueue.Enqueue(new Point(x, z + 1));
                }
            }
            else if (cell2Data.IsBox)
            {
                cell2Data.IsBox = false;
                cell2Data.IsWall = true;
            }
        }
    }

    private void Box2Wall(int x, int z)
    {
        static void Turn(ref CellData cell)
        {
            if (cell.IsBox)
            {
                cell.IsBox = false;
                cell.IsWall = true;
            }
        }

        if (x > 0)
        {
            Turn(ref _grid[x - 1, z]);
        }

        if (z > 0)
        {
            Turn(ref _grid[x, z - 1]);
        }

        if (x < _width - 1)
        {
            Turn(ref _grid[x + 1, z]);
        }

        if (z < _length - 1)
        {
            Turn(ref _grid[x, z + 1]);
        }
    }
}
