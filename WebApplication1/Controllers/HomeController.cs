using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        private JobPortalEntities _db = new JobPortalEntities();

        public ActionResult Index()
        {
            return View();
            //return View(_db.Logins);
        }

        public ActionResult ApplicantList()
        {
            String _connStr = @"Data Source=SOURAV-PC\HUMBERBRIDGING;Initial Catalog = JOB_PORTAL_DB; Integrated Security = True; Connect Timeout = 15; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //Console.WriteLine(Id);
            using (SqlConnection sqlConn = new SqlConnection(_connStr))
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlConn;
                sqlcmd.CommandText = "select * from Applicant_Educations";
                sqlConn.Open();

                SqlDataReader dataRead = sqlcmd.ExecuteReader();
                //ApplicantEducationPoco[] pocoArray = new ApplicantEducationPoco[1000];
                var model = new List<ApplicantEducationPoco>();

                //int arrIndex = 0;

                while (dataRead.Read())
                {
                    ApplicantEducationPoco tempPoco = new ApplicantEducationPoco();
                    tempPoco.Id = dataRead.GetGuid(0);
                    tempPoco.Applicant = dataRead.GetGuid(1);
                    tempPoco.Major = dataRead.GetString(2);
                    tempPoco.CertificateDiploma = dataRead.GetString(3);
                    tempPoco.StartDate = dataRead.GetDateTime(4);
                    tempPoco.CompletionDate = dataRead.GetDateTime(5);
                    tempPoco.CompletionPercent = dataRead.GetByte(6);
                    tempPoco.TimeStamp = (byte[])(dataRead["Time_Stamp"]);

                    model.Add(tempPoco);

                    //pocoArray[arrIndex] = tempPoco;
                    //arrIndex++;
                }

                return View(model);
            }
        }

        public ActionResult EmployeeLogin()
        {
            return View();
        }


        public ActionResult EmployerLogin()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult HotJobs()
        {
            String _connStr = @"Data Source=SOURAV-PC\HUMBERBRIDGING;Initial Catalog = JOB_PORTAL_DB; Integrated Security = True; Connect Timeout = 15; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            //Console.WriteLine(Id);
            using (SqlConnection sqlConn = new SqlConnection(_connStr))
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.Connection = sqlConn;
                sqlcmd.CommandText = @"select top 10 jobdes.Job_Name, comdes.Company_Name, jobdes.Job_Descriptions  from 
                                        dbo.Company_Jobs as job
                                        JOIN
                                        dbo.Company_Jobs_Descriptions jobdes ON job.Id = jobdes.Job
                                        JOIN
                                        dbo.Company_Descriptions comdes
                                        ON comdes.Company = job.Company
                                        where comdes.LanguageID = 'EN'";
                sqlConn.Open();

                SqlDataReader dataRead = sqlcmd.ExecuteReader();
                //ApplicantEducationPoco[] pocoArray = new ApplicantEducationPoco[1000];
                var model = new List<HotJobs>();

                //int arrIndex = 0;

                while (dataRead.Read())
                {
                    HotJobs tempPoco = new HotJobs();
                    tempPoco.JobName = dataRead.GetString(0);
                    tempPoco.CompanyName = dataRead.GetString(1);
                    tempPoco.JobDescription = dataRead.GetString(2);

                    model.Add(tempPoco);
                }

                return View(model);
            }
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}