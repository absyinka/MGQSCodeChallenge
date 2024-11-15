using System;

namespace BasicApp.Shared;

public static class Helper
{
    public static string GenerateCode(int id)
    {
        return $"EMP-{id:0000}";
    }

    public static int SelectEnum(string screenMessage, int validStart, int validEnd)
    {
        int outValue;

        while (true)
        {
            Console.Write(screenMessage);

            if (int.TryParse(Console.ReadLine(), out outValue) && outValue >= validStart && outValue <= validEnd)
            {
                break;
            }
        }

        return outValue;
    }

    public static void SuccessTextOutput(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void FailureTextOutput(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: {0}", text);
        Console.ResetColor();
        Console.WriteLine();
    }

    public static void InfoTextOutput(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text);
        Console.ResetColor();
        Console.WriteLine();
    }


    // public static int SelectEnum(string screenMessage, int validStart, int validEnd)
    // {
    //     int outValue;
    //     do
    //     {
    //         Console.Write(screenMessage);
    //     } while (!(int.TryParse(Console.ReadLine(), out outValue) && IsValid(outValue, validStart, validEnd)));

    //     return outValue;
    // }

    // public static bool IsValid(int outValue, int start, int end)
    // {
    //     return outValue >= start && outValue <= end;
    // }
}