package main

import "fmt"

func longestPalindrome(s string) string {

	maxLength := 0
	startIndex := 0

	findPalindrome := func(left, right int) {
		for left >= 0 && right < len(s) && s[left] == s[right] {
			if right-left+1 > maxLength {
				startIndex = left
				maxLength = right - left + 1
			}

			left--
			right++
		}
	}

	for i := 0; i < len(s); i++ {
		findPalindrome(i, i)
		findPalindrome(i, i+1)
	}

	return s[startIndex : startIndex+maxLength]
}

func main0005() {
	input := "babad"
	expectedResult := "bab"

	result := longestPalindrome(input)
	fmt.Println("Result:", result)
	fmt.Println("Expected:", expectedResult)

	input = "cbbd"
	expectedResult = "bb"

	result = longestPalindrome(input)
	fmt.Println("Result:", result)
	fmt.Println("Expected:", expectedResult)
}
