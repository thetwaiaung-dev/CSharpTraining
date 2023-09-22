using CSharpTraining.DTOs;
using CSharpTraining.Models;
using CSharpTraining.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CSharpTraining.Examples
{
    public class ADODotNetExample
    {
        public static void Run()
        {
            #region Create

            ADODotNetService adoDotNetService = new ADODotNetService(AppSetting.DbConnection);
            //       BlogModel blogModel = new BlogModel();
            //       Console.Write("Enter Blog Title   : ");
            //       blogModel.BlogTitle = Console.ReadLine();

            //       Console.Write("Enter Blog Author : ");
            //       blogModel.BlogAuthor = Console.ReadLine();

            //       Console.Write("Enter Blog Content  : ");
            //       blogModel.BlogContent = Console.ReadLine();


            //       BlogDTO dto = blogModel.Change();

            //       string queryInsert = $@"
            //INSERT INTO [dbo].[Tbl_Blog]
            //      ([Blog_Title]
            //      ,[Blog_Author]
            //      ,[Blog_Content])
            //VALUES
            //      ('{dto.BlogTitle}'
            //      ,'{dto.BlogAuthor}'
            //      ,'
            //       {dto.BlogContent}')";

            //       int resultInsert = adoDotNetService.Execute(queryInsert);


            ProductModel productModel = new ProductModel();
            Console.WriteLine("Enter Product Name : ");
            productModel.ProductName = Console.ReadLine();

            againPrice:
            Console.WriteLine("Enter Product Price : ");
            string ProductPrice = Console.ReadLine();
            bool ChangePriceType = short.TryParse(ProductPrice, out short productPrice);
            productModel.ProductPrice = productPrice;

            if (!ChangePriceType)
            {
                Console.WriteLine("Please Enter Price only number");
                goto againPrice;
            }

            ProductDto productDto = ChangeModelProduct.Change(productModel);
            string insertQuery = $@"
                             INSERT INTO [dbo].[product]
                                   ([name]
                                   ,[price])
                             VALUES
                                   ('{productDto.ProductName}'
                                   ,{productDto.ProductPrice})
                                 ";
            int resultInsert = adoDotNetService.Execute(insertQuery);
            Console.WriteLine(resultInsert > 0 ? "Saving Successful!" : "Saving Failed!");
            #endregion

            #region GetAll
            Console.WriteLine("Get All Products :: ");
            string getAllQuery = $@"
                            SELECT 
                                   [name]
                                  ,[price]
                              FROM [dbo].[product] 
                                  ";

            DataTable dataTable = adoDotNetService.Query(getAllQuery);
            if(dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    string ProductName = row["name"].ToString();
                    int Price = Convert.ToInt16(row["price"]);

                    Console.WriteLine($"Product Name => {ProductName}");
                    Console.WriteLine($"Product Price => {Price}");
                }
            }
            else
            {
                Console.WriteLine("Products have not found ");
            }
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
