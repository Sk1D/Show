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
    class ItemRepository : IRepository<Item>
    {
        private StoreContext db;
        public void Create(Item value)
        {
            db.Items.Add(value);
        }

        public void Delete(int id)
        {
            var value=db.Items.Find(id);
            if(value!=null)
            {
                db.Items.Remove(value);
            }
        }

        public IEnumerable<Item> Find(Func<Item, bool> predicate)
        {
            return db.Items.Include(o => o.store).Where(predicate).ToList();
        }

        public Item Get(int id)
        {
            return db.Items.Find(id);
        }

        public IEnumerable<Item> GetAll()
        {
            return db.Items.Include(o=>o.store);
        }

        public void Update(Item value)
        {
            db.Entry(value).State = EntityState.Modified;
        }
    }
}
