package main

import (
	"fmt"
	"math"
)

func findMedianSortedArrays(nums1 []int, nums2 []int) float64 {
	smallNums := []int{}
	largeNums := []int{}

	if len(nums1) > len(nums2) {
		smallNums = nums2
		largeNums = nums1
	} else {
		smallNums = nums1
		largeNums = nums2
	}

	smallLength := len(smallNums)
	largeLength := len(largeNums)

	low := 0
	high := smallLength

	for low <= high {
		smallPartition := (low + high) / 2
		largePartition := (smallLength+largeLength+1)/2 - smallPartition

		leftSmallMax := math.MinInt64
		if smallPartition > 0 {
			leftSmallMax = smallNums[smallPartition-1]
		}

		rightSmallMin := math.MaxInt64
		if smallPartition < smallLength {
			rightSmallMin = smallNums[smallPartition]
		}

		leftLargeMax := math.MinInt64
		if largePartition > 0 {
			leftLargeMax = largeNums[largePartition-1]
		}

		rightLargeMin := math.MaxInt64
		if largePartition < largeLength {
			rightLargeMin = largeNums[largePartition]
		}

		if leftSmallMax <= rightLargeMin && leftLargeMax <= rightSmallMin {

			if (smallLength+largeLength)%2 == 1 {
				return float64(max(leftSmallMax, leftLargeMax))
			}

			return float64(max(leftSmallMax, leftLargeMax)+min(rightSmallMin, rightLargeMin)) / 2
		}

		if leftSmallMax > rightLargeMin {
			high = smallPartition - 1
		} else {
			low = smallPartition + 1
		}
	}

	return 0
}

func max(a, b int) int {
	if a < b {
		return b
	}
	return a
}
func min(a, b int) int {
	if a < b {
		return a
	}
	return b
}

func main0004() {
	nums1 := []int{1, 2}
	nums2 := []int{3, 4}
	expectedResult := 2.50000

	result := findMedianSortedArrays(nums1, nums2)
	fmt.Println("Result:", result)
	fmt.Println("Expected:", expectedResult)
}
