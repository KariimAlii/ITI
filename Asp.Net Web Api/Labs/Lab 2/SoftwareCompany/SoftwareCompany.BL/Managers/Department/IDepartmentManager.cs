using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public interface IDepartmentManager
    {
        Task<IEnumerable<DepartmentReadDto>> GetAll();
        Task<DepartmentReadDto?> GetById(int id);
        Task<DepartmentReadDetailsDto?> GetDetails(int id);
        Task<int> Add(DepartmentAddDto departmentDto);
        Task<bool> Update(DepartmentUpdateDto departmentDto);
        Task Delete(int id);
    }
}
