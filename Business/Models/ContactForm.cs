using System.ComponentModel.DataAnnotations;
namespace Business.Models;

public class ContactForm
{
    [Required]
    public string FirstName { get; set; } = null!;

    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public string Adress { get; set; } = null!;

    [Required]
    public string PostalCode { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
