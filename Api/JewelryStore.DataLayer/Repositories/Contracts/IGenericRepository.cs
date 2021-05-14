using JewelryStore.DataLayer.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ContactManagement.DataLayer
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetQueryable(Expression<Func<T, bool>>
            filter = null, string includeProperties = null);

        //T GetById(Guid id, string includeProperties);

        //List<T> List(string includeProperties);

        //List<T> List(Expression<Func<T, bool>> predicate);

        //Guid Add(T entity);

        //void Delete(T entity);

        //void Update(T entity);

        //void Save();
    }
}
