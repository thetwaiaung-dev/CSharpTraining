using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTraining.Models
{
    public class BlogModel
    {
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogAuthor { get; set; }
    }

    public class ProductModel
    {
        public string ProductName { get; set; }
        public short ProductPrice { get; set; }
    }
}
