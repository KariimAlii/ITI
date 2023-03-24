using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("FullName")]
        public string Name { get; set; }
        public double? Salary { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Birthdate { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        [ForeignKey("SupervisedDept")]
        public int? SupervisedDeptId { get; set; }
        public virtual Department SupervisedDept { get; set; }

        public virtual ICollection<WorksFor> WorksFors { get; set; }
    }
}
