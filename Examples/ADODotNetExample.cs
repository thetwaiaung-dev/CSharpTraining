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
            ////       BlogModel blogModel = new BlogModel();
            ////       Console.Write("Enter Blog Title   : ");
            ////       blogModel.BlogTitle = Console.ReadLine();

            ////       Console.Write("Enter Blog Author : ");
            ////       blogModel.BlogAuthor = Console.ReadLine();

            ////       Console.Write("Enter Blog Content  : ");
            ////       blogModel.BlogContent = Console.ReadLine();


            ////       BlogDTO dto = blogModel.Change();

            ////       string queryInsert = $@"
            ////INSERT INTO [dbo].[Tbl_Blog]
            ////      ([Blog_Title]
            ////      ,[Blog_Author]
            ////      ,[Blog_Content])
            ////VALUES
            ////      ('{dto.BlogTitle}'
            ////      ,'{dto.BlogAuthor}'
            ////      ,'
            ////       {dto.BlogContent}')";

            ////       int resultInsert = adoDotNetService.Execute(queryInsert);


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
            if (dataTable.Rows.Count > 0)
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
            Console.WriteLine("Get Product By Id :");
        againProductId:
            Console.WriteLine("Enter Product Id : ");
            string ProductId = Console.ReadLine();
            bool checkProductId = long.TryParse(ProductId, out long convertProductId);
            if (!checkProductId)
            {
                Console.WriteLine("Enter number for product Id");
                goto againProductId;
            }
            string getQuery = $@"
                        SELECT 
                               [name]
                               ,[price]
                              FROM [dbo].[product] 
                            where id={convertProductId}
                            ";
            DataTable getProduct = adoDotNetService.Query(getQuery);
            if (getProduct.Rows.Count > 0)
            {
                DataRow dataRow = getProduct.Rows[0];
                string GetProductName = dataRow["name"].ToString();
                int GetProductPrice = Convert.ToInt16(dataRow["price"]);
                Console.WriteLine($"Product Name : {GetProductName}");
                Console.WriteLine($"Product Price : {GetProductPrice}");
            }
            else
            {
                Console.WriteLine("Product Data have no found");
            }
            #endregion

            #region Update
            ProductModel updateProductModel = new ProductModel();
            Console.WriteLine("To Update Product by Id :");
        againUpdateId:
            Console.WriteLine("Enter Product Id :");
            bool checkUpdateId = long.TryParse(Console.ReadLine(), out long updateId);
            if (!checkUpdateId)
            {
                Console.WriteLine("Enter only number for Product Id!");
                goto againUpdateId;
            }

            Console.WriteLine("Enter Product Name :");
            productModel.ProductName = Console.ReadLine();

        againUpdateProductPrice:
            Console.WriteLine("Enter Product Price : ");
            bool checkUpdateProductPrice = short.TryParse(Console.ReadLine(), out short convertUpdatePrice);
            if (!checkUpdateProductPrice)
            {
                Console.WriteLine("Enter only number for product price ");
                goto againUpdateProductPrice;
            }
            productModel.ProductPrice = convertUpdatePrice;

            ProductDto updateProductDto = ChangeModelProduct.Change(productModel);
            string updateQuery = $@"
                            UPDATE [dbo].[product]
                                   SET [name] = '{productDto.ProductName}'
                                      ,[price] = {productDto.ProductPrice}
                                    WHERE <Search Conditions,,>
                                  ";
            int updateResult = adoDotNetService.Execute(updateQuery);
            Console.WriteLine(updateResult > 0 ? "Update successful" : "Update failed");
            #endregion

            #region Delete
            Console.WriteLine("To Delete Product By Id : ");
            Console.WriteLine("Enter product id : ");
        againDeleteId:
            bool checkDeleteId = long.TryParse(Console.ReadLine(), out long convertDeleteId);
            if (!checkDeleteId)
            {
                Console.WriteLine("Enter only number for product id!");
                goto againDeleteId;
            }
            string deleteQuery = $@"
                                 Delete  FROM [dbo].[product]
                                    WHERE  id={convertDeleteId} 
                                ";
            int deleteResult = adoDotNetService.Execute(deleteQuery);
            Console.WriteLine(deleteResult > 0 ? "Delete Successful " : "Delete failed");
            #endregion
        }
    }
}
