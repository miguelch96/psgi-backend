namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiembroV31 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Miembro", "Grupo_GrupoId", "dbo.Grupo");
            DropIndex("dbo.Miembro", new[] { "Grupo_GrupoId" });
            RenameColumn(table: "dbo.Miembro", name: "Grupo_GrupoId", newName: "GrupoId");
            AlterColumn("dbo.Miembro", "GrupoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Miembro", "GrupoId");
            AddForeignKey("dbo.Miembro", "GrupoId", "dbo.Grupo", "GrupoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Miembro", "GrupoId", "dbo.Grupo");
            DropIndex("dbo.Miembro", new[] { "GrupoId" });
            AlterColumn("dbo.Miembro", "GrupoId", c => c.Int());
            RenameColumn(table: "dbo.Miembro", name: "GrupoId", newName: "Grupo_GrupoId");
            CreateIndex("dbo.Miembro", "Grupo_GrupoId");
            AddForeignKey("dbo.Miembro", "Grupo_GrupoId", "dbo.Grupo", "GrupoId");
        }
    }
}
