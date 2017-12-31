namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NroDocReFixed : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Miembro", new[] { "NroDocumento" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Miembro", "NroDocumento", unique: true);
        }
    }
}
