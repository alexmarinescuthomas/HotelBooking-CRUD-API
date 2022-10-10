using Microsoft.EntityFrameworkCore;
using HotelBooking.Models;

namespace HotelBooking.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<HotelBookingModel> Bookings { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options)
            :base(options)
        {
            
        }
    }
}
