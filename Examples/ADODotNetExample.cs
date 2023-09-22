using CSharpTraining.DTOs;
using CSharpTraining.Models;
using CSharpTraining.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpTraining.Examples
{
    public class ADODotNetExample
    {
        public static void Run()
        {
            #region Create

            ADODotNetService adoDotNetService = new ADODotNetService(AppSetting.DbConnection);
            BlogModel blogModel = new BlogModel();
            Console.Write("Enter Blog Title   : ");
            blogModel.BlogTitle = Console.ReadLine();

            Console.Write("Enter Blog Author : ");
            blogModel.BlogAuthor = Console.ReadLine();

            Console.Write("Enter Blog Content  : ");
            blogModel.BlogContent = Console.ReadLine();


            BlogDTO dto = blogModel.Change();

            string queryInsert = $@"
     INSERT INTO [dbo].[Tbl_Blog]
           ([Blog_Title]
           ,[Blog_Author]
           ,[Blog_Content])
     VALUES
           ('{dto.BlogTitle}'
           ,'{dto.BlogAuthor}'
           ,'
            {dto.BlogContent}')";

            int resultInsert = adoDotNetService.Execute(queryInsert);
            Console.WriteLine(resultInsert > 0 ? "Saving Successful!" : "Saving Failed!");

            #endregion

            #region GetAll

            #endregion


            #region GetById

            #endregion

            #region Update

            #endregion

            #region Delete

            #endregion
        }
    }
}
