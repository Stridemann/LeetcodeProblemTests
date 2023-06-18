using System.Diagnostics;

public class Reverse_Linked_List
{
    [Theory]
    [InlineData()]
    public void Test()
    {
        var s = new Solution();

        //var result = s.ReverseList(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))));
        var result2 = s.ReverseList(new ListNode(1));
    }
}

[DebuggerDisplay("{val}")]
public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode? ReverseList(ListNode? head)
    {
        if (head == null)
            return null;

        ListNode prev1 = head;
        ListNode cur2 = prev1.next;

        if (cur2 == null)
            return head;
        prev1.next = null;

        while (true)
        {
            var next = cur2.next;
            cur2.next = prev1;

            if (next == null)
            {
                return cur2;
            }

            prev1 = cur2;
            cur2 = next;
        }
    }
}
