namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class EstaticoExamenMiembroV1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Courses", newName: "Course");
            RenameTable(name: "dbo.StudentPerCourses", newName: "StudentPerCourse");
            RenameTable(name: "dbo.Students", newName: "Student");
            CreateTable(
                "dbo.Area",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        Territorio_TerritorioId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Area_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.AreaId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Territorio", t => t.Territorio_TerritorioId)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.Territorio_TerritorioId);
            
            CreateTable(
                "dbo.Territorio",
                c => new
                    {
                        TerritorioId = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
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
                    { "DynamicFilter_Territorio_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.TerritorioId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy);
            
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        DivisionId = c.Byte(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.DivisionId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.EstadoId);
            
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
                    })
                .PrimaryKey(t => t.ExamenId);
            
            CreateTable(
                "dbo.ExamenMiembro",
                c => new
                    {
                        ExamenMiembroId = c.Int(nullable: false, identity: true),
                        FechaInscripcion = c.DateTime(nullable: false),
                        MiembroId = c.Int(nullable: false),
                        ExamenId = c.Int(nullable: false),
                        GradoObtenidoId = c.Int(),
                        Asistio = c.Boolean(nullable: false),
                        Aprobado = c.Boolean(nullable: false),
                        GradoObtenido_GradoId = c.Int(),
                    })
                .PrimaryKey(t => t.ExamenMiembroId)
                .ForeignKey("dbo.Examen", t => t.ExamenId, cascadeDelete: true)
                .ForeignKey("dbo.Grado", t => t.GradoObtenido_GradoId)
                .ForeignKey("dbo.Miembro", t => t.MiembroId, cascadeDelete: true)
                .Index(t => t.MiembroId)
                .Index(t => t.ExamenId)
                .Index(t => t.GradoObtenido_GradoId);
            
            CreateTable(
                "dbo.Grado",
                c => new
                    {
                        GradoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.GradoId);
            
            CreateTable(
                "dbo.Miembro",
                c => new
                    {
                        MiembroId = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        TipoDocumentoId = c.Int(nullable: false),
                        NroDocumento = c.String(),
                        Sexo = c.Int(nullable: false),
                        TipoMiembroId = c.Int(nullable: false),
                        DivisionId = c.Int(nullable: false),
                        GrupoId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        GradoId = c.Int(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        Division_DivisionId = c.Byte(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Miembro_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.MiembroId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Division", t => t.Division_DivisionId)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: true)
                .ForeignKey("dbo.Grado", t => t.GradoId)
                .ForeignKey("dbo.Grupo", t => t.GrupoId, cascadeDelete: true)
                .ForeignKey("dbo.TipoDocumento", t => t.TipoDocumentoId, cascadeDelete: true)
                .ForeignKey("dbo.TipoMiembro", t => t.TipoMiembroId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.TipoDocumentoId)
                .Index(t => t.TipoMiembroId)
                .Index(t => t.GrupoId)
                .Index(t => t.EstadoId)
                .Index(t => t.GradoId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.Division_DivisionId);
            
            CreateTable(
                "dbo.Grupo",
                c => new
                    {
                        GrupoId = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        Sector_SectorId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Grupo_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.GrupoId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.Sector", t => t.Sector_SectorId)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.Sector_SectorId);
            
            CreateTable(
                "dbo.Sector",
                c => new
                    {
                        SectorId = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        Zona_ZonaId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Sector_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.SectorId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .ForeignKey("dbo.Zona", t => t.Zona_ZonaId)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.Zona_ZonaId);
            
            CreateTable(
                "dbo.Zona",
                c => new
                    {
                        ZonaId = c.Int(nullable: false, identity: true),
                        Nombre = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                        Area_AreaId = c.Int(),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Zona_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.ZonaId)
                .ForeignKey("dbo.Area", t => t.Area_AreaId)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.DeletedBy)
                .ForeignKey("dbo.AspNetUsers", t => t.UpdatedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.UpdatedBy)
                .Index(t => t.DeletedBy)
                .Index(t => t.Area_AreaId);
            
            CreateTable(
                "dbo.TipoDocumento",
                c => new
                    {
                        TipoDocumentoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.TipoDocumentoId);
            
            CreateTable(
                "dbo.TipoMiembro",
                c => new
                    {
                        TipoMiembroId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.TipoMiembroId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Miembro", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Miembro", "TipoMiembroId", "dbo.TipoMiembro");
            DropForeignKey("dbo.Miembro", "TipoDocumentoId", "dbo.TipoDocumento");
            DropForeignKey("dbo.Miembro", "GrupoId", "dbo.Grupo");
            DropForeignKey("dbo.Grupo", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Grupo", "Sector_SectorId", "dbo.Sector");
            DropForeignKey("dbo.Sector", "Zona_ZonaId", "dbo.Zona");
            DropForeignKey("dbo.Zona", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Zona", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Zona", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Zona", "Area_AreaId", "dbo.Area");
            DropForeignKey("dbo.Sector", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sector", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sector", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Grupo", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Grupo", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Miembro", "GradoId", "dbo.Grado");
            DropForeignKey("dbo.ExamenMiembro", "MiembroId", "dbo.Miembro");
            DropForeignKey("dbo.Miembro", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Miembro", "Division_DivisionId", "dbo.Division");
            DropForeignKey("dbo.Miembro", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Miembro", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.ExamenMiembro", "GradoObtenido_GradoId", "dbo.Grado");
            DropForeignKey("dbo.ExamenMiembro", "ExamenId", "dbo.Examen");
            DropForeignKey("dbo.Area", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Area", "Territorio_TerritorioId", "dbo.Territorio");
            DropForeignKey("dbo.Territorio", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Territorio", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Territorio", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Area", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Area", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Zona", new[] { "Area_AreaId" });
            DropIndex("dbo.Zona", new[] { "DeletedBy" });
            DropIndex("dbo.Zona", new[] { "UpdatedBy" });
            DropIndex("dbo.Zona", new[] { "CreatedBy" });
            DropIndex("dbo.Sector", new[] { "Zona_ZonaId" });
            DropIndex("dbo.Sector", new[] { "DeletedBy" });
            DropIndex("dbo.Sector", new[] { "UpdatedBy" });
            DropIndex("dbo.Sector", new[] { "CreatedBy" });
            DropIndex("dbo.Grupo", new[] { "Sector_SectorId" });
            DropIndex("dbo.Grupo", new[] { "DeletedBy" });
            DropIndex("dbo.Grupo", new[] { "UpdatedBy" });
            DropIndex("dbo.Grupo", new[] { "CreatedBy" });
            DropIndex("dbo.Miembro", new[] { "Division_DivisionId" });
            DropIndex("dbo.Miembro", new[] { "DeletedBy" });
            DropIndex("dbo.Miembro", new[] { "UpdatedBy" });
            DropIndex("dbo.Miembro", new[] { "CreatedBy" });
            DropIndex("dbo.Miembro", new[] { "GradoId" });
            DropIndex("dbo.Miembro", new[] { "EstadoId" });
            DropIndex("dbo.Miembro", new[] { "GrupoId" });
            DropIndex("dbo.Miembro", new[] { "TipoMiembroId" });
            DropIndex("dbo.Miembro", new[] { "TipoDocumentoId" });
            DropIndex("dbo.ExamenMiembro", new[] { "GradoObtenido_GradoId" });
            DropIndex("dbo.ExamenMiembro", new[] { "ExamenId" });
            DropIndex("dbo.ExamenMiembro", new[] { "MiembroId" });
            DropIndex("dbo.Territorio", new[] { "DeletedBy" });
            DropIndex("dbo.Territorio", new[] { "UpdatedBy" });
            DropIndex("dbo.Territorio", new[] { "CreatedBy" });
            DropIndex("dbo.Area", new[] { "Territorio_TerritorioId" });
            DropIndex("dbo.Area", new[] { "DeletedBy" });
            DropIndex("dbo.Area", new[] { "UpdatedBy" });
            DropIndex("dbo.Area", new[] { "CreatedBy" });
            DropTable("dbo.TipoMiembro");
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.Zona",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Zona_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Sector",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Sector_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Grupo",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Grupo_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Miembro",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Miembro_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Grado");
            DropTable("dbo.ExamenMiembro");
            DropTable("dbo.Examen");
            DropTable("dbo.Estado");
            DropTable("dbo.Division");
            DropTable("dbo.Territorio",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Territorio_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.Area",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Area_IsDeleted", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            RenameTable(name: "dbo.Student", newName: "Students");
            RenameTable(name: "dbo.StudentPerCourse", newName: "StudentPerCourses");
            RenameTable(name: "dbo.Course", newName: "Courses");
        }
    }
}
