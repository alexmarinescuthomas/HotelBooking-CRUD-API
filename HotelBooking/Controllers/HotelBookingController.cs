using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HotelBooking.Models;
using HotelBooking.Data;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly ApiContext _context;

        public HotelBookingController(ApiContext context)
        {
            _context = context;
        }

        [HttpPost]
        public JsonResult SaveBooking(HotelBookingModel booking)
        {
            try
            {
                //Add new booking to db if no id
                if (booking.Id == 0)
                {
                    _context.Bookings.Add(booking);
                }
                //Otherwise, we edit.
                else
                {
                    //Check DB for it
                    var bookingInDb = _context.Bookings.Find(booking.Id);

                    //If not found return warning
                    if (bookingInDb == null)
                        return new JsonResult(NotFound());

                    //Else we replace it.
                    bookingInDb = booking;
                }

                //Always save changes made to DB.
                _context.SaveChanges();

                //Return status code 200 message with booking
                return new JsonResult(Ok(booking));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public JsonResult GetBookingByKey(int id)
        {
            try
            {
                //Search DB using id.
                var result = _context.Bookings.Find(id);

                //If not found return message.
                if (result == null)
                    return new JsonResult(NotFound());

                //If found return status code 200 with result.
                return new JsonResult(Ok(result));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public JsonResult DeleteBooking(int id)
        {
            var result = _context.Bookings.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Bookings.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        [HttpGet()]
        public JsonResult GetBookingsList()
        {
            var result = _context.Bookings.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
