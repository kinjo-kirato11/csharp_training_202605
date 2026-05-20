using System.ComponentModel.DataAnnotations;

namespace WebEmployeeManagement.Infrastructures.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;



        [Required]
        public string UserName { get; set; } = string.Empty;

    }
}