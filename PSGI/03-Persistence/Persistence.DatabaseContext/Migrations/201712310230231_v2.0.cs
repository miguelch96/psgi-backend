namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Area", "Territorio_TerritorioId", "dbo.Territorio");
            DropForeignKey("dbo.Grupo", "Sector_SectorId", "dbo.Sector");
            DropForeignKey("dbo.Sector", "Zona_ZonaId", "dbo.Zona");
            DropForeignKey("dbo.Zona", "Area_AreaId", "dbo.Area");
            DropIndex("dbo.Area", new[] { "Territorio_TerritorioId" });
            DropIndex("dbo.Grupo", new[] { "Sector_SectorId" });
            DropIndex("dbo.Sector", new[] { "Zona_ZonaId" });
            DropIndex("dbo.Zona", new[] { "Area_AreaId" });
            RenameColumn(table: "dbo.Area", name: "Territorio_TerritorioId", newName: "TerritorioId");
            RenameColumn(table: "dbo.Grupo", name: "Sector_SectorId", newName: "SectorId");
            RenameColumn(table: "dbo.Sector", name: "Zona_ZonaId", newName: "ZonaId");
            RenameColumn(table: "dbo.Zona", name: "Area_AreaId", newName: "AreaId");
            CreateTable(
                "dbo.DetalleSuscripcion",
                c => new
                    {
                        DetalleSuscripcionId = c.Int(nullable: false, identity: true),
                        SuscripcionId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        TipoSuscripcionId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Subtotal = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.DetalleSuscripcionId)
                .ForeignKey("dbo.Producto", t => t.ProductoId, cascadeDelete: true)
                .ForeignKey("dbo.Suscripcion", t => t.SuscripcionId, cascadeDelete: true)
                .ForeignKey("dbo.TipoSuscripcion", t => t.TipoSuscripcionId, cascadeDelete: true)
                .Index(t => t.SuscripcionId)
                .Index(t => t.ProductoId)
                .Index(t => t.TipoSuscripcionId);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        NroEdicion = c.Int(nullable: false),
                        TipoProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.TipoProducto", t => t.TipoProductoId, cascadeDelete: true)
                .Index(t => t.TipoProductoId);
            
            CreateTable(
                "dbo.TipoProducto",
                c => new
                    {
                        TipoProductoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Siglas = c.String(),
                    })
                .PrimaryKey(t => t.TipoProductoId);
            
            CreateTable(
                "dbo.Suscripcion",
                c => new
                    {
                        SuscripcionId = c.Int(nullable: false, identity: true),
                        Total = c.Single(nullable: false),
                        MiembroId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SuscripcionId)
                .ForeignKey("dbo.Miembro", t => t.MiembroId, cascadeDelete: true)
                .Index(t => t.MiembroId);
            
            CreateTable(
                "dbo.TipoSuscripcion",
                c => new
                    {
                        TipoSuscripcionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.TipoSuscripcionId);
            
            AlterColumn("dbo.Area", "TerritorioId", c => c.Int(nullable: false));
            AlterColumn("dbo.Grupo", "Nombre", c => c.String());
            AlterColumn("dbo.Grupo", "SectorId", c => c.Int(nullable: false));
            AlterColumn("dbo.Sector", "ZonaId", c => c.Int(nullable: false));
            AlterColumn("dbo.Zona", "AreaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Area", "TerritorioId");
            CreateIndex("dbo.Grupo", "SectorId");
            CreateIndex("dbo.Sector", "ZonaId");
            CreateIndex("dbo.Zona", "AreaId");
            AddForeignKey("dbo.Area", "TerritorioId", "dbo.Territorio", "TerritorioId", cascadeDelete: true);
            AddForeignKey("dbo.Grupo", "SectorId", "dbo.Sector", "SectorId", cascadeDelete: true);
            AddForeignKey("dbo.Sector", "ZonaId", "dbo.Zona", "ZonaId", cascadeDelete: true);
            AddForeignKey("dbo.Zona", "AreaId", "dbo.Area", "AreaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Zona", "AreaId", "dbo.Area");
            DropForeignKey("dbo.Sector", "ZonaId", "dbo.Zona");
            DropForeignKey("dbo.Grupo", "SectorId", "dbo.Sector");
            DropForeignKey("dbo.Area", "TerritorioId", "dbo.Territorio");
            DropForeignKey("dbo.DetalleSuscripcion", "TipoSuscripcionId", "dbo.TipoSuscripcion");
            DropForeignKey("dbo.DetalleSuscripcion", "SuscripcionId", "dbo.Suscripcion");
            DropForeignKey("dbo.Suscripcion", "MiembroId", "dbo.Miembro");
            DropForeignKey("dbo.DetalleSuscripcion", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.Producto", "TipoProductoId", "dbo.TipoProducto");
            DropIndex("dbo.Zona", new[] { "AreaId" });
            DropIndex("dbo.Sector", new[] { "ZonaId" });
            DropIndex("dbo.Grupo", new[] { "SectorId" });
            DropIndex("dbo.Suscripcion", new[] { "MiembroId" });
            DropIndex("dbo.Producto", new[] { "TipoProductoId" });
            DropIndex("dbo.DetalleSuscripcion", new[] { "TipoSuscripcionId" });
            DropIndex("dbo.DetalleSuscripcion", new[] { "ProductoId" });
            DropIndex("dbo.DetalleSuscripcion", new[] { "SuscripcionId" });
            DropIndex("dbo.Area", new[] { "TerritorioId" });
            AlterColumn("dbo.Zona", "AreaId", c => c.Int());
            AlterColumn("dbo.Sector", "ZonaId", c => c.Int());
            AlterColumn("dbo.Grupo", "SectorId", c => c.Int());
            AlterColumn("dbo.Grupo", "Nombre", c => c.Int(nullable: false));
            AlterColumn("dbo.Area", "TerritorioId", c => c.Int());
            DropTable("dbo.TipoSuscripcion");
            DropTable("dbo.Suscripcion");
            DropTable("dbo.TipoProducto");
            DropTable("dbo.Producto");
            DropTable("dbo.DetalleSuscripcion");
            RenameColumn(table: "dbo.Zona", name: "AreaId", newName: "Area_AreaId");
            RenameColumn(table: "dbo.Sector", name: "ZonaId", newName: "Zona_ZonaId");
            RenameColumn(table: "dbo.Grupo", name: "SectorId", newName: "Sector_SectorId");
            RenameColumn(table: "dbo.Area", name: "TerritorioId", newName: "Territorio_TerritorioId");
            CreateIndex("dbo.Zona", "Area_AreaId");
            CreateIndex("dbo.Sector", "Zona_ZonaId");
            CreateIndex("dbo.Grupo", "Sector_SectorId");
            CreateIndex("dbo.Area", "Territorio_TerritorioId");
            AddForeignKey("dbo.Zona", "Area_AreaId", "dbo.Area", "AreaId");
            AddForeignKey("dbo.Sector", "Zona_ZonaId", "dbo.Zona", "ZonaId");
            AddForeignKey("dbo.Grupo", "Sector_SectorId", "dbo.Sector", "SectorId");
            AddForeignKey("dbo.Area", "Territorio_TerritorioId", "dbo.Territorio", "TerritorioId");
        }
    }
}
