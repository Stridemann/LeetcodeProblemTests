using System.Collections;

public class Linked_List_Cycle
{
    [Theory]
    [InlineData("[3,2,0,-4]", true)]
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
        for (var temp = head; temp != null; temp = temp.next)
        {
            if (temp.val == 99999)
                return true;
            temp.val = 99999;
        }

        return false;
    }
}