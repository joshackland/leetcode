namespace LeetCode.Challenges._0061RotateList;

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
    public ListNode RotateRight(ListNode head, int k)
    {
        if (head is null) return null;
        if (head.next is null) return head;

        ListNode current = head;
        int total = 1;

        while (current.next != null)
        {
            current = current.next;
            total++;
        }

        int iterations = k % total;

        current = head;
        ListNode previous = current;

        for (int i = 0; i < iterations; i++)
        {
            while (current.next != null)
            {
                previous = current;
                current = current.next;
            }

            previous.next = null;
            current.next = head;
            head = current;
        }

        return head;
    }
}

public static class _0061RotateList
{
    private static List<List<int>> Inputs = new List<List<int>>()
    {
        new List<int> {1,2,3,4,5,},
        new List<int> {0,1,2},
    };
    private static List<int> Ks = new List<int>()
    {
        2,
        4,
    };

    private static List<List<int>> ExpectedOutputs = new List<List<int>>
    {
        new List<int> {4,5,1,2,3},
        new List<int> {2,0,1},
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

            var actualOutput = solution.RotateRight(input, Ks[i]);
            Console.WriteLine($"Input: {string.Join(',', Inputs[i])}, K: {Ks[i]}, Expected Output: {PrintNodeValues(expectedOutput)} Actual Output: {PrintNodeValues(actualOutput)}");
        }
    }

    public static string PrintListInts(List<int[]> ints)
    {
        string output = "{";

        foreach (var intArr in ints)
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