namespace CreditInfoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContractData : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.GuaranteeAmounts", newName: "Amounts");
            CreateTable(
                "dbo.ContractDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhaseOfContract = c.String(),
                        DateOfLastPayment = c.DateTime(nullable: false),
                        NextPaymentDate = c.DateTime(nullable: false),
                        DateAccountOpened = c.DateTime(nullable: false),
                        RealEndDate = c.DateTime(nullable: false),
                        CurrentBalance_Id = c.Int(),
                        InstallmentAmount_Id = c.Int(),
                        OriginalAmount_Id = c.Int(),
                        OverdueBalance_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Amounts", t => t.CurrentBalance_Id)
                .ForeignKey("dbo.Amounts", t => t.InstallmentAmount_Id)
                .ForeignKey("dbo.Amounts", t => t.OriginalAmount_Id)
                .ForeignKey("dbo.Amounts", t => t.OverdueBalance_Id)
                .Index(t => t.CurrentBalance_Id)
                .Index(t => t.InstallmentAmount_Id)
                .Index(t => t.OriginalAmount_Id)
                .Index(t => t.OverdueBalance_Id);
            
            AddColumn("dbo.Contracts", "Data_Id", c => c.Int());
            AddColumn("dbo.SubjectRoles", "CustomerCode", c => c.String());
            CreateIndex("dbo.Contracts", "Data_Id");
            AddForeignKey("dbo.Contracts", "Data_Id", "dbo.ContractDatas", "Id");
            DropColumn("dbo.SubjectRoles", "ContractCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubjectRoles", "ContractCode", c => c.String());
            DropForeignKey("dbo.Contracts", "Data_Id", "dbo.ContractDatas");
            DropForeignKey("dbo.ContractDatas", "OverdueBalance_Id", "dbo.Amounts");
            DropForeignKey("dbo.ContractDatas", "OriginalAmount_Id", "dbo.Amounts");
            DropForeignKey("dbo.ContractDatas", "InstallmentAmount_Id", "dbo.Amounts");
            DropForeignKey("dbo.ContractDatas", "CurrentBalance_Id", "dbo.Amounts");
            DropIndex("dbo.ContractDatas", new[] { "OverdueBalance_Id" });
            DropIndex("dbo.ContractDatas", new[] { "OriginalAmount_Id" });
            DropIndex("dbo.ContractDatas", new[] { "InstallmentAmount_Id" });
            DropIndex("dbo.ContractDatas", new[] { "CurrentBalance_Id" });
            DropIndex("dbo.Contracts", new[] { "Data_Id" });
            DropColumn("dbo.SubjectRoles", "CustomerCode");
            DropColumn("dbo.Contracts", "Data_Id");
            DropTable("dbo.ContractDatas");
            RenameTable(name: "dbo.Amounts", newName: "GuaranteeAmounts");
        }
    }
}
