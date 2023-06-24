using System.Diagnostics;

public class Merge_Two_Sorted_Lists
{
    [Theory]
    [InlineData()]
    public void Test()
    {
        var s = new Solution();

        var result = s.MergeTwoLists(
            new ListNode(1, new ListNode(2, new ListNode(4))),
            new ListNode(1, new ListNode(3, new ListNode(4))));
    }
}

[DebuggerDisplay("{val}")]
public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        if (list1 == null)
            return list2;

        if (list2 == null)
            return list1;

        ListNode dummy = new ListNode(0);
        ListNode cur = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                cur.next = list1;
                list1 = list1.next;
            }
            else
            {
                cur.next = list2;
                list2 = list2.next;
            }

            cur = cur.next;
        }

        cur.next = list1 ?? list2;

        GC.Collect();

        return dummy.next;
    }
}
