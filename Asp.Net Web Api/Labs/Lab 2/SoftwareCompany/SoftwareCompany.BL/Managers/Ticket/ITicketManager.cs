using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public interface ITicketManager
    {
        Task<IEnumerable<TicketReadDto>> GetAll();
        Task<TicketReadDto?> GetById(int id);
        Task<int> Add(TicketAddDto entity);
        Task<bool> Update(TicketUpdateDto entity);
        Task Delete(int id);
    }
}
