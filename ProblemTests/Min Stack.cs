public class Min_Stack
{
    [Fact]
    public void Test1()
    {
        var minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        minStack.GetMin().ShouldBe(-3);
        minStack.Pop();
        minStack.Top().ShouldBe(0);
        minStack.GetMin().ShouldBe(-2);
    }

    [Fact]
    public void Test2()
    {
        var minStack = new MinStack();
        minStack.Push(2);
        minStack.Push(0);
        minStack.Push(3);
        minStack.Push(0);
        minStack.GetMin().ShouldBe(0);
        minStack.Pop();
        minStack.GetMin().ShouldBe(0);
        minStack.Pop();
        minStack.GetMin().ShouldBe(0);
        minStack.Pop();
        minStack.GetMin().ShouldBe(2);
    }

    [Fact]
    public void Test3()
    {
        var minStack = new MinStack();
        minStack.Push(2147483646);
        minStack.Push(2147483646);
        minStack.Push(2147483647);
        var t0 = minStack.Top();
        minStack.Pop();
        var min1 = minStack.GetMin();
        minStack.Pop();
        var min2 = minStack.GetMin();
        minStack.Pop();
        minStack.Push(2147483647);
        var t1 = minStack.Top();
        //
        var min3 = minStack.GetMin();
        minStack.Push(-2147483648);
        var t2 = minStack.Top();
        var min4 = minStack.GetMin();
        minStack.Pop();
        var min5 = minStack.GetMin();
    }
}

public class MinStack
{
    List<int> _data;
    List<int> _mins;

    public MinStack()
    {
        _data = new List<int>();
        _mins = new List<int>();
    }

    public void Push(int x)
    {
        _data.Add(x);

        if (_mins.Count > 0)
            _mins.Add(Math.Min(x, _mins[^1]));
        else
            _mins.Add(x);
    }

    public void Pop()
    {
        if (_data.Count > 0)
        {
            _data.RemoveAt(_data.Count - 1);
            _mins.RemoveAt(_mins.Count - 1);
        }
    }

    public int Top()
    {
        if (_data.Count > 0)
            return _data[^1];

        return 0;
    }

    public int GetMin()
    {
        if (_mins.Count > 0)
            return _mins[^1];

        return 0;
    }
}
