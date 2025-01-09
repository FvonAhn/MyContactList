using Business.Factories;
using Business.Models;
using Business.Interfaces;
using System.Text.Json;

namespace Business.Services;
public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;
    private List<Contact> _contacts = [];

    public bool CreateContact(ContactForm form)
    {
        try
        {
            var contact  = ContactFactory.Create(form);
            _contacts.Add(contact);

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

    public IEnumerable<Contact> GetContacs()
    {
        var contact = _fileService.GetContactsFromFile();
        try
        {
            _contacts = JsonSerializer.Deserialize<List<Contact>>(contact)!;
        }
        catch 
        {
            _contacts = [];
        }
        return _contacts;
    }
}
