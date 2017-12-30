namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V112 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Division");
        }
        
        public override void Down()
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
            
        }
    }
}
