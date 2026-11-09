using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{

    //SOLIDİ
    //Open Closed Principle, ef ekledik fakat mevcuttaki business kodlarına dokunmadık

    internal class Program
    {
        static void Main(string[] args)
        {
            //hangi veri yöntemiyle çalışacağımı söyledim,
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GetByUnitPrice(40,100))
            {
                Console.WriteLine(product.ProductName);
            }

        }
    }
}
