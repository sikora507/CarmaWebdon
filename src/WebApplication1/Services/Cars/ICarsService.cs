using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApplication1.Services.Cars
{
    public interface ICarsService
    {
        Dictionary<uint,string> GetCarsList();
        List<CarDTO> GetCarById(uint carId);
    }
}
