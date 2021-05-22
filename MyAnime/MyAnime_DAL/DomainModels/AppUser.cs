using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnime_DAL
{
    [Table("AppUser")]
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        [Index(IsUnique =true)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress]
        [Index(IsUnique = true)]
        [MaxLength(450)]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(450)]
        public string PasswordHash { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public ICollection<Serie> Series { get; set; }
        public ICollection<Episode> Episodes { get; set; }
        public ICollection<UserEpisode> UserEpisodes { get; set; }
    }
}
