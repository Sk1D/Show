using NLayerApp.DAL.Entities;
using NLayerApp.DAL.Intefaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Repositories
{
    public class StoreRepository : IRepository<Store>
    {
        private StoreContext db;
        public StoreRepository(StoreContext context)
        {
            this.db = context;
            var nn = context.Stores.Count();
        }
        public void Create(Store value)
        {
            db.Stores.Add(value);
        }

        public void Delete(int id)
        {
            var value=db.Stores.Find(id);
            if(value!=null)
            {
                db.Stores.Remove(value);
            }
        }

        public IEnumerable<Store> Find(Func<Store, bool> predicate)
        {
            return db.Stores.Where(predicate).ToList();
        }

        public Store Get(int id)
        {
            return db.Stores.Find(id);
        }

        public IEnumerable<Store> GetAll()
        {
            return db.Stores;
        }

        public void Update(Store value)
        {
            db.Entry(value).State = EntityState.Modified;
        }
    }
}
