namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateReservationsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReservationDate = c.DateTime(nullable: false),
                        ArrivalDate = c.DateTime(nullable: false),
                        DateOfDeparture = c.DateTime(nullable: false),
                        ClientId = c.Int(nullable: false),
                        HotelRoomId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.HotelRooms", t => t.HotelRoomId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.HotelRoomId);
        }
        
        public override void Down()
        {   
            DropForeignKey("dbo.Reservations", "HotelRoomId", "dbo.HotelRooms");
            DropForeignKey("dbo.Reservations", "ClientId", "dbo.Clients");
            DropIndex("dbo.Reservations", new[] { "HotelRoomId" });
            DropIndex("dbo.Reservations", new[] { "ClientId" });
            DropTable("dbo.Reservations");
        }
    }
}
