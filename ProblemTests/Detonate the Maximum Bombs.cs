using System.Drawing;

public class Detonate_the_Maximum_Bombs
{
    [Theory]
    [InlineData("[[2,1,3],[6,1,4]]", 2)]
    [InlineData("[[1,1,5],[10,10,5]]", 1)]
    [InlineData("[[1,2,3],[2,3,1],[3,4,2],[4,5,3],[5,6,4]]", 5)]
    [InlineData(
        "[[868,658,84],[82,386,48],[464,157,11],[422,654,85],[864,418,84],[366,314,72],[955,270,60],[460,98,60],[824,147,38],[580,660,27],[423,102,73],[317,471,74]]",
        3)]
    [InlineData("[[464,157,11],[460,98,60],[423,102,73]]", 3)]
    [InlineData("[[37207,2653,5261],[40784,59523,20635],[16390,1426,39102],[42236,12,96855],[72839,62027,61667],[60691,58191,48447],[42932,46579,41248],[35868,43119,6870],[41693,98905,17374],[43441,1266,41621]]", 10)]
    [InlineData("[[855,82,158],[17,719,430],[90,756,164],[376,17,340],[691,636,152],[565,776,5],[464,154,271],[53,361,162],[278,609,82],[202,927,219],[542,865,377],[330,402,270],[720,199,10],[986,697,443],[471,296,69],[393,81,404],[127,405,177]]", 9)]
    public void Test(string arrStr, int expected)
    {
        var arr = ArrayUtils.ArrayFromStr(arrStr);
        var dbg = MatheretterUtils.CirclesCfgFromArray(arr);
        var s = new Solution();
        s.MaximumDetonation(arr).ShouldBe(expected);
    }
}

public class Solution
{
    private int _bombsAmount;
    private bool[,] _ajTable;
    private byte[] _bombLayerInfo;
    private byte _processCounter;

    public int MaximumDetonation(int[][] bombs)
    {
        _bombsAmount = bombs.Length;

        if (_bombsAmount <= 1)
            return _bombsAmount;

        _ajTable = new bool[_bombsAmount, _bombsAmount];
        _bombLayerInfo = new byte[_bombsAmount];

        for (var b1i = 0; b1i < _bombsAmount; b1i++)
        {
            var b1 = bombs[b1i];
            double b1r = b1[2];
            b1r *= b1r;

            for (int b2i = b1i + 1; b2i < _bombsAmount; b2i++)
            {
                var b2 = bombs[b2i];
                double b2r = b2[2];
                b2r *= b2r;
                var dist = Math.Pow(b2[0] - b1[0], 2) + Math.Pow(b2[1] - b1[1], 2);

                if (dist <= b1r)
                {
                    _ajTable[b1i, b2i] = true;
                }

                if (dist <= b2r)
                {
                    _ajTable[b2i, b1i] = true;
                }
            }
        }

        var maxBombs = 1;

        for (int i = 0; i < _bombsAmount; i++)
        {
            _processCounter++;
            var curBombs = 0;
            ProcessBomb(i, ref curBombs);
            maxBombs = Math.Max(maxBombs, curBombs);
        }

        return maxBombs;
    }

    private void ProcessBomb(int bombIndex, ref int bombAmount)
    {
        ref byte processedId = ref _bombLayerInfo[bombIndex];

        var isProcessed = processedId == _processCounter;

        if (isProcessed)
        {
            return;
        }

        bombAmount++;
        processedId = _processCounter;

        for (int connBombId = 0; connBombId < _bombsAmount; connBombId++)
        {
            var connBomb = _ajTable[bombIndex, connBombId];

            if (!connBomb)
                continue;

            ProcessBomb(connBombId, ref bombAmount);
        }
    }
}

//public class Solution
//{
//    private int _bombsAmount;
//    private ValueTuple<bool, bool>[,] _ajTable;
//    private byte[] _bombLayerInfo;
//    private byte _processCounter;

//    public int MaximumDetonation(int[][] bombs)
//    {
//        _bombsAmount = bombs.Length;

//        if (_bombsAmount <= 1)
//            return _bombsAmount;

//        _ajTable = new ValueTuple<bool, bool>[_bombsAmount, _bombsAmount];
//        _bombLayerInfo = new byte[_bombsAmount];

//        for (var b1i = 0; b1i < _bombsAmount; b1i++)
//        {
//            var b1 = bombs[b1i];
//            double b1r = b1[2];
//            b1r *= b1r;

//            for (int b2i = b1i + 1; b2i < _bombsAmount; b2i++)
//            {
//                var b2 = bombs[b2i];
//                double b2r = b2[2];
//                b2r *= b2r;
//                var dist = Math.Pow(b2[0] - b1[0], 2) + Math.Pow(b2[1] - b1[1], 2);

//                ref ValueTuple<bool, bool> fw = ref _ajTable[b1i, b2i];
//                ref ValueTuple<bool, bool> bw = ref _ajTable[b2i, b1i];

//                if (dist <= b1r)
//                {
//                    fw.Item1 = true;
//                    bw.Item2 = true;
//                }

//                if (dist <= b2r)
//                {
//                    fw.Item2 = true;
//                    bw.Item1 = true;
//                }
//            }
//        }

//        var maxBombs = 1;
//        _processCounter++;

//        for (int i = 0; i < _bombsAmount; i++)
//        {
//            maxBombs = Math.Max(maxBombs, ProcessBomb(i));
//        }

//        return maxBombs;
//    }

//    private int ProcessBomb(int bombIndex)
//    {
//        ref byte processedId = ref _bombLayerInfo[bombIndex];

//        var isProcessed = processedId == _processCounter;

//        if (isProcessed)
//        {
//            return 0;
//        }

//        processedId = _processCounter;
//        var curBombs = 1;
//        var parentMax = 0;

//        for (int connBombId = 0; connBombId < _bombsAmount; connBombId++)
//        {
//            var connBomb = _ajTable[bombIndex, connBombId];

//            if (connBomb.Item1)
//            {
//                //BFS
//                curBombs += ProcessBomb(connBombId);
//            }

//            if (connBomb.Item2)
//            {
//                parentMax = Math.Max(parentMax, ProcessBomb(connBombId));
//            }
//        }

//        return curBombs + parentMax;
//    }
//}
