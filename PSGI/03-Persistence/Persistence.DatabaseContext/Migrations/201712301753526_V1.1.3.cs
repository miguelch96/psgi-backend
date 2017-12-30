namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V113 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        DivisionId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Siglas = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.DivisionId);
            
            AddColumn("dbo.Miembro", "DivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Miembro", "DivisionId");
            AddForeignKey("dbo.Miembro", "DivisionId", "dbo.Division", "DivisionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Miembro", "DivisionId", "dbo.Division");
            DropIndex("dbo.Miembro", new[] { "DivisionId" });
            DropColumn("dbo.Miembro", "DivisionId");
            DropTable("dbo.Division");
        }
    }
}
