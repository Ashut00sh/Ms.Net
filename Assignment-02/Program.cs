using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Manager("Ashutosh", 4, "Developer", 12000);
            Employee e2 = new GeneralManager("hari", 5, 50000,"CEO");
            Employee e3 = new CEO("ram", 6, 1100000);

            Console.WriteLine(e1.CalCNetSalary());
            Console.WriteLine(e2.CalCNetSalary());
            Console.WriteLine(e3.CalCNetSalary());

            Console.ReadLine();
        }
    }
    public  abstract class Employee
    {
        private string name;
        private int empNo;
        private static int SempNO=0;
        private short deptNo;
        private decimal basic;
       
        #region properties 
        public string Name
        {
            set
            {
                if (value != "")
                {
                    name = value;
                }
                else
                {
                    Console.WriteLine("Name should not be blanck");
                }
            }
            get
            {
                return name;
            }
        }
        public int EmpNo
        {
            //property  accessor
            private set
            {
                empNo = value;
            }
            get
            {
                return empNo;
            }
        }
        public short DeptNo
        {
            set
            {
                if (value > 0)
                {
                    deptNo = value;
                }
                else
                {
                    Console.WriteLine("deptno is gretter than 0");
                }
            }
            get
            {
                return deptNo;
            }
        }
        //ABSTRACT  property
        public abstract decimal Basic
        {
            set;
            get;
        }
        #endregion properties
        #region constructor
        //constructor
        public Employee(string name="", short deptno=0,decimal basic=0)
        {
            SempNO++;
            EmpNo = SempNO;
            Name = name;
            DeptNo = deptno;
            Basic = basic;

        }


        #endregion
        #region method
        public abstract decimal CalCNetSalary();
        #endregion method
    }
    //manager class 
    public class Manager : Employee
    {
        private string designation;
        private decimal basic;
  
        #region properties
        //designation property
        public string Designation
        {
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("designation can not be blanck");
                    
                }
                else
                {
                    designation = value;
                }
            }
            get
            {
                return designation;
            }
        }
        //override a propery basic
        public override decimal Basic
        {
            set
            {
                basic = value;
            }
            get
            {
                return basic;
            }
        }
        #endregion properties
        //constructor
        public Manager(string name, short deptno, string designation,decimal basic) : base(name,deptno)
        {
            Designation = designation;
            Basic=basic;
        }
        //override CalNetSalary method
        #region override method
        public override decimal CalCNetSalary()
        {
            return Basic+(Basic*10);
        }
        #endregion method
    }
    //class General Manager
    public class GeneralManager : Employee
    {
        private string perks;
        private decimal basic;
        //property of perck
        public string Perks
        {
            set
            {
                perks = value;
            }
            get
            {
                return perks;
            }
        }
        //override basic property
        public override decimal Basic
        {
            get
            {
                return basic;
            }
            set
            {
                basic = value;
            }
        }
                //constuctor 
         public GeneralManager(string name,short deptno,decimal basic,string perks) : base(name, deptno)
        {
            this.perks = perks;
            Basic = basic;
        }
        //override CalNetSalary
        public override decimal CalCNetSalary()
        {
            return (Basic+Basic*15);
        }
    }
    //class CEO
    public class CEO:Employee {
        private decimal basic;
        //override basic property
        public override decimal Basic
        {
            set
            {
                basic = value;
            }
            get
            {
                return basic;
            }
        }
            //ceo constructor
           public CEO(string name,short deptno,decimal basic) : base(name, deptno)
            {
            Basic = basic;
                    
            }
        //override method CalNetSalary
        public sealed override decimal CalCNetSalary()
        {
            return Basic + (Basic * 20);
        }
    }
    
}
