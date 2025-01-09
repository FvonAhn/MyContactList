using Business.Models;

namespace Business.Interfaces;
public interface IContactService
{
    bool SaveContact(ContactForm form);
    IEnumerable<Contact> GetContacs();
}