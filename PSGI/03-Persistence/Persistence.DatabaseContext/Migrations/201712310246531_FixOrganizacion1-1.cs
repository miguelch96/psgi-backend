namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixOrganizacion11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Area", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Area", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Territorio", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Territorio", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Territorio", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Area", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Grupo", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Grupo", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sector", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sector", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sector", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Zona", "CreatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Zona", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Zona", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Grupo", "UpdatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.Area", new[] { "CreatedBy" });
            DropIndex("dbo.Area", new[] { "UpdatedBy" });
            DropIndex("dbo.Area", new[] { "DeletedBy" });
            DropIndex("dbo.Territorio", new[] { "CreatedBy" });
            DropIndex("dbo.Territorio", new[] { "UpdatedBy" });
            DropIndex("dbo.Territorio", new[] { "DeletedBy" });
            DropIndex("dbo.Grupo", new[] { "CreatedBy" });
            DropIndex("dbo.Grupo", new[] { "UpdatedBy" });
            DropIndex("dbo.Grupo", new[] { "DeletedBy" });
            DropIndex("dbo.Sector", new[] { "CreatedBy" });
            DropIndex("dbo.Sector", new[] { "UpdatedBy" });
            DropIndex("dbo.Sector", new[] { "DeletedBy" });
            DropIndex("dbo.Zona", new[] { "CreatedBy" });
            DropIndex("dbo.Zona", new[] { "UpdatedBy" });
            DropIndex("dbo.Zona", new[] { "DeletedBy" });
            DropColumn("dbo.Area", "CreatedAt");
            DropColumn("dbo.Area", "CreatedBy");
            DropColumn("dbo.Area", "UpdatedAt");
            DropColumn("dbo.Area", "UpdatedBy");
            DropColumn("dbo.Area", "DeletedAt");
            DropColumn("dbo.Area", "DeletedBy");
            DropColumn("dbo.Territorio", "CreatedAt");
            DropColumn("dbo.Territorio", "CreatedBy");
            DropColumn("dbo.Territorio", "UpdatedAt");
            DropColumn("dbo.Territorio", "UpdatedBy");
            DropColumn("dbo.Territorio", "DeletedAt");
            DropColumn("dbo.Territorio", "DeletedBy");
            DropColumn("dbo.Grupo", "CreatedAt");
            DropColumn("dbo.Grupo", "CreatedBy");
            DropColumn("dbo.Grupo", "UpdatedAt");
            DropColumn("dbo.Grupo", "UpdatedBy");
            DropColumn("dbo.Grupo", "DeletedAt");
            DropColumn("dbo.Grupo", "DeletedBy");
            DropColumn("dbo.Sector", "CreatedAt");
            DropColumn("dbo.Sector", "CreatedBy");
            DropColumn("dbo.Sector", "UpdatedAt");
            DropColumn("dbo.Sector", "UpdatedBy");
            DropColumn("dbo.Sector", "DeletedAt");
            DropColumn("dbo.Sector", "DeletedBy");
            DropColumn("dbo.Zona", "CreatedAt");
            DropColumn("dbo.Zona", "CreatedBy");
            DropColumn("dbo.Zona", "UpdatedAt");
            DropColumn("dbo.Zona", "UpdatedBy");
            DropColumn("dbo.Zona", "DeletedAt");
            DropColumn("dbo.Zona", "DeletedBy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Zona", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Zona", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Zona", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Zona", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Zona", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Zona", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Sector", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Sector", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Sector", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Sector", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Sector", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Sector", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Grupo", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Grupo", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Grupo", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Grupo", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Grupo", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Grupo", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Territorio", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Territorio", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Territorio", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Territorio", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Territorio", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Territorio", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Area", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Area", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Area", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Area", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Area", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Area", "CreatedAt", c => c.DateTime());
            CreateIndex("dbo.Zona", "DeletedBy");
            CreateIndex("dbo.Zona", "UpdatedBy");
            CreateIndex("dbo.Zona", "CreatedBy");
            CreateIndex("dbo.Sector", "DeletedBy");
            CreateIndex("dbo.Sector", "UpdatedBy");
            CreateIndex("dbo.Sector", "CreatedBy");
            CreateIndex("dbo.Grupo", "DeletedBy");
            CreateIndex("dbo.Grupo", "UpdatedBy");
            CreateIndex("dbo.Grupo", "CreatedBy");
            CreateIndex("dbo.Territorio", "DeletedBy");
            CreateIndex("dbo.Territorio", "UpdatedBy");
            CreateIndex("dbo.Territorio", "CreatedBy");
            CreateIndex("dbo.Area", "DeletedBy");
            CreateIndex("dbo.Area", "UpdatedBy");
            CreateIndex("dbo.Area", "CreatedBy");
            AddForeignKey("dbo.Grupo", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Zona", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Zona", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Zona", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Sector", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Sector", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Sector", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Grupo", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Grupo", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Area", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Territorio", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Territorio", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Territorio", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Area", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Area", "CreatedBy", "dbo.AspNetUsers", "Id");
        }
    }
}
