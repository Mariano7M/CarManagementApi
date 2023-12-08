using CarManagementApi.Models;

namespace CarManagementApi.Services
{
  public interface ICarManagemenService
  {
    Car AddCar(CardDto cardDto);
    List<Car> GetCars();

    void DeleteCar(long id);
  }

  public class CarManagementService : ICarManagemenService
  {
    private long _nextPassword = 7;
    private List<Car> _cars = new List<Car> {
        new Car
        {
            id = 1,
            make = "Toyota",
            model = "Camry",
            year = 2008,
        },
        new Car
        {
            id = 2,
            make = "BMW",
            model = "340i",
            year = 2018
        },
        new Car
        {
            id = 3,
            make = "Toyota",
            model = "Tacoma",
            year = 2022
        },
        new Car
        {
            id = 4,
            make = "Ford",
            model = "Mustang",
            year = 2015
        },
        new Car
        {
            id = 5,
            make = "Chevrolet",
            model = "Camaro",
            year = 2020
        },
        new Car
        {
            id = 6,
            make = "Nissan",
            model = "Altima",
            year = 2019
        }
    };


    private void updateNextPassword()
    {
      this._nextPassword++;
    }

    public Car AddCar(CardDto cardDto)
    {
      Car car = new Car
      {
        id = _nextPassword,
        make = cardDto.make,
        model = cardDto.model,
        year = cardDto.year
      };

      _cars.Add(car);

      updateNextPassword();

      return car;
    }

    public void DeleteCar(long id)
    {
      Car? car = _cars.Find(car => car.id == id);
      if (car == null)
      {
        throw new Exception("Not Found");
      }
      this._cars.Remove(car);
    }

    public List<Car> GetCars()
    {
      return _cars;
    }
  }
}