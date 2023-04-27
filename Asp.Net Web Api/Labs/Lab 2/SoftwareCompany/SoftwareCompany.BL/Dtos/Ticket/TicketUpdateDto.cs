using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public class TicketUpdateDto
    {
        public required int Id { get; set; }
        public required string Description { get; set; } = string.Empty;
        public required string Title { get; set; } = string.Empty;
        public required int? DepartmentId { get; set; }
    }
}
