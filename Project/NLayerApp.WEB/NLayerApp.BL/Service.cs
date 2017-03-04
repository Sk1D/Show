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
             Store store = Database.Stores.Get(itemDto.StoreId);
            Item item = new Item
            {
                Name = itemDto.Name,
                Description = itemDto.Description,
                Sum = itemDto.Sum,
                Date = DateTime.Now,
                StoreId = store.Id
            };
            Database.Items.Create(item);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
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
            var result = Mapper.Map<IEnumerable<Store>, IEnumerable<StoreDTO>>(Database.Stores.GetAll());
            return result;
        }

        public IEnumerable<ItemDTO> GetItems(int? store_id)
        {
            var resultItems = Database.Items.Find(x => x.StoreId == store_id);
            Mapper.Initialize(cfg => cfg.CreateMap<Item, ItemDTO>());
            var result = Mapper.Map<IEnumerable<Item>, IEnumerable<ItemDTO>>(resultItems);
            return result;
        }
    }
}
