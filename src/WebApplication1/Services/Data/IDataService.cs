namespace WebApplication1.Services.Data
{
    public interface IDataService
    {
        string[] Palettes { get; }
        string CarmaDir { get;  }
        PixDir[] PixDirs { get; }
        string ActorsDir { get; }
    }
}
