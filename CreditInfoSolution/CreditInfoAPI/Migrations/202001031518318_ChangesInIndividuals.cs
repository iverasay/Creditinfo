namespace CreditInfoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInIndividuals : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Individuals", "Contract_Id", "dbo.Contracts");
            DropIndex("dbo.Individuals", new[] { "Contract_Id" });
            CreateTable(
                "dbo.IndividualContracts",
                c => new
                    {
                        Individual_Id = c.Int(nullable: false),
                        Contract_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Individual_Id, t.Contract_Id })
                .ForeignKey("dbo.Individuals", t => t.Individual_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contracts", t => t.Contract_Id, cascadeDelete: true)
                .Index(t => t.Individual_Id)
                .Index(t => t.Contract_Id);
            
            DropColumn("dbo.Individuals", "Contract_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Individuals", "Contract_Id", c => c.Int());
            DropForeignKey("dbo.IndividualContracts", "Contract_Id", "dbo.Contracts");
            DropForeignKey("dbo.IndividualContracts", "Individual_Id", "dbo.Individuals");
            DropIndex("dbo.IndividualContracts", new[] { "Contract_Id" });
            DropIndex("dbo.IndividualContracts", new[] { "Individual_Id" });
            DropTable("dbo.IndividualContracts");
            CreateIndex("dbo.Individuals", "Contract_Id");
            AddForeignKey("dbo.Individuals", "Contract_Id", "dbo.Contracts", "Id");
        }
    }
}
