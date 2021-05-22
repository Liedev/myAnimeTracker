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
    [Table("Writer")]
    public partial class Writer: BaseClass
    {
        [Key]
        public int WriterId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        public ICollection<Serie> Series { get; set; }

    }
}
