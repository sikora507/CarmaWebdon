using System.Collections.Generic;

namespace WebApplication1.Helpers
{
    public interface IFilesHelper
    {
        List<string> GetFiles(string directory, string extension);
    }
}