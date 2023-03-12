using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Reservations
    {
        [Key]
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DateOfDeparture { get; set; }

        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }

        public int HotelRoomId { get; set; }
        [ForeignKey("HotelRoomId")]
        public virtual HotelRoom HotelRoom { get; set; }
    }
}
