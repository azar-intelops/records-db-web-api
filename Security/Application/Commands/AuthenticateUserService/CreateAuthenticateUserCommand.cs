using MediatR;

namespace Application.Commands.AuthenticateUserService
{
    public class CreateAuthenticateUserCommand : IRequest<int>
    {
        public int Id  { get; set; }
    
        
        public string Password { get; set; }
        
    
        
        public string Username { get; set; }
        
    
    }
}
