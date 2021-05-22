using MyAnime_DAL.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnime_DAL
{
    [Table("Episode")]
    public class Episode: BaseClass
    {
        [Key]
        public int EpisodeId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Image is required")]
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Number is required")]
        public int Number { get; set; }
        [Required(ErrorMessage = "Releasedate is required")]
        [DataType(DataType.Date)]        
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public int SerieId { get; set; }
        [Required]
        public int UserId { get; set; }
        public Serie Serie { get; set; }        
        public AppUser User { get; set; }
        public ICollection<UserEpisode> UserEpisodes { get; set; }
    }
}
