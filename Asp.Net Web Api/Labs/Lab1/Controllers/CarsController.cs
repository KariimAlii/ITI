using Lab1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Lab1.Filters;

namespace Lab1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DepricateVersion1]
    public class CarsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Car>> GetAllCars()
            => Ok(Car.GetCars()); // {return Car.GetCars(); }

        //[HttpGet(Name = "GetById")]
        //[Route("{id}")]
        //public ActionResult<Car> GetCarById(int id)
        //{
        //    Car requiredCar = Car.GetCars().FirstOrDefault(c => c.Id == id);
        //    if (requiredCar is null) { return NotFound(new GeneralResponse(HttpStatusCode.NotFound, "Required Car Not Found!")); }
        //    return Ok(requiredCar);
        //}

        [HttpPost]
        [Route("v1")]
        public ActionResult AddCarV1(Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest(new GeneralResponse(HttpStatusCode.BadRequest, ModelState.First().Value.Errors.First().ErrorMessage));

            car.Id = Car.GetCars().Count() + 1;
            car.Type = "Gas";
            Car.GetCars().Add(car);
            return CreatedAtAction
            (
                "GetAllCars", // ===  nameof(GetAllCars)
                new GeneralResponse(HttpStatusCode.Created, $"New Car Added with Id :{car.Id}")
            );

            //return CreatedAtAction
            //(
            //    nameof(GetCarById),  // === "GetCarById"
            //    new { id = car.Id },
            //    new GeneralResponse(HttpStatusCode.Created, $"New Car Added with Id :{car.Id} Successfully")
            //);


            //return CreatedAtRoute
            //(
            //    "GetById",
            //    new { id = car.Id },
            //   new GeneralResponse(HttpStatusCode.Created, $"New Car Added with Id :{car.Id} Successfully")
            //);
        }

        [HttpPost]
        [Route("v2")]
        [ValidateCarType]
        public ActionResult AddCarV2(Car car)
        {
            // OnActionExecuting()

            if (!ModelState.IsValid)
                return BadRequest(new GeneralResponse(HttpStatusCode.BadRequest, "Car Data Not Valid"));
            car.Id = Car.GetCars().Count() + 1;
            Car.GetCars().Add(car);
            return CreatedAtAction
            (
                "GetCarById",
                new { id = car.Id },
                new GeneralResponse(HttpStatusCode.Created, $"New Car Added with Id :{car.Id} Successfully")
            );

            // OnActionExecuted()    // ==> after return
        }

        [HttpPut]
        [Route("{id}")]
        public ActionResult UpdateCar(int id , Car car)
        {
            if (!ModelState.IsValid)
                return BadRequest(new GeneralResponse(HttpStatusCode.BadRequest, "Car Data Not Valid"));
            if (id != car.Id)
                return BadRequest(new GeneralResponse(HttpStatusCode.BadRequest, "Car Id not valid"));
            Car requiredCar = Car.GetCars().FirstOrDefault(c => c.Id == id);
            if (requiredCar is null)
                return NotFound(new GeneralResponse(HttpStatusCode.NotFound, "Car Not Found"));
            requiredCar.Name = car.Name;
            requiredCar.Model = car.Model;
            requiredCar.Price = car.Price;
            requiredCar.Type = car.Type;
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteCar(int id)
        {
            Car requiredCar = Car.GetCars().FirstOrDefault(c => c.Id == id);
            if (requiredCar is null) return NotFound(new GeneralResponse(HttpStatusCode.NotFound, "Car Not Found"));
            Car.GetCars().Remove(requiredCar);
            return NoContent();
        }
    }
}
