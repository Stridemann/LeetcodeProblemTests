public class Palindrome_Linked_List
{
    [Theory]
    [InlineData("[1,2,2,1]", true)]
    [InlineData("[1,2,3,4]", false)]
    [InlineData("[1,2,3,4,5]", false)]
    [InlineData("[1,2,3,2,1]", true)]
    [InlineData("[1,2]", false)]
    public void Test(string headStr, bool expected)
    {
        var s = new Solution();
        var head = ListNode.FromString(headStr);
        var result = s.IsPalindrome(head);
        result.ShouldBe(expected);
    }
}

public class Solution
{
    public bool IsPalindrome(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (slow.next != null && fast.next?.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        if (fast.next == null) //odd //1,2,3,4,5
        {
            var middle = slow;

            //reverse
            ListNode? prev = middle;
            var iter = middle.next;
            middle.next = null;

            while (iter != null)
            {
                var tmp = iter.next;
                iter.next = prev;
                prev = iter;
                iter = tmp;
            }

            var iter21 = head;
            var iter22 = prev;

            while (iter21 != null && iter22 != null)
            {
                if (iter21.val != iter22.val)
                    return false;

                iter21 = iter21.next;
                iter22 = iter22.next;
            }

            return true;
        }
        else //even  //1,2,3,4
        {
            var leftStart = slow;
            var rightStart = slow.next;

            //reverse
            ListNode? prev = null;
            var iter = rightStart;

            while (iter != null)
            {
                var tmp = iter.next;
                iter.next = prev;
                prev = iter;
                iter = tmp;
            }

            var iter21 = head;
            var iter22 = prev;

            while (iter21 != null && iter22 != null)
            {
                if (iter21.val != iter22.val)
                    return false;

                iter21 = iter21.next;
                iter22 = iter22.next;
            }

            return true;
        }

        return false;
    }
}
