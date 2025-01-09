using Business.Factories;
using Business.Models;

namespace MyContactList_Test.Factories;
public class ContactFactory_Test
{
    [Fact]
    public void Create_ShouldReturnContactForm()
    {
        // Act
        var result = ContactFactory.Create();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactForm>(result);
    }

    [Fact]

    public void Create_ShouldReturnContact_WhenContactFormIsProvided() 
    {
        // Arrange
        var contactForm = new ContactForm()
        {
            FirstName = "Fred",
            LastName = "Flinta",
            Adress = "Flintgatan 1",
            PostalCode = "12345",
            City = "Flintville",
            Email = "fred.flinta@flintstones.com",
            Phone = "0123456789",
        };

        // Act
        var result = ContactFactory.Create(contactForm);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<Contact>(result);
        Assert.Equal(contactForm.FirstName, result.FirstName);
        Assert.Equal(contactForm.LastName, result.LastName);
        Assert.Equal(contactForm.Adress, result.Adress);
        Assert.Equal(contactForm.PostalCode, result.PostalCode);
        Assert.Equal(contactForm.City, result.City);
        Assert.Equal(contactForm.Email, result.Email);
        Assert.Equal(contactForm.Phone, result.Phone);
    }
    

}
