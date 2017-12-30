namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class ExamenMiembroV11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grado",
                c => new
                    {
                        GradoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
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
                    { "DynamicFilter_Grado_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.GradoId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            AddColumn("dbo.ExamenMiembro", "GradoObtenidoId", c => c.Int(nullable: false));
            AddColumn("dbo.ExamenMiembro", "Asistio", c => c.Boolean(nullable: false));
            AddColumn("dbo.ExamenMiembro", "Aprobado", c => c.Boolean(nullable: false));
            AddColumn("dbo.ExamenMiembro", "GradoObtenido_GradoId", c => c.Int());
            AddColumn("dbo.Miembro", "GradoId", c => c.Int());
            CreateIndex("dbo.ExamenMiembro", "GradoObtenido_GradoId");
            CreateIndex("dbo.Miembro", "GradoId");
            AddForeignKey("dbo.ExamenMiembro", "GradoObtenido_GradoId", "dbo.Grado", "GradoId");
            AddForeignKey("dbo.Miembro", "GradoId", "dbo.Grado", "GradoId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Miembro", "GradoId", "dbo.Grado");
            DropForeignKey("dbo.ExamenMiembro", "GradoObtenido_GradoId", "dbo.Grado");
            DropForeignKey("dbo.Grado", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Grado", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Grado", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Miembro", new[] { "GradoId" });
            DropIndex("dbo.Grado", new[] { "DeletedBy" });
            DropIndex("dbo.Grado", new[] { "UpdatedBy" });
            DropIndex("dbo.Grado", new[] { "CreatedBy" });
            DropIndex("dbo.ExamenMiembro", new[] { "GradoObtenido_GradoId" });
            DropColumn("dbo.Miembro", "GradoId");
            DropColumn("dbo.ExamenMiembro", "GradoObtenido_GradoId");
            DropColumn("dbo.ExamenMiembro", "Aprobado");
            DropColumn("dbo.ExamenMiembro", "Asistio");
            DropColumn("dbo.ExamenMiembro", "GradoObtenidoId");
            DropTable("dbo.Grado",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Grado_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
