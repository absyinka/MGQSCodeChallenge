using System;

namespace BasicApp;

public static class Helper
{
    public static string GenerateCode(int id)
    {
        return $"EMP-{id.ToString("0000")}";
    }

    public static int SelectEnum(string screenMessage, int validStart, int validEnd)
    {
        int outValue;
        do
        {
            Console.Write(screenMessage);
        } while (!(int.TryParse(Console.ReadLine(), out outValue) && IsValid(outValue, validStart, validEnd)));

        return outValue;
    }

    public static bool IsValid(int outValue, int start, int end)
    {
        return outValue >= start && outValue <= end;
    }
}