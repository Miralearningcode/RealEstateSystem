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
        public string StreetName { get; set; } = null!; 
        public string StreetNumber { get; set; } = null!; 
        public string PostalCode { get; set; } = null!; 
        public string City { get; set; } = null!; 
        public string ApartmentSerialNumber { get; set; } = null!; 
        public string Description { get; set; } = null!;
        public DateTime Created { get; set; } 
        public string Status { get; set; } = null!;


        public string Text { get; set; } = null!; //Comment
        public string TimeStamp { get; set; } = null!;  //Comment
    }
}
