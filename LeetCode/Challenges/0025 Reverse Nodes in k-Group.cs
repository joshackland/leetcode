using System.Globalization;

namespace LeetCode.Challenges.ReverseNodesInKGroup0025

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
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        if (head is null) return null;

        ListNode[] swap = new ListNode[k];

        if (ValidAmountOfNodes(head, k))
        {
            ListNode tmp = head;

            for (int i = 0; i < k; i++)
            {
                swap[swap.Length - 1 - i] = tmp;
                tmp = tmp.next;

                if (i != 0)
                {
                    swap[swap.Length - 1].next = swap[swap.Length - 1 - i].next;
                    swap[swap.Length - 1 - i].next = swap[swap.Length - i];
                }
            }

            head = swap[0];
        }
        else
        {
            return head;
        }

        ListNode current = swap[k-1];

        while (ValidAmountOfNodes(current.next, k))
        {
            ListNode tmp = current.next;

            for (int i = 0; i < k; i++)
            {
                swap[swap.Length - 1 - i] = tmp;
                tmp = tmp.next;

                if (i == k-1)
                {
                    current.next = swap[swap.Length - 1 - i];
                }

                if (i != 0)
                {
                    swap[swap.Length - 1].next = swap[swap.Length - 1 - i].next;
                    swap[swap.Length - 1 - i].next = swap[swap.Length - i];
                }
            }

            current = swap[k-1];
        }

        return head;
    }

    public bool ValidAmountOfNodes(ListNode current, int k)
    {
        bool valid = true;
        ListNode tmp = current;

        for (int i = 0; i < k; i++)
        {
            if (tmp is null)
            {
                valid = false;
                break;
            }

            tmp = tmp.next;
        }
        return valid;
    }
}

public static class ReverseNodesInKGroup0025
{
    private static List<List<int>> Inputs = new List<List<int>>()
    {
        new List<int> {1,2},
        new List<int> {1,2,3,4,5},
        new List<int> {1,2,3,4,5},
    };
    private static List<int> Ks = new List<int>()
    {
        2,
        2,
        3
    };

    private static List<List<int>> ExpectedOutputs = new List<List<int>>
    {
        new List<int> {2,1},
        new List<int> {2,1,4,3,5},
        new List<int> {3,2,1,4,5},
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

            var actualOutput = solution.ReverseKGroup(input, Ks[i]);
            Console.WriteLine($"Input: {string.Join(',', Inputs[i])}, K: {Ks[i]}, Expected Output: {PrintNodeValues(expectedOutput)} Actual Output: {PrintNodeValues(actualOutput)}");
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