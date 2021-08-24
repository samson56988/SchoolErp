﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolErp.Config;
using SchoolErp.Models.Teacher;
using SchoolErp.Models.Admin;
using System.Data.SqlClient;
using System.Data;

namespace SchoolErp.Controllers.Teacher
{
    public class TeacherClassController : Controller
    {
        // GET: TeacherClass
        public ActionResult StudentAttendance(int PageNumber = 1)
        {
            string Username = (string)Session["Username"];
            List<StudentAttendance> student = new List<StudentAttendance>();
            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("GetStudentAttendance", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", Username);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dtTable = new DataTable();

                    dtTable.Load(sdr);

                    foreach (DataRow row in dtTable.Rows)
                    {
                        student.Add(
                            new StudentAttendance
                            {
                                AdmissionNo = Convert.ToInt32(row["AdmissionNo"].ToString()),
                                Studentname = row["FullName"].ToString(),
                                Date = Convert.ToDateTime(row["Date"].ToString()),
                                Remark = row["Remark"].ToString()


                            }

                            );
                    }
                }
            }
            ViewBag.TotalPages = Math.Ceiling(student.Count() / 10.0);
            ViewBag.PageNumber = PageNumber;
            student = student.Skip((PageNumber - 1) * 10).Take(10).ToList();
            return View(student);
        }
       
        public ActionResult MarkAttendance()
        {
            FillName();
            return View();
        }

        public void FillName()
        {
            string Username = (string)Session["Username"];
            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select s.AdmissionNo, s.FullName  from Student s inner join AssignClass a on a.ClassLevelID = s.ClassLevelID inner join RoleTbl r on r.StaffID = a.StaffID where r.Username = '" + Username + "'", con))
                {
                    cmd.Parameters.AddWithValue("Username", Session["Username"].ToString());
                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    List<SelectListItem> li = new List<SelectListItem>();
                    li.Add(new SelectListItem { Text = "Select" , Value = "0" });
                    while(rdr.Read())
                    {
                        li.Add(new SelectListItem { Text = rdr[1].ToString(),Value = rdr[0].ToString() });
                    }

                    ViewData["Id"] = li;
                }
            }
        }

        [HttpPost]
        public ActionResult MarkAttendance(StudentAttendance student)
        {
            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("InserStudentAttendance", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AddmissionNo", student.AdmissionNo);
                    cmd.Parameters.AddWithValue("@Date", student.Date);
                    cmd.Parameters.AddWithValue("@Remark", student.Remark);

                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }

            TempData["SuccessMessage"] = "Record Saved Successfully";
            return RedirectToAction("StudentAttendance");
        }
      
        public ActionResult StudentList(int PageNumber = 1)
        {
            List<Student> student = new List<Student>();

            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("GetStudentList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dtSessions = new DataTable();

                    dtSessions.Load(sdr);

                    foreach (DataRow row in dtSessions.Rows)
                    {
                        student.Add(
                            new Student
                            {
                                AdmissionNo = Convert.ToInt32(row["AdmissionNo"].ToString()),
                                StudentName = row["FullName"].ToString(),
                                SessionName = row["Session"].ToString(),
                                ClassLevel = row["ClassLevel"].ToString(),
                                ClassAphabet = row["ClassAlphabet"].ToString(),
                                Gender = row["Gender"].ToString()


                            }

                            );
                    }
                }

              


            }

            ViewBag.TotalPages = Math.Ceiling(student.Count() / 10.0);
            ViewBag.PageNumber = PageNumber;
            student = student.Skip((PageNumber - 1) * 10).Take(10).ToList();
            return View(student);

        }
        [HttpPost]
        public ActionResult StudentList(string searchtxt)
        {
            List<Student> student = new List<Student>();

            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("SearchStudent", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Studentname", searchtxt);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();

                    SqlDataReader sdr = cmd.ExecuteReader();

                    DataTable dtSessions = new DataTable();

                    dtSessions.Load(sdr);

                    foreach (DataRow row in dtSessions.Rows)
                    {
                        student.Add(
                            new Student
                            {
                                AdmissionNo = Convert.ToInt32(row["AdmissionNo"].ToString()),
                                StudentName = row["FullName"].ToString(),
                                SessionName = row["Session"].ToString(),
                                ClassLevel = row["ClassLevel"].ToString(),
                                ClassAphabet = row["ClassAlphabet"].ToString(),
                                Gender = row["Gender"].ToString()


                            }

                            );
                    }
                }




            }

            ViewBag.TotalPages = Math.Ceiling(student.Count() / 10.0);
            return View(student);
        }

        private static List<Subject> PopulateSubject()
        {
            List<Subject> subject = new List<Subject>();

            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {

                using (SqlCommand cmd = new SqlCommand("select  * from Subject ", con))
                {
                    cmd.Connection = con;

                    con.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            subject.Add(
                                new Subject
                                {
                                    SubjectID = Convert.ToInt32(sdr["ID"]),
                                    Subjectname = sdr["Subject"].ToString()
                                }

                                );
                        }
                        con.Close();
                    }


                }

                return subject;

            }
        }

        private static List<Session> PopulateSession()
        {
            List<Session> session = new List<Session>();

            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {

                using (SqlCommand cmd = new SqlCommand("Select ID, Session + '  ' + Term as Name from SessionTble where IsActive = 'Active' ", con))
                {
                    cmd.Connection = con;

                    con.Open();

                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            session.Add(
                                new Session
                                {
                                    SessionID = Convert.ToInt32(sdr["ID"]),
                                    SessionName = sdr["Name"].ToString()
                                }

                                );
                        }
                        con.Close();
                    }


                }

                return session;

            }
        }

        public ActionResult AssignMark(int id)
        {
            ViewBag.Subject = PopulateSubject();

            ViewBag.Session = PopulateSession();

            SubjectMark mark = new SubjectMark();

            DataTable dtsession = new DataTable();

            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {
                con.Open();
                string query = "Select * from Student where AdmissionNo = @ID";
                SqlDataAdapter sqlDA = new SqlDataAdapter(query, con);
                sqlDA.SelectCommand.Parameters.AddWithValue("@ID", id);

                sqlDA.Fill(dtsession);

            }
            if (dtsession.Rows.Count == 1)
            {
                 mark.AdmissionNo = Convert.ToInt32(dtsession.Rows[0][0].ToString());
                 mark.StudentName = dtsession.Rows[0][1].ToString();
                return View(mark);
            }

            else


                return View("StudentList");
        }

        [HttpPost]
        public ActionResult AssignMark(SubjectMark mark)
        {

            using (SqlConnection con = new SqlConnection(StoreConnection.GetConnection()))
            {
                using (SqlCommand cmd = new SqlCommand("insertMark", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SessionID", mark.SessionID);
                    cmd.Parameters.AddWithValue("@SubjectID", mark.SubjectID);
                    cmd.Parameters.AddWithValue("@ClassID", mark.ClassLevelID);
                    cmd.Parameters.AddWithValue("@AdmissionNo", mark.AdmissionNo);
                    cmd.Parameters.AddWithValue("@FirstCa", mark.FirstCA);
                    cmd.Parameters.AddWithValue("@SecondCa", mark.SecondCA);
                    cmd.Parameters.AddWithValue("@ThirdCa", mark.ThirdCA);
                    cmd.Parameters.AddWithValue("@Exams", mark.Exams);
                    if (con.State != System.Data.ConnectionState.Open)

                        con.Open();
                    cmd.ExecuteNonQuery();
                }

                con.Close();
            }

            TempData["SuccessMessage"] = "Record Saved Successfully";
            return RedirectToAction("StudentList");
        }



    }
}