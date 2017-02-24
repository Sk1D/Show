using NLayerApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.DAL
{
    public class StoreContext : DbContext
    {
        public DbSet<Store> Stores { get; set; }
        public DbSet<Item> Items { get; set; }
      //  public StoreContext(string connectionString="MobileContext") : base(connectionString)
        public StoreContext():base("DefaultConnection")
        { }
        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(new StoreDbInitializer());
        }

    }

    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext db)
        {
            var stores = new List<Store>
            {
                new Store { Id=1,
                    Name ="Атлант",
                    Address ="г. Минск, Пушкина просп., 14 ",
                    OpenningTimes ="пн-вс 10.00-20.00",
                    Items =new List<Item> { new Item { Id = 1, Name = "Холодильник Samsung RB37J5000B1", Description = "полный No Frost, электронное управление, класс A+, полезный объём: 367 л (269 + 98 л), инверторный компрессор, зона свежести, 59.5x67.5x201 см, черный" } }
                },
               new Store { Id=2,
                    Name ="Горизонт",
                    Address ="г. Минск, Куйбышева ул., 22 ",
                    OpenningTimes ="пн-пт 10.00-19.00",
                    Items =new List<Item> { new Item { Id = 2, Name = "Horizont 55LE7161D", Description = "1920x1080 (Full HD), матрица IPS, частота 50 Гц, Smart TV (Android), Wi-Fi" } }
                },
               new Store { Id=3,
                    Name ="Домотехника",
                    Address ="г. Минск, Дзержинского просп., 69/2-417",
                    OpenningTimes ="пн-пт 9.00-20.00, сб, вс 10.00-18.00",
                    Items =new List<Item> { new Item { Id = 3, Name = "Canon EOS 700D Kit 18-55 IS STM", Description = "зеркальная камера, матрица APS-C (1.6 crop) 18 Мп, с объективом F3.5-5.6 18-55 мм" }, new Item { Id = 4, Name = "Sony Alpha a6000 Kit 16-50mm (ILCE-6000L)", Description = "беззеркальная камера, матрица APS-C (1.5 crop) 24.3 Мп, с объективом F3.5-5.6 16-50 мм, Wi-Fi" }, new Item { Id = 5, Name = "Nikon Coolpix L340", Description = "компакт-камера, матрица 1/2.3 20.2 Мп, объектив 28X F3.1-5.9 22.5-630 мм" } }
                },
               new Store { Id=4,
                    Name ="Техно Плюс",
                    Address ="г. Минск, Монтажников ул., 2",
                    OpenningTimes ="пн-вс 10.00-21.00",
                    Items =new List<Item> { new Item { Id = 6, Name = "Samsung UE60KS7000U", Description = "Производитель: Samsung Electronics Co., Ltd. Мэтан-донг 129, Самсунг-ро, Енгтонг-гу, Suwon-si, Gyeonggi-do, 443-742, Korea г. Сувон, Кёнги-до, 443-742, Республика Корея" }, new Item { Id = 7, Name = "Стиральная машина LG F1096ND3", Description = "автоматическая стиральная машина, загрузка до 6 кг, отжим 1000 об/мин, глубина 44 см, энергопотребление A, прямой привод, 13 программ" }, new Item { Id = 8, Name = "Стиральная машина Bosch WLG2426WOE", Description = "автоматическая стиральная машина, загрузка до 5 кг, отжим 1200 об/мин, глубина 40 см, энергопотребление A, защита от протечек, 15 программ" } }
                },
                new Store { Id=5,
                    Name ="AppleStore",
                    Address ="Купертино, Калифорния, США",
                    OpenningTimes ="пн-вс 10.00-20.00",
                    Items =new List<Item>()

                    },
            };
            stores.ForEach(x => db.Stores.AddOrUpdate(x));
            db.SaveChanges();
        }
    }
}
