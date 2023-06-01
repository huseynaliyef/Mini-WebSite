using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public partial class RegisteredUser
    {
        public int Id { get; set; }

		[Required]
		public string? UserName { get; set; }

        [Required]
		[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
		public string? Email { get; set; }
        
		[Required]
		[StringLength(16, MinimumLength = 8)]
		public string? Password { get; set; }
    }
}
