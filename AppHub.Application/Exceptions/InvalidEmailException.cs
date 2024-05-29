using AppHub.Application.Common;

namespace AppHub.Application.Exceptions;

public class InvalidEmailException: AppLayerException
{
    public InvalidEmailException(): base("The e-mail is not valid.")
    {
        
    }
}