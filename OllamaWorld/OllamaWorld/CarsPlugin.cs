using Microsoft.SemanticKernel;
using OllamaWorld;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollamaworld
{
    public class CarsPlugin
    {
        private readonly List<CarsModel> _cars = new ()
        {
            new CarsModel
            {
                Id = "1",
                name = "BMW",
                Model = "X5",
                Color = "Black",
                car_number = 1234,
                IsIn = true,
                place_number = 1,
                place_sector = 'A'
            },
            new CarsModel
            {
                Id = "2",
                name = "Audi",
                Model = "A6",
                Color = "White",
                car_number = 5678,
                IsIn = false,
                place_number = 2,
                place_sector = 'B'
            },
            new CarsModel
            {
                Id = "3",
                name = "Mercedes",
                Model = "S500",
                Color = "Red",
                car_number = 7833,
                IsIn = true,
                place_number = 3,
                place_sector = 'A'
            }
        };

        [KernelFunction("GetCar")]
        [Description("Get a list of cars and their current state")]
        [return: Description("List of cars")]
        public async Task< List<CarsModel>> GetCarsAsync()
        {
            return _cars;
        }

        [KernelFunction("get_car_info")]
        [Description("Get the information about a car by its number")]
        [return: Description("Information about the car")]
        public async Task<CarsModel> GetCarInfoAsync([Description("The number of the car")] int car_number)
        {
            return _cars.FirstOrDefault( _cars => _cars.car_number == car_number);
        }

        [KernelFunction("get_state")]
        [Description("Get the state of a car by its number")]
        [return: Description("State of the car")]
        public async Task<CarsModel> GetStateAsync(int car_number)
        {
            return _cars.FirstOrDefault(c => c.car_number == car_number);
        }

        [KernelFunction("get_place")]
        [Description("Get the place of a car by its number")]
        [return: Description("Place of the car")]
        public async Task<CarsModel> GetPlaceAsync(int car_number)
        {
            return _cars.FirstOrDefault(c => c.car_number == car_number);
        }

        [KernelFunction("get_taken_places")]
        [Description("Get the list of taken places")]
        [return: Description("List of taken places")]
        public async Task<string> GetTakenPlacesAsync()
        {
            var takenPlaces = _cars.Where(c => c.IsIn).Select(c => $"{c.place_sector}{c.place_number}");
            return string.Join(", ", takenPlaces);
        }

        [KernelFunction("change_state")]
        [Description("Change the state of a car by its number")]
        [return: Description("New state of the car")]
        public async Task<CarsModel> ChangeStateAsync(int car_number, bool IsIn)
        {
            var car = _cars.FirstOrDefault(c => c.car_number == car_number);
            if (car == null)
            {
                return null;
            }

            car.IsIn = !car.IsIn;
            return car;

        }

        [KernelFunction("change_place")]
        [Description("Change the place of a car by its number")]
        [return: Description("New place of the car")]
        public async Task<CarsModel> ChangePlaceAsync(int car_number, int place_number, char place_sector)
        {
            var car = _cars.FirstOrDefault(c => c.car_number == car_number);
            if (car == null)
            {
                return null;
            }
            car.place_number = place_number;
            car.place_sector = place_sector;
            return car;
        }

        [KernelFunction("add_car")]
        [Description("Add a new car")]
        [return: Description("New car")]
        public async Task<CarsModel> AddCarAsync(string name, string model, string color, int car_number, bool IsIn, int place_number, char place_sector)
        {
            var car = new CarsModel
            {
                Id = Guid.NewGuid().ToString(),
                name = name,
                Model = model,
                Color = color,
                car_number = car_number,
                IsIn = IsIn,
                place_number = place_number,
                place_sector = place_sector
            };
            _cars.Add(car);
            return car;
        }

    }
}