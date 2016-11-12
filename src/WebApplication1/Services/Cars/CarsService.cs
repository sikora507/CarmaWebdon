using OpenC1Logic.Parsers;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Services.Cars
{
    public class CarsService : ICarsService
    {
        private static Dictionary<uint, string> _carsList;
        static CarsService()
        {
            _carsList = new Dictionary<uint, string>();
            _carsList.Add(1, "EAGLE.ACT");
            _carsList.Add(2, "DUMP.ACT");
            _carsList.Add(3, "GRIMM.ACT");
            _carsList.Add(4, "KUTTER.ACT");
            _carsList.Add(5, "OTIS.ACT");
            _carsList.Add(6, "SCREWIE.ACT");
        }

        public List<CarDTO> GetCarById(uint carId)
        {
            if (_carsList.ContainsKey(carId))
            {
                var actFile = new ActFile(_carsList[carId]);
                var carActors = actFile.Hierarchy.All().Select(x => new CarDTO {
                    Name = x.Name,
                    MaterialName = x.MaterialName,
                    ModelName = x.ModelName
                });
                return carActors.ToList();
            }
            else
            {
                return null;
            }
        }

        public Dictionary<uint, string> GetCarsList()
        {
            return _carsList;
        }
    }
}
