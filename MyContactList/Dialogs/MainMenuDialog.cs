using Business.Factories;
using Business.Interfaces;

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

        var contacts = _contactService.GetContacs();

        foreach (var contact in contacts)
        {
            Console.WriteLine("----------- Contact ----------");
            Console.WriteLine($"{"Name:",-8}{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{"Adress:",-8}{contact.Adress} {contact.PostalCode} {contact.City}");
            Console.WriteLine($"{"Email:",-8}{contact.Email}");
            Console.WriteLine($"{"Phone:",-8}{contact.Phone}");
            Console.WriteLine("------------------------------");
            Console.WriteLine("");
        }

        Console.ReadKey();
    }

    public void NewContact()
    {
        var form = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("--------- New Contact --------");
        Console.Write("Enter your first name: ");
        form.FirstName = Console.ReadLine()!;
        Console.Write("Enter your last name: ");
        form.LastName = Console.ReadLine()!;
        Console.Write("Enter your adress: ");
        form.Adress = Console.ReadLine()!;
        Console.Write("Enter the postal code: ");
        form.PostalCode = Console.ReadLine()!;
        Console.Write("Enter what city: ");
        form.City = Console.ReadLine()!;
        Console.Write("Enter your email: ");
        form.Email = Console.ReadLine()!;
        Console.Write("Enter your phonenumber: ");
        form.Phone = Console.ReadLine()!;

        var addContact = _contactService.SaveContact(form);
        if (addContact)
        { 
            Console.Clear();
            Console.WriteLine("Contact added succesfully.");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Failed adding contact.");
        }
    }

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
