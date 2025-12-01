# Advent of Code 2025 - .NET Solutions

Conventions and workflow:

- Each day lives in a folder named `Day XX` (zero-padded, e.g., `Day 01`).
- Each day contains `puzzle.txt` (the problem statement), `input.txt` (your private input), a `.csproj`, and `Program.cs` which reads the files and prints solutions.
- The projects target `net9.0` and require the .NET SDK `9.0.304`.
- Use the provided `run.ps1` in a day's folder to build and run the solution in PowerShell.

Creating a new day from the template:

1. Copy the `Day 01` folder and rename it to `Day XX`.
2. Rename the `.csproj` to match the folder (optional) and update namespaces/filenames if you like.
3. Put the puzzle text in `puzzle.txt` and your input in `input.txt`.
4. Update `Program.cs` with that day's solving logic. Ensure sample inputs (if in `puzzle.txt`) produce the expected sample outputs.

Running a single day in PowerShell:

```powershell
cd "Day 05"
.\run.ps1
```

Running all days (simple loop):

```powershell
Get-ChildItem -Directory | ForEach-Object {
  Set-Location $_.FullName
  if (Test-Path run.ps1) { .\run.ps1 }
  Set-Location ..
}
```
