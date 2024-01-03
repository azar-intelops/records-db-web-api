namespace Application.Responses
{
    public class DBLicenseInfoResponse
    {    
        public int Id  { get; protected set; }
    
        
        public string BuildNumber { get; set; }
        
    
        
        public string DatabaseDate { get; set; }
        
    
        
        public string DatabaseExpirationDate { get; set; }
        
    
        
        public string DatabaseFileDirectory { get; set; }
        
    
        
        public string LicenseExpirationDate { get; set; }
        
    
        
        public string LicenseKey { get; set; }
        
    
        
        public int MaxNumberOfAddressesPermittedPerRequest { get; set; }
        
    
        
        public string ResidentialBusinessDeliveryIndicatorDatabaseDate { get; set; }
        
    
    }
}
