namespace CreditInfoAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Firstapproach : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractCode = c.String(),
                        Ind1_Id = c.Int(),
                        Ind2_Id = c.Int(),
                        Ind3_Id = c.Int(),
                        SR1_Id = c.Int(),
                        SR2_Id = c.Int(),
                        SR3_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Individuals", t => t.Ind1_Id)
                .ForeignKey("dbo.Individuals", t => t.Ind2_Id)
                .ForeignKey("dbo.Individuals", t => t.Ind3_Id)
                .ForeignKey("dbo.SubjectRoles", t => t.SR1_Id)
                .ForeignKey("dbo.SubjectRoles", t => t.SR2_Id)
                .ForeignKey("dbo.SubjectRoles", t => t.SR3_Id)
                .Index(t => t.Ind1_Id)
                .Index(t => t.Ind2_Id)
                .Index(t => t.Ind3_Id)
                .Index(t => t.SR1_Id)
                .Index(t => t.SR2_Id)
                .Index(t => t.SR3_Id);
            
            CreateTable(
                "dbo.Individuals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerCode = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        IdN_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentificationNumbers", t => t.IdN_Id)
                .Index(t => t.IdN_Id);
            
            CreateTable(
                "dbo.IdentificationNumbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NationalID = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubjectRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractCode = c.String(),
                        RoleOfCustomer = c.Int(nullable: false),
                        Guarantee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GuaranteeAmounts", t => t.Guarantee_Id)
                .Index(t => t.Guarantee_Id);
            
            CreateTable(
                "dbo.GuaranteeAmounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Single(nullable: false),
                        Currency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "SR3_Id", "dbo.SubjectRoles");
            DropForeignKey("dbo.Contracts", "SR2_Id", "dbo.SubjectRoles");
            DropForeignKey("dbo.Contracts", "SR1_Id", "dbo.SubjectRoles");
            DropForeignKey("dbo.SubjectRoles", "Guarantee_Id", "dbo.GuaranteeAmounts");
            DropForeignKey("dbo.Contracts", "Ind3_Id", "dbo.Individuals");
            DropForeignKey("dbo.Contracts", "Ind2_Id", "dbo.Individuals");
            DropForeignKey("dbo.Contracts", "Ind1_Id", "dbo.Individuals");
            DropForeignKey("dbo.Individuals", "IdN_Id", "dbo.IdentificationNumbers");
            DropIndex("dbo.SubjectRoles", new[] { "Guarantee_Id" });
            DropIndex("dbo.Individuals", new[] { "IdN_Id" });
            DropIndex("dbo.Contracts", new[] { "SR3_Id" });
            DropIndex("dbo.Contracts", new[] { "SR2_Id" });
            DropIndex("dbo.Contracts", new[] { "SR1_Id" });
            DropIndex("dbo.Contracts", new[] { "Ind3_Id" });
            DropIndex("dbo.Contracts", new[] { "Ind2_Id" });
            DropIndex("dbo.Contracts", new[] { "Ind1_Id" });
            DropTable("dbo.GuaranteeAmounts");
            DropTable("dbo.SubjectRoles");
            DropTable("dbo.IdentificationNumbers");
            DropTable("dbo.Individuals");
            DropTable("dbo.Contracts");
        }
    }
}
