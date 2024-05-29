using AppHub.Domain.Common;

namespace AppHub.Domain.Exceptions;

public class InvalidBirthDateException: DomainException
{
    public InvalidBirthDateException() : base(message:"Invalid birtDate")
    {
    }
}