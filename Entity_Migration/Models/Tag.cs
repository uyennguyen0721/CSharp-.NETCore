using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity_Migration.Models
{
    public class Tag
    {
        [Key]
        [StringLength(20)]
        public string TagId { set; get; }
        [Column(TypeName = "ntext")]
        public string Content { set; get; }
    }
}
