using Business.Models;

namespace Business.Interfaces;
public interface IFileService
{
    List<ContactEntity> GetContactsFromFile();
    bool SaveContactToFile(List<ContactEntity> contact);
}