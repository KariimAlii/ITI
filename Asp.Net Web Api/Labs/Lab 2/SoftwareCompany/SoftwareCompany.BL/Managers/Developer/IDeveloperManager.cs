using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public interface IDeveloperManager
    {
        Task<IEnumerable<DeveloperReadDto>> GetAll();
        Task<DeveloperReadDto?> GetById(int id);
        Task<int> Add(DeveloperAddDto developerDto);
        Task<bool> Update(DeveloperUpdateDto developerDto);
        Task Delete(int id);
    }
}
