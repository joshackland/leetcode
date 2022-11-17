/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {        
        for(ListNode node = l1; node != null; node=node.next){
            if (l2 != null){
                node.val += l2.val;
                
                l2 = l2.next;

                if (l2 != null && node.next == null){
                    node.next = new ListNode();
                }
            }

            if (node.val >= 10){
                node.val -= 10;

                if (node.next == null){
                    node.next = new ListNode();
                }
                node.next.val += 1;
            }
        }

        return l1;
    }
}