using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JewelryStore.Services.Dtos
{
    public class AuthRequestDto
    {
        [MinLength(5, ErrorMessage = "User name must have alteast 5 characters")]
        [MaxLength(50, ErrorMessage = "User name can have almost 50 characters")]
        public string UserName { get; set; }

        [MinLength(5, ErrorMessage = "Password must have alteast 5 characters")]
        [MaxLength(50, ErrorMessage = "Password can have almost 50 characters")]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{5,}", ErrorMessage = "Password require atleast 1 number, 1 uppercase, 1 lowercase and 1 special character")]
        public string Password { get; set; }
    }
}
