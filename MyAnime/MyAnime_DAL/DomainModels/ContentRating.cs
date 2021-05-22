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
    [Table("ContentRating")]
    public partial class ContentRating: BaseClass
    {
        [Key]
        public int ContentRatingId { get; set; }
        [Required(ErrorMessage = "Image is required")]
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [Required(ErrorMessage = "Rating is required")]
        [MaxLength(255)]
        public string Rating { get; set; }
        public ICollection<Serie> Series { get; set; }
    }
}
