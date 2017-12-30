namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V114 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TipoDocumento", "Siglas", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TipoDocumento", "Siglas");
        }
    }
}
