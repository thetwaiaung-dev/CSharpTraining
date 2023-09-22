using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSharpTraining.DTOs
{
    [Table("Tbl-Blog")]
    public class BlogDTO
    {
        [Key]
        [Column("Blog_Id")]
        public long Id { get; set; }
        [Column("Blog_Title")]
        public string BlogTitle { get; set; }
        [Column("Blog_Content")]
        public string BlogContent { get; set; }
        [Column("Blog_Author")]
        public string BlogAuthor { get; set; }

    }

    [Table("product")]
    public class ProductDto
    {
        [Key]
        [Column ("id")]
        public long Id { get; set; }
        [Column("name")]
        public string ProductName {  get; set; }
        [Column("price")]
        public short ProductPrice { get; set; }
    }
}
