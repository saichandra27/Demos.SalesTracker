namespace Demos.SalesTracker.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Demos.SalesTracker.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var Region1 = new Region() { Id = 1, Title = "Region1" };
            var Region2 = new Region() { Id = 2, Title = "Region2" };
            var Region3 = new Region() { Id = 3, Title = "Region3" };
            var Region4 = new Region() { Id = 4, Title = "Region4" };
            var Region5 = new Region() { Id = 5, Title = "Region5" };

            var SubRegion1 = new SubRegion() { Id = 1, Title = "SubRegion1" };
            var SubRegion2 = new SubRegion() { Id = 2, Title = "SubRegion2" };
            var SubRegion3 = new SubRegion() { Id = 3, Title = "SubRegion3" };
            var SubRegion4 = new SubRegion() { Id = 4, Title = "SubRegion4" };
            var SubRegion5 = new SubRegion() { Id = 5, Title = "SubRegion5" };

            var SupportingDocument1 = new SupportingDocument() { Id = 1, Title = "Docx1", FileName = "DOCX1.docx", Created = DateTime.Now, Modified = DateTime.Now, Createdby = "714b5a05-bdce-4968-952f-99d6a284f1d0", Modifiedby = "714b5a05-bdce-4968-952f-99d6a284f1d0" };
            var SupportingDocument2 = new SupportingDocument() { Id = 2, Title = "Docx2", FileName = "DOCX2.docx", Created = DateTime.Now, Modified = DateTime.Now, Createdby = "714b5a05-bdce-4968-952f-99d6a284f1d0", Modifiedby = "714b5a05-bdce-4968-952f-99d6a284f1d0" };
            var SupportingDocument3 = new SupportingDocument() { Id = 3, Title = "Docx3", FileName = "DOCX3.docx", Created = DateTime.Now, Modified = DateTime.Now, Createdby = "714b5a05-bdce-4968-952f-99d6a284f1d0", Modifiedby = "714b5a05-bdce-4968-952f-99d6a284f1d0" };
            var SupportingDocument4 = new SupportingDocument() { Id = 4, Title = "Docx4", FileName = "DOCX4.docx", Created = DateTime.Now, Modified = DateTime.Now, Createdby = "714b5a05-bdce-4968-952f-99d6a284f1d0", Modifiedby = "714b5a05-bdce-4968-952f-99d6a284f1d0" };
            var SupportingDocument5 = new SupportingDocument() { Id = 5, Title = "Docx5", FileName = "DOCX5.docx", Created = DateTime.Now, Modified = DateTime.Now, Createdby = "714b5a05-bdce-4968-952f-99d6a284f1d0", Modifiedby = "714b5a05-bdce-4968-952f-99d6a284f1d0" };

            var ProjectDocument1 = new ProjectDocument() { Id = 1, Title = "Docx1", FileName = "DOCX1.docx", Created = DateTime.Now, Modified = DateTime.Now, Createdby = "714b5a05-bdce-4968-952f-99d6a284f1d0", Modifiedby = "714b5a05-bdce-4968-952f-99d6a284f1d0" };
            var ProjectDocument2 = new ProjectDocument() { Id = 2, Title = "Docx2", FileName = "DOCX2.docx", Created = DateTime.Now, Modified = DateTime.Now, Createdby = "714b5a05-bdce-4968-952f-99d6a284f1d0", Modifiedby = "714b5a05-bdce-4968-952f-99d6a284f1d0" };
            var ProjectDocument3 = new ProjectDocument() { Id = 3, Title = "Docx3", FileName = "DOCX3.docx", Created = DateTime.Now, Modified = DateTime.Now, Createdby = "714b5a05-bdce-4968-952f-99d6a284f1d0", Modifiedby = "714b5a05-bdce-4968-952f-99d6a284f1d0" };
            var ProjectDocument4 = new ProjectDocument() { Id = 4, Title = "Docx4", FileName = "DOCX4.docx", Created = DateTime.Now, Modified = DateTime.Now, Createdby = "714b5a05-bdce-4968-952f-99d6a284f1d0", Modifiedby = "714b5a05-bdce-4968-952f-99d6a284f1d0" };
            var ProjectDocument5 = new ProjectDocument() { Id = 5, Title = "Docx5", FileName = "DOCX5.docx", Created = DateTime.Now, Modified = DateTime.Now, Createdby = "714b5a05-bdce-4968-952f-99d6a284f1d0", Modifiedby = "714b5a05-bdce-4968-952f-99d6a284f1d0" };

            ApplicationDbContext dbContext = new ApplicationDbContext();

            dbContext.Region.AddRange(new List<Region>() { Region1, Region2, Region3, Region4, Region5 });
            dbContext.SubRegion.AddRange(new List<SubRegion>() { SubRegion1, SubRegion2, SubRegion3, SubRegion4, SubRegion5 });
            dbContext.ProjectDocument.AddRange(new List<ProjectDocument>() { ProjectDocument1, ProjectDocument2, ProjectDocument3, ProjectDocument4, ProjectDocument5 });
            dbContext.SuportingDocument.AddRange(new List<SupportingDocument>() { SupportingDocument1, SupportingDocument2, SupportingDocument3, SupportingDocument4, SupportingDocument5 });

            dbContext.SaveChanges();
        }
    }
}
