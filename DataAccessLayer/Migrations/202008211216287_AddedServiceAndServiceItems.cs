namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedServiceAndServiceItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateIssued = c.DateTime(nullable: false),
                        TimeIssued = c.Time(nullable: false, precision: 7),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.Vehicle_Id);                        
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.ServiceItems", "Service_Id", "dbo.Services");
            DropIndex("dbo.Services", new[] { "Vehicle_Id" });
            DropIndex("dbo.ServiceItems", new[] { "Service_Id" });
            DropTable("dbo.Services");
            DropTable("dbo.ServiceItems");
        }
    }
}
