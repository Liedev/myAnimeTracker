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
    [Table("Serie")]
    public partial class Serie: BaseClass
    {
        [Key]
        public int SerieId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Image is required")]
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [Required(ErrorMessage = "Airdate is required")]
        [DataType(DataType.Date)]
        public DateTime? AirDate { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public int TypeId { get; set; }
        [Required(ErrorMessage = "Contentrating is required")]
        public int ContentRatingId { get; set; }
        [Required(ErrorMessage = "A writer is required")]
        public int WriterId { get; set; }
        [Required]
        public int UserId { get; set; }
        public Type Type { get; set; }
        public ContentRating ContentRating { get; set; }
        public Writer Writer { get; set; }
        public AppUser User { get; set; }
        public ICollection<SerieCategory> SerieCategories { get; set; }
        public ICollection<Episode> Episodes { get; set; }
    }
}
