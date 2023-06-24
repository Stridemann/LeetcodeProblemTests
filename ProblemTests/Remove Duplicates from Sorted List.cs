using System.Collections;
using System.Xml.Linq;

public class Remove_Duplicates_from_Sorted_List
{
    [Theory]
    [ClassData(typeof(CalculatorTestData))]
    public void Test(ListNode head)
    {
        var s = new Solution();
        var result = s.DeleteDuplicates(head);
    }
}

public class CalculatorTestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[] { new ListNode(1, new ListNode(1, new ListNode(2))) };
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Solution
{
public ListNode DeleteDuplicates(ListNode head)
{
    ListNode? cur = head;

    while (cur != null)
    {
        while (cur.next != null && cur.val == cur.next.val)
        {
            cur.next = cur.next.next;
        }

        cur = cur.next;
    }

    return head;
}
}
