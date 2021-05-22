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
    [Table("SerieCategory")]
    public partial class SerieCategory: BaseClass
    {
        [Key]
        public int SerieCategoryId { get; set; }
        [Required]
        public int SerieId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        public Serie Serie { get; set; }
        public Category Category { get; set; }
    }
}
