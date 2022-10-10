namespace HotelBooking.Models
{
    public class Package
    {
        public int PackageId { get; set; }

        public string PackageName { get; set; }

        public int NumberOfDays { get; set; }

        public int NumberOfGuests { get; set; }

        public decimal Price { get; set; }
    }
}
