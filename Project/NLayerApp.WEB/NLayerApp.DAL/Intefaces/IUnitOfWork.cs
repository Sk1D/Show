using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL.Intefaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Store> Stores { get; }
        IRepository<Item> Items { get; }
        void Save();
    }
}
