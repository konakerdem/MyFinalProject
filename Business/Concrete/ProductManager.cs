using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal; //db katmanına erişmek için interface kullanılır. Interface üzerinden istediğim somuta erişim sağlayabiliriz zaten.


        // sen bana hangi türde bir productdal verirsen onu kullanacağım.  (InMemoryProductDal, EfProductDal gibi)

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal; 

        }


        public List<Product> GetAll()
        {
            //iş kodları
            //yetkisi var mı? gibi kontroller yapılabilir.
            return _productDal.GetAll(); //veri erişim katmanına gidilir ve tüm ürünler listelenir.

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            //hepsine ayrı ayrı get diye dal da yazmadık gettall üzerinden filtrelemiş olduk businessda ayırdık sadece 
            return _productDal.GetAll(p=>p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);

        }
    }
}
