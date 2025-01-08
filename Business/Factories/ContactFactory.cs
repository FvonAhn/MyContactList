using Business.Helpers;
using Business.Models;
using System.Diagnostics;

namespace Business.Factories;
public static class ContactFactory
{
    public static ContactForm Create()
    {
        return new ContactForm();
    }
    
    public static Contact? Create(ContactForm form)
    {
        try
        {
            return new Contact
            {
                Id = IdGenerator.GenerateID(),
                FirstName = form.FirstName,
                LastName = form.LastName,
                Adress = form.Adress,
                PostalCode = form.PostalCode,
                City = form.City,
                Email = form.Email,
                Phone = form.Phone,
            };
        }
        catch (Exception ex) 
        {
            Debug.WriteLine($"Error Creating Contact: {ex.Message}");
            return null;
        }
    }
}
