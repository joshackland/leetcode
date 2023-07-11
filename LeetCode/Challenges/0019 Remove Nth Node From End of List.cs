namespace LeetCode.Challenges.RemoveNthNodeFromEndOfLIst0019;
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
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode currentNode = head;
        List<ListNode> list = new List<ListNode>();

        while (currentNode != null)
        {
            list.Add(currentNode);
            currentNode = currentNode.next;
        }

        if (list.Count == 1)
        {
            return null;
        }
        else if (list.Count == n)
        {
            return head.next;
        }

        list[list.Count - n - 1].next = list[list.Count - n].next;

        return head;
    }
}

public static class RemoveNthNodeFromEndOfLIst0019
{
    private static List<List<int>> Inputs = new List<List<int>>()
    {
        new List<int> { 1, 2 },
        new List<int> { 1, 2, 3, 4, 5 },
        new List<int> { 1 },
        new List<int> { 1, 2 },
    };
    private static List<int> Ns = new List<int>
    {
        2,
        2,
        1,
        1
    };
    private static List<List<int>> ExpectedOutputs = new List<List<int>>
    {
        new List<int> { 2 },
        new List<int> { 1, 2, 3, 5 },
        new List<int> {  },
        new List<int> { 1 }
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            var input = new ListNode(Inputs[i][0]);
            ListNode prevNode = input;
            for (int j = 1; j < Inputs[i].Count; j++)
            {
                var newNode = new ListNode(Inputs[i][j]);
                prevNode.next = newNode;
                prevNode = newNode;
            }

            ListNode expectedOutput = null;
            if (ExpectedOutputs[i].Count > 0)
            {
                expectedOutput = new ListNode(ExpectedOutputs[i][0]);
                ListNode prevExpected = expectedOutput;
                for (int j = 1; j < ExpectedOutputs[i].Count; j++)
                {
                    var newNode = new ListNode(ExpectedOutputs[i][j]);
                    prevExpected.next = newNode;
                    prevExpected = newNode;
                }

            }

            
            var actualOutput = solution.RemoveNthFromEnd(input, Ns[i]);
            Console.WriteLine($"Input: {string.Join(',', Inputs[i])}, N: {Ns[i]} Expected Output: {PrintNodeValues(expectedOutput)} Actual Output: {PrintNodeValues(actualOutput)}");
        }
    }

    public static string PrintNodeValues(ListNode head)
    {
        if (head == null) return "(null)";

        string output = "";
        ListNode currentNode = head;

        while (currentNode != null)
        {
            output += currentNode.val + ", ";
            currentNode = currentNode.next;
        }

        return output;
    }
}