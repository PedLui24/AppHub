using AppHub.Domain.Common;

namespace AppHub.Domain.Exceptions;

public class InvalidPhoneNumberException: DomainException
{
    public InvalidPhoneNumberException(): base(message:"")
    {
        
    }
}