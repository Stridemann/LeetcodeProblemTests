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
    private readonly List<ListNode> _nodes = new List<ListNode>();

    public Solution(ListNode head)
    {
        for (var current = head; current != null; current = current.next)
        {
            _nodes.Add(current);
        }
    }

    public int GetRandom()
    {
        var rand = new Random();
        return _nodes[rand.Next(_nodes.Count)].val;
    }
}
