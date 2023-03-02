using ConsoleApp.Contexts;
using ConsoleApp.Models.Entities;
using ConsoleApp.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp.Services
{
    internal class ErrorReportService
    {

        private static DataContext _context = new DataContext();

        //SaveAsync
        public static async Task SaveAsync(ErrorReport errorReport)
        {
            var _errorReportEntity = new ErrorReportEntity
            {
                FirstName = errorReport.FirstName,
                LastName = errorReport.LastName,
                Email = errorReport.Email,
                PhoneNumber = errorReport.PhoneNumber,
                Description = errorReport.Description,
                Created = errorReport.Created = DateTime.Now, //SKA DENNA VARA MED HÄR?
                Status = errorReport.Status
            };

            var _apartmentEntity = await _context.Apartments.FirstOrDefaultAsync(x => x.StreetName == errorReport.StreetName && x.StreetNumber == errorReport.StreetNumber && x.PostalCode == errorReport.PostalCode && x.City == errorReport.City);
            if (_apartmentEntity != null)
                _errorReportEntity.ApartmentId = _apartmentEntity.Id;
            else
                _errorReportEntity.Apartment = new ApartmentEntity
                {
                    StreetName = errorReport.StreetName,
                    StreetNumber = errorReport.StreetNumber,
                    PostalCode = errorReport.PostalCode,
                    City = errorReport.City
                };


            _context.Add(_errorReportEntity);
            await _context.SaveChangesAsync();

        }

        //GetAllAsync 
        public static async Task<IEnumerable<ErrorReport>> GetAllAsync()
        {
            var _errorReports = new List<ErrorReport>();

            foreach (var _errorReport in await _context.ErrorReports.Include(x => x.Apartment).ToListAsync())
                _errorReports.Add(new ErrorReport
                {
                    Id = _errorReport.Id,
                    FirstName = _errorReport.FirstName,
                    LastName = _errorReport.LastName,
                    Email = _errorReport.Email,
                    PhoneNumber = _errorReport.PhoneNumber,
                    StreetName = _errorReport.Apartment.StreetName, //Apartment
                    StreetNumber = _errorReport.Apartment.StreetNumber,//Apartment
                    PostalCode = _errorReport.Apartment.PostalCode,//Apartment
                    City = _errorReport.Apartment.City,//Apartment
                    Description = _errorReport.Description,
                    Created = _errorReport.Created, //SKA DENNA VARA MED?
                    Status = _errorReport.Status,
                });
            return _errorReports;
        }

        //GetAsync
        public static async Task<ErrorReport> GetAsync(string email)
        {
            var _errorReport = await _context.ErrorReports.Include(x => x.Apartment).FirstOrDefaultAsync(x => x.Email == email);
            if (_errorReport != null)
                return new ErrorReport
                {
                    Id = _errorReport.Id,
                    FirstName = _errorReport.FirstName,
                    LastName = _errorReport.LastName,
                    Email = _errorReport.Email,
                    PhoneNumber = _errorReport.PhoneNumber,
                    StreetName = _errorReport.Apartment.StreetName, //Apartment
                    StreetNumber = _errorReport.Apartment.StreetNumber,//Apartment
                    PostalCode = _errorReport.Apartment.PostalCode,//Apartment
                    City = _errorReport.Apartment.City,//Apartment
                    Description = _errorReport.Description,
                    Created = _errorReport.Created, //SKA DENNA VARA MED?
                    Status = _errorReport.Status
                };
            else
                return null!;
        }


        //UpdateAsync
        public static async Task UpdateAsync(ErrorReport errorReport)
        {
            var _errorReportEntity = await _context.ErrorReports.Include(x => x.Apartment).FirstOrDefaultAsync(x => x.Id == errorReport.Id);
            if (_errorReportEntity != null)
            {
                if (!string.IsNullOrEmpty(errorReport.Status))
                    _errorReportEntity.Status = errorReport.Status;

                _context.Entry(_errorReportEntity).State = EntityState.Modified; //_context.Update(_errorReportEntity); //ÄNDRA HÄR OM DET INTE FUNKAR
                await _context.SaveChangesAsync();
            }
        }


        //DeleteAsync
        public static async Task DeleteAsync(string email)  
        {
            var _errorReport = await _context.ErrorReports.Include(x => x.Apartment).FirstOrDefaultAsync(x => x.Email == email);
            if (_errorReport != null)
            {
                _context.Remove(_errorReport);
                await _context.SaveChangesAsync();
            }
        }
    }
}

