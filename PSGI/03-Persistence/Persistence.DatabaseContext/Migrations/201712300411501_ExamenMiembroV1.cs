namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExamenMiembroV1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ExamenMiembro", "GradoObtenidoId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ExamenMiembro", "GradoObtenidoId", c => c.Int(nullable: false));
        }
    }
}
