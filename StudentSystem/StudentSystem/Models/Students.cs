using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class Students
    {
        [Required(ErrorMessage = "This is mandatory")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "This is mandatory")]
        
        [Range(20,99,ErrorMessage = "Age should be more than 21 and less than 99")]
        public int Age { get; set; }
        
        [Required(ErrorMessage = "This is mandatory")]
        public string Gender { get; set; }
        
        public bool Education { get; set; }
        public int? EducationId { get; set; }
        
        [Required(ErrorMessage = "This is mandatory")]
        public string City { get; set; }
        public List<CheckModel> Educations { get; set; }
        public List<KeyPair> Cities { get; set; }
    }
}