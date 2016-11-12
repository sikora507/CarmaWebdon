using WebApplication1.Services.Common;

namespace WebApplication1.Services.Data
{
    public struct PixFile
    {
        public string Name { get; internal set; }
        public string Path { get; internal set; }
        public PixImage[] Images { get; set; }
    }
}
