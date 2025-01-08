using Business.Factories;
using Business.Helpers;
using Business.Models;
using Business.Interfaces;
using System.Text.Json;

namespace Business.Services;
public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;
    public List<ContactEntity> _contacts = [];

    public bool CreateContact(ContactForm form)
    {
        try
        {
            var contactEntity  = ContactFactory.Create(form);
            contactEntity.Id = IdGenerator.GenerateID();
            _contacts.Add(contactEntity);

            var json = JsonSerializer.Serialize(_contacts);
            var contactCreated = _fileService.SaveContactToFile(json);
            return contactCreated;
        }
        catch 
        {
            return false;
        }
    }

    //public bool SaveContact(ContactEntity contact)
    //{
    //    var json = JsonSerializer.Serialize(_contacts);
    //    var contactCreated = _fileService.SaveContactToFile(json);
    //    return contactCreated;
    //}

    public IEnumerable<ContactEntity> GetContacs()
    {
        var contact = _fileService.GetContactsFromFile();
        try
        {
            _contacts = JsonSerializer.Deserialize<List<ContactEntity>>(contact)!;
        }
        catch 
        {
            _contacts = [];
        }
        return _contacts;
    }
}
