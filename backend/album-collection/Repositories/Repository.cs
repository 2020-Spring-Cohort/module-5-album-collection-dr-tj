using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace album_collection.Repositories
{
    public class Repository<T> where T : class
    {
        private MusicApiContext db;
        public Repository(MusicApiContext db) 
        { 
            this.db = db; 
        }

        public int Count() 
        { 
            return db.Set<T>().Count(); 
        }

        public void Create(T entity) 
        { 
            db.Set<T>().Add(entity); 
            db.SaveChanges(); 
        }

        public void Update(T entity) 
        { 
            db.Set<T>().Update(entity); 
            db.SaveChanges(); 
        }

        public T GetById(int id) 
        { 
            return db.Set<T>().Find(id); 
        }

        public void Delete(T entity) 
        { 
            db.Set<T>().Remove(entity); 
            db.SaveChanges(); 
        }       
        
        public void Save()
        {
            db.SaveChanges();
        }
        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }
    }
}
