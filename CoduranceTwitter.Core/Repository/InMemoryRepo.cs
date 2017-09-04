using System;
using System.Collections.Generic;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Repository {
    
    public class InMemoryRepo<T> : IRepository<T> where T : IEntity {
        
        public InMemoryRepo() {
        }

        public IEnumerable<T> Entities => throw new NotImplementedException();

        public void Add(T entity) {
            throw new NotImplementedException();
        }

        public void Delete(T entity) {
            throw new NotImplementedException();
        }

        public void Save(T entity) {
            throw new NotImplementedException();
        }
    }
}
