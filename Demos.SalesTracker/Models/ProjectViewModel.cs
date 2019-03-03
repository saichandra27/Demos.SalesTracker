using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demos.SalesTracker.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Region { get; set; }
        public string SubRegion { get; set; }
        public string ClientName { get; set; }
        public string CleintIndustry { get; set; }
        public string ProjectStatus { get; set; }
        public string ProjectTechnology { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}