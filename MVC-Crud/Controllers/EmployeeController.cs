using MVC_Crud.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Crud.Controllers
{
    public class EmployeeController : Controller
    {
        string constr = "Data Source=DESKTOP-9S00RF6;Initial Catalog = mvc; Integrated Security = True";
        // GET: Employee
        public ActionResult Index()
        {
            List<EmployeeModel> EmployeeObj = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_ShowEmployee", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    EmployeeObj.Add(new EmployeeModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        EmpName = sdr["EmpName"].ToString(),
                        EmpNumber = sdr["EmpNumber"].ToString(),
                        EmpEmail = sdr["EmpEmail"].ToString(),
                        Address = sdr["Address"].ToString(),
                        BloodGroup = sdr["BloodGroup"].ToString(),

                    });
                }

                con.Close();
            }
            return View(EmployeeObj);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            EmployeeModel empobj = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_ShowEmployee_Id " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    empobj = new EmployeeModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        EmpName = sdr["EmpName"].ToString(),
                        EmpNumber = sdr["EmpNumber"].ToString(),
                        EmpEmail = sdr["EmpEmail"].ToString(),
                        Address = sdr["Address"].ToString(),
                        BloodGroup = sdr["BloodGroup"].ToString(),

                    };
                }

                con.Close();
            }
            return View(empobj);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel obj)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "sp_create '" + obj.EmpName + "','" + obj.EmpNumber + "','" + obj.EmpEmail + "','" + obj.Address + "','"
                            + obj.BloodGroup + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteReader();
                        con.Close();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.MSG = "MVC CRUD";
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            else
            {
                EmployeeModel empobj = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("sp_ShowEmployee_Id " + id, con);
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        empobj = new EmployeeModel
                        {
                            id = Convert.ToInt32(sdr["id"]),
                            EmpName = sdr["EmpName"].ToString(),
                            EmpNumber = sdr["EmpNumber"].ToString(),
                            EmpEmail = sdr["EmpEmail"].ToString(),
                            Address = sdr["Address"].ToString(),
                            BloodGroup = sdr["BloodGroup"].ToString(),

                        };
                    }

                    con.Close();
                }
                return View(empobj);
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EmployeeModel obj)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "sp_Edit " + id + ",'" + obj.EmpName + "','" + obj.EmpNumber +
                            "','" + obj.EmpEmail + "','" + obj.Address + "','" + obj.BloodGroup + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteReader();
                        con.Close();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeModel empobj = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("sp_ShowEmployee_Id " + id, con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    empobj = new EmployeeModel
                    {
                        id = Convert.ToInt32(sdr["id"]),
                        EmpName = sdr["EmpName"].ToString(),
                        EmpNumber = sdr["EmpNumber"].ToString(),
                        EmpEmail = sdr["EmpEmail"].ToString(),
                        Address = sdr["Address"].ToString(),
                        BloodGroup = sdr["BloodGroup"].ToString(),

                    };
                }

                con.Close();
            }

            return View(empobj);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        string query = "sp_Delete " + id;
                        SqlCommand cmd = new SqlCommand(query, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
