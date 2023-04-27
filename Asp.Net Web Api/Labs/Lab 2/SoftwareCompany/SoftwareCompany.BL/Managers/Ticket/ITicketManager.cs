using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public interface ITicketManager
    {
        IEnumerable<TicketReadDto> GetAll();
        TicketReadDto? GetById(int id);
        int Add(TicketAddDto entity);
        bool Update(TicketUpdateDto entity);
        void Delete(int id);
    }
}
