using API.Controllers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests
{
    public class ProductTest
    {
        DbContextOptions<ApiDbContext> options; 
        ApiDbContext context; //para la bd
        ProductController controller; //para la api

        public ProductTest()
        {
            //especifico la cadena de conexion ya que por alguna razón que desconozco, no toma la del startup
            options =  new DbContextOptionsBuilder<ApiDbContext>()
            .UseSqlServer("Data Source=.\\SQLEXPRESS;Initial catalog=DB_API_REST;Integrated Security=True;")
            .Options; 
            context = new ApiDbContext(options);
            controller = new ProductController(context);
        }

        [Fact]
        public async Task TestGetAll()
        {
            var listProductApi = await controller.GetAll();
            var listProductaDB = await context.Products.ToListAsync();
            Assert.Equal(listProductApi.Count(), listProductaDB.Count());
        }

        /*
        [Fact]
        public async Task GetByIdAsync()
        {
            int id = 3;
            Product productApi = await context.Products.FirstOrDefaultAsync(e => e.Id == id);
            Product productDB = (Product)await controller.GetById(id);
            Assert.Equal(productApi, productDB);
        }
        */
    }
}
