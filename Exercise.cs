using System;
using Humanizer;

namespace BasicApp
{
    public class Exercise
    {
        public decimal NormalHourlyRate { get { return 25; } }
        public decimal OvertimeHourlyRate { get { return 10; } }
        public int HoursWorked { get; set; }
        public int OvertimeHours { get; set; }
        public int NoOfDaysWorked { get; set; }
        public decimal MonthlyGrossPay { get; set; }
        public decimal WeeklyGrossPay { get; set; }
        public decimal MonthlyNetPay { get; set; }
        public decimal Deduction { get; set; }
        const int MAXIMUMHOURSWORKED = 8;

        public decimal TaxCalculation(decimal monthlyGrossPay)
        {
            decimal taxRate = 0.00m;

            if (monthlyGrossPay <= 1000)
            {
                taxRate += monthlyGrossPay * 1.5m / 100;
            }
            else if (monthlyGrossPay > 1000 && monthlyGrossPay <= 2500)
            {
                taxRate += monthlyGrossPay * 2.5m / 100;
            }
            else if (monthlyGrossPay > 2500)
            {
                taxRate += monthlyGrossPay * 4.5m / 100;
            }

            return taxRate;
        }

        public string PaymentCalculations()
        {
            var hoursWorked = GetTotalNumberOfHoursWorked(NoOfDaysWorked);
            HoursWorked = hoursWorked.Item1;
            OvertimeHours = hoursWorked.Item2;

            MonthlyGrossPay = (NormalHourlyRate * HoursWorked) + (OvertimeHourlyRate * OvertimeHours);

            WeeklyGrossPay = MonthlyGrossPay / 4;

            MonthlyNetPay = MonthlyGrossPay - TaxCalculation(MonthlyGrossPay);

            Deduction = TaxCalculation(MonthlyGrossPay);

            return $"Normal Hours worked: {"hour".ToQuantity(HoursWorked)}\nOvertime Hours worked: {"hour".ToQuantity(OvertimeHours)}\nMonthly Gross: ${MonthlyGrossPay}\nTotal Deduction: ${Deduction}\nNet Payment: ${MonthlyNetPay}\nWeekly Gross: ${WeeklyGrossPay}"; 
        }

        public Tuple<int, int> GetTotalNumberOfHoursWorked(int noOfDaysWorked)
        {
            int sumOfNormalHoursWorked = 0;
            int sumOfOvertimeWorked = 0;
            int normalHoursWorked = 0;

            for (int i = 1; i <= noOfDaysWorked; i++)
            {
                Console.Write($"Enter hours worked for day {i}: ");
                int hoursWorked = int.Parse(Console.ReadLine());

                if(hoursWorked > 15)
                {
                    hoursWorked = 15;
                }
                
                if(hoursWorked > MAXIMUMHOURSWORKED)
                {
                    sumOfOvertimeWorked += hoursWorked - MAXIMUMHOURSWORKED;
                }
                normalHoursWorked += hoursWorked;

                sumOfNormalHoursWorked = normalHoursWorked - sumOfOvertimeWorked;
            }

            var result = new Tuple<int, int>(sumOfNormalHoursWorked, sumOfOvertimeWorked);
            return result;
        }
    }
}