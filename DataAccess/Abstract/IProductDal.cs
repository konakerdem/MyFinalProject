using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    
    public interface IProductDal:IEntityRepository<Product>
    {


    }
}

//önce ınterface olıuşturulur. sonra ınterface implement eden class olusturulur.
#region Generic Öncesi
/*
//interface metotları default olarak publictir. Bu yüzden access modifier yazmaya gerek yoktur.
List<Product> GetAll();
void Add(Product product);
void Update(Product product);
void Delete(Product product);
List<Product> GetAllByCategory(int categoryId);

*/
#endregion