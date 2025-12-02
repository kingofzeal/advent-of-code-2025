using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;

class Program
{
    private static readonly string GeneratedBy = "Gemini 3 Pro (Preview)";

    static int Main()
    {
        Console.WriteLine("Advent of Code - Day 02");

        var folder = AppContext.BaseDirectory;
        // Adjust path to find the root of the day folder from bin/Release/net9.0
        // Day 02/Gemini/bin/Release/net9.0 -> Day 02
        var projectDir = Directory.GetParent(folder)!.Parent!.Parent!.Parent!.FullName;
        // Actually, the template uses 5 parents because it assumes running from bin/Release/net9.0 inside the project folder.
        // Let's verify the path depth.
        // c:\src\advent-of-code-2025\Day 02\Gemini\bin\Release\net9.0
        // Parent 1: Release
        // Parent 2: bin
        // Parent 3: Gemini
        // Parent 4: Day 02
        // So 4 parents to get to Day 02 root where input.txt is.
        // The template had 5 parents?
        // Template: var projectDir = Directory.GetParent(folder)!.Parent!.Parent!.Parent!.Parent!.FullName;
        // If folder is .../bin/Release/net9.0
        // 1: Release
        // 2: bin
        // 3: ProjectFolder (e.g. Gemini)
        // 4: DayFolder (e.g. Day 02)
        // 5: RepoRoot (e.g. advent-of-code-2025)
        
        // Wait, the template code says:
        // var projectDir = Directory.GetParent(folder)!.Parent!.Parent!.Parent!.Parent!.FullName;
        // And then: var inputPath = Path.Combine(projectDir, "input.txt");
        // But input.txt is in Day 02 root.
        // If I am in Day 02/Gemini/bin/Release/net9.0
        // 1. Release
        // 2. bin
        // 3. Gemini
        // 4. Day 02
        // So 4 parents gets me to Day 02.
        // The template might be assuming it's looking for the repo root?
        // "Shared files used by all implementations (example: `puzzle.txt`, `input.txt`) should live in the `Day XX` root."
        // So we want `Day 02`.
        // Let's stick to 4 parents if we are running from net9.0.
        
        // Let's be robust.
        var current = new DirectoryInfo(folder);
        while (current != null && !File.Exists(Path.Combine(current.FullName, "input.txt")))
        {
            current = current.Parent;
        }
        
        if (current == null)
        {
             // Fallback to standard relative path if search fails (though search should work if structure is correct)
             // Assuming standard structure: Day XX/Author/bin/Release/net9.0
             // We want Day XX
             current = Directory.GetParent(folder)!.Parent!.Parent!.Parent;
        }

        var dayDir = current!.FullName;

        var puzzlePath = Path.Combine(dayDir, "puzzle.txt");
        var inputPath = Path.Combine(dayDir, "input.txt");
        var samplePath = Path.Combine(dayDir, "sample.txt");
        var sampleExpectedPath = Path.Combine(dayDir, "sample.expected.txt");

        Console.WriteLine($"Day dir: {dayDir}");

        if (!File.Exists(inputPath))
        {
            Console.WriteLine("ERROR: input.txt not found. Please add your input to input.txt.");
            return 1;
        }

        var inputText = File.ReadAllText(inputPath);
        var sampleText = File.Exists(samplePath) ? File.ReadAllText(samplePath) : string.Empty;
        var sampleExpectedText = File.Exists(sampleExpectedPath) ? File.ReadAllText(sampleExpectedPath) : string.Empty;

        if (GeneratedBy == "REPLACE_WITH_MODEL_NAME")
        {
            Console.WriteLine("ERROR: GeneratedBy placeholder not replaced in Program.cs. Replace with model name used to generate this solution.");
            return 3;
        }

        try
        {            
            if (!string.IsNullOrEmpty(sampleText) || !string.IsNullOrEmpty(sampleExpectedText))
            {
                if (string.IsNullOrEmpty(sampleText) || string.IsNullOrEmpty(sampleExpectedText))
                {
                    Console.WriteLine("ERROR: sample.txt and sample.expected.txt must both be present for validation.");
                    return 4;
                }

                var sampleResult = Solve(sampleText);
                Console.WriteLine("-- Sample Result --");
                Console.WriteLine($"Sample Result: {sampleResult}");

                var normalizedExpected = sampleExpectedText.Replace("\r\n", "\n").Trim();
                var normalizedActual = sampleResult.Replace("\r\n", "\n").Trim();
                if (normalizedExpected != normalizedActual)
                {
                    Console.WriteLine("ERROR: Sample result did not match sample.expected.txt");
                    Console.WriteLine("Expected:\n" + normalizedExpected);
                    Console.WriteLine("Actual:\n" + normalizedActual);
                    return 5;
                }
                else
                {
                    Console.WriteLine("Sample validation passed.");
                }
            }

            var sw = Stopwatch.StartNew();
            var result = Solve(inputText);
            sw.Stop();

            Console.WriteLine($"Result: {result}");
            Console.WriteLine($"Elapsed: {sw.Elapsed}");
            Console.WriteLine($"Generated by: {GeneratedBy}");

            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during solve: {ex}");
            return 2;
        }
    }

    static string Solve(string input)
    {
        // Input format: "11-22,95-115,..."
        // Remove newlines just in case, though sample.txt might have them if not careful.
        // The instructions say "in your input, they appear on a single long line".
        // But sample.txt might have been created with newlines if I wasn't careful (I was).
        // But let's be safe and join lines if multiple.
        var cleanInput = string.Join("", input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries));
        
        var ranges = cleanInput.Split(',', StringSplitOptions.RemoveEmptyEntries);
        
        BigInteger part1Sum = 0;
        BigInteger part2Sum = 0;

        foreach (var range in ranges)
        {
            var parts = range.Split('-');
            if (parts.Length != 2) continue;

            if (long.TryParse(parts[0], out long start) && long.TryParse(parts[1], out long end))
            {
                for (long i = start; i <= end; i++)
                {
                    if (IsInvalidPart1(i))
                    {
                        part1Sum += i;
                    }
                    if (IsInvalidPart2(i))
                    {
                        part2Sum += i;
                    }
                }
            }
        }

        return $"Part 1: {part1Sum}\nPart 2: {part2Sum}";
    }

    static bool IsInvalidPart1(long n)
    {
        var s = n.ToString();
        if (s.Length % 2 != 0) return false;
        var half = s.Length / 2;
        return s.Substring(0, half) == s.Substring(half);
    }

    static bool IsInvalidPart2(long n)
    {
        var s = n.ToString();
        var len = s.Length;
        // We need a sequence repeated at least twice.
        // The length of the sequence 'k' must be a divisor of 'len'.
        // And 'k' must be <= len / 2.
        
        for (int k = 1; k <= len / 2; k++)
        {
            if (len % k == 0)
            {
                var sub = s.Substring(0, k);
                bool match = true;
                for (int i = k; i < len; i += k)
                {
                    if (string.Compare(s, i, sub, 0, k) != 0)
                    {
                        match = false;
                        break;
                    }
                }
                if (match) return true;
            }
        }
        return false;
    }
}
