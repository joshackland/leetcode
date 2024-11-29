package main

import (
	"fmt"
	"math"
)

func reverse(x int) int {
	result := 0

	for x != 0 {
		num := x % 10

		x /= 10

		if result > (math.MaxInt32-num)/10 || result < (math.MinInt32-num)/10 {
			return 0
		}

		result = result*10 + num
	}

	return result
}

func main0007() {
	input := 123
	expectedResult := 321

	result := reverse(input)
	fmt.Println("Result:", result)
	fmt.Println("Expected:", expectedResult)
}
