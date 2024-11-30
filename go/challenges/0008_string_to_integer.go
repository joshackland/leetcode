package main

import (
	"fmt"
	"math"
	"unicode"
)

func myAtoi(s string) int {
	index := 0
	isPositive := true
	result := 0
	length := len(s)

	for index < length && s[index] == ' ' {
		index++
	}

	if index < length && (s[index] == '+' || s[index] == '-') {
		if s[index] == '-' {
			isPositive = false
		}
		index++
	}

	for index < length && unicode.IsDigit(rune(s[index])) {
		num := int(s[index] - '0')
		fmt.Println(num)

		if result > (math.MaxInt32-num)/10 {
			if isPositive {
				return math.MaxInt32
			}
			return math.MinInt32
		}

		result = result*10 + num
		index++
	}

	if !isPositive {
		result *= -1
	}

	return result
}

func main0008() {
	input := "42"
	expectedResult := 42

	result := myAtoi(input)
	fmt.Println("Result:", result)
	fmt.Println("Expected:", expectedResult)
}
