using System;
using System.Collections.Generic;
using System.Text;

namespace CookingPapa.Domain.RepositoryInterfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();
    }
}
