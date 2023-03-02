using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Models.Entities
{
    internal class ErrorReportEntity
    {
        [Key]
        public int Id { get; set; } //PK

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(20)")]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; } = null!;

        //[Required]
        [Column(TypeName = "datetime2")] //[Column(TypeName = "char(20)")]
        public DateTime Created { get; set; } // public string Created { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; } = null!;

        [Required]
        public int ApartmentId { get; set; } //FK
        public ApartmentEntity Apartment { get; set; } = null!;

    }
}
