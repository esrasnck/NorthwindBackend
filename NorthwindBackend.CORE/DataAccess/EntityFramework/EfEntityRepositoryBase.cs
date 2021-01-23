using Microsoft.EntityFrameworkCore;
using NorthwindBackend.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBackend.CORE.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())  // unit of work ü implement eder
            {
                // birden çok transaction açmak yerine onu iş katmanında bir kez transaction açılıyor

                var addedEntity = context.Entry(entity);  // gönderilen entity'i entity context'e attach ediyorsunuz. abone ediyoruz.
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())  // unit of work ü implement eder
            {
                // birden çok transaction açmak yerine onu iş katmanında bir kez transaction açılıyor

                var deletedEntity = context.Entry(entity);  // gönderilen entity'i entity context'e attach ediyorsunuz. abone ediyoruz.
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)   // todo: fena patlayacak :)
        {
            using (var context = new TContext())  // disposable = nesnenin hayatını sonlandurmasını garbage collector'a bırakmayıp, kendimiz yapıyoruz.
            {

                return  context.Set<TEntity>().SingleOrDefault(filter);

            }  
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ?  context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }

        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())  // unit of work ü implement eder
            {
                // birden çok transaction açmak yerine onu iş katmanında bir kez transaction açılıyor

                var updatedEntity = context.Entry(entity);  // gönderilen entity'i entity context'e attach ediyorsunuz. abone ediyoruz.
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
