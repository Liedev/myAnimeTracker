using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnime_DAL
{
    public partial class Category
    {
        [NotMapped]
        public bool IsChecked { get; set; }
    }
}
