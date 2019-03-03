using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Demos.SalesTracker.Models
{
    public class Project :IRecordInfo
    {
        public int Id { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectTechnology { get; set; }
        public string ProjectStatus { get; set; }
        [ForeignKey("Region")]
        public int RegionId { get; set; }
        [ForeignKey("SubRegion")]
        public int SubRegionId { get; set; }
        public string ClientName { get; set; }
        public string ClientIndustry { get; set; }
        public virtual Region Region { get; set; }
        public virtual SubRegion SubRegion { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}