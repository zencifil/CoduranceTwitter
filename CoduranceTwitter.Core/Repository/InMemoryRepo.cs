using System.Collections.Concurrent;
using System.Collections.Generic;

using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Repository {

    public class InMemoryRepo<T> : IRepository<T> where T : IEntity {
        
        ConcurrentBag<T> _entities;

        public InMemoryRepo() {
            _entities = new ConcurrentBag<T>();
        }

        public IReadOnlyCollection<T> Entities => _entities;

        public void Add(T entity) {
            _entities.Add(entity);
        }

        public void Save(T entity) {
            
        }
    }
}
