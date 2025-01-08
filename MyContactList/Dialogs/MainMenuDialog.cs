using Business.Factories;
using Business.Interfaces;
using Business.Services;

namespace MyContactList.Dialogs;
public class MainMenuDialog(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;
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
            string answer = Console.ReadLine()!;
            switch (answer.ToLower())
            {
                case "1":
                    ShowContacts();
                    break;
                case "2":
                    NewContact();
                    break;
                //case "3":
                //    SaveContact();
                //    break;
                case "q":
                    QuitApp();
                    break;
                default:
                    break;
            }
            Console.ReadKey();
        }
    }

    public void ShowContacts()
    {
        Console.Clear();

        if (_contactService != null)
        {
            foreach (var contacts in _contactService.GetContacs())
            {
                Console.WriteLine("----------- Contact ----------");
                Console.WriteLine($"{"Name:",-5}{contacts.FirstName} {contacts.LastName}");
                Console.WriteLine($"{"Name:",-5}{contacts.Adress} {contacts.PostalCode}");
                Console.WriteLine($"{"Name:",-5}{contacts.City}");
                Console.WriteLine($"{"Name:",-5}{contacts.Email}");
                Console.WriteLine($"{"Name:",-5}{contacts.Phone}");
                Console.WriteLine("------------------------------");
                Console.WriteLine("");
            }
        }
        else 
        {
            Console.WriteLine("No contacts found!");
        }
        Console.ReadKey();
    }

    public void NewContact()
    {
        var contact = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("--------- New Contact --------");
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

        var addContact = _contactService.CreateContact(contact);
        if (addContact)
        {
            Console.Clear();
            Console.WriteLine("Contact Added.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("If you want to keep the new contact \nyou need to save it to file."); 
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Failed adding contact");
        }
    }

    //public void SaveContact()
    //{
    //    var contact = _contactService.GetContacs().Last();
    //    Console.WriteLine($"{"Would you like to save contact:"} {contact.FirstName} {contact.LastName}{"?"}");
    //    Console.WriteLine($"{"",-11}Y / N");
    //    var answer = Console.ReadLine()!;
    //}

    public void QuitApp() 
    {
        Console.Clear();
        Console.WriteLine("Are you sure you want to quit?");
        Console.WriteLine($"{"",-11}Y / N");
        var quitAppAnswer = Console.ReadLine()!;

        if (quitAppAnswer.ToLower() == "y")
        {
            Console.Clear();
            Console.WriteLine("Goodbye!");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }

}
