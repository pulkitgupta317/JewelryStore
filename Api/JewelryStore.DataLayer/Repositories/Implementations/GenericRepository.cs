using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using JewelryStore.DataLayer.Models.Base;
using JewelryStore.DataLayer;

namespace ContactManagement.DataLayer
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity
    {
        protected readonly JewelryStoreDbContext _context;
        protected readonly DbSet<T> _entity;

        public GenericRepository(JewelryStoreDbContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
        }

        public IQueryable<T> GetQueryable(Expression<Func<T, bool>>
            filter = null, string includeProperties = null)
        {
            includeProperties = includeProperties == null ? string.Empty : includeProperties;
            IQueryable<T> query = _entity;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        //public Guid Add(T entity)
        //{
        //    _entity.Add(entity);
        //    return entity.Id;
        //}

        //public void Delete(T entity)
        //{
        //    _entity.Remove(entity);
        //}

        //public T GetById(Guid id, string includeProperties)
        //{
        //    return GetQueryable(x => x.Id == id, includeProperties: includeProperties).FirstOrDefault();
        //}

        //public List<T> List(string includeProperties)
        //{
        //    return GetQueryable(null, includeProperties: includeProperties).ToList();
        //}

        //public List<T> List(Expression<Func<T, bool>> predicate)
        //{
        //    return _entity.Where(predicate).ToList();
        //}

        //public void Update(T entity)
        //{
        //    _entity.Update(entity);
        //}

        //public void Save()
        //{
        //    try
        //    {
        //         _context.SaveChanges();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
