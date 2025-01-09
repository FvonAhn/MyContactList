using Business.Interfaces;

namespace Business.Services;
public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string fileName)
    {
        _directoryPath = "Data";
        _filePath = Path.Combine(_directoryPath, fileName);
    }


    public bool SaveContactToFile(string contact)
    {
        try
        {
            if (!Directory.Exists(_directoryPath))
            {
                Directory.CreateDirectory(_directoryPath);
            }

            File.WriteAllText(_filePath, contact);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string GetContactsFromFile()
    {

            if (!File.Exists(_filePath))
            {
                return File.ReadAllText(_filePath);
            }
 
        return null!;
    }
}
