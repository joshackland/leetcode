package main

import "fmt"

func twoSum(nums []int, target int) []int {
	for i, num := range nums {
		for j, num2 := range nums[i+1:] {
			j += i + 1
			if num+num2 == target {
				return []int{i, j}
			}
		}
	}
	return nil
}

func main() {
	input := []int{2, 7, 11, 15}
	target := 9
	expectedResult := []int{0, 1}

	result := twoSum(input, target)
	fmt.Println("Result:", result)
	fmt.Println("Expected:", expectedResult)
}
