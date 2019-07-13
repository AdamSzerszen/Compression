namespace Infrastructure.interfaces
{
    public interface IFileService
    {
        string LoadData(string path);
        void SaveData(string path, string content);
    }
}