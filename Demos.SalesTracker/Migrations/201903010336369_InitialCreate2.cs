namespace Demos.SalesTracker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectDocumentInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ProjectDocumentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectDocuments", t => t.ProjectDocumentId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.ProjectDocumentId);
            
            CreateTable(
                "dbo.SupportingDocumentInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        SupportingDocumentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.SupportingDocuments", t => t.SupportingDocumentId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.SupportingDocumentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupportingDocumentInfoes", "SupportingDocumentId", "dbo.SupportingDocuments");
            DropForeignKey("dbo.SupportingDocumentInfoes", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectDocumentInfoes", "ProjectDocumentId", "dbo.ProjectDocuments");
            DropForeignKey("dbo.ProjectDocumentInfoes", "ProjectId", "dbo.Projects");
            DropIndex("dbo.SupportingDocumentInfoes", new[] { "SupportingDocumentId" });
            DropIndex("dbo.SupportingDocumentInfoes", new[] { "ProjectId" });
            DropIndex("dbo.ProjectDocumentInfoes", new[] { "ProjectDocumentId" });
            DropIndex("dbo.ProjectDocumentInfoes", new[] { "ProjectId" });
            DropTable("dbo.SupportingDocumentInfoes");
            DropTable("dbo.ProjectDocumentInfoes");
        }
    }
}
