using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Hotel.Models;

namespace Hotel
{
    public class HotelContext : DbContext
    {
        public HotelContext() : base("DefaultConnection")
        {

        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Reservations> Reservationss { get; set; }
    }
}
