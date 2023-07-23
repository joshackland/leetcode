namespace LeetCode.Challenges._0021MergeTwoSortedLists
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
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode sortedHead = new ListNode();
        ListNode sorted = new ListNode();

        if (list1 == null && list2 == null) return null;
        else if (list1 == null || list2 == null) 
        {
            if (list1 == null) return list2;
            return list1;
        }

        if (list1.val <= list2.val) 
        {
            sortedHead.val = list1.val;
            list1 = list1.next;
        }
        else
        {
            sortedHead.val = list2.val;
            list2 = list2.next;
        }

        sorted = sortedHead;

        while (!(list1 == null && list2 == null))
        {
            sorted.next = new ListNode();

            if (list2 == null || list1 != null && list1.val <= list2.val)
            {
                sorted.next.val = list1.val;
                list1 = list1.next;
            }
            else
            {
                sorted.next.val = list2.val;
                list2 = list2.next;
            }

            sorted = sorted.next;
        }

        return sortedHead;
    }
}

public static class _0021MergeTwoSortedLists
{
    private static List<List<int>> List1 = new List<List<int>>()
    {
        new List<int> { 1,2,4 },
        new List<int> {  },
        new List<int> {  },
    };

    private static List<List<int>> List2 = new List<List<int>>()
    {
        new List<int> { 1,3,4 },
        new List<int> {  },
        new List<int> { 0 },
    };
    private static List<List<int>> ExpectedOutputs = new List<List<int>>
    {
        new List<int> { 1,1,2,3,4,4 },
        new List<int> {  },
        new List<int> { 0 },
    };

    public static void Test()
    {
        var solution = new Solution();

        for (int i = 0; i < List1.Count; i++)
        {
            ListNode inputList1 = null;
            if (List1[i].Count > 0)
            {
                inputList1 = new ListNode(List1[i][0]);
                ListNode prevNode1 = inputList1;
                for (int j = 1; j < List1[i].Count; j++)
                {
                    var newNode = new ListNode(List1[i][j]);
                    prevNode1.next = newNode;
                    prevNode1 = newNode;
                }
            }

            ListNode inputList2 = null;
            if (List2[i].Count > 0)
            {
                inputList2 = new ListNode(List2[i][0]);
                ListNode prevNode2 = inputList2;
                for (int j = 1; j < List2[i].Count; j++)
                {
                    var newNode = new ListNode(List2[i][j]);
                    prevNode2.next = newNode;
                    prevNode2 = newNode;
                }
            }

            ListNode expectedOutput = null;
            if (ExpectedOutputs[i].Count > 0)
            {
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
            }

            
            var actualOutput = solution.MergeTwoLists(inputList1, inputList2);
            Console.WriteLine($"List1: {string.Join(',', List1[i])}, List2: {string.Join(',', List2[i])} Expected Output: {PrintNodeValues(expectedOutput)} Actual Output: {PrintNodeValues(actualOutput)}");
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