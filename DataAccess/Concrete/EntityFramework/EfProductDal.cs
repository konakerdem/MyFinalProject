using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //c# a özel bir yapı IDisposable pattern implementation of c#
            using (NorthwindContext contex = new NorthwindContext())
            {
                var adddedEntity = contex.Entry(entity); //eklenecek nesnenin referansını yakala
                adddedEntity.State = EntityState.Added; //ekleme işlemi yap
                contex.SaveChanges(); //değişiklikleri kaydet
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext contex = new NorthwindContext())
            {
                var deletedEntity = contex.Entry(entity); //silinecek nesnenin referansını yakala
                deletedEntity.State = EntityState.Deleted; //silme işlemi yap
                contex.SaveChanges(); //değişiklikleri kaydet
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //
                return context.Set<Product>().SingleOrDefault(filter); //filtreye göre "TEK" bir nesne getir
            }
        }
        

        //filtre koyup koymama seçeneği yapmıştık
        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter==null ? context.Set<Product>().ToList() //filtre yoksa tümünü listele
                    : context.Set<Product>().Where(filter).ToList(); //filtre varsa filtreye göre listele

            }
        }

        public void Update(Product entity)
        {
            {
                using (NorthwindContext contex = new NorthwindContext())
                {
                    var updatedEntity = contex.Entry(entity); //güncellenecek nesnenin referansını yakala
                    updatedEntity.State = EntityState.Modified; //güncelleme işlemi yap
                    contex.SaveChanges(); //değişiklikleri kaydet
                }

            }
        }
    }
}
