package main

import "fmt"

func convert(s string, numRows int) string {
	if len(s) == 1 || len(s) < numRows || numRows == 1 {
		return s
	}

	rows := make([]string, numRows)
	currentRow := 0
	down := false
	output := ""

	for _, char := range s {
		rows[currentRow] += string(char)

		if currentRow == 0 || currentRow == numRows-1 {
			down = !down
		}

		if down {
			currentRow++
		} else {
			currentRow--
		}
	}

	for _, row := range rows {
		output += row
	}

	return output
}

func main0006() {
	input := "PAYPALISHIRING"
	rows := 4
	expectedResult := "PINALSIGYAHRPI"

	result := convert(input, rows)
	fmt.Println("Result:", result)
	fmt.Println("Expected:", expectedResult)
}
