
using AutoMapper;
using NLayerApp.BL;
using NLayerApp.BL.DTO;
using NLayerApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayerApp.WEB.Controllers
{
    public class HomeController : Controller
    {
        private IService serv;
        public HomeController(IService service)
        {
            this.serv = service;
        }
        public ActionResult Index()
        {
            IEnumerable<StoreDTO> col = serv.GetStores();
            //Mapper.Initialize(cfg => cfg.CreateMap<StoreDTO, StoreViewModel>()
            //.ForMember(x => x.Id, x => x.MapFrom(m => m.Id))
            //.ForMember(x => x.Name, x => x.MapFrom(m => m.Name))
            //.ForMember(x => x.Address, x => x.MapFrom(m => m.Address))
            //.ForMember(x => x.OpenningTimes, x => x.MapFrom(m => m.OpenningTimes)));
            //var stores = Mapper.Map<IEnumerable<StoreDTO>, List<StoreViewModel>>(serv.GetStores());

            // Настройка AutoMapper
            Mapper.Initialize(cfg => cfg.CreateMap<StoreDTO, StoreViewModel>());
            // сопоставление
            var stores =
                Mapper.Map<IEnumerable<StoreDTO>, List<StoreViewModel>>(col);

            //Mapper.CreateMap<StoreDTO, StoreViewModel>();
            //var stores = Mapper.Map<IEnumerable<StoreDTO>, List<StoreViewModel>>(serv.GetStores());
            return View(stores);
        }
        public ActionResult MakeItem(int? id)
        {
            var model = serv.GetStore(id);
            Mapper.Initialize(cfg => cfg.CreateMap<StoreDTO, ItemViewModel>()
            .ForMember(x=>x.StoreId, opt => opt.MapFrom(src => src.Id))
            .ForMember(x=>x.Name,opt=>opt.Ignore())
            .ForMember(x=>x.Description,opt=>opt.Ignore())
            .ForMember(x => x.Sum, opt => opt.Ignore()));
            var result = Mapper.Map<StoreDTO, ItemViewModel>(model);
            return View(result);

        }
        [HttpPost]
        public ActionResult MakeItem(ItemViewModel item)
        {
            try
            {
                Mapper.Initialize(cfg => cfg.CreateMap<ItemViewModel, ItemDTO>());
                var itemDto = Mapper.Map<ItemViewModel, ItemDTO>(item);
                serv.addItem(itemDto);
                return Content("<h2>Ваш заказ успешно оформлен</h2>");
            }
            catch(Exception e)
            {
                var m = e;
            }

            return View(item);
        }
        protected override void Dispose(bool disposing)
        {
            serv.Dispose();
            base.Dispose(disposing);
        }
    }
}