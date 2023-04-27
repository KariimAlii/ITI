using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public class DeveloperAddDto
    {
        public required string Name { get; set; } = string.Empty;
        public required decimal Salary { get; set; }
    }
}
