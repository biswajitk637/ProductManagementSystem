using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagementSystem.Models
{
    public class Regsitration
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }
     
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter EmailId")]
        [DataType(DataType.EmailAddress)]
        public string EmailId { get; set; }
      
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        public bool IsActive { get; set; }
        public string ProfileImage { get; set; }
        public bool IsVerified { get; set; }
    }
}
