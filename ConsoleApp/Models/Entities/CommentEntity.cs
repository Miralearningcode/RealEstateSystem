using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models.Entities
{
    internal class CommentEntity
    {
        [Key]
        public int Id { get; set; } //PK

        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Text { get; set; } = null!;

        [Column(TypeName = "datetime2")]
        public DateTime Created { get; set; }

        [Required]
        public int ErrorReportId { get; set; } //FK
        public ErrorReportEntity ErrorReport { get; set; } = null!;
    }
}
