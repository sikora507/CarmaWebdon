using System.Collections.Generic;

namespace WebApplication1.Services.Cars
{
    public class CarDTO
    {
        public string MaterialName { get; internal set; }
        public string ModelName { get; internal set; }
        public List<string> Models { get; internal set; }
        public string Name { get; internal set; }
    }
}
