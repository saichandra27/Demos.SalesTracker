using System.ComponentModel.DataAnnotations.Schema;

namespace Demos.SalesTracker.Models
{
    public class ProjectDocumentInfo : IRecordInfo
    {
        public int Id { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        [ForeignKey("ProjectDocument")]
        public int ProjectDocumentId { get; set; }
        public virtual Project Project { get; set; }
        public virtual ProjectDocument ProjectDocument { get; set; }
    }

    public class SupportingDocumentInfo : IRecordInfo
    {
        public int Id { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }
        [ForeignKey("SupportingDocument")]
        public int SupportingDocumentId { get; set; }
        public virtual Project Project { get; set; }
        public virtual SupportingDocument SupportingDocument { get; set; }
    }
}