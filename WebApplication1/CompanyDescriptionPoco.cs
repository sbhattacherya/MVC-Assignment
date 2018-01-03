using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1
{
        [Table("Company_Descriptions")]
        public class CompanyDescriptionPoco : IPoco
        {
            [Key]
            public Guid Id { get; set; }

            [Column("Company_Name")]
            public String CompanyName { get; set; }

            [Column("Company_Description")]
            public String CompanyDescription { get; set; }

            [Column("Time_Stamp")]
            public byte[] TimeStamp { get; set; }

            [ForeignKey("Company_Profiles")]
            public Guid Company { get; set; }
            public String LanguageId { get; set; }

            public virtual CompanyProfilePoco CompanyProfile { get; set; }
        }
}