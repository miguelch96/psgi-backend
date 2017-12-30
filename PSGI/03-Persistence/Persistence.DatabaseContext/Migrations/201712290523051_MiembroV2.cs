namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MiembroV2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Courses", newName: "Course");
            RenameTable(name: "dbo.StudentPerCourses", newName: "StudentPerCourse");
            RenameTable(name: "dbo.Students", newName: "Student");
            RenameTable(name: "dbo.Miembroes", newName: "Miembro");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Miembro", newName: "Miembroes");
            RenameTable(name: "dbo.Student", newName: "Students");
            RenameTable(name: "dbo.StudentPerCourse", newName: "StudentPerCourses");
            RenameTable(name: "dbo.Course", newName: "Courses");
        }
    }
}
