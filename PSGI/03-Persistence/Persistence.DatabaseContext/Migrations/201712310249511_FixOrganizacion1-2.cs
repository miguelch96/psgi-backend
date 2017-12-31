namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class FixOrganizacion12 : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Area",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        TerritorioId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Area_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Territorio",
                c => new
                    {
                        TerritorioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Territorio_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Grupo",
                c => new
                    {
                        GrupoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        SectorId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Grupo_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Sector",
                c => new
                    {
                        SectorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ZonaId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Sector_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Zona",
                c => new
                    {
                        ZonaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        AreaId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Zona_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            DropColumn("dbo.Area", "Deleted");
            DropColumn("dbo.Territorio", "Deleted");
            DropColumn("dbo.Grupo", "Deleted");
            DropColumn("dbo.Sector", "Deleted");
            DropColumn("dbo.Zona", "Deleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zona", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Sector", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Grupo", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Territorio", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Area", "Deleted", c => c.Boolean(nullable: false));
            AlterTableAnnotations(
                "dbo.Zona",
                c => new
                    {
                        ZonaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        AreaId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Zona_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Sector",
                c => new
                    {
                        SectorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        ZonaId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Sector_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Grupo",
                c => new
                    {
                        GrupoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        SectorId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Grupo_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Territorio",
                c => new
                    {
                        TerritorioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Territorio_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Area",
                c => new
                    {
                        AreaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        TerritorioId = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Area_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
        }
    }
}
