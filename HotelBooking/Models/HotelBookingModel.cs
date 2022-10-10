using System.ComponentModel.DataAnnotations.Schema;

namespace HotelBooking.Models
{
    public class HotelBookingModel
    {
        public int Id { get; set; }

        public int RoomNumber { get; set; }

        public string ClientName { get; set; }

        public string Comments { get; set; }

        
        public int PackageId { get; set; }

        [ForeignKey("PackageId")]
        public Package Package { get; set; }
    }
}
