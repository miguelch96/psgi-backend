namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class V11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Division", "Siglas", c => c.String());
            AddColumn("dbo.Division", "Descripcion", c => c.String());
            AddColumn("dbo.Estado", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Estado", "Descripcion");
            DropColumn("dbo.Division", "Descripcion");
            DropColumn("dbo.Division", "Siglas");
        }
    }
}
