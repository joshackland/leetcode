using System.Globalization;

namespace LeetCode.Challenges._0024SwapNodesInPairs

;
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
    public ListNode SwapPairs(ListNode head)
    {
        if (head is null) return null;
        if (head.next is null) return head;

        ListNode tmp = head;
        head = head.next;
        tmp.next = head.next;
        head.next = tmp;

        ListNode current = head.next;

        while (current.next != null && current.next.next != null)
        {
            tmp = current.next;
            current.next = current.next.next;
            tmp.next = current.next.next;
            current.next.next = tmp;

            current = current.next.next;
        }

        return head;
    }
}

public static class _0024SwapNodesInPairs
{
    private static List<List<int>> Inputs = new List<List<int>>()
    {
        new List<int> {1,2,3,4},
        new List<int> {},
        new List<int> {1}
    };

    private static List<List<int>> ExpectedOutputs = new List<List<int>>
    {
        new List<int> { 2,1,4,3 },
        new List<int> {  },
        new List<int> { 1 },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < Inputs.Count; i++)
        {
            ListNode input = null;
            if (Inputs[i].Count > 0)
            {
                input = new ListNode(Inputs[i][0]);
                ListNode prevNode = input;
                for (int j = 1; j < Inputs[i].Count; j++)
                {
                    var newNode = new ListNode(Inputs[i][j]);
                    prevNode.next = newNode;
                    prevNode = newNode;
                }
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

            var actualOutput = solution.SwapPairs(input);
            Console.WriteLine($"Input: {string.Join(',', Inputs[i])} Expected Output: {PrintNodeValues(expectedOutput)} Actual Output: {PrintNodeValues(actualOutput)}");
        }
    }

    public static string PrintListInts(List<int[]> ints)
    {
        string output = "{";

        foreach(var intArr in ints)
        {
            output += "[" + string.Join(',', intArr) + "]";
        }

        output += '}';
        return output;
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