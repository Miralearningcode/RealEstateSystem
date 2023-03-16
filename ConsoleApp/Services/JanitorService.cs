using ConsoleApp.Contexts;
using ConsoleApp.Models.Entities;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Services
{
    internal class JanitorService
    {
        private static DataContext _context = new DataContext();

        //SaveAsync
        public static async Task SaveAsync(Janitor janitor)
        {
            var _janitorEntity = new JanitorEntity
            {
                FirstName = janitor.FirstName,
                LastName = janitor.LastName,
                Email = janitor.Email,
                PhoneNumber = janitor.PhoneNumber
            };

                _context.Add(_janitorEntity);
            await _context.SaveChangesAsync();

        }
    }
}
