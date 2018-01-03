using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    public class ApplicantEducationPoco
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Applicat_Profiles")]
        public Guid Applicant { get; set; }
        public String Major { get; set; }

        [Column("Certificate_Diploma")]
        public String CertificateDiploma { get; set; }

        [Column("Start_Date")]
        public DateTime? StartDate { get; set; }

        [Column("Completion_Date")]
        public DateTime? CompletionDate { get; set; }

        [Column("Completion_Percent")]
        public byte? CompletionPercent { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }
    }
}