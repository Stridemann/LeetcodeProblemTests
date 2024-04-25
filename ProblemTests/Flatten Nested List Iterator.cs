public class NestedIterator
{
    private readonly Stack<NestedInteger> _stack = new Stack<NestedInteger>();
    private IEnumerator<NestedInteger>? _enumerator;
    private int? _value;

    public NestedIterator(IList<NestedInteger> nestedList)
    {
        for (var i = nestedList.Count - 1; i >= 0; i--)
        {
            var nestedInteger = nestedList[i];
            _stack.Push(nestedInteger);
        }

        MoveNext();
    }

    private void MoveNext()
    {
        while (_stack.TryPop(out var iter))
        {
            if (iter.IsInteger())
            {
                _value = iter.GetInteger();

                break;
            }

            var list = iter.GetList();

            for (var i = list.Count - 1; i >= 0; i--)
            {
                var nestedInteger = list[i];
                _stack.Push(nestedInteger);
            }
        }
    }

    public bool HasNext()
    {
        return _value.HasValue;
    }

    public int Next()
    {
        if (_value.HasValue)
        {
            var val = _value.Value;
            _value = null;
            MoveNext();

            return val;
        }

        return -999;
    }
}

public interface NestedInteger
{
    // @return true if this NestedInteger holds a single integer, rather than a nested list.
    bool IsInteger();

    // @return the single integer that this NestedInteger holds, if it holds a single integer
    // Return null if this NestedInteger holds a nested list
    int GetInteger();

    // @return the nested list that this NestedInteger holds, if it holds a nested list
    // Return null if this NestedInteger holds a single integer
    IList<NestedInteger> GetList();
}
