using CarManagementApi.Models;
using CarManagementApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarManagementApi.Controllers;

[ApiController]
[Route("api/cars")]
public class CarManagementController : ControllerBase
{
    private readonly ICarManagemenService _service;

    public CarManagementController(ICarManagemenService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<Car>> GetCars()
    {
        return _service.GetCars();
    }

    [HttpDelete("{id}")]
    public ActionResult<Car> DeleteCar(long id)
    {
        try
        {
            _service.DeleteCar(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public ActionResult<Car> PostCar(CardDto cardDto)
    {
        Car car = _service.AddCar(cardDto);
        return CreatedAtAction(nameof(PostCar), car);
    }
}
