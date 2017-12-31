namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GradoDefaulPostulante : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Miembro", "GradoId", "dbo.Grado");
            DropIndex("dbo.Miembro", new[] { "GradoId" });
            AlterColumn("dbo.Miembro", "GradoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Miembro", "GradoId");
            AddForeignKey("dbo.Miembro", "GradoId", "dbo.Grado", "GradoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Miembro", "GradoId", "dbo.Grado");
            DropIndex("dbo.Miembro", new[] { "GradoId" });
            AlterColumn("dbo.Miembro", "GradoId", c => c.Int());
            CreateIndex("dbo.Miembro", "GradoId");
            AddForeignKey("dbo.Miembro", "GradoId", "dbo.Grado", "GradoId");
        }
    }
}
