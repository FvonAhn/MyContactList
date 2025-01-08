using Business.Models;

namespace Business.Interfaces;
public interface IFileService
{
    string GetContactsFromFile();
    bool SaveContactToFile(string contact);
}