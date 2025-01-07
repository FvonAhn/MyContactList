using Business.Factories;
using Business.Helpers;
using Business.Models;
using Business.Interfaces;
using System.Diagnostics;

namespace Business.Services;
public class ContactService : IContactService
{
    public List<ContactEntity> _contacts = [];
    private readonly FileService _fileService;

    public ContactService(FileService fileService)
    {
        _fileService = fileService;
    }

    public bool CreateContact(ContactForm form)
    {
        try
        {
            ContactEntity contactEntity = ContactFactory.Create(form)!;
            contactEntity.Id = IdGenerator.GenerateID();

            _contacts.Add(contactEntity);
            _fileService.SaveContactToFile(_contacts);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<ContactEntity> GetContacs()
    {
        _contacts = _fileService.GetContactsFromFile();
        return _contacts;
    }
}
