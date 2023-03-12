namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateHotelRoomTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HotelRooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumberRoom = c.String(),
                        NumberFloor = c.String(),
                        NumberOfPlaces = c.String(),
                        PriceOfDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HotelRooms");
        }
    }
}
