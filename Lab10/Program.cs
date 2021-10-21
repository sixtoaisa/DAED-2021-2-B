using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {

            //origen de datos
            NorthwndDataContext context = new NorthwndDataContext();

            //consulta general

            /*
            //CONSULTA PARA OBTENER TODOS LOS PRODUCTOS 
            var query = from p in context.Products
                        select p;

            
            //CONSULTA PARA OBTENER PODRUCTOS CON LA CATEGORIA BEVERAGES
            var query = from p in context.Products
                        where p.Categories.CategoryName == "Beverages" 
                        select p ;
            
            //CONSULTA PARA OBTENER LOS PRODUCTOS CON PRECIO MENOR A 20
            var query = from p in context.Products
                        where p.UnitPrice < 20
                        select p;
            

            //CONSULTA PARA OBTENER LOS PRODUCTOS CUYO NOMBRE INCLUYE LA PALABRA QUESO
            var query = from p in context.Products
                        where SqlMethods.Like(p.ProductName, "%Queso%")
                        select p;
            

            //CONSULTA PARA OBTENER LOS PRODUCTOS CUYA PRESENTACION SEA PAQUETES (PKG O PKGS)
            var query = from p in context.Products
                        where SqlMethods.Like(p.QuantityPerUnit, "%pkg%")
                        select p;
            
            //CONSULTA PARA OBTENER LOS PRODUCTOS QUE EMPIEZAN CON LA LETRA A
            var query = from p in context.Products
                        where SqlMethods.Like(p.ProductName, "A%")
                        select p;
           
            
            //CONSULTA PARA OBTENER LOS PRODUCTOS SIN  STOCK
            var query = from p in context.Products
                        where p.UnitsInStock==0
                        select p;
          

            //CONSULTA PARA OBTENER LOS PRODUCTOS DESCONTONUADOS
            var query = from p in context.Products
                        where p.Discontinued == true
                        select p;

            //ejecucion de la consulta
            foreach (var prod in query)
            {
                //Console.WriteLine("ID={0} \t Proce={1} \t Name={2} ", prod.ProductID, prod.UnitPrice, prod.ProductName);
                Console.WriteLine("ID={0} \t Name={1} ", prod.ProductID, prod.ProductName);
            }
                        
            //CONSULTA PARA OBTENER LOS PRODUCTOS CON LA CATEGORIA DAIRY PRODUCTS
            var query = from p in context.Products
                        where p.Categories.CategoryName  == "Dairy Products"
                        select p;

            */

            //CONSULTA PARA OBTENER LOS PRODUCTOS CON PROVEEDORES UBICADOS EN USA
            var query = from p in context.Products
                        where p.Suppliers.Country == "USA"
                        select p;

            //ejecucion de la consulta
            foreach (var prod in query)
            {
                Console.WriteLine("ID={0} \t Name={1} \t Proveedor={2} ", prod.ProductID, prod.ProductName,prod.Suppliers.CompanyName);
            }


           
            Console.ReadKey();



        }

        

        private static void nuevoProducto()
        {
            //origen de datos
            NorthwndDataContext context = new NorthwndDataContext();

            Products p = new Products();
            p.ProductName = "Peruvian Coffe";
            p.SupplierID = 20;
            p.CategoryID = 1;
            p.QuantityPerUnit = "10 pkgs";
            p.UnitPrice = 25;

            //ejecutar
            context.Products.InsertOnSubmit(p);
            context.SubmitChanges();
        }

        private static void modificarProducto()
        {
            //origen de datos
            NorthwndDataContext context = new NorthwndDataContext();

            var product = (from p in context.Products
                           where p.ProductName == "Tofu"
                           select p).FirstOrDefault();

            product.UnitPrice = 100;
            product.UnitsInStock = 15;
            product.Discontinued = true;

            //ejecutar
            context.SubmitChanges();
        }

        private static void eliminarProducto()
        {
            //origen de datos
            NorthwndDataContext context = new NorthwndDataContext();

            var product = (from p in context.Products
                           where p.ProductID == 78
                           select p).FirstOrDefault();


            //ejecutar
            context.Products.DeleteOnSubmit(product);
            context.SubmitChanges();
        }

        private static void nuevaCategoria()
        {
            //origen de datos
            NorthwndDataContext context = new NorthwndDataContext();

            Categories c = new Categories();
            c.CategoryName = "Nueva Categoria";
            c.Description = "Nueva Categoria creada con Linq";
            
            //ejecutar
            context.Categories.InsertOnSubmit(c);
            context.SubmitChanges();
        }

    }
}
