using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CF.Model
{
    public class CatalogModel
    {
        [Required]
        [MaxLength(100)]
        public string Cataname { get; set; }
    }
}
