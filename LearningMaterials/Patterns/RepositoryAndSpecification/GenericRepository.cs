using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LearningMaterials.Patterns.Repository
{
    /// <summary>
    /// Generic repository provide all base needed methods (CRUD)
    /// Унифицированный интерфейс который скрывает доступ к контексту и DbSet'y
    /// Generic позволяет уйти от дублирования кода при доступе к разным таблицам
    /// 
    /// Если вы пишите что-то больше чем просто CRUD операции, то каждый из бизнес-объектов будет обладать своим списком доступного функционала. Например метод удаления объекта, или добавления, может быть недоступен для этого типа объектов, при реализации через GenericRepository мы даем доступ всех Crud операций для этого типа объектов.
    /// </summary>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Persists all updates to the data source
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Persists all updates to the data source async
        /// </summary>
        Task SaveChangesAsync();

        /// <summary>
        /// Get first entity by predicate 
        /// </summary>
        /// <param name="predicate">LINQ predicate</param>
        /// <returns>T entity</returns>
        T First(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get first entity by predicate 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>T entity</returns>
        T FirstOrDefault(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get first entity
        /// </summary>
        /// <returns>T entity</returns>
        T FirstOrDefault();

        /// <summary>
        /// Get first entity async
        /// </summary>
        /// <returns>T entity</returns>
        Task<T> FirstOrDefaultAsync();

        /// <summary>
        /// Get all queries
        /// </summary>
        /// <returns>IQueryable queries</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Find queries by predicate (where logic)
        /// </summary>
        /// <param name="predicate">Search predicate (LINQ)</param>
        /// <returns>IQueryable queries</returns>
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find queries by predicate
        /// </summary>
        /// <param name="predicate">Search predicate (LINQ)</param>
        /// <returns>IQueryable queries</returns>
        bool Any(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find entity by keys
        /// </summary>
        /// <param name="keys">Search key</param>
        /// <returns>T entity</returns>
        T Find(params object[] keys);

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Add(T entity);

        /// <summary>
        /// Add new entities
        /// </summary>
        /// <param name="entities">Entity collection</param>
        void AddRange(IEnumerable<T> entities);

        /// <summary>
        /// Remove entity from database
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Delete(T entity);

        /// <summary>
        /// Remove entities from database
        /// </summary>
        /// <param name="entity">Entity object</param>
        void DeleteRange(IEnumerable<T> entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        void Update(T entity);

        /// <summary>
        /// Order by
        /// </summary>
        IOrderedQueryable<T> OrderBy<K>(Expression<Func<T, K>> predicate);

        /// <summary>
        /// Order by
        /// </summary>
        IQueryable<IGrouping<K, T>> GroupBy<K>(Expression<Func<T, K>> predicate);

        /// <summary>
        /// Remove range of given entities
        /// </summary>
        void RemoveRange(IEnumerable<T> entities);
    }
    /// <summary>
    /// Generic repository provide all base needed methods (CRUD)
    /// </summary>
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;
        private readonly DbContext _context;
        /// <summary>
        /// Ctor with DI
        /// </summary>
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Get first entity by predicate 
        /// </summary>
        /// <param name="predicate">LINQ predicate</param>
        /// <returns>T entity</returns>     
        public virtual T First(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.First(predicate);
        }

        /// <summary>
        /// Get first entity by predicate 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns>T entity</returns>
        public virtual T FirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        /// <summary>
        /// Get first entity
        /// </summary>
        /// <returns>T entity</returns>
        public T FirstOrDefault()
        {
            return _dbSet.FirstOrDefault();
        }

        /// <summary>
        /// Get all queries
        /// </summary>
        /// <returns>IQueryable queries</returns>
        public virtual IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        /// <summary>
        /// Find queries by predicate (where logic)
        /// </summary>
        /// <param name="predicate">Search predicate (LINQ)</param>
        /// <returns>IQueryable queries</returns>
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }

        /// <summary>
        /// Find entity by keys
        /// </summary>
        /// <param name="keys">Search key</param>
        /// <returns>T entity</returns>
        public virtual T Find(params object[] keys)
        {
            return _dbSet.Find(keys);
        }

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        /// <summary>
        /// Add new entitities
        /// </summary>
        /// <param name="entities">Entity collection</param>
        public virtual void AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
        }

        /// <summary>
        /// Remove entity from database
        /// </summary>
        /// <param name="entity">Entity object</param>
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        /// <summary>
        /// Remove entities from database
        /// </summary>
        /// <param name="entity">Entity object</param>
        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity object</param>
        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Persists all updates to the data source
        /// </summary>
        public virtual void SaveChanges()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Persists all updates to the data source async
        /// </summary>
        public virtual Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get first entity async
        /// </summary>
        /// <returns>T entity</returns>
        public Task<T> FirstOrDefaultAsync()
        {
            return _dbSet.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Order by
        /// </summary>
        public IOrderedQueryable<T> OrderBy<K>(Expression<Func<T, K>> predicate)
        {
            return _dbSet.OrderBy(predicate);
        }

        /// <summary>
        /// Order by
        /// </summary>
        public IQueryable<IGrouping<K, T>> GroupBy<K>(Expression<Func<T, K>> predicate)
        {
            return _dbSet.GroupBy(predicate);
        }

        /// <summary>
        /// Remove range of given entities
        /// </summary>
        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }
}
