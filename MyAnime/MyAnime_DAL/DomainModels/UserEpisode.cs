using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnime_DAL
{
    [Table("UserEpisode")]
    public class UserEpisode
    {
        [Key]
        public int UserEpisodeID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Episode is required")]
        public int EpisodeId { get; set; }
        [Required(ErrorMessage = "Watched is required")]
        public bool Watched { get; set; }
        public AppUser User { get; set; }
        public Episode Episode { get; set; }
    }
}
