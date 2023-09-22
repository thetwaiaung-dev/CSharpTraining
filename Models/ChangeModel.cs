using CSharpTraining.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharpTraining.Models
{
    public static class ChangeModel
    {
        public static BlogModel Change(this BlogDTO dto)
        {
            if (dto == null) return null;
            return new BlogModel
            {
                BlogAuthor = dto.BlogAuthor,
                BlogContent = dto.BlogContent,
                BlogTitle = dto.BlogTitle
            };
        }
        public static BlogDTO Change (this BlogModel model)
        {
            if (model == null) return null;
            return new BlogDTO
            {
               BlogAuthor = model.BlogAuthor,
                BlogContent = model.BlogContent,
               BlogTitle = model.BlogTitle
            };
        }
    }
}
