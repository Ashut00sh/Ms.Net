using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_05
{
    class Program
    {
        private decimal basic=1000;
        private bool isgreaterthantenK = true;
        static void Main(string[] args)
        {
            //lamda for simple interest
            Func<decimal, decimal, decimal, decimal> o1 = (p, n, r) =>
            {
                return (p * n * r) / 100;
            };
            Console.WriteLine(o1(5000,2,4));
            //lamda for Isgreater use predicate
            Predicate<int> o2 = (a) =>
              {
                  return true;
              };
            Console.WriteLine(o2(20));
            //lamda for is greater use func
            Func<int, int, bool> o3 = (a, b) =>
            {
                return a>b;
            };
            Console.WriteLine("isgreater using func==="+o3(50, 40));
            //lamda for Getbasic salary of employee
            Program prg = new Program();
            //getbsic salary
            Func<object,decimal> o5 = (p) =>
            {
                Program p1 = new Program();
                return p1.basic;
            };
            Console.WriteLine("basic salary=="+o5(1000));
            //lamda for iseven function
            Func<int, bool> o4 = (int a) =>
                {
                    return a%2==0;
                };
            Console.WriteLine("is even="+o4(12));
            //lamda function for basic is greater than 10k
            Func<object, bool> o6 = (p) =>
            {
                Program g = new Program();
                return g.isgreaterthantenK;
            };
            Console.WriteLine("isgreaterthan ten k==="+o6(1000));
           
        }
        //simple interest method
        static decimal SimpleInterest(decimal p,decimal n,decimal r)
        {
            decimal si = (p * n * r) / 100;
            return si;
        }
        //isgreater function
        static bool IsGreater(int a,int b)
        {
            return (a > b);
        }
       //iseven function
        static bool IsEven(int a)
        {
            return (a % 2 == 0);
        }
        //getbasic salary function
        static decimal GetBasic(Program p)
        {
            return p.basic;
        }
        //isgreathan function
        static bool IsGreaterThan(Program b)
        {
            return b.isgreaterthantenK;
        }
    }

}
