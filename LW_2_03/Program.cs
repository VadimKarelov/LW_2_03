using System;

namespace LW_2_03
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal a = 0.1m;
            decimal b = 1;
            int k = 10;
            decimal e = 0.0001m;
            int n = 25;
            decimal step = (b - a) / k;

            for (decimal x = a; x <= b; x += step)
            {
                decimal SN = 0, SE = 0, prevSE = 1;
                ulong factorial = 1;
                decimal pow = 1;
                // SN
                for (uint i = 0; i < n; i++)
                {
                    SN += (decimal)Math.Cos(i * Math.PI / 4) / factorial * pow;
                    if (i != 0)
                    {
                        factorial *= i;
                        pow *= x;
                    }
                }
                // SE
                factorial = 1;
                pow = 1;
                for (uint i = 0; Math.Abs(prevSE - SE) > e; i++)
                {
                    prevSE = SE;
                    SE += (decimal)Math.Cos(i * Math.PI / 4) / factorial * pow;
                    if (i != 0)
                    {
                        factorial *= i;
                        pow *= x;
                    }
                }
                Console.WriteLine($"X = {x:0.000000} SN = {SN:0.000000} SE = {SE:0.000000} Y = {F(x):0.000000}");
            }
        }

        static double F(decimal x)
        {
            return Math.Exp((double)x * Math.Cos(Math.PI / 4)) * Math.Cos((double)x * Math.Sin(Math.PI / 4));
        }
    }
}