namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class TerrArZonSecGrupo : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Miembro", "FechaNacimiento", c => c.DateTime(nullable: false));
            AddColumn("dbo.Miembro", "Genre", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
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
            DropIndex("dbo.Territorio", new[] { "DeletedBy" });
            DropIndex("dbo.Territorio", new[] { "UpdatedBy" });
            DropIndex("dbo.Territorio", new[] { "CreatedBy" });
            DropIndex("dbo.Area", new[] { "Territorio_TerritorioId" });
            DropIndex("dbo.Area", new[] { "DeletedBy" });
            DropIndex("dbo.Area", new[] { "UpdatedBy" });
            DropIndex("dbo.Area", new[] { "CreatedBy" });
            DropColumn("dbo.Miembro", "Genre");
            DropColumn("dbo.Miembro", "FechaNacimiento");
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
        }
    }
}
