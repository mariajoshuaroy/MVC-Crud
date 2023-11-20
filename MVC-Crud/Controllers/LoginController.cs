using MVC_Crud.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Crud.Controllers
{
    public class LoginController : Controller
    {
        string constr = "Data Source=DESKTOP-9S00RF6;Initial Catalog = mvc; Integrated Security = True";

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel log)
        {
            int loggedID = 0;
            if (ModelState.IsValid)
            {
                using (SqlConnection con = new SqlConnection(constr))
                {
                    string query = "sp_tbl_user_login '" + log.username
                            + "','" + log.pwd + "'";
                    SqlCommand cmd = new SqlCommand(query, con);

                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        log = new LoginModel
                        {
                            id = Convert.ToInt32(sdr["id"]),
                            username = sdr["Username"].ToString(),
                            pwd = sdr["pwd"].ToString(),
                        };
                    }
                    con.Close();
                    loggedID = log.id;
                    if (loggedID == 0)
                    {
                        ModelState.AddModelError("", "Invalid Username and Password");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Employee");
                        //return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }
    }
}