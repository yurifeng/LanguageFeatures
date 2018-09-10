﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// 返回string类型视图(没有修饰)
        /// localhost:12306/Home/Index
        /// </summary>
        /// <returns></returns>
        public string Index()
        {
            return "Navigate to a URL to show an example";
        }

        /// <summary>
        /// 返回ViewResult视图
        /// localhost:12306/Home/AutoProperty
        /// </summary>
        /// <returns></returns>
        public ViewResult AutoProperty()
        {
            // 创建实例对象(使用对象初始化器)
            Product myProduct = new Product { Name = "livir van" };

            // 获取Name属性
            string productName = myProduct.Name;

            // 返回生成的View
            return View("Result",
                (object)$"Product name: {productName}");
        }

        /// <summary>
        /// 返回ViewResult视图
        /// localhost:12306/home/CreateProduct
        /// </summary>
        /// <returns></returns>
        public ViewResult CreateProduct()
        {
            // 创建新的Product实例
            Product myProduct = new Product
            {
                ProductId = 100,
                Name = "yty optimas",
                Description = "A boat for one person",
                Price = 275M,
                Category = "Watersports"
            };

            //返回生成的View
            return View("Result",
                (object)$"Description: {myProduct.Description}");
        }

        /// <summary>
        /// 返回ViewResult视图
        /// localhost:12306/home/CreateCollection
        /// </summary>
        /// <returns></returns>
        public ViewResult CreateCollection()
        {
            //创建集合示例
            string[] stringArray = { "apple", "orange", "plum" };
            List<int> intList = new List<int> { 10, 20, 30, 40 };
            Dictionary<string, int> myDict = new Dictionary<string, int> {
                { "apple", 10 }, { "orange", 20 }, { "plum", 30 }
            };

            return View("Result", (object)stringArray[1]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ViewResult UseExtension()
        {
            // create and populate ShoppingCart 
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // get the total value of the products in the cart
            decimal cartTotal = cart.TotalPrices();

            return View("Result",
                (object)$"Total: {cartTotal:c}");
        }

        public ViewResult UseExtensionEnumerable()
        {

            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Price = 275M},
                    new Product {Name = "Lifejacket", Price = 48.95M},
                    new Product {Name = "Soccer ball", Price = 19.50M},
                    new Product {Name = "Corner flag", Price = 34.95M}
                }
            };

            // create and populate an array of Product objects
            Product[] productArray = {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "Lifejacket", Price = 48.95M},
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            // get the total value of the products in the cart
            decimal cartTotal = products.TotalPrices();
            decimal arrayTotal = products.TotalPrices();

            return View("Result",
                (object)$"Cart Total: {cartTotal}, Array Total: {arrayTotal}");
        }

        public ViewResult UseFilterExtensionMethod()
        {

            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                    new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                    new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                    new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
                }
            };

            decimal total = 0;

            foreach (Product prod in products
                    .Filter(prod => prod.Category == "Soccer" || prod.Price > 20))
            {
                total += prod.Price;
            }
            return View("Result", (object)$"Total: {total}");
        }

        public ViewResult CreateAnonArray()
        {

            var oddsAndEnds = new[] {
                new { Name = "MVC", Category = "Pattern"},
                new { Name = "Hat", Category = "Clothing"},
                new { Name = "Apple", Category = "Fruit"}
            };

            StringBuilder result = new StringBuilder();
            foreach (var item in oddsAndEnds)
            {
                result.Append(item.Name).Append(" ");
            }
            return View("Result", (object)result.ToString());
        }

        public ViewResult FindProducts()
        {

            Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };

            var foundProducts = products.OrderByDescending(e => e.Price)
                                    .Take(3)
                                    .Select(e => new
                                    {
                                        e.Name,
                                        e.Price
                                    });

            products[2] = new Product { Name = "Stadium", Price = 79600M };

            StringBuilder result = new StringBuilder();
            foreach (var p in foundProducts)
            {
                result.AppendFormat("Price: {0} ", p.Price);
            }

            return View("Result", (object)result.ToString());
        }

        public ViewResult SumProducts()
        {
            Product[] products = {
                new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
                new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
                new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
                new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
            };

            var results = products.Sum(e => e.Price);

            products[2] = new Product { Name = "Stadium", Price = 79500M };

            return View("Result",
                (object)$"Sum: {results:c}");
        }


    }
}