using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProduct : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
          mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" + 
                 "VALUES('Caderno espiral','Caderno espiral 100 folhas', 7.45 , 50 ,'caderno.jpg', 1)");
        
          mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" + 
                 "VALUES('Estojo escolar','Estojo escolar cinza', 5.65 , 70 ,'estojo.jpg', 1)"); 

           mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" + 
                 "VALUES('Borracha escolar','Borracha pequena', 3.76 , 30 ,'Borracha.jpg', 1)");
            
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId)" + 
                 "VALUES('Calculadora escolar','Calculadora simples', 15.67 , 20 ,'calculadora.jpg', 1)");


        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM PRODUCTS");
        }
    }
}
