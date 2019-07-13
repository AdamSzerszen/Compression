using System.IO;
using Infrastructure.interfaces;

namespace Infrastructure.services
{
    public class FileService : IFileService
    {
        public string LoadData(string path)
        {
            var result = File.ReadAllText(path);

            return result;
        }

        public void SaveData(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }
}