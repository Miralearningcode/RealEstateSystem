using ConsoleApp.Contexts;
using ConsoleApp.Models.Entities;
using ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Services
{
    internal class CommentService
    {
        private static DataContext _context = new DataContext();

        //SaveAsync
        

        //GetAsync
        public static async Task<ErrorReport> GetAsync(string apartmentSerialNumber)
        {
            var _errorReport = await _context.ErrorReports.Include(x => x.Tenant).FirstOrDefaultAsync(x => x.Tenant.ApartmentSerialNumber == apartmentSerialNumber);
            if (_errorReport != null)
                return new ErrorReport
                {
                    Id = _errorReport.Id,
                    FirstName = _errorReport.Tenant.FirstName, //Tenant
                    LastName = _errorReport.Tenant.LastName, //Tenant
                    Email = _errorReport.Tenant.Email, //Tenant
                    PhoneNumber = _errorReport.Tenant.PhoneNumber, //Tenant
                    StreetName = _errorReport.Tenant.StreetName, //Tenant
                    StreetNumber = _errorReport.Tenant.StreetNumber, //Tenant
                    PostalCode = _errorReport.Tenant.PostalCode, //Tenant
                    City = _errorReport.Tenant.City, //Tenant
                    ApartmentSerialNumber = _errorReport.Tenant.ApartmentSerialNumber, //Tenant
                    Description = _errorReport.Description,
                    Created = _errorReport.Created, 
                    Status = _errorReport.Status
                };
            else
                return null!;
        }
    }
}
