using System;
using Humanizer;

namespace BasicApp.CalculatorConsole;

public class WageCalculator
{
    public static decimal NormalHourlyRate => 25;
    public static decimal OvertimeHourlyRate => 10;
    public int HoursWorked { get; set; }
    public int OvertimeHours { get; set; }
    public int NoOfDaysWorked { get; set; }
    public decimal MonthlyGrossPay { get; set; }
    public decimal WeeklyGrossPay { get; set; }
    public decimal MonthlyNetPay { get; set; }
    public decimal Deduction { get; set; }
    const int MAXIMUM_HOURS_PER_DAY = 8;

    public string PaymentCalculations()
    {
        Console.Title = "Wages Calculator";
        Console.WriteLine("======THE WAGES CALCULATOR=====");
        Console.Write("Enter number of days worked: ");
        NoOfDaysWorked = int.Parse(Console.ReadLine());

        var (totalNormalHours, totalOvertimeHours) = GetTotalNumberOfHoursWorked(NoOfDaysWorked);
        HoursWorked = totalNormalHours;
        OvertimeHours = totalOvertimeHours;

        MonthlyGrossPay = (NormalHourlyRate * HoursWorked) + (OvertimeHourlyRate * OvertimeHours);
        WeeklyGrossPay = MonthlyGrossPay / 4;
        MonthlyNetPay = MonthlyGrossPay - TaxCalculation(MonthlyGrossPay);
        Deduction = TaxCalculation(MonthlyGrossPay);

        return $"""
                Normal Hours worked: {"hour".ToQuantity(HoursWorked)}
                Overtime Hours worked: {"hour".ToQuantity(OvertimeHours)}
                Monthly Gross: ${MonthlyGrossPay}
                Total Deduction: ${Deduction}
                Net Payment: ${MonthlyNetPay}
                Weekly Gross: ${WeeklyGrossPay}
                """;
    }

    private decimal TaxCalculation(decimal grossPay)
    {
        if (grossPay <= 1000)
        {
            return grossPay * 0.015m;
        }
        else if (grossPay <= 2500)
        {
            return grossPay * 0.025m;
        }
        else
        {
            return grossPay * 0.045m;
        }
    }

    private (int, int) GetTotalNumberOfHoursWorked(int daysWorked)
    {
        int totalNormalHours = 0;
        int totalOvertimeHours = 0;

        for (int i = 1; i <= daysWorked; i++)
        {
            Console.Write($"Enter hours worked for day {i}: ");
            int hoursWorked = int.Parse(Console.ReadLine());

            // if(hoursWorked > 15)
            // {
            //     hoursWorked = 15;
            // }

            hoursWorked = Math.Min(hoursWorked, 15);

            if (hoursWorked > MAXIMUM_HOURS_PER_DAY)
            {
                totalNormalHours += MAXIMUM_HOURS_PER_DAY;
                totalOvertimeHours += hoursWorked - MAXIMUM_HOURS_PER_DAY;
            }
            else
            {
                totalNormalHours += hoursWorked;
            }
        }

        return (totalNormalHours, totalOvertimeHours);
    }
}
