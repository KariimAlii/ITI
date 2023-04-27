using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public class TicketAddDto
    {
        public required string Description { get; set; } = string.Empty;
        public required string Title { get; set; } = string.Empty;
        public required int? DepartmentId { get; set; }
    }
}
