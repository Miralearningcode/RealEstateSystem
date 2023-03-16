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
                Description = errorReport.Description,
                Created = errorReport.Created = DateTime.Now, 
                Status = errorReport.Status
            };

            var _tenantEntity = await _context.Tenants.FirstOrDefaultAsync(x => x.FirstName == errorReport.FirstName && x.LastName == errorReport.LastName && x.Email == errorReport.Email && x.PhoneNumber == errorReport.PhoneNumber && x.StreetName == errorReport.StreetName && x.StreetNumber == errorReport.StreetNumber && x.PostalCode == errorReport.PostalCode && x.City == errorReport.City && x.ApartmentSerialNumber == errorReport.ApartmentSerialNumber);
            if (_tenantEntity != null)
                _errorReportEntity.TenantId = _tenantEntity.Id;
            else
                _errorReportEntity.Tenant = new TenantEntity
                {
                    FirstName = errorReport.FirstName,
                    LastName = errorReport.LastName,
                    Email = errorReport.Email,
                    PhoneNumber = errorReport.PhoneNumber,
                    StreetName = errorReport.StreetName,
                    StreetNumber = errorReport.StreetNumber,
                    PostalCode = errorReport.PostalCode,
                    City = errorReport.City,
                    ApartmentSerialNumber = errorReport.ApartmentSerialNumber
                };


            _context.Add(_errorReportEntity);
            await _context.SaveChangesAsync();

        }

        //GetAllAsync 
        public static async Task<IEnumerable<ErrorReport>> GetAllAsync()
        {
            var _errorReports = new List<ErrorReport>();

            foreach (var _errorReport in await _context.ErrorReports.Include(x => x.Tenant).ToListAsync())
                _errorReports.Add(new ErrorReport
                {
                    Id = _errorReport.Id,
                    FirstName = _errorReport.Tenant.FirstName, 
                    LastName = _errorReport.Tenant.LastName,
                    Email = _errorReport.Tenant.Email, 
                    PhoneNumber = _errorReport.Tenant.PhoneNumber, 
                    StreetName = _errorReport.Tenant.StreetName, 
                    StreetNumber = _errorReport.Tenant.StreetNumber, 
                    PostalCode = _errorReport.Tenant.PostalCode, 
                    City = _errorReport.Tenant.City, 
                    ApartmentSerialNumber = _errorReport.Tenant.ApartmentSerialNumber, 
                    Description = _errorReport.Description,
                    Created = _errorReport.Created, 
                    Status = _errorReport.Status
                });
            return _errorReports;
        }

        //GetAsync
        public static async Task<ErrorReport> GetAsync(string apartmentSerialNumber)
        {
            var _errorReport = await _context.ErrorReports.Include(x => x.Tenant).FirstOrDefaultAsync(x => x.Tenant.ApartmentSerialNumber == apartmentSerialNumber);
            if (_errorReport != null)
                return new ErrorReport
                {
                    Id = _errorReport.Id,
                    FirstName = _errorReport.Tenant.FirstName, 
                    LastName = _errorReport.Tenant.LastName, 
                    Email = _errorReport.Tenant.Email, 
                    PhoneNumber = _errorReport.Tenant.PhoneNumber, 
                    StreetName = _errorReport.Tenant.StreetName, 
                    StreetNumber = _errorReport.Tenant.StreetNumber, 
                    PostalCode = _errorReport.Tenant.PostalCode, 
                    City = _errorReport.Tenant.City, 
                    ApartmentSerialNumber = _errorReport.Tenant.ApartmentSerialNumber, 
                    Description = _errorReport.Description,
                    Created = _errorReport.Created, 
                    Status = _errorReport.Status
                };
            else
                return null!;
        }


        //UpdateAsync
        public static async Task UpdateAsync(ErrorReport errorReport)
        {
            var _errorReportEntity = await _context.ErrorReports.Include(x => x.Tenant).FirstOrDefaultAsync(x => x.Id == errorReport.Id);
            if (_errorReportEntity != null)
            {
                if (!string.IsNullOrEmpty(errorReport.Status))
                    _errorReportEntity.Status = errorReport.Status;

                _context.Entry(_errorReportEntity).State = EntityState.Modified; 
                await _context.SaveChangesAsync();
            }
        }


        //DeleteAsync
        public static async Task DeleteAsync(string apartmentSerialNumber)  
        {
            var _errorReport = await _context.ErrorReports.Include(x => x.Tenant).FirstOrDefaultAsync(x => x.Tenant.ApartmentSerialNumber == apartmentSerialNumber);
            if (_errorReport != null)
            {
                _context.Remove(_errorReport);
                await _context.SaveChangesAsync();
            }
        }
    }
}

