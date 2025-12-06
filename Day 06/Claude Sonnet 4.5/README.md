# Day 06 Solution - Claude Sonnet 4.5

## Problem Summary

Day 6 involves parsing and solving Cephalopod math worksheets where problems are arranged in columns.

### Part 1
Problems are arranged vertically:
- Each column contains one problem
- Numbers are multi-digit values stacked vertically
- The operator (*or +) is at the bottom of each column
- Problems are separated by columns of spaces
- Calculate the sum of all problem results

### Part 2
Cephalopod math is read right-to-left:
- Process columns from right to left
- Each column represents one number
- Digits in a column are read top-to-bottom (most significant digit at top)
- The operator is in the last row of its column
- Problems are still separated by columns of spaces
- Calculate the sum of all problem results

## Solution Approach

**Part 1:**
1. Parse the input into a 2D grid
2. Identify column blocks (separated by empty columns)
3. For each block, extract numbers and the operator
4. Compute the result and sum all problems

**Part 2:**
1. Parse the input into a 2D grid
2. Process columns from right to left
3. For each column, read digits top-to-bottom to form a number
4. Accumulate numbers until finding an operator (marks end of problem)
5. Compute results and sum all problems

## Results

- Part 1: 6957525317641
- Part 2: 13215665360076
- Execution time: ~10ms

## Key Insights

- Part 2's "right-to-left" reading means processing columns in reverse order
- Each column in Part 2 represents a complete number (not a digit)
- Vertical reading with "most significant at top" means concatenating digits from top row to bottom row
- Empty columns serve as problem separators in both parts
