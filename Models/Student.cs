using System.ComponentModel.DataAnnotations;

namespace MVCCoreDemo.Models    
{    
    public class Student    
    {    
        [Required]   
        public int StudId { get; set; }    
        [Required]    
        public required string Name { get; set; }    
        [Required]    
        public required string Gender { get; set; }    
        [Required]    
        public required string Department { get; set; }    
        [Required]    
        public required string City { get; set; }    
    }    
}