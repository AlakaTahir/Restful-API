using BookingSystem.Models;
using BookingSystem.DTOs;
using BookingSystem.Configurations;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Services
{
    public class BookingService
    {
        private readonly BookingDbContext _context;
        public BookingService(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<Booking?> CreateBookingAsync(string userId, BookingRequest request)
        {
            var room = await _context.Rooms.FindAsync(request.RoomId);
            if (room == null) return null;
            // Improved overlap check: any overlap at all
            bool overlap = await _context.Bookings.AnyAsync(b => b.RoomId == request.RoomId &&
                b.StartTime < request.EndTime && request.StartTime < b.EndTime);
            if (overlap) return null;
            var booking = new Booking
            {
                UserId = userId,
                RoomId = request.RoomId,
                StartTime = request.StartTime,
                EndTime = request.EndTime
            };
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<List<BookingResponse>> GetUserBookingsAsync(string userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.Room)
                .Select(b => new BookingResponse
                {
                    Id = b.Id,
                    RoomId = b.RoomId,
                    RoomName = b.Room != null ? b.Room.Name : string.Empty,
                    StartTime = b.StartTime,
                    EndTime = b.EndTime
                })
                .ToListAsync();
        }
    }
}
