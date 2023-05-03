using SoftwareCompany.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareCompany.BL
{
    public class TicketManager : ITicketManager
    {
        #region Fields & Constructor
        private readonly IGenericRepository<Ticket> ticketRepo;

        public TicketManager(IGenericRepository<Ticket> _ticketRepo)
        {
            ticketRepo = _ticketRepo;
        }
        #endregion

        #region Methods


        public async Task<IEnumerable<TicketReadDto>> GetAll()
        {

            var TicketsFromDB = await ticketRepo.GetAll();
            return TicketsFromDB.Select(d => new TicketReadDto
            {
                Id = d.Id,
                Description = d.Description,
                Title = d.Title,
                DepartmentId = d.DepartmentId
            }).ToList();
        }
        public async Task<TicketReadDto?> GetById(int id)
        {
            var TicketFromDB = await ticketRepo.GetById(id);
            if (TicketFromDB == null)
                return null;
            return new TicketReadDto
            {
                Id = TicketFromDB.Id,
                Description = TicketFromDB.Description,
                Title = TicketFromDB.Title,
                DepartmentId = TicketFromDB.DepartmentId
            };
        }
        public async Task<int> Add(TicketAddDto ticketDto)
        {
            var newTicket = new Ticket
            {
                Description = ticketDto.Description,
                Title = ticketDto.Title,
                DepartmentId = ticketDto.DepartmentId
            };
            await ticketRepo.Add(newTicket);
            // newTicket.Id = default
            await ticketRepo.SaveChanges(); //====> returns the object added with its {Id} set by database provider
            // newTicket.Id = 157
            return newTicket.Id;
        }
        public async Task<bool> Update(TicketUpdateDto ticketDto)
        {
            var TicketFromDB = await ticketRepo.GetById(ticketDto.Id);
            if (TicketFromDB == null)
                return false;
            TicketFromDB.Description = ticketDto.Description;
            TicketFromDB.Title = ticketDto.Title;
            TicketFromDB.DepartmentId = ticketDto.DepartmentId;
            ticketRepo.Update(TicketFromDB);
            await ticketRepo.SaveChanges();
            return true;
        }
        public async Task Delete(int id)
        {
            var TicketFromDB = await ticketRepo.GetById(id);
            if (TicketFromDB == null)
                return;
            ticketRepo.Delete(TicketFromDB);
            await ticketRepo.SaveChanges();
        }

        #endregion
    }
}
