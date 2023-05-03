using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareCompany.BL;
using System.Net;

namespace SoftwareCompany.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        #region Fields & Constructor
        private readonly ITicketManager TicketsManager;

        public TicketsController(ITicketManager _TicketsManager)
        {
            TicketsManager = _TicketsManager;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<ActionResult<TicketReadDto>> GetAll()
        {
            var Tickets = await TicketsManager.GetAll();
            return Ok(Tickets);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<TicketReadDto>> GetById(int id)
        {
            TicketReadDto? Ticket = await TicketsManager.GetById(id);
            if (Ticket is null) return NotFound(new CustomResponse(HttpStatusCode.NotFound, "Invalid Ticket Id"));
            return Ok(Ticket);
        }
        [HttpPost]
        public async Task<ActionResult> Add(TicketAddDto Ticket)
        {
            int newId = await TicketsManager.Add(Ticket);
            return CreatedAtAction
                (
                    nameof(GetById),
                    new { id = newId },
                    new CustomResponse(HttpStatusCode.Created, "New Ticket Created Successfully")
                );
        }
        [HttpPut]
        public async Task<ActionResult> Update(TicketUpdateDto Ticket)
        {
            var isUpdated = await TicketsManager.Update(Ticket);
            if (!isUpdated) return BadRequest(new CustomResponse(HttpStatusCode.BadRequest, "Invalid Ticket Details"));
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await TicketsManager.Delete(id);
            return NoContent();
        }
        #endregion
    }
}
