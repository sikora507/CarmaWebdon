using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WebApplication1.Helpers
{
    public class FilesHelper : IFilesHelper
    {
        public List<string> GetFiles(string directory, string extension)
        {
            if (!Directory.Exists(directory))
            {
                return new List<string>();
            }
            string[] filePaths;
            if (string.IsNullOrEmpty(extension))
            {
                filePaths = Directory.GetFiles(directory);
            }
            else
            {
                filePaths = Directory.GetFiles(directory, "*." + extension);
            }
            return filePaths.ToList();
        }
    }
}
