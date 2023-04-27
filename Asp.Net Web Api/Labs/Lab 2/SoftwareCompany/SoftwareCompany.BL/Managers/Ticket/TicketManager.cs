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


        public IEnumerable<TicketReadDto> GetAll()
        {
            var TicketsFromDB = ticketRepo.GetAll();
            return TicketsFromDB.Select(d => new TicketReadDto
            {
                Id = d.Id,
                Description = d.Description,
                Title = d.Title,
                DepartmentId = d.DepartmentId
            }).ToList();
        }
        public TicketReadDto? GetById(int id)
        {
            var TicketFromDB = ticketRepo.GetById(id);
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
        public int Add(TicketAddDto ticketDto)
        {
            var newTicket = new Ticket
            {
                Description = ticketDto.Description,
                Title = ticketDto.Title,
                DepartmentId = ticketDto.DepartmentId
            };
            ticketRepo.Add(newTicket);
            // newTicket.Id = default
            ticketRepo.SaveChanges(); //====> returns the object added with its {Id} set by database provider
            // newTicket.Id = 157
            return newTicket.Id;
        }
        public bool Update(TicketUpdateDto ticketDto)
        {
            var TicketFromDB = ticketRepo.GetById(ticketDto.Id);
            if (TicketFromDB == null)
                return false;
            TicketFromDB.Description = ticketDto.Description;
            TicketFromDB.Title = ticketDto.Title;
            TicketFromDB.DepartmentId = ticketDto.DepartmentId;
            ticketRepo.Update(TicketFromDB);
            ticketRepo.SaveChanges();
            return true;
        }
        public void Delete(int id)
        {
            var TicketFromDB = ticketRepo.GetById(id);
            if (TicketFromDB == null)
                return;
            ticketRepo.Delete(TicketFromDB);
            ticketRepo.SaveChanges();
        }

        #endregion
    }
}
