namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updates1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Departments", newName: "Department");
            MoveTable(name: "dbo.Department", newSchema: "HR");
            RenameColumn(table: "dbo.Employees", name: "Name", newName: "FullName");
            AddColumn("HR.Department", "Location", c => c.String(nullable: false, maxLength: 100, defaultValue: ""));
            AddColumn("dbo.Employees", "Birthdate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("HR.Department", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Employees", "Salary", c => c.Double());
        }

        public override void Down()
        {
            AlterColumn("dbo.Employees", "Salary", c => c.Double(nullable: false));
            AlterColumn("HR.Department", "Name", c => c.String());
            DropColumn("dbo.Employees", "Birthdate");
            DropColumn("HR.Department", "Location");
            RenameColumn(table: "dbo.Employees", name: "FullName", newName: "Name");
            MoveTable(name: "HR.Department", newSchema: "dbo");
            RenameTable(name: "dbo.Department", newName: "Departments");
        }
    }
}
