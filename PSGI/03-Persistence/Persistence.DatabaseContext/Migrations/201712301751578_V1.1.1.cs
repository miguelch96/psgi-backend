namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V111 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Miembro", "DivisionId", "dbo.Division");
            DropIndex("dbo.Miembro", new[] { "DivisionId" });
            DropColumn("dbo.Miembro", "DivisionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Miembro", "DivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Miembro", "DivisionId");
            AddForeignKey("dbo.Miembro", "DivisionId", "dbo.Division", "DivisionId", cascadeDelete: true);
        }
    }
}
