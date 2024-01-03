using MediatR;

namespace Application.Commands.AuthenticateUserService
{
    public class UpdateAuthenticateUserCommand : IRequest
    {
        public int Id  { get; set; }
    
        
        public string Password { get; set; }
        
    
        
        public string Username { get; set; }
        
    
    }
}
