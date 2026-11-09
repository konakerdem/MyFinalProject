using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //generic bir interface yaptık



    //Generic constraint
    //class: referans tip
    //IEntity:IEntity olabilir veya IEntity den implemente edilmiş bir nesne olabilir demek istiyoruz.
    //new(): new'lenebilir olmalı demek istiyoruz.Interface göndereme oraya IEntity gönderemezsin çünkü interface new'lenemez. IEntity den implemente edilmiş bir nesne olabilir demek istiyoruz.
    public interface IEntityRepository<T> where T : class,IEntity,new()
    {

        // LINQ ile türlü türlü filreletebilmemiz için buraya bir expression yazıyoruz
        //bu sayede .. olanları getir .. olanları getir vb hepsi için ayrı ayrı metot yazmaya gerek kalmıyor.
        List<T> GetAll(Expression<Func<T, bool>> filter = null); //null demek filtre vermeyedebilirsin demek

        T Get(Expression<Func<T, bool>> filter); //Tek bir data getirmek için, burda filtre vermek zorundayız çünkü tek bir data getireceğiz.
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
