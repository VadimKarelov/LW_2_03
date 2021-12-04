using System;

namespace LW_2_03
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0.1;
            double b = 1;
            int k = 10;
            decimal e = 0.00000000000000001m; // 16
            int n = 25;
            double step = (b - a) / k;

            for (double x = a; x <= b; x += step)
            {
                double SN = 0;
                decimal SE = 0, prevSE = 1;
                ulong factorial = 1;
                double pow = 1;
                // SN
                for (uint i = 0; i < n; i++)
                {
                    if (i != 0)
                    {
                        factorial *= i;
                    }
                    SN += (pow * Math.Cos(i * Math.PI / 4)) / factorial;                    
                    pow *= x;
                }
                // SE
                factorial = 1;
                //pow = 1;
                decimal pow1 = 1;
                //for (uint i = 0; Math.Abs(prevSE - SE) > e; i++)
                for (uint i = 0; prevSE - SE > 0 && prevSE - SE > e || prevSE - SE < 0 && prevSE - SE < -e; i++)
                {
                    prevSE = SE;
                    if (i != 0)
                    {
                        factorial *= i;
                    }
                    SE += (pow1 * (decimal)Math.Cos(i * Math.PI / 4)) / factorial;
                    pow1 *= (decimal)x;
                }
                Console.WriteLine($"X = {x:0.000000} SN = {SN:0.000000} SE = {SE:0.000000} Y = {F(x):0.000000}");
            }
        }

        static double F(double x)
        {            
            return Math.Exp(x * Math.Cos(Math.PI / 4)) * Math.Cos(x * Math.Sin(Math.PI / 4));
        }
    }
}