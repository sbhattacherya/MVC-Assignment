using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1
{
    [Table("Company_Jobs_Descriptions")]
    public class CompanyJobDescriptionPoco : IPoco
    {
        [Key]
        public Guid Id { get; set; }

        [Column("Job_Name")]
        public String JobName { get; set; }

        [Column("Job_Descriptions")]
        public String JobDescriptions { get; set; }

        [Column("Time_Stamp")]
        public byte[] TimeStamp { get; set; }

        [ForeignKey("Company_Jobs")]
        public Guid Job { get; set; }

        public virtual CompanyJobPoco CompanyJob { get; set; }
    }
}