using ConsoleApp.Models.Entities;

namespace ConsoleApp.Models
{
    internal class ErrorReport
    {
        public int Id { get; set; } //PK
        public string FirstName { get; set; } = null!; //Tenant
        public string LastName { get; set; } = null!; //Tenant
        public string Email { get; set; } = null!; //Tenant
        public string PhoneNumber { get; set; } = null!; //Tenant
        public string StreetName { get; set; } = null!; //Tenant
        public string StreetNumber { get; set; } = null!; //Tenant
        public string PostalCode { get; set; } = null!; //Tenant
        public string City { get; set; } = null!; //Tenant
        public string ApartmentSerialNumber { get; set; } = null!; //Tenant
        public string Description { get; set; } = null!;
        public DateTime Created { get; set; } 
        public string Status { get; set; } = null!;
        public string Text { get; set; } = null!; //Comment


    }
}
