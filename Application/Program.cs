// See https://aka.ms/new-console-template for more information
using Application.Days;

Console.WriteLine("Welcome to Advent of Code 2023!");
Console.WriteLine("This is Robin's Unified Answer Application.");
Console.WriteLine("Please peruse the following options:");
Console.Write("Enter a Day (1-25):");

while (ReadInput(Console.ReadLine()) == false) { Console.Write("Enter a Day (1-25):"); }

static bool ReadInput (string? input)
{
    if (input is null || string.IsNullOrWhiteSpace(input)) return false;
    if (input == "exit" || input == "quit") return true;

    string[]? lines = null;
    try
    {
        lines = File.ReadAllLines($"./Input/Day{input}.txt");
    }
    catch (Exception ex)
    {    }

    if(lines is null)
    {
        Console.WriteLine(new string(input.Reverse().ToArray()));
        return false;
    }
    
    if (input == "1")
    {
        Console.WriteLine(new Day1.Solver().Solve(lines));
    }
    if(input == "2") Console.WriteLine(new Day2(12, 13, 14).Solve(lines));
    return false;
}