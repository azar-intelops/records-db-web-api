namespace Application.Exceptions
{
    public class AuthenticateUserNotFoundException : ApplicationException
    {
        public AuthenticateUserNotFoundException(string name, object key) : base($"Entity {name} - {key} is not found.")
        {

        }
    }
}
