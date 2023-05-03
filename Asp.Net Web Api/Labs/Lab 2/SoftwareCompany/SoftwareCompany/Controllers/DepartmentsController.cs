using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoftwareCompany.BL;
using SoftwareCompany.DAL;
using System.Net;

namespace SoftwareCompany.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        #region Fields & Constructor
        private readonly IDepartmentManager departmentsManager;

        public DepartmentsController(IDepartmentManager _departmentsManager)
        {
            departmentsManager = _departmentsManager;
        }
        #endregion

        #region Methods
        [HttpGet]
        public async Task<ActionResult<DepartmentReadDto>> GetAll()
        {
            var departments = await departmentsManager.GetAll();
            return Ok(departments);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<DepartmentReadDto>> GetById(int id)
        {
            DepartmentReadDto? department = await departmentsManager.GetById(id);
            if (department is null) return NotFound(new CustomResponse(HttpStatusCode.NotFound, "Invalid Department Id"));
            return Ok(department);
        }

        [HttpGet]
        [Route("{id}/Details")]
        public async Task<ActionResult<DepartmentReadDetailsDto>> GetDetails(int id)
        {
            DepartmentReadDetailsDto? department = await departmentsManager.GetDetails(id);
            if (department is null) return NotFound(new CustomResponse(HttpStatusCode.NotFound, "Invalid Department Id"));
            return Ok(department);
        }
        [HttpPost]
        public async Task<ActionResult> Add(DepartmentAddDto department)
        {
            int newId = await departmentsManager.Add(department);
            return CreatedAtAction
                (
                    nameof(GetById),
                    new { id = newId },
                    new CustomResponse(HttpStatusCode.Created, "New Department Created Successfully")
                );
        }
        [HttpPut]
        public async Task<ActionResult> Update(DepartmentUpdateDto department)
        {
            var isUpdated = await departmentsManager.Update(department);
            if (!isUpdated) return BadRequest(new CustomResponse(HttpStatusCode.BadRequest, "Invalid Department Details"));
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await departmentsManager.Delete(id);
            return NoContent();
        }
        #endregion
    }
}
