using StudentSystem.Models;
using StudentSystem.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace StudentSystem.Controllers
{
    public class HomeController : Controller
    {
        DbRepo dbRepo = new DbRepo();
        public ActionResult Index()
        {

            Students students = new Students()
            {
                Cities = dbRepo.GetAvailableCities(),
                Educations = dbRepo.GetAvailableEducations(),
            };
            return View(students);
        }

        [HttpPost]
        public ActionResult Index(Students students)
        {
            bool eduValid = false;
            int eduId = 0;
            for (int i = 0; i < students.Educations.Count; i++)
            {
                if (students.Educations[i].Checked)
                {
                    eduValid = true;
                    eduId = students.Educations[i].Id;
                    break;
                }
            }
            if (ModelState.IsValid && eduValid)
            {
                // save it here to db. and retrun rediret to any where if needed.
                SaveToDB(students, eduId);
               
            }
            else
            {
                if (!eduValid)
                    ModelState.AddModelError("Education", "This is mandatory");
            }
            students.Cities = dbRepo.GetAvailableCities();
            students.Educations = dbRepo.GetAvailableEducations();
            return View(students);
        }

        [HttpPost]
        public JsonResult AjaxPostCall(Students students)
        {
             
            if (ModelState.IsValid)
            {
                // save it here to db. and retrun rediret to any where if needed.
                students.Cities = dbRepo.GetAvailableCities();
                students.City= students.Cities.Where(x => x.Text == students.City).FirstOrDefault().Value.ToString();
                SaveToDB(students, (int) students.EducationId);
            }
            students.Cities = dbRepo.GetAvailableCities();
            students.Educations = dbRepo.GetAvailableEducations();
            return Json(students, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private void SaveToDB(Students students, int eduId)
        {
            string str = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Admin\source\repos\StudentSystem\StudentSystem\App_Data\assignment.mdf;Integrated Security=True";
            SqlConnection cn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("usp_Insert", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", students.Name);
            cmd.Parameters.AddWithValue("@Age", students.Age);
            cmd.Parameters.AddWithValue("@Gender", students.Gender);
            cmd.Parameters.AddWithValue("@Education", eduId);
            cmd.Parameters.AddWithValue("@City", students.City);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }

}