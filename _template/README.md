# Day Template

This `_template` folder contains a ready-to-copy project you can use to create each day's implementation.

Files in the template:
- `DayTemplate.csproj` — the .NET project file (rename to `DayXX.csproj` when copying, e.g., `Day01.csproj`).
- `Program.cs` — the template solver implementation.

Shared files (stored in `Day XX` root, not in the template):
- `puzzle.txt` — the official puzzle text (not parsed by the program, used by AI for understanding requirements).
- `input.txt` — your personal puzzle input (required).
- `sample.txt` and `sample.expected.txt` — example input and expected output for validation (both required together).

Important:
- The template's `Program.cs` contains a placeholder `REPLACE_WITH_MODEL_NAME`. Replace this with the actual model name used to generate the solution.
- The `Solve` function should return both Part 1 and Part 2 results formatted as: `Part 1: <answer>\nPart 2: <answer>`.
- If Part 2 is not yet available, use `Part 2: Not yet available` as a placeholder.

To create a new implementation:
1. Copy this `_template` folder into `Day XX\<Author>` (e.g., `Day 01\Claude Sonnet 4.5`).
2. Rename `DayTemplate.csproj` to `DayXX.csproj` (e.g., `Day01.csproj`).
3. Replace `REPLACE_WITH_MODEL_NAME` in `Program.cs` with the model name used for generating the solution.
4. Implement the day's `Solve` logic inside `Program.cs`.
5. Run with `dotnet run -c Release` from the implementation folder.
