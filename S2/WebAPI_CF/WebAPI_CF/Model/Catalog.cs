using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_CF.Model
{
    [Table("Loai")]
    public class Catalog
    {
        [Key]
        public int CataID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Cataname { get; set; }
    }
}
