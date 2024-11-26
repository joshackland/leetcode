package main

import "fmt"

type ListNode struct {
	Val  int
	Next *ListNode
}

func addTwoNumbers(l1 *ListNode, l2 *ListNode) *ListNode {
	result := &ListNode{}
	current := result
	carry := 0

	for l1 != nil || l2 != nil || carry != 0 {
		sum := carry

		if l1 != nil {
			sum += l1.Val
			l1 = l1.Next
		}

		if l2 != nil {
			sum += l2.Val
			l2 = l2.Next
		}

		carry = sum / 10
		sum = sum % 10
		fmt.Println(sum)
		current.Next = &ListNode{Val: sum}
		current = current.Next
	}

	return result.Next
}

func listNodeToArray(head *ListNode) []int {
	result := []int{}

	for head != nil {
		result = append(result, head.Val)
		head = head.Next
	}

	return result
}

func main0002() {
	l1Nums := []int{2, 4, 3}
	l2Nums := []int{5, 6, 4}
	expectedResult := []int{7, 0, 8}

	var l1 *ListNode
	var l2 *ListNode

	for i := len(l1Nums) - 1; i >= 0; i-- {
		l1 = &ListNode{Val: l1Nums[i], Next: l1}
	}

	for i := len(l2Nums) - 1; i >= 0; i-- {
		l2 = &ListNode{Val: l2Nums[i], Next: l2}
	}

	result := addTwoNumbers(l1, l2)
	fmt.Println("Result:", listNodeToArray(result))
	fmt.Println("Expected:", expectedResult)
}
