using System.Net.Mail;
using System.Text.RegularExpressions;
using AppHub.Domain.Exceptions;

namespace AppHub.Domain.Models;

public class PersonModel
{
    public Guid Id { get; private set; } 
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime BirthDate { get; private set; }

    public PersonModel(
        Guid id, 
        string name, 
        string lastName, 
        string email, 
        string phoneNumber, 
        DateTime birthdate
    )
    {
        Id = id;
        Name = name;
        LastName = lastName; 
        Email = ValidatedEmail(email);
        PhoneNumber = ValidatePhone(phoneNumber);
        BirthDate = ValidateBirthDate(birthdate);
    }

    public void UpdatePhone(string phoneNumber) => phoneNumber = ValidatePhone(phoneNumber);
    
    private static string ValidatedEmail(string email)
    {
        if (!new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Match(email).Success)
            throw new InvalidEmailException();
        
        return email;
    }
    
    private static DateTime ValidateBirthDate(DateTime birtdate)
    {
        if ((DateTime.Now.Year - birtdate.Year) <= 15)
            throw new InvalidBirthDateException();
        return birtdate;
    }

    private static string ValidatePhone(string phoneNumber)
    {
        if (!IsPhoneNumber(phoneNumber))
            throw new InvalidPhoneNumberException();
        return phoneNumber;
    }

    private static bool IsPhoneNumber(string number)
    {
        return Regex.Match(number, @"^(\+?\s?[0-9\s]+)$").Success;
    }
}