namespace Lap_TH456.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "Attendee_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Attendances", "CourseId", "dbo.Courses");
            DropIndex("dbo.Attendances", new[] { "Attendee_Id" });
            DropColumn("dbo.Attendances", "AttendeeId");
            RenameColumn(table: "dbo.Attendances", name: "Attendee_Id", newName: "AttendeeId");
            DropPrimaryKey("dbo.Attendances");
            AlterColumn("dbo.Attendances", "AttendeeId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Attendances", "AttendeeId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Attendances", new[] { "CourseId", "AttendeeId" });
            CreateIndex("dbo.Attendances", "AttendeeId");
            AddForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Attendances", "CourseId", "dbo.Courses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            DropPrimaryKey("dbo.Attendances");
            AlterColumn("dbo.Attendances", "AttendeeId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Attendances", "AttendeeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Attendances", new[] { "CourseId", "AttendeeId" });
            RenameColumn(table: "dbo.Attendances", name: "AttendeeId", newName: "Attendee_Id");
            AddColumn("dbo.Attendances", "AttendeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Attendances", "Attendee_Id");
            AddForeignKey("dbo.Attendances", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Attendances", "Attendee_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
