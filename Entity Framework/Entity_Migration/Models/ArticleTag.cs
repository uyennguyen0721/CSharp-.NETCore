using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity_Migration.Models
{
    public class ArticleTag
    {
        [Key]
        public int ArticleTagId { set; get; }

        public int TagId { set; get; } // Fk

        [ForeignKey("TagId")]
        public Tag Tag { set; get; }

        public int ArticleId { set; get; } // Fk

        [ForeignKey("ArticleId")]
        public Article Article { set; get; }

    }
}
