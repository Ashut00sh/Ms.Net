using ModelBindAndDbCode1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModelBindAndDbCode1.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Employees";
           // Employee Empobj = new Employee();
          
            List<Employee> LstEmp = new List<Employee>();
            
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                LstEmp.Add(new Employee {EmpNo=(int)dr["EmpNo"],Name=(string)dr["Name"],Basic=(decimal)dr["Basic"],DeptNo=(int)dr["DeptNo"]});
            }
            dr.Close();
            cn.Close();
            return View(LstEmp);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id=0)
        {
            try
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmpNoDetail";

                Employee Empobj = new Employee();
                cmd.Parameters.AddWithValue("@EmpNo",id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Empobj.EmpNo = (int)dr["EmpNo"];
                    Empobj.Name = (string)dr["Name"];
                    Empobj.Basic = (decimal)dr["Basic"];
                    Empobj.DeptNo = (int)dr["DeptNo"];
                }
                dr.Close();

                //cmd.Parameters.AddWithValue("@Name", Empobj.Name);
                //cmd.Parameters.AddWithValue("@Basic", Empobj.Basic);
                //cmd.Parameters.AddWithValue("@DeptNo", Empobj.DeptNo);

               
                cn.Close();
                
                return View(Empobj);
            }catch(Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertEmployee";
            cmd.Parameters.AddWithValue("@EmpNo", emp.EmpNo);
            cmd.Parameters.AddWithValue("@Name", emp.Name);
            cmd.Parameters.AddWithValue("@Basic", emp.Basic);
            cmd.Parameters.AddWithValue("@DeptNo", emp.DeptNo);
            try
            {
                cmd.ExecuteNonQuery();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        
        {
            
            
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EmpNoDetail";

                Employee Empobj = new Employee();
                cmd.Parameters.AddWithValue("@EmpNo", id);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Empobj.EmpNo = (int)dr["EmpNo"];
                    Empobj.Name = (string)dr["Name"];
                    Empobj.Basic = (decimal)dr["Basic"];
                    Empobj.DeptNo = (int)dr["DeptNo"];
                }
                dr.Close();
                cn.Close();

                return View(Empobj);
             
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee obj)
        {

                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
                cn.Open();
                SqlCommand cmdedit = new SqlCommand();
                cmdedit.Connection = cn;
                cmdedit.CommandType = CommandType.StoredProcedure;
                cmdedit.CommandText = "updateEmployee";
                
                
                cmdedit.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdedit.Parameters.AddWithValue("@Name", obj.Name);
                cmdedit.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdedit.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

                
            try
            {
                cmdedit.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EmpNoDetail";

            Employee Empobj = new Employee();
            cmd.Parameters.AddWithValue("@EmpNo", id);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Empobj.EmpNo = (int)dr["EmpNo"];
                Empobj.Name = (string)dr["Name"];
                Empobj.Basic = (decimal)dr["Basic"];
                Empobj.DeptNo = (int)dr["DeptNo"];
            }
            dr.Close();
            cn.Close();

            return View(Empobj);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,Employee obj)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmdedit = new SqlCommand();
            cmdedit.Connection = cn;
            cmdedit.CommandType = CommandType.StoredProcedure;
            cmdedit.CommandText = "deleteEmployee";

            cmdedit.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
          

            try
            {
                cmdedit.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
