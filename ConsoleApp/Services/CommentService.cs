using ConsoleApp.Contexts;
using ConsoleApp.Models.Entities;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Services
{
    internal class CommentService
    {
        private static DataContext _context = new DataContext();

        //SaveAsync
        public static async Task SaveAsync(Comment comment)
        {
            var errorReportEntity = await _context.ErrorReports.FindAsync(comment.ErrorReportId);

            if (errorReportEntity == null)
            {
               
            }

            var _commentEntity = new CommentEntity
            {
                Text = comment.Text,
                TimeStamp = DateTime.Now
            };

            errorReportEntity.Comments.Add(_commentEntity);

            await _context.SaveChangesAsync();
        }

        //GetAsync
        public static async Task<Comment> GetAsync(string apartmentSerialNumber)
        {
            var _comment = await _context.Comments.Include(x => x.ErrorReport).FirstOrDefaultAsync(x => x.ErrorReport.Tenant.ApartmentSerialNumber == apartmentSerialNumber);
            if (_comment != null)
                return new Comment
                {
                    Id = _comment.Id,
                    Text = _comment.Text,
                    TimeStamp = _comment.TimeStamp
                };
            else
                return null!;
        }
    }
}
