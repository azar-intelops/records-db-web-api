using Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class AuthenticateUser : EntityBase
    {
        public int Id  { get; set; }
    
        
        public string Password { get; set; }
        
    
        
        public string Username { get; set; }
        
    
    }
}
