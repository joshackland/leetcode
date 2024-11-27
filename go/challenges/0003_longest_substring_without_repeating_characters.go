package main

import "fmt"

func lengthOfLongestSubstring(s string) int {
	maxLength := 0
	start := 0
	charIndex := make(map[byte]int)

	for i := 0; i < len(s); i++ {
		if lastIndex, exists := charIndex[s[i]]; exists && lastIndex >= start {
			start = lastIndex + 1
		}

		charIndex[s[i]] = i

		currentLength := i - start + 1

		if currentLength > maxLength {
			maxLength = currentLength
		}
	}

	return maxLength
}

func main0003() {
	input := "abcabcbb"
	expectedResult := 3

	result := lengthOfLongestSubstring(input)
	fmt.Println("Result:", result)
	fmt.Println("Expected:", expectedResult)
}
