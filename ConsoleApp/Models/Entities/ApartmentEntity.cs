using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models.Entities
{
    internal class ApartmentEntity
    {
        [Key]
        [Column(TypeName = "char(6)")]
        public string ApartmentSerialNumber { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string StreetName { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(6)")]
        public string StreetNumber { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(10)")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(4)")]
        public string ApartmentNumber { get; set; } = null!;


        public ICollection<ErrorReportEntity> ErrorReports = new HashSet<ErrorReportEntity>(); 

    }

    internal class ErrorReportEntity
    {
        [Key]
        public int Id { get; set; } //Ha guid istället? Så den blir sökbar, samt när man skapat felanmälan kan de få ett felanmälans-nummer

        [Required]
        [Column(TypeName = "char(6)")]
        public string ApartmentId { get; set; } = null!; //FK
        public ApartmentEntity Apartment { get; set; } = null!; //FK

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(6)")] //VAD SKA DET VARA HÄR
        public string Email { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(20)")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(6)")] //VAD SKA DET VARA HÄR
        public string Created { get; set; } = null!; //TimeStamp

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; } = null!; //Är det enda man ska kunna Uppdatera i felanmälan

    }

}
