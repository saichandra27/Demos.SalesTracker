using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demos.SalesTracker.Models
{
    public class SupportingDocument : IRecordInfo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FileName { get; set; }
        public string Createdby { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
    }
}