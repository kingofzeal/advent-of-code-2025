# Day 4: Printing Department - GitHub Copilot Solution

## Problem Summary

The puzzle involves a grid of paper rolls (@) arranged at a printing department. Forklifts can only access rolls that have fewer than 4 rolls in their 8 adjacent positions.

**Part 1**: Count how many rolls can be accessed by forklifts.

**Part 2**: Simulate repeatedly removing accessible rolls until no more can be removed, and count the total removed.

## Solution Approach

1. **Part 1**: Iterate through the grid and count rolls where the number of adjacent rolls is less than 4.

2. **Part 2**: Use a simulation that repeatedly:
   - Finds all currently accessible rolls
   - Removes them all in one pass
   - Repeats until no more rolls can be removed

## Results

- **Sample Input**: Part 1 = 13, Part 2 = 43 ✓
- **Puzzle Input**: Part 1 = 1409, Part 2 = 8366

## Performance

Execution time: ~12ms
