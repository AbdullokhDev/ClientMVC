using System.ComponentModel.DataAnnotations;

namespace ClientMVC.Models
{
    public class Client
    {
        public int Id { get; set; }
        [Required]
        public string? firstName { get; set; }
        [Required]
        public string? lastName { get; set; }
        [Required]
        public string? phoneNumber { get; set; }
        [Required]
        public string? email { get; set; }
        [Required]
        public string? address { get; set; }

    }
}