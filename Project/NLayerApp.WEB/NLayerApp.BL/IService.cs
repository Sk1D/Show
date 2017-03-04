using NLayerApp.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BL
{
    public interface IService
    {
        void addItem(ItemDTO itemDto);
        StoreDTO GetStore(int? id);
        IEnumerable<StoreDTO> GetStores();
        IEnumerable<ItemDTO> GetItems(int? store_id);
        void Dispose();
    }
}
