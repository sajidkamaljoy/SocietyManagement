namespace dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iinitdbb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.flats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        flat_number = c.String(),
                        building_number = c.String(),
                        rent = c.Double(nullable: false),
                        status = c.String(),
                        owner_id = c.Int(),
                        manager_id = c.Int(),
                        tenant_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.users", t => t.manager_id)
                .ForeignKey("dbo.users", t => t.owner_id)
                .ForeignKey("dbo.users", t => t.tenant_id)
                .Index(t => t.owner_id)
                .Index(t => t.manager_id)
                .Index(t => t.tenant_id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        email = c.String(nullable: false),
                        password = c.String(nullable: false),
                        role = c.String(nullable: false),
                        nid = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.repairs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        repairDescription = c.String(),
                        repairStatus = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "dbo.tenants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        utilityId = c.Int(nullable: false),
                        flatId = c.Int(nullable: false),
                        utilityStatus = c.String(),
                        tenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.flats", t => t.flatId, cascadeDelete: true)
                .ForeignKey("dbo.services", t => t.utilityId, cascadeDelete: true)
                .ForeignKey("dbo.users", t => t.tenantId, cascadeDelete: true)
                .Index(t => t.utilityId)
                .Index(t => t.flatId)
                .Index(t => t.tenantId);
            
            CreateTable(
                "dbo.services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        utilityName = c.String(),
                        utilityCharge = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.gatepasses",
                c => new
                    {
                        pid = c.Int(nullable: false, identity: true),
                        building_number = c.String(),
                        date = c.DateTime(nullable: false),
                        status = c.String(),
                        sec_id = c.Int(nullable: false),
                        flat_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.pid)
                .ForeignKey("dbo.flats", t => t.flat_id, cascadeDelete: true)
                .ForeignKey("dbo.securities", t => t.sec_id, cascadeDelete: true)
                .Index(t => t.sec_id)
                .Index(t => t.flat_id);
            
            CreateTable(
                "dbo.securities",
                c => new
                    {
                        sid = c.Int(nullable: false, identity: true),
                        rank = c.String(),
                        sotiton = c.String(),
                        shifts = c.String(),
                        salary = c.Int(nullable: false),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.sid)
                .ForeignKey("dbo.users", t => t.user_Id)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.verifications",
                c => new
                    {
                        vid = c.Int(nullable: false, identity: true),
                        vehical_number = c.String(),
                        vehical_type = c.String(),
                        owner_name = c.String(),
                        owner_phone = c.String(),
                        penalty = c.Int(nullable: false),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.vid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.securities", "user_Id", "dbo.users");
            DropForeignKey("dbo.gatepasses", "sec_id", "dbo.securities");
            DropForeignKey("dbo.gatepasses", "flat_id", "dbo.flats");
            DropForeignKey("dbo.flats", "tenant_id", "dbo.users");
            DropForeignKey("dbo.flats", "owner_id", "dbo.users");
            DropForeignKey("dbo.flats", "manager_id", "dbo.users");
            DropForeignKey("dbo.tenants", "tenantId", "dbo.users");
            DropForeignKey("dbo.tenants", "utilityId", "dbo.services");
            DropForeignKey("dbo.tenants", "flatId", "dbo.flats");
            DropForeignKey("dbo.repairs", "userId", "dbo.users");
            DropIndex("dbo.securities", new[] { "user_Id" });
            DropIndex("dbo.gatepasses", new[] { "flat_id" });
            DropIndex("dbo.gatepasses", new[] { "sec_id" });
            DropIndex("dbo.tenants", new[] { "tenantId" });
            DropIndex("dbo.tenants", new[] { "flatId" });
            DropIndex("dbo.tenants", new[] { "utilityId" });
            DropIndex("dbo.repairs", new[] { "userId" });
            DropIndex("dbo.flats", new[] { "tenant_id" });
            DropIndex("dbo.flats", new[] { "manager_id" });
            DropIndex("dbo.flats", new[] { "owner_id" });
            DropTable("dbo.verifications");
            DropTable("dbo.securities");
            DropTable("dbo.gatepasses");
            DropTable("dbo.services");
            DropTable("dbo.tenants");
            DropTable("dbo.repairs");
            DropTable("dbo.users");
            DropTable("dbo.flats");
        }
    }
}
