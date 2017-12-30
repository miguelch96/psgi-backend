namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DivisionIdINT : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Miembro", "Division_DivisionId", "dbo.Division");
            DropIndex("dbo.Miembro", new[] { "Division_DivisionId" });
            DropColumn("dbo.Miembro", "DivisionId");
            RenameColumn(table: "dbo.Miembro", name: "Division_DivisionId", newName: "DivisionId");
            DropPrimaryKey("dbo.Division");
            AlterColumn("dbo.Division", "DivisionId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Miembro", "DivisionId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Division", "DivisionId");
            CreateIndex("dbo.Miembro", "DivisionId");
            AddForeignKey("dbo.Miembro", "DivisionId", "dbo.Division", "DivisionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Miembro", "DivisionId", "dbo.Division");
            DropIndex("dbo.Miembro", new[] { "DivisionId" });
            DropPrimaryKey("dbo.Division");
            AlterColumn("dbo.Miembro", "DivisionId", c => c.Byte());
            AlterColumn("dbo.Division", "DivisionId", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Division", "DivisionId");
            RenameColumn(table: "dbo.Miembro", name: "DivisionId", newName: "Division_DivisionId");
            AddColumn("dbo.Miembro", "DivisionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Miembro", "Division_DivisionId");
            AddForeignKey("dbo.Miembro", "Division_DivisionId", "dbo.Division", "DivisionId");
        }
    }
}
