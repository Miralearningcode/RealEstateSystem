using ConsoleApp.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp.Models.Entities
{
    internal class TenantEntity
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
        [Column(TypeName = "nvarchar(50)")]
        public string StreetName { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(4)")]
        public string StreetNumber { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(6)")]
        public string PostalCode { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = null!;

        [Required]
        [Column(TypeName = "char(6)")]
        public string ApartmentSerialNumber { get; set; } = null!;



        public ICollection<ErrorReportEntity> ErrorReports = new HashSet<ErrorReportEntity>();
    }



}

