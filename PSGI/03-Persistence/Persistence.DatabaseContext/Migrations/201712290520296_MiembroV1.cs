namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class MiembroV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Miembroes",
                c => new
                    {
                        MiembroId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Miembro_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.MiembroId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Miembroes", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Miembroes", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Miembroes", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Miembroes", new[] { "DeletedBy" });
            DropIndex("dbo.Miembroes", new[] { "UpdatedBy" });
            DropIndex("dbo.Miembroes", new[] { "CreatedBy" });
            DropTable("dbo.Miembroes",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Miembro_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
