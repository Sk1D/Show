using NLayerApp.DAL.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.DAL.Entities;

namespace NLayerApp.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private StoreContext db;
        private ItemRepository itemRepository;
        private StoreRepository storeRepository;
        public EFUnitOfWork(string connectionString)
        {
            this.db = new StoreContext(connectionString);
        }
        public IRepository<Item> Items
        {
            get
            {
                if (itemRepository == null)
                {
                    itemRepository = new ItemRepository(db);

                }
                return itemRepository;
            }
        }

        public IRepository<Store> Stores
        {
            get
            {
                if (storeRepository == null)
                {
                    storeRepository = new StoreRepository(db);
                }
                return storeRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
