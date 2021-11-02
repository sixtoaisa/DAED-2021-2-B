using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Globalization;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;


namespace Lab11_A
{
    class Program
    {
        static void Main(string[] args)
        {
            //ejercicio1();
            //ejercicio2();
            //ejercicio3();
            //ejercicio4();
            //ejercicio5();
            //ejercicio8();
            //ejercicio9();
            //ejercicio10();
            //ejercicio12();
            //ejercicio14();
            //ejercicio15();
            ejercicio16();

            Console.ReadKey();


        }

        public static void ejercicio1()
        {
            //EJERCICIO 1
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;
                IQueryable<string> productNames = from p in products
                                                  select p.Name;
                Console.WriteLine("Productos");
                foreach (var productName in productNames)
                {
                    Console.WriteLine(productName);
                }               
            }
        }

        public static void ejercicio2()
        {
            //EJERCICIO 2
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;
                IQueryable<string> productNames = products.Select(p => p.Name);

                Console.WriteLine("Productos");
                foreach (var productName in productNames)
                {
                    Console.WriteLine(productName);
                }                
            }
        }
        public static void ejercicio3()
        {
            //EJERCICIO 3
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;
                IQueryable<Product> productsQuery = from p in products
                                                   select p;
                IQueryable<Product> largeProducts = productsQuery.Where(p => p.Size == "L");

                Console.WriteLine("Productos de tamaño L :");
                foreach (var product in largeProducts)
                {
                    Console.WriteLine(product.Name);
                }
            }
        }

        public static void ejercicio4()
        {
            //EJERCICIO 4
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
               
                IQueryable<Product> productsQuery = from product in context.Product
                                                    select product;
                                
                Console.WriteLine("Productos:");
                foreach (var prod in productsQuery)
                {
                    Console.WriteLine(prod.Name);
                }
            }
        }
        public static void ejercicio5()
        {
            //EJERCICIO 5
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from product in context.Product
                            select new
                            {
                                ProductId = product.ProductID,
                                ProductName = product.Name
                            };

                Console.WriteLine("Informacion  de productos:");
                foreach (var productInfo in query)
                {
                    Console.WriteLine("Product Id: {0} Product name: {1}",
                        productInfo.ProductId,productInfo.ProductName);
                }
            }
        }

        public static void ejercicio8()
        {
            //EJERCICIO 8
            int orderQtyMin = 2;
            int orderQtyMax = 6;

            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from order in context.SalesOrderDetail
                            where order.OrderQty > orderQtyMin
                            && order.OrderQty < orderQtyMax
                            select new
                            {
                                SalesOrderID = order.SalesOrderID,
                                OrderQty = order.OrderQty
                            };
                               
                foreach (var order in query)
                {
                    Console.WriteLine("Order ID: {0} Order quantity: {1}",
                        order.SalesOrderID, order.OrderQty);
                }
            }
        }

        public static void ejercicio9()
        {
            //EJERCICIO 9
            String color = "Red";
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var query = from product in context.Product
                            where product.Color == color
                            select new
                            {
                                Name = product.Name,
                                ProductNumber = product.ProductNumber,
                                ListPrice = product.ListPrice
                            };

                foreach (var product in query)
                {
                    Console.WriteLine("Name: {0}",product.Name);
                    Console.WriteLine("Product number: {0}", product.ProductNumber);
                    Console.WriteLine("List price: ${0}", product.ListPrice);
                    Console.WriteLine("");
                }
            }
        }

        public static void ejercicio10()
        {
            //EJERCICIO 10
            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                int?[] productModelIds = { 19, 26, 118 };
                var products = from p in AWEntities.Product
                               where productModelIds.Contains(p.ProductModelID)
                               select p;

                foreach (var product in products)
                {
                    Console.WriteLine("{0}: {1}", product.ProductModelID,product.ProductID);
                }
            }
        }

        public static void ejercicio12()
        {
            //EJERCICIO 12
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                IQueryable<Decimal> sortedPrices = from p in context.Product
                                                   orderby p.ListPrice descending
                                                   select p.ListPrice;

                Console.WriteLine("Lista de precios desde el más alto al más bajo:");
                
                foreach (Decimal price in sortedPrices)
                {
                    Console.WriteLine(price);
                }
            }
        }

        public static void ejercicio14()
        {
            //EJERCICIO 14
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var products = context.Product;
                var query = from product in products
                            group product by product.Style into g
                            select new
                            {
                                Style = g.Key,
                                AverageListPrice = g.Average(product => product.ListPrice)
                            };
                              
                foreach (var product in query)
                {
                    Console.WriteLine("Estilo: {0} Precio promedio: {1}", product.Style, product.AverageListPrice);
                }
            }
        }

        public static void ejercicio15()
        {
            //EJERCICIO 15
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var products = context.Product;
                var query = from product in products
                            group product by product.Color into g
                            select new
                            {
                                Color = g.Key,
                                ProductCount = g.Count()
                            };

                foreach (var product in query)
                {
                    Console.WriteLine("Color: {0} \t Cantidad = {1}", product.Color, product.ProductCount);
                }
            }
        }

        public static void ejercicio16()
        {
            //EJERCICIO 16
            using (AdventureWorksEntities context = new AdventureWorksEntities())
            {
                var orders = context.SalesOrderHeader;
                var query = from order in orders
                            group order by order.SalesPersonID into g
                            select new
                            {
                                Category = g.Key,
                                maxTotalDue = g.Max(order => order.TotalDue)
                            };

                foreach (var order in query)
                {
                    Console.WriteLine("PersonID: {0} TotalDue Máximo : {1}", order.Category, order.maxTotalDue);
                }
            }
        }
    }
}
