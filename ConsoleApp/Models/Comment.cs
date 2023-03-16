using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    internal class Comment
    {
        public int Id { get; set; } //PK
        public string Text { get; set; } = null!;
        public DateTime TimeStamp { get; set; }

        public int ErrorReportId { get; set; }
    }
}
