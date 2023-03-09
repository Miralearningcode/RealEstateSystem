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
        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; } = null!;
        
        [Column(TypeName = "datetime2")] 
        public DateTime Created { get; set; } 

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Status { get; set; } = null!;


        [Required]
        public int TenantId { get; set; } //FK
        public TenantEntity Tenant { get; set; } = null!;



        public ICollection<CommentEntity> Comments = new HashSet<CommentEntity>();

    }
}
