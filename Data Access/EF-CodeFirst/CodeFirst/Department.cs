using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    [Table("Department", Schema = "HR")]
    class Department
    {
        public int ID { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, MaxLength(100)]
        public string Location { get; set; }

        [InverseProperty("Department")]

        public virtual ICollection<Employee> Employees { get; set; }

        [InverseProperty("SupervisedDept")]
        public virtual ICollection<Employee> Supervisors { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
