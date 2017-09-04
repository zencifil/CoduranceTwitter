﻿using System;
using System.Collections.Generic;
using CoduranceTwitter.Core.Models;

namespace CoduranceTwitter.Core.Repository {
    public interface IRepository<T> where T : IEntity {
        
        IEnumerable<T> Entities { get; }
        void Add(T entity);
        void Delete(T entity);
        void Save(T entity);
    }
}