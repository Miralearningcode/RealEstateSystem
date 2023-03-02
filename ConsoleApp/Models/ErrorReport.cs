using ConsoleApp.Models.Entities;

namespace ConsoleApp.Models
{
    internal class ErrorReport
    {
        public int Id { get; set; } //PK
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!; //Apartment
        public string StreetNumber { get; set; } = null!; //Apartment
        public string PostalCode { get; set; } = null!; //Apartment
        public string City { get; set; } = null!; //Apartment
        public string Description { get; set; } = null!;
        public DateTime Created { get; set; } //SKA DENNA VARA MED HÄR?
        public string Status { get; set; } = null!;

        
    }
}
