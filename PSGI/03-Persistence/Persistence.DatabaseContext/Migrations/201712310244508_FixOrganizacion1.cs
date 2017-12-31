namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixOrganizacion1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Area", "Nombre", c => c.String());
            AlterColumn("dbo.Territorio", "Nombre", c => c.String());
            AlterColumn("dbo.Sector", "Nombre", c => c.String());
            AlterColumn("dbo.Zona", "Nombre", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Zona", "Nombre", c => c.Int(nullable: false));
            AlterColumn("dbo.Sector", "Nombre", c => c.Int(nullable: false));
            AlterColumn("dbo.Territorio", "Nombre", c => c.Int(nullable: false));
            AlterColumn("dbo.Area", "Nombre", c => c.Int(nullable: false));
        }
    }
}
