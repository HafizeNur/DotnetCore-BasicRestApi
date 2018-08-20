using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.BasicRestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.BasicRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //statik bir ürün listesi olusturup bunun üzerinde işlemler yapıyoruz.
        static List<Product> _products = new List<Product>()
        {
            new Product(){ProductId=0,ProductName="Laptop",ProductPrice="3000"},
            new Product(){ProductId=1,ProductName="SmartPhone",ProductPrice="2000"},
        };

        
        //get-->read
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _products;

        }

        //post-->create
        [HttpPost]
        public void PostProduct([FromBody]Product product)
        {
            _products.Add(product);
        }

        //put-->update
        [HttpPut("{id}")]
        public void PutProduct(int id,[FromBody]Product product)
        {
            _products[id] = product;
        }


        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            _products.RemoveAt(id);
        }

    }
}