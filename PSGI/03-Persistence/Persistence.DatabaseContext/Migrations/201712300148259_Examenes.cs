namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class Examenes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Examen",
                c => new
                    {
                        ExamenId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Ubicacion = c.String(),
                        FechaInicioInscripcion = c.DateTime(nullable: false),
                        FechaFinInsripcion = c.DateTime(nullable: false),
                        FechaExamen = c.DateTime(nullable: false),
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
                    { "DynamicFilter_Examen_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.ExamenId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.ExamenMiembro",
                c => new
                    {
                        ExamenMiembroId = c.Int(nullable: false, identity: true),
                        FechaInscripcion = c.DateTime(nullable: false),
                        MiembroId = c.Int(nullable: false),
                        ExamenId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ExamenMiembroId)
                .ForeignKey("dbo.Examen", t => t.ExamenId, cascadeDelete: true)
                .ForeignKey("dbo.Miembro", t => t.MiembroId, cascadeDelete: true)
                .Index(t => t.MiembroId)
                .Index(t => t.ExamenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Examen", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ExamenMiembro", "MiembroId", "dbo.Miembro");
            DropForeignKey("dbo.ExamenMiembro", "ExamenId", "dbo.Examen");
            DropForeignKey("dbo.Examen", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Examen", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.ExamenMiembro", new[] { "ExamenId" });
            DropIndex("dbo.ExamenMiembro", new[] { "MiembroId" });
            DropIndex("dbo.Examen", new[] { "DeletedBy" });
            DropIndex("dbo.Examen", new[] { "UpdatedBy" });
            DropIndex("dbo.Examen", new[] { "CreatedBy" });
            DropTable("dbo.ExamenMiembro");
            DropTable("dbo.Examen",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Examen_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
