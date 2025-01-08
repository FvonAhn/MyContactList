using Business.Interfaces;
using Business.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Business.Services;
public class FileService : IFileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directoryPath = "Data", string fileName = "contacts.json")
    {
        _directoryPath = directoryPath;
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
        try
        {
            if (!File.Exists(_filePath))
            {
                return File.ReadAllText(_filePath);
            }
        }
        catch
        {
            Console.Clear();
            Console.WriteLine("No Contacts available.");
            Console.ReadKey();
        }
        return null!;

    }
}
