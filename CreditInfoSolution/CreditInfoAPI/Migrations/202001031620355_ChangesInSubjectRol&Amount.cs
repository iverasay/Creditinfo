namespace CreditInfoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInSubjectRolAmount : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Amounts", "Currency", c => c.String());
            AlterColumn("dbo.SubjectRoles", "RoleOfCustomer", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubjectRoles", "RoleOfCustomer", c => c.Int(nullable: false));
            AlterColumn("dbo.Amounts", "Currency", c => c.Int(nullable: false));
        }
    }
}
