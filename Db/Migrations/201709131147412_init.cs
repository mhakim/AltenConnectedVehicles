namespace Db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(maxLength: 200),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicle",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VIN = c.String(nullable: false, maxLength: 100),
                        RegistrationNumber = c.String(maxLength: 100),
                        OwnerId = c.Guid(nullable: false),
                        LastStampTime = c.DateTimeOffset(precision: 7),
                        CreatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdatedAt = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.Stamp",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        VehicleId = c.Guid(nullable: false),
                        StampTime = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicle", t => t.VehicleId)
                .Index(t => t.VehicleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stamp", "VehicleId", "dbo.Vehicle");
            DropForeignKey("dbo.Vehicle", "OwnerId", "dbo.Customer");
            DropIndex("dbo.Stamp", new[] { "VehicleId" });
            DropIndex("dbo.Vehicle", new[] { "OwnerId" });
            DropTable("dbo.Stamp");
            DropTable("dbo.Vehicle");
            DropTable("dbo.Customer");
        }
    }
}
