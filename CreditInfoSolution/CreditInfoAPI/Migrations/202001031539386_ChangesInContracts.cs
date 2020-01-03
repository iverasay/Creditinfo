namespace CreditInfoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInContracts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contracts", "Data_Id", "dbo.ContractDatas");
            DropIndex("dbo.Contracts", new[] { "Data_Id" });
            AddColumn("dbo.ContractDatas", "Contract_Id", c => c.Int());
            CreateIndex("dbo.ContractDatas", "Contract_Id");
            AddForeignKey("dbo.ContractDatas", "Contract_Id", "dbo.Contracts", "Id");
            DropColumn("dbo.Contracts", "Data_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contracts", "Data_Id", c => c.Int());
            DropForeignKey("dbo.ContractDatas", "Contract_Id", "dbo.Contracts");
            DropIndex("dbo.ContractDatas", new[] { "Contract_Id" });
            DropColumn("dbo.ContractDatas", "Contract_Id");
            CreateIndex("dbo.Contracts", "Data_Id");
            AddForeignKey("dbo.Contracts", "Data_Id", "dbo.ContractDatas", "Id");
        }
    }
}
