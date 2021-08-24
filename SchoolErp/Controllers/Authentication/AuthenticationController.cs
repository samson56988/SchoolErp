﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolErp.Config;
using SchoolErp.Models.Authentication;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace SchoolErp.Controllers.Authentication
{
    public class AuthenticationController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        // GET: Authentication
        public ActionResult Login()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = Config.StoreConnection.GetConnection();
        }

        [HttpPost]
        public ActionResult Login(Login log)
        {
            string username = "", rolename = "";
            bool found = false;
            SqlDataReader dr;
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "Select * from RoleTbl where Username = '" + log.username + "'and Password = '" + log.password + "'";

            dr = com.ExecuteReader();

            if(dr.Read())
            {
                found = true;
                username = dr["Username"].ToString();
                rolename = dr["Role"].ToString();
                FormsAuthentication.SetAuthCookie(log.username, true);
                Session["Username"] = log.username.ToString();
            }
            else
            {
                found = false;
            }
            dr.Close();
            con.Close();
            if(found == true)
            {
                if(rolename == "Teacher")
                {
                    FormsAuthentication.SetAuthCookie(log.username, true);
                    Session["Username"] = log.username.ToString();
                    return RedirectToAction("Index", "TeacherDashboard");
                }
                else if(rolename == "Admin")
                {
                    FormsAuthentication.SetAuthCookie(log.username, true);
                    Session["Username"] = log.username.ToString();
                    return RedirectToAction("Index", "Dashboard");
                }
            }
            else
            {
                ViewData["message"] = "Username and Password are wrong!";
            }
            con.Close();
            return View();
        }
    }
}