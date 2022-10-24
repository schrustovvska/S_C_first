using Microsoft.AspNetCore.Builder;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;

namespace S_c_first.Models
{
    public class User_M
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a E-mail")]
        [StringLength(100)]
        public string email { get; set; }
        [Range (16, 99, ErrorMessage = "Age has to be between 16 and up")]
        public int Age { get; set; }
    }
}
