using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public interface IDeveloperManager
    {
        IEnumerable<DeveloperReadDto> GetAll();
        DeveloperReadDto? GetById(int id);
        int Add(DeveloperAddDto developerDto);
        bool Update(DeveloperUpdateDto developerDto);
        void Delete(int id);
    }
}
