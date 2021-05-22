using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnime_DAL
{
    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        public ICollection<SerieCategory> SerieCategories { get; set; }
    }
}
