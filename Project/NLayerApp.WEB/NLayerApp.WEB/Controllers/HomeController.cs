
using AutoMapper;
using NLayerApp.BL;
using NLayerApp.BL.DTO;
using NLayerApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLayerApp.BL.Filters;


namespace NLayerApp.WEB.Controllers
{
    [Culture]
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
            if (!ModelState.IsValid)
            {
                return View(item);
            }
            else
            {
                try
                {
                    Mapper.Initialize(cfg => cfg.CreateMap<ItemViewModel, ItemDTO>());
                    var itemDto = Mapper.Map<ItemViewModel, ItemDTO>(item);
                    serv.addItem(itemDto);

                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    throw new Exception("Error data automapper", e);
                }
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
        public ActionResult ChangeCulture(string lang)
        {
            string returnUrl = Request.UrlReferrer.AbsolutePath;
            List<string> culture = new List<string> { "ru", "en", "de" };
            if (!culture.Contains(lang))
            {
                lang = "ru";
            }
            HttpCookie cookie = Request.Cookies["Language"];
            if (cookie == null)
            {
                HttpCookie aCookie = new HttpCookie("Language");
                aCookie.Values["lang"] = lang;
                aCookie.HttpOnly = false;
                aCookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(aCookie);
            }
            else
            {
                cookie.Values["lang"] = lang;
                Response.Cookies.Add(cookie);
            }

            return Redirect(returnUrl);
        }
    }
}