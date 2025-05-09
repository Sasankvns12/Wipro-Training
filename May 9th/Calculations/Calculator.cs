using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Calculator
    {
        public int Add(int a,int b)
        {
            return a + b;
        }
        public double Add(double a, double b)
        {
            return a + b;
        }
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }


         public int Sub(int a,int b)
        {
            return a - b;
        }
        public double Sub(double a, double b)
        {
            return a - b;
        }
        public int Sub(int a, int b, int c)
        {
            return a - b - c;
        }


         public int Mul(int a,int b)
        {
            return a * b;
        }
        public double Mul(double a, double b)
        {
            return a * b;
        }
        public int Mul(int a, int b, int c)
        {
            return a * b * c;
        }
    }
}
