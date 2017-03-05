
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
            Mapper.Initialize(cfg => cfg.CreateMap<StoreDTO, StoreViewModel>());
            var stores =
                Mapper.Map<IEnumerable<StoreDTO>, List<StoreViewModel>>(col);
            return View(stores);
        }
        [HttpGet]
        public JsonResult Find(int? id)
        {
            IEnumerable<ItemDTO> model = serv.GetItems(id);
            Mapper.Initialize(cfg => cfg.CreateMap<ItemDTO, ItemViewModel>());
            var items =
                Mapper.Map<IEnumerable<ItemDTO>, List<ItemViewModel>>(model);
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult DeleteItem(int id)
        {
            int store_id = serv.GetStoreId(id);
            serv.delItem(id);
            return this.Find(store_id);
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

              return  RedirectToAction("Index");
            }
            catch(Exception e)
            {
                throw new Exception("Error data automapper", e);
            }

        }

        public ActionResult IndexItems()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            serv.Dispose();
            base.Dispose(disposing);
        }
    }
}