using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class CompanyJobPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Profile_Created")]
        public DateTime ProfileCreated { get; set; }

        [Column("Is_Inactive")]
        public bool IsInactive { get; set; }

        [Column("Is_Company_Hidden")]
        public bool IsCompanyHidden { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        [ForeignKey("Applicant_Job_Applications")]
        public Guid Company { get; set; }

        public virtual ApplicantJobApplicationPoco ApplicantJobApplication { get; set; }
    }
}