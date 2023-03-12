using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Models
{
    [Table("dbo.HotelRooms")]
    public class HotelRoom
    {
        [Key]
        public int Id { get; set; }
        public string NumberRoom { get; set; }
        public string NumberFloor { get; set; }
        public string NumberOfPlaces { get; set; }
        public decimal PriceOfDay { get; set; }
        public string Category { get; set; }
    }
}
