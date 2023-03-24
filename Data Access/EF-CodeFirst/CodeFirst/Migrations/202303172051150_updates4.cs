namespace CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class updates4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WorksFors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Hours = c.Int(nullable: false),
                        Employee_ID = c.Int(),
                        Project_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Employees", t => t.Employee_ID)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .Index(t => t.Employee_ID)
                .Index(t => t.Project_Id);

            AddColumn("dbo.Employees", "SupervisedDeptId", c => c.Int());
            CreateIndex("dbo.Employees", "SupervisedDeptId");
            AddForeignKey("dbo.Employees", "SupervisedDeptId", "HR.Department", "ID");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Employees", "SupervisedDeptId", "HR.Department");
            DropForeignKey("dbo.WorksFors", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.WorksFors", "Employee_ID", "dbo.Employees");
            DropIndex("dbo.WorksFors", new[] { "Project_Id" });
            DropIndex("dbo.WorksFors", new[] { "Employee_ID" });
            DropIndex("dbo.Employees", new[] { "SupervisedDeptId" });
            DropColumn("dbo.Employees", "SupervisedDeptId");
            DropTable("dbo.WorksFors");
        }
    }
}
