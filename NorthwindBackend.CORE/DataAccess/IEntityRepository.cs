using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NorthwindBackend.CORE.Entities;

namespace NorthwindBackend.CORE.DataAccess
{
   public interface IEntityRepository<T> where T:class, IEntity, new()
       // new() : gönderdiğin nesne new'lenebilir olmalı. referans olan, Ientity'den implement edilmiş herşey gidebilir.
    {
        T Get(Expression<Func<T, bool>> filter);

       IList<T> GetList(Expression<Func<T, bool>> filter=null); // filtre gönderilmezse tümünü listelesin

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
