using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //Employee o1 = new Employee("Amol", 123465, 10);
            //Employee o2 = new Employee("Amol", 123465);
            //Employee o3 = new Employee("Amol");
            //Employee o4 = new Employee();
            //Console.WriteLine(o2);
            //Console.WriteLine(o3);
            //Console.WriteLine(o4);
            //Test cases
            Employee o1 = new Employee();
            Employee o2 = new Employee();
            Employee o3 = new Employee();
            // Employee o3 = new Employee("", 173465, 10);
            //check null name val
            //Console.WriteLine(o3.Name1="");
            //check basic sal val
            //Console.WriteLine(o3.Basic1=171234);
            //check deptno not zero val
            // Console.WriteLine(o3.DeptNo1 = 0);
            //Console.WriteLine(o3.EmpNo1);


            Console.WriteLine(o1.EmpNo1);
            Console.WriteLine(o2.EmpNo1);
            Console.WriteLine(o3.EmpNo1);
            Console.WriteLine("=====================");
            Console.WriteLine(o3.EmpNo1);
            Console.WriteLine(o2.EmpNo1);
            Console.WriteLine(o1.EmpNo1);
            Console.ReadLine();



        }
    }
    public class Employee
    {
        string Name;
        int Empno;
        decimal Basic;
        short DeptNo;
        static int EmpNo_cnt=0;
        // decimal al;

        //property for Name
        #region properties
        public string Name1
        {
            set
            {
                if (value != "")
                    Name = value;
                else
                    Console.WriteLine("Name should not be blanck");
            }
            get
            {
                return Name;
            }
        }
        //property for employee no
        public int EmpNo1
        {
            get
            {
                return Empno;
            }
        }
        //property for basic salary
        public decimal Basic1
        {
            set
            {
                if (value >= 120000 && value <= 150000)
                    Basic = value;
                else
                    Console.WriteLine("basic salary is in between 1lac to 1.5k");
            }
            get
            {
                return Basic;
            }
        }
        
        //property for deptno
        public short DeptNo1
        {
            set
            {
                if (value > 0)
                    DeptNo = value;
            }
            get
            {
                return DeptNo;
            }
        }
        #endregion properties
        //constructor
        #region constructor
        public Employee(string Name1,decimal Basic1=0,short DeptNo1=0)
        {
            EmpNo_cnt++;
            Name = Name1;
            Empno = EmpNo_cnt;
            Basic = Basic1;
            DeptNo = DeptNo1;
        }
        //two para constr
        public Employee(string Name1, decimal Basic1)
        {
            EmpNo_cnt++;
            Name = Name1;
            Empno = EmpNo_cnt;
            Basic = Basic1;
        }
        //one para constr
        public Employee(string Name1)
        {
            EmpNo_cnt++;
            Name = Name1;
            Empno = EmpNo_cnt;
        }
        //zero para constr
        public Employee()
        {
            EmpNo_cnt++;
            Empno = EmpNo_cnt;
        }
        #endregion constructor
        //method
        #region method
        public decimal GetNetSalary()
        {
            decimal salary = Basic1 + (Basic1*10);
            return salary;
        }
        #endregion method
    }

  
}
