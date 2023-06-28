using System.Collections;

public class Linked_List_Random_Node
{
    [Theory]
    [InlineData("[5]", "[5]", "[0,1]")]
    public void Test(string headStr, string expected)
    {
        var s = new Solution();
        var head = ListNode.FromString(headStr);
        var result = s.RemoveNthFromEnd(head);
        result.PrintMe.ShouldBe(expected);
    }
}

public class Solution
{
    private ListNode? _node;
    private int _max;
    private int _randIter;
    private ListNode _head;

    public Solution(ListNode head)
    {
        _head = head;
        _node = head;
    }

    public int GetRandom()
    {
        if (_node == null)
        {
            _node = _head;
        }

        var nodeVal = _node.val;
        _node = _node.next;
        _max++;

        return nodeVal;
    }
}