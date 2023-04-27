using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.DAL
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        [ForeignKey("Department")]
        public int? DepartmentId { get;set; }
        public Department? Department { get; set; }
        public ICollection<Developer> Developers { get; set; } = new HashSet<Developer>();
    }
}

#region Useful Tutorials
// https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
#endregion