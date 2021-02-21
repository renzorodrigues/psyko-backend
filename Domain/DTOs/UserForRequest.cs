using System.ComponentModel.DataAnnotations;

namespace CCAU.Domain.DTOs
{
    public class UserForRequest
    {
        [MinLength(5), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(0), MaxLength(100), EmailAddress]
        public string Email { get; set; }
    }
}