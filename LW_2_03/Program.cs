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
            double e = 0.0001;
            int n = 25;
            double step = (b - a) / k;

            for (double x = a; x <= b; x += step)
            {
                double SN = 0, SE = 0, prevSE = 1;
                int factorial = 1;
                // SN
                for (int i = 0; i <= n; i++)
                {
                    SN += Math.Cos(i * Math.PI / 4) / factorial * Math.Pow(x, i);
                    if (i != 0) factorial = factorial * i;
                }
                // SE
                factorial = 1;
                for (int i = 0; Math.Abs(prevSE - SE) > e; i++)
                {
                    prevSE = SE;
                    SE += Math.Cos(i * Math.PI / 4) / factorial * Math.Pow(x, i);
                    if (i != 0) factorial = factorial * i;
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
