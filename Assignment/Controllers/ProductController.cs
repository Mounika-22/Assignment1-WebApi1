using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment.Controllers
{
    public class ProductController : ApiController
    {
        static List<Product> _productList = null;
        void Initialize()
        {
            _productList = new List<Product>()
           {
               new Product() { ProductId=1, Name="Books" , QtyInStock=50, Description="Available", Supplier="Amazon"},
            };
        
        }
        public ProductController()
        {
            if (_productList == null)
            {
                Initialize();
            }
        }


        
        // GET api/<controller>/5
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _productList);
        }

        
        public HttpResponseMessage Get(int id)
        {
            Product product = _productList.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");
            else
                return Request.CreateResponse(HttpStatusCode.OK, product);
        }


        // POST api/<controller>
        public HttpResponseMessage Post(Product product)
        {
            if (product != null)
            {
                _productList.Add(product);
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }



        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, Product objProduct)
        {
            Product student = _productList.Where(x => x.ProductId == id).FirstOrDefault();
            if (student == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");

            }
            else
            {
                if (student != null)
                {
                    foreach (Product temp in _productList)
                    {
                        if (temp.ProductId == id)
                        {
                            temp.Name = objProduct.Name;
                            temp.QtyInStock = objProduct.QtyInStock;
                            temp.Description = objProduct.Description;
                            temp.Supplier = objProduct.Supplier;
                        }
                    }


                }
                return Request.CreateResponse(HttpStatusCode.OK, "Modified");

            }
        }


        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            Product product = _productList.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "STudent Not found");

            }
            else
            {
                if (product != null)
                {
                    _productList.Remove(product);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Deleteed");
            }

        }

    }
}