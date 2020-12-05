using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04
{
    public class Employee
    {
        //fields
        private int empno;
        private string name;
        private decimal salary;
        private string deptno;
        //property of salary
        public decimal Salary
        {
            set
            {
                salary = value;
            }
            get
            {
                return salary;
            }
        }
        //property of empno
        public int Empno
        {
            set
            {
                empno = value;
            }
            get
            {
                return empno;
            }
        }
        //constructor
        public Employee(int empno,string name,decimal salary,string deptno)
        {
            this.empno = empno;
            this.name = name;
            this.salary = salary;
            this.deptno = deptno;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter size of aaray");
            Employee[] emp = new Employee[Convert.ToInt32(Console.ReadLine())];
            for(int i = 0; i < emp.Length; i++)
            {
                //accept all details of emp
                Console.WriteLine("enter empno number");
                int empno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter name ");
                string name = Console.ReadLine();
                Console.WriteLine("enter salary ");
                decimal salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter deptno");
                string deptno = Console.ReadLine();
                //store obj in array
                emp[i] = new Employee(empno, name, salary, deptno);
                //calculalte highest salary
                decimal sal = emp[0].Salary;
                if (sal > emp[i].Salary)
                {
                    sal = emp[i].Salary;

                }
                //display highest salary
                Console.WriteLine("highest salary="+sal);

            }
            //display all emp info
            foreach(Employee e in emp){
                Console.WriteLine(e);
            }
            //search emp deatails with empno
            int Sempno = Convert.ToInt32(Console.ReadLine());
            foreach(Employee e in emp)
            {
                if (e.Empno == Sempno)
                {
                    Console.WriteLine(e.Salary);
                    Console.WriteLine(e.Empno);
                }
            }
            Console.ReadLine();
        }
       
    }
}
