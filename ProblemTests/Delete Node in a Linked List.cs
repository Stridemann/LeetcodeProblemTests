using Shouldly;

public class Delete_Node_in_a_Linked_List
{
    [Theory]
    [InlineData("[4,5,1,9]", 5, "[4,1,9]")]
    public void Test(string headStr, int start, string expected)
    {
        var s = new Solution();
        var head = ListNode.FromString(headStr);
        s.DeleteNode(head.FindNode(start));
        head.PrintMe.ShouldBe(expected);
    }
}

public class Solution
{
    public void DeleteNode(ListNode node)
    {
        for (var iter = node; iter != null; iter = iter.next)
        {
            iter.val = iter.next.val;

            if (iter.next.next == null)
            {
                iter.next = null;

                break;
            }
        }
    }
}
