namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiembroV3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Miembro", "TipoDocumento", c => c.Int(nullable: false));
            AddColumn("dbo.Miembro", "NroDocumento", c => c.String());
            AddColumn("dbo.Miembro", "Sexo", c => c.Int(nullable: false));
            AddColumn("dbo.Miembro", "TipoMiembro", c => c.Int(nullable: false));
            AddColumn("dbo.Miembro", "Estado", c => c.Int(nullable: false));
            AddColumn("dbo.Miembro", "Grupo_GrupoId", c => c.Int());
            CreateIndex("dbo.Miembro", "Grupo_GrupoId");
            AddForeignKey("dbo.Miembro", "Grupo_GrupoId", "dbo.Grupo", "GrupoId");
            DropColumn("dbo.Miembro", "Genre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Miembro", "Genre", c => c.Int(nullable: false));
            DropForeignKey("dbo.Miembro", "Grupo_GrupoId", "dbo.Grupo");
            DropIndex("dbo.Miembro", new[] { "Grupo_GrupoId" });
            DropColumn("dbo.Miembro", "Grupo_GrupoId");
            DropColumn("dbo.Miembro", "Estado");
            DropColumn("dbo.Miembro", "TipoMiembro");
            DropColumn("dbo.Miembro", "Sexo");
            DropColumn("dbo.Miembro", "NroDocumento");
            DropColumn("dbo.Miembro", "TipoDocumento");
        }
    }
}
