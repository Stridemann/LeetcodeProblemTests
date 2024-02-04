public class Find_Median_from_Data_Stream
{
    [Fact]
    public void Test()
    {
        MedianFinder medianFinder = new MedianFinder();
        medianFinder.AddNum(1); // arr = [1]
        medianFinder.AddNum(2); // arr = [1, 2]
        medianFinder.FindMedian().ShouldBe(1.5f); // return 1.5 (i.e., (1 + 2) / 2)
        medianFinder.AddNum(3); // arr[1, 2, 3]
        medianFinder.FindMedian().ShouldBe(2.0); // return 2.0
    }

    [Fact]
    public void Test2()
    {
        MedianFinder medianFinder = new MedianFinder();
        medianFinder.AddNum(-1);
        medianFinder.FindMedian().ShouldBe(-1);
        medianFinder.AddNum(-2);
        medianFinder.FindMedian().ShouldBe(-1.5f);

        medianFinder.AddNum(-3);
        medianFinder.FindMedian().ShouldBe(-2f);

        medianFinder.AddNum(-4);
        medianFinder.FindMedian().ShouldBe(-2.5f);

        medianFinder.AddNum(-5);
        medianFinder.FindMedian().ShouldBe(-3f);
    }
}

public class MedianFinder
{
    private readonly PriorityQueue<int, int> _lowPq = new PriorityQueue<int, int>();
    private readonly PriorityQueue<int, int> _highPq = new PriorityQueue<int, int>();
    private double? _median;
    private int _total;

    public void AddNum(int num)
    {
        _total++;

        if (!_median.HasValue)
        {
            _lowPq.Enqueue(num, -num);

            _median = num;

            return;
        }

        if (num > _median)
        {
            _highPq.Enqueue(num, num);

            if (_highPq.Count > _lowPq.Count)
            {
                var balance = _highPq.Dequeue();
                _lowPq.Enqueue(balance, -balance);
            }
        }
        else
        {
            _lowPq.Enqueue(num, -num);

            if (_lowPq.Count > _highPq.Count + 1)
            {
                var balance = _lowPq.Dequeue();
                _highPq.Enqueue(balance, balance);
            }
        }

        if (_total % 2 == 1)
        {
            _median = _lowPq.Peek();
        }
        else
        {
            _median = (_lowPq.Peek() + _highPq.Peek()) * 0.5f;
        }
    }

    public double FindMedian()
    {
        return _median.Value;
    }
}
