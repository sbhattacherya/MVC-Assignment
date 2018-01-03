using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class TestClass
    {

        public static void Main()
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
                ApplicantEducationPoco[] pocoArray = new ApplicantEducationPoco[1000];
                int arrIndex = 0;

                while (dataRead.Read())
                {
                    ApplicantEducationPoco tempPoco = new ApplicantEducationPoco();
                    tempPoco.Id = dataRead.GetGuid(0);
                    Console.WriteLine(tempPoco.Id);
                    tempPoco.Applicant = dataRead.GetGuid(1);
                    tempPoco.Major = dataRead.GetString(2);
                    tempPoco.CertificateDiploma = dataRead.GetString(3);
                    tempPoco.StartDate = dataRead.GetDateTime(4);
                    tempPoco.CompletionDate = dataRead.GetDateTime(5);
                    tempPoco.CompletionPercent = dataRead.GetByte(6);
                    tempPoco.TimeStamp = (byte[])(dataRead["Time_Stamp"]);

                    pocoArray[arrIndex] = tempPoco;
                    arrIndex++;
                }
                Console.WriteLine(arrIndex);
            }
        }

    }
}
