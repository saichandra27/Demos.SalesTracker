using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demos.SalesTracker.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Department { get; set; }
        public string Designation { get; set; }
        public string ReportingManager { get; set; }
    }
}