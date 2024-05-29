using AppHub.Application.Common;

namespace AppHub.Application.Exceptions;

public class DuplicatedEmailException: AppLayerException
{
    public DuplicatedEmailException(): base("Invalid email, Duplicated")
    {
        
    }
}