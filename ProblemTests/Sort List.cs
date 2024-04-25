public class Sort_List
{
    [Theory]
    [InlineData("[4,2,1,3]", "[1,2,3,4]")]
    public void Test(string headStr, string expected)
    {
        var s = new Solution();
        var head = ListNode.FromString(headStr);
        var result = s.SortList(head);
        result.PrintMe.ShouldBe(expected);
    }
}

public class Solution
{
    public ListNode SortList(ListNode head)
    {
        var nodesList = new List<ListNode>();

        for (var iterator = head; iterator != null; iterator = iterator.next)
        {
            nodesList.Add(iterator);
        }

        ListNode prev = null;
        head = null;

        foreach (ListNode listNode in nodesList.OrderBy(x => x.val))
        {
            if (head == null)
                head = listNode;

            if (prev != null)
            {
                prev.next = listNode;
            }

            prev = listNode;
        }

        if (prev != null)
            prev.next = null;

        return head;
    }
}
