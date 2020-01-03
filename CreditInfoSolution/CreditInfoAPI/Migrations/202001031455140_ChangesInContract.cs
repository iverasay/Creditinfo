namespace CreditInfoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInContract : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contracts", "Ind1_Id", "dbo.Individuals");
            DropForeignKey("dbo.Contracts", "Ind2_Id", "dbo.Individuals");
            DropForeignKey("dbo.Contracts", "Ind3_Id", "dbo.Individuals");
            DropForeignKey("dbo.Contracts", "SR1_Id", "dbo.SubjectRoles");
            DropForeignKey("dbo.Contracts", "SR2_Id", "dbo.SubjectRoles");
            DropForeignKey("dbo.Contracts", "SR3_Id", "dbo.SubjectRoles");
            DropIndex("dbo.Contracts", new[] { "Ind1_Id" });
            DropIndex("dbo.Contracts", new[] { "Ind2_Id" });
            DropIndex("dbo.Contracts", new[] { "Ind3_Id" });
            DropIndex("dbo.Contracts", new[] { "SR1_Id" });
            DropIndex("dbo.Contracts", new[] { "SR2_Id" });
            DropIndex("dbo.Contracts", new[] { "SR3_Id" });
            AddColumn("dbo.Individuals", "Contract_Id", c => c.Int());
            AddColumn("dbo.SubjectRoles", "Contract_Id", c => c.Int());
            CreateIndex("dbo.Individuals", "Contract_Id");
            CreateIndex("dbo.SubjectRoles", "Contract_Id");
            AddForeignKey("dbo.Individuals", "Contract_Id", "dbo.Contracts", "Id");
            AddForeignKey("dbo.SubjectRoles", "Contract_Id", "dbo.Contracts", "Id");
            DropColumn("dbo.Contracts", "Ind1_Id");
            DropColumn("dbo.Contracts", "Ind2_Id");
            DropColumn("dbo.Contracts", "Ind3_Id");
            DropColumn("dbo.Contracts", "SR1_Id");
            DropColumn("dbo.Contracts", "SR2_Id");
            DropColumn("dbo.Contracts", "SR3_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "SR3_Id", c => c.Int());
            AddColumn("dbo.Contracts", "SR2_Id", c => c.Int());
            AddColumn("dbo.Contracts", "SR1_Id", c => c.Int());
            AddColumn("dbo.Contracts", "Ind3_Id", c => c.Int());
            AddColumn("dbo.Contracts", "Ind2_Id", c => c.Int());
            AddColumn("dbo.Contracts", "Ind1_Id", c => c.Int());
            DropForeignKey("dbo.SubjectRoles", "Contract_Id", "dbo.Contracts");
            DropForeignKey("dbo.Individuals", "Contract_Id", "dbo.Contracts");
            DropIndex("dbo.SubjectRoles", new[] { "Contract_Id" });
            DropIndex("dbo.Individuals", new[] { "Contract_Id" });
            DropColumn("dbo.SubjectRoles", "Contract_Id");
            DropColumn("dbo.Individuals", "Contract_Id");
            CreateIndex("dbo.Contracts", "SR3_Id");
            CreateIndex("dbo.Contracts", "SR2_Id");
            CreateIndex("dbo.Contracts", "SR1_Id");
            CreateIndex("dbo.Contracts", "Ind3_Id");
            CreateIndex("dbo.Contracts", "Ind2_Id");
            CreateIndex("dbo.Contracts", "Ind1_Id");
            AddForeignKey("dbo.Contracts", "SR3_Id", "dbo.SubjectRoles", "Id");
            AddForeignKey("dbo.Contracts", "SR2_Id", "dbo.SubjectRoles", "Id");
            AddForeignKey("dbo.Contracts", "SR1_Id", "dbo.SubjectRoles", "Id");
            AddForeignKey("dbo.Contracts", "Ind3_Id", "dbo.Individuals", "Id");
            AddForeignKey("dbo.Contracts", "Ind2_Id", "dbo.Individuals", "Id");
            AddForeignKey("dbo.Contracts", "Ind1_Id", "dbo.Individuals", "Id");
        }
    }
}
