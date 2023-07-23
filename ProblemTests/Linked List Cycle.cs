using System.Collections;

public class Linked_List_Cycle
{
    [Theory]
    [InlineData("[3,2,0,-4]", true)]
    [InlineData("[1]", false)]
    public void Test(string headStr, bool expected)
    {
        var s = new Solution();
        var head = ListNode.FromString(headStr);
        var result = s.HasCycle(head);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool HasCycle(ListNode head)
    {
        if (head == null)
            return false;
        var slow = head;
        var fast = head.next;

        while (slow != fast && fast != null)
        {
            slow = slow.next;
            fast = fast.next?.next;
        }

        return slow == fast;
    }
}
