using Business.Models;
using Business.Services;

namespace MyContactList.Dialogs;
public class MainMenuDialog
{
    private readonly ContactService _contactService = new();
    public void MainMenu()
    {
        Console.WriteLine("Welcome!");
        Console.ReadKey();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("----------- Menu -----------");
            Console.WriteLine($"{"",-5}1. Show All Contacts.");
            Console.WriteLine($"{"",-5}2. New Contact.");
            Console.WriteLine($"{"",-5}3. Save New Contact To File.");
            Console.WriteLine($"{"",-5}Q. Close Applicaton.");
            Console.WriteLine("----------------------------");
            MenuOptions();
        }
    }

    public void MenuOptions()
    {
        string answer = Console.ReadLine()!;
        switch (answer.ToLower())
        {
            case "1":
                ShowContacts();
                break;
            case "2":
                NewContact();
                break;
            case "3":
                SaveContact();
                break;
            case "q":
                QuitApp();
                break;
            default:
                break;
        }
    }
    public void ShowContacts()
    {
        Console.Clear();
;
        foreach (var contacts in _contactService.GetContacs())
        {
            Console.WriteLine("----------- Contact ----------");
            Console.WriteLine($"{"Name:",-5}{contacts.FullName}");
            Console.WriteLine($"{"Name:",-5}{contacts.FullAdress}");
            Console.WriteLine($"{"Name:",-5}{contacts.City}");
            Console.WriteLine($"{"Name:",-5}{contacts.Email}");
            Console.WriteLine($"{"Name:",-5}{contacts.Phone}");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
        }
        Console.ReadKey();
    }

    public void NewContact()
    {
        var contact = new ContactForm();
        Console.Clear();
        Console.Write("Enter your first name: ");
        contact.FirstName = Console.ReadLine()!;
        Console.Write("Enter your last name: ");
        contact.LastName = Console.ReadLine()!;
        Console.Write("Enter your adress: ");
        contact.Adress = Console.ReadLine()!;
        Console.Write("Enter the postal code: ");
        contact.PostalCode = Console.ReadLine()!;
        Console.Write("Enter what city: ");
        contact.City = Console.ReadLine()!;
        Console.Write("Enter your email: ");
        contact.Email = Console.ReadLine()!;
        Console.Write("Enter your phonenumber: ");
        contact.Phone = Console.ReadLine()!;
    }

    public void SaveContact()
    {

    }

    public void QuitApp() 
    {

    }

}
