namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiembroV4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ExamenMiembro", "GradoObtenido_GradoId", "dbo.Grado");
            DropForeignKey("dbo.Miembro", "GradoId", "dbo.Grado");
            DropIndex("dbo.ExamenMiembro", new[] { "GradoObtenido_GradoId" });
            DropIndex("dbo.Miembro", new[] { "GradoId" });
            DropPrimaryKey("dbo.Grado");
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        EstadoId = c.Byte(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.EstadoId);
            
            CreateTable(
                "dbo.TipoDocumento",
                c => new
                    {
                        TipoDocumentoId = c.Byte(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.TipoDocumentoId);
            
            CreateTable(
                "dbo.TipoMiembro",
                c => new
                    {
                        TipoMiembroId = c.Byte(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.TipoMiembroId);
            
            AddColumn("dbo.Miembro", "TipoDocumentoId", c => c.Byte(nullable: false));
            AddColumn("dbo.Miembro", "TipoMiembroId", c => c.Byte(nullable: false));
            AddColumn("dbo.Miembro", "EstadoId", c => c.Byte(nullable: false));
            AlterColumn("dbo.ExamenMiembro", "GradoObtenido_GradoId", c => c.Byte());
            AlterColumn("dbo.Grado", "GradoId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Miembro", "GradoId", c => c.Byte());
            AddPrimaryKey("dbo.Grado", "GradoId");
            CreateIndex("dbo.ExamenMiembro", "GradoObtenido_GradoId");
            CreateIndex("dbo.Miembro", "TipoDocumentoId");
            CreateIndex("dbo.Miembro", "TipoMiembroId");
            CreateIndex("dbo.Miembro", "EstadoId");
            CreateIndex("dbo.Miembro", "GradoId");
            AddForeignKey("dbo.Miembro", "EstadoId", "dbo.Estado", "EstadoId", cascadeDelete: true);
            AddForeignKey("dbo.Miembro", "TipoDocumentoId", "dbo.TipoDocumento", "TipoDocumentoId", cascadeDelete: true);
            AddForeignKey("dbo.Miembro", "TipoMiembroId", "dbo.TipoMiembro", "TipoMiembroId", cascadeDelete: true);
            AddForeignKey("dbo.ExamenMiembro", "GradoObtenido_GradoId", "dbo.Grado", "GradoId");
            AddForeignKey("dbo.Miembro", "GradoId", "dbo.Grado", "GradoId");
            DropColumn("dbo.Miembro", "TipoDocumento");
            DropColumn("dbo.Miembro", "TipoMiembro");
            DropColumn("dbo.Miembro", "Estado");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Miembro", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Miembro", "TipoMiembro", c => c.Int(nullable: false));
            AddColumn("dbo.Miembro", "TipoDocumento", c => c.Int(nullable: false));
            DropForeignKey("dbo.Miembro", "GradoId", "dbo.Grado");
            DropForeignKey("dbo.ExamenMiembro", "GradoObtenido_GradoId", "dbo.Grado");
            DropForeignKey("dbo.Miembro", "TipoMiembroId", "dbo.TipoMiembro");
            DropForeignKey("dbo.Miembro", "TipoDocumentoId", "dbo.TipoDocumento");
            DropForeignKey("dbo.Miembro", "EstadoId", "dbo.Estado");
            DropIndex("dbo.Miembro", new[] { "GradoId" });
            DropIndex("dbo.Miembro", new[] { "EstadoId" });
            DropIndex("dbo.Miembro", new[] { "TipoMiembroId" });
            DropIndex("dbo.Miembro", new[] { "TipoDocumentoId" });
            DropIndex("dbo.ExamenMiembro", new[] { "GradoObtenido_GradoId" });
            DropPrimaryKey("dbo.Grado");
            AlterColumn("dbo.Miembro", "GradoId", c => c.Int());
            AlterColumn("dbo.Grado", "GradoId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.ExamenMiembro", "GradoObtenido_GradoId", c => c.Int());
            DropColumn("dbo.Miembro", "EstadoId");
            DropColumn("dbo.Miembro", "TipoMiembroId");
            DropColumn("dbo.Miembro", "TipoDocumentoId");
            DropTable("dbo.TipoMiembro");
            DropTable("dbo.TipoDocumento");
            DropTable("dbo.Estado");
            AddPrimaryKey("dbo.Grado", "GradoId");
            CreateIndex("dbo.Miembro", "GradoId");
            CreateIndex("dbo.ExamenMiembro", "GradoObtenido_GradoId");
            AddForeignKey("dbo.Miembro", "GradoId", "dbo.Grado", "GradoId");
            AddForeignKey("dbo.ExamenMiembro", "GradoObtenido_GradoId", "dbo.Grado", "GradoId");
        }
    }
}
