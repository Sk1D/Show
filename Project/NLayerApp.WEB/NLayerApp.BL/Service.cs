using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerApp.BL.DTO;
using NLayerApp.DAL.Intefaces;
using NLayerApp.DAL.Entities;
using AutoMapper;

namespace NLayerApp.BL
{
    public class Service : IService
    {
        IUnitOfWork Database { get; set; }
        public Service(IUnitOfWork uow)
        {
            this.Database = uow;
        }
        public void addItem(ItemDTO itemDto)
        {
            // Store store = Database.Stores.Get(itemDto.Id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public StoreDTO GetStore(int? id)
        {
            var store = Database.Stores.Get(id.Value);
            // Настройка AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<Store, StoreDTO>());
            // сопоставление
            var result = Mapper.Map<Store, StoreDTO>(store);
            return result;
        }

        public IEnumerable<StoreDTO> GetStores()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Store, StoreDTO>());
            return Mapper.Map<IEnumerable<Store>, IEnumerable<StoreDTO>>(Database.Stores.GetAll());
        }
    }
}
