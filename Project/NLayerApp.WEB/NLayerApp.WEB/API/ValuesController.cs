using AutoMapper;
using NLayerApp.BL;
using NLayerApp.BL.DTO;
using NLayerApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NLayerApp.WEB.API
{
    public class ValuesController : ApiController
    {
        private IService service;
        public ValuesController(IService service)
        {
            this.service = service;
        }
        // GET: api/Values
        public IEnumerable<StoreDTO> Get()
        {
            IEnumerable<StoreDTO> values = service.GetStores();
            return values;
        }

        // GET: api/Values/5
        public List<ItemViewModel> Get(int id)
        {
            IEnumerable<ItemDTO> model = service.GetItems(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ItemDTO, ItemViewModel>());
            var items =
                Mapper.Map<IEnumerable<ItemDTO>, List<ItemViewModel>>(model);
            return items;
        }

        // POST: api/Values
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Values/5
        public int Delete(int id)
        {
            int store_id = service.GetStoreId(id);
            service.delItem(id);
            return store_id;          
        }
    }
}
