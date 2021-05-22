﻿using MyAnime_DAL.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAnime_DAL
{
    [Table("Type")]
    public partial class Type: BaseClass
    {
        [Key]
        public int TypeID { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        public ICollection<Serie> Series { get; set; }

    }
}
