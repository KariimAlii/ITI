using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public interface IDepartmentManager
    {
        IEnumerable<DepartmentReadDto> GetAll();
        DepartmentReadDto? GetById(int id);
        int Add(DepartmentAddDto departmentDto);
        bool Update(DepartmentUpdateDto departmentDto);
        void Delete(int id);
    }
}
