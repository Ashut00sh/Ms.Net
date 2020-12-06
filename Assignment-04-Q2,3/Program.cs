using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_02_Q2
{
    class Program1
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("Enter no of batches");
            int batch = Convert.ToInt32(Console.ReadLine());
            int[][] arr = new int[batch][];
            Console.WriteLine("array length"+arr.Length);
            for(int i=0;i<arr.Length;i++){
                Console.WriteLine("Enter number of students of batch{0}",i);
                int stdno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("student no size"+stdno);
                int[] marks = new int[stdno];
                Console.WriteLine("Enter marks of student of batch {0}",i);
                for(int j = 0; j < stdno; i++)
                {
                    marks[j] = Convert.ToInt32(Console.ReadLine());
                }
                arr[i] = marks;
            }
            Console.WriteLine("details==================");
            for(int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine(arr[i][j]);
                }
                Console.WriteLine(" ");
            }
            Console.ReadLine();

        }
    }
}
/*2.CDAC has certain number of batches. each batch has certain number of students
         accept number of batches from the user. for each batch accept number of students.
         create an array to store mark for each student. 
         accept the marks.
         display the marks.*/
/*3. Create a struct Student with the following properties. Put in appropriate validations.
string Name
int RollNo
decimal Marks

Create a parameterized constructor.

Create an array to accept details for 5 students*/
namespace Assignment_02_Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            student[] stud = new student[5];
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter name of student");
                string name = Console.ReadLine();
                Console.WriteLine("enter  roll no of student");
                int rollno = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("enter enter marks");
                int mrks = Convert.ToInt32(Console.ReadLine());
                stud[i] = new student(name, rollno, mrks);
            }
            for(int i = 0; i < stud.Length; i++)
            {
                Console.WriteLine(stud[i]);
            }
        }
    }
    public struct student
    {
        public string name;
        public int rollno;
        public decimal marks;
        //properties 
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
                    Console.WriteLine("name should not be blank");
                }
            }
            get
            {
                return name;
            }
        }
        public int Rollno
        {
            set
            {
                if (value > 0)
                {
                    rollno = value;

                }
                else
                {
                    Console.WriteLine("Give positive roll no ");
                }
            }
            get
            {
                return rollno;
            }
        }
        public decimal Marks
        {
            set
            {
                if (value > -1&&value>=100)
                {
                    marks = value;
                }
                else
                {
                    Console.WriteLine("enter positive marks");
                }
            }
            get
            {
                return marks;
            }
        }
        public student(string name,int rollno,decimal marks)
        {
            this.name = "vin bhav";
            this.rollno = 10;
            this.marks = 35;
            Name = name;
            Rollno = rollno;
            Marks = marks;
        }
    }
}