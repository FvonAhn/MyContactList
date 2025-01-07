using Business.Models;

namespace Business.Interfaces;
public interface IContactService
{
    bool CreateContact(ContactForm form);
    IEnumerable<ContactEntity> GetContacs();
}