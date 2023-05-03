using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareCompany.BL;
using System.Net;

namespace SoftwareCompany.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevelopersController : ControllerBase
    {
        #region Fields & Constructor
        private readonly IDeveloperManager DevelopersManager;

        public DevelopersController(IDeveloperManager _DevelopersManager)
        {
            DevelopersManager = _DevelopersManager;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<ActionResult<DeveloperReadDto>> GetAll()
        {
            var Developers = await DevelopersManager.GetAll();
            return Ok(Developers);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DeveloperReadDto>> GetById(int id)
        {
            DeveloperReadDto? Developer = await DevelopersManager.GetById(id);
            if (Developer is null) return NotFound(new CustomResponse(HttpStatusCode.NotFound, "Invalid Developer Id"));
            return Ok(Developer);
        }
        [HttpPost]
        public async Task<ActionResult> Add(DeveloperAddDto Developer)
        {
            int newId = await DevelopersManager.Add(Developer);
            return CreatedAtAction
                (
                    nameof(GetById),
                    new { id = newId },
                    new CustomResponse(HttpStatusCode.Created, "New Developer Created Successfully")
                );
        }
        [HttpPut]
        public async Task<ActionResult> Update(DeveloperUpdateDto Developer)
        {
            var isUpdated = await DevelopersManager.Update(Developer);
            if (!isUpdated) return BadRequest(new CustomResponse(HttpStatusCode.BadRequest, "Invalid Developer Details"));
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await DevelopersManager.Delete(id);
            return NoContent();
        }
        #endregion
    }
}
