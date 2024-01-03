using MediatR;

namespace Application.Commands.AddressService
{
    public class CreateAddressCommand : IRequest<int>
    {
        public int Id  { get; set; }
    
        
        public string AddressLine1 { get; set; }
        
    
        
        public string AddressLine2 { get; set; }
        
    
        
        public string City { get; set; }
        
    
        
        public string CityStateZipCodeLine { get; set; }
        
    
        
        public string Company { get; set; }
        
    
        
        public string PuertoRicanUrbanization { get; set; }
        
    
        
        public string State { get; set; }
        
    
        
        public string Suite { get; set; }
        
    
        
        public string ZipCode { get; set; }
        
    
        
        public string ZipCodePlus4 { get; set; }
        
    
    }
}
