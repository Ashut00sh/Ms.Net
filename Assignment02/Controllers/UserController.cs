using Assignment02.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment02.Controllers
{
    public class UserController : Controller
    {
        // GET: index login
        public ActionResult Index()
        {
            User u = new User();
            return View(u);
        }
        //index post login
        [HttpPost]
        public ActionResult Index(User user)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Loginapp;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Users where LoginName=@LoginName and Password = @Password";

            cmd.Parameters.AddWithValue("@LoginName", user.LoginName);
            cmd.Parameters.AddWithValue("@Password", user.Password);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                User u = new User
                {
                    LoginName = dr["LoginName"].ToString(),
                    Password = dr["Password"].ToString(),
                    FullName = dr["FullName"].ToString(),
                    EmailId = dr["EmailId"].ToString(),
                    CityId = Convert.ToInt32(dr["CityId"].ToString()),
                    Phone = dr["Phone"].ToString()
                };

                Session["user"] = u;
                Session["name"] = u.LoginName;
                Session["fullname"] = u.FullName;

                if (user.IsActive)
                {
                    HttpCookie objCookie = new HttpCookie("abc");

                    objCookie.Expires = DateTime.Now.AddDays(2);
                    objCookie.Values["LoginName"] = user.LoginName;
                    objCookie.Values["Password"] = user.Password;

                    Response.Cookies.Add(objCookie);
                }

                cn.Close();

                return RedirectToAction("Home");
            }
            else
            {
                cn.Close();
                return RedirectToAction("Login");
            }


        }
        //home Get
        public ActionResult Home(string id)
        {

            HttpCookie objCookie = Request.Cookies["abc"];
            if (Session["user"] != null)
            {
                return View();
            }
            else if (objCookie != null)
            {
                User user = new User
                {
                    LoginName = objCookie.Values["UserName"],
                    Password = objCookie.Values["Password"]
                };
                if (IsCookieAlive(user))
                {
                    return View();
                }
                else
                    return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        //Get Register
        public ActionResult Register()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Loginapp;Integrated Security=True";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Cities";

            SqlDataReader dr = cmd.ExecuteReader();

            User o = new User();

            List<SelectListItem> objCities = new List<SelectListItem>();

            while (dr.Read())
            {

                objCities.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["CityId"].ToString() });

            }
            o.Cities = objCities;

            dr.Close();
            cn.Close();

            return View(o);
        }
        [HttpPost]
        public ActionResult Register(User  obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=Loginapp;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Users values(@LoginName,@Password,@ConfirmPassword,@FullName,@EmailId,@CityId,@Phone)";
            cmd.Parameters.AddWithValue("@LoginName",obj.LoginName);
            cmd.Parameters.AddWithValue("@Password",obj.Password);
            cmd.Parameters.AddWithValue("@ConfirmPassword",obj.ConfirmPassword);
            cmd.Parameters.AddWithValue("@FullName", obj.FullName);
            cmd.Parameters.AddWithValue("@EmailId", obj.EmailId);
            cmd.Parameters.AddWithValue("@CityId", obj.CityId);
            cmd.Parameters.AddWithValue("@Phone", obj.Phone);
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

        //Get Remaimber Me
        public ActionResult RemaimberMe()
        {
            return View();
        }
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
       // GET: User/Login
       // public ActionResult Login()
       // {
       //     User u = new User();
       //     return View(u);

       // }

       // POST: User/Login
       //[HttpPost]
       // public ActionResult Login(User user)
       // {
       //     return View();
       // }


        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public bool IsCookieAlive(User user)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=JKDec20;Integrated Security=True";
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Users where LoginName=@LoginName and Password = @Password";

            cmd.Parameters.AddWithValue("@LoginName", user.LoginName);
            cmd.Parameters.AddWithValue("@Password", user.Password);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                User u = new User
                {
                    LoginName = dr["LoginName"].ToString(),
                    Password = dr["Password"].ToString(),
                    FullName = dr["FullName"].ToString(),
                    EmailId = dr["EmailId"].ToString(),
                    CityId = Convert.ToInt32(dr["CityId"].ToString()),
                    Phone = dr["Phone"].ToString()
                };

                Session["username"] = user;
                Session["loginname"] = user.LoginName;
                Session["fullname"] = user.FullName;

                return true;
            }
            return false;

        }
    }
}
