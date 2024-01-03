using Core.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class RecordDBDataConfiguration : EntityBase
    {
        public int Id  { get; set; }
    
        
        public int AddressAliasCodeType { get; set; }
        
    
        
        public int AddressStandardizationCodeType { get; set; }
        
    
        
        public int AddressSuiteParseCodeType { get; set; }
        
    
        
        public bool EnableAlternateAddresses { get; set; }
        
    
        
        public bool EnableCodingAccuracySupportSystemDetection { get; set; }
        
    
        
        public bool EnableCompanyNameSuiteDetection { get; set; }
        
    
        
        public bool EnableDeliveryPointValidationDetection { get; set; }
        
    
        
        public bool EnableLocatableAddressConversionSystemDetection { get; set; }
        
    
        
        public bool EnableMelissaAddressKeyDetection { get; set; }
        
    
        
        public bool EnableResidentialBusinessDeliveryDetection { get; set; }
        
    
        
        public bool EnableSuiteDetection { get; set; }
        
    
        
        public bool EnableUSPSPreferredCityNames { get; set; }
        
    
    }
}
