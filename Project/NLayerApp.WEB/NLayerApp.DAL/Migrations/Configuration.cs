namespace NLayerApp.DAL.Migrations
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NLayerApp.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NLayerApp.DAL.StoreContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var stores = new List<Store>
            {
                new Store { Id=1,
                    Name ="������",
                    Address ="�. �����, ������� �����., 14 ",
                    OpenningTimes ="��-�� 10.00-20.00",
                    Items =new List<Item> { new Item { Id = 1, Name = "����������� Samsung RB37J5000B1", Description = "������ No Frost, ����������� ����������, ����� A+, �������� �����: 367 � (269 + 98 �), ����������� ����������, ���� ��������, 59.5x67.5x201 ��, ������" } }
                },
               new Store { Id=2,
                    Name ="��������",
                    Address ="�. �����, ��������� ��., 22 ",
                    OpenningTimes ="��-�� 10.00-19.00",
                    Items =new List<Item> { new Item { Id = 2, Name = "Horizont 55LE7161D", Description = "1920x1080 (Full HD), ������� IPS, ������� 50 ��, Smart TV (Android), Wi-Fi" } }
                },
               new Store { Id=3,
                    Name ="�����������",
                    Address ="�. �����, ������������ �����., 69/2-417",
                    OpenningTimes ="��-�� 9.00-20.00, ��, �� 10.00-18.00",
                    Items =new List<Item> { new Item { Id = 3, Name = "Canon EOS 700D Kit 18-55 IS STM", Description = "���������� ������, ������� APS-C (1.6 crop) 18 ��, � ���������� F3.5-5.6 18-55 ��" }, new Item { Id = 4, Name = "Sony Alpha a6000 Kit 16-50mm (ILCE-6000L)", Description = "������������� ������, ������� APS-C (1.5 crop) 24.3 ��, � ���������� F3.5-5.6 16-50 ��, Wi-Fi" }, new Item { Id = 5, Name = "Nikon Coolpix L340", Description = "�������-������, ������� 1/2.3 20.2 ��, �������� 28X F3.1-5.9 22.5-630 ��" } }
                },
               new Store { Id=4,
                    Name ="����� ����",
                    Address ="�. �����, ����������� ��., 2",
                    OpenningTimes ="��-�� 10.00-21.00",
                    Items =new List<Item> { new Item { Id = 6, Name = "Samsung UE60KS7000U", Description = "�������������: Samsung Electronics Co., Ltd. �����-���� 129, �������-��, �������-��, Suwon-si, Gyeonggi-do, 443-742, Korea �. �����, ʸ���-��, 443-742, ���������� �����" }, new Item { Id = 7, Name = "���������� ������ LG F1096ND3", Description = "�������������� ���������� ������, �������� �� 6 ��, ����� 1000 ��/���, ������� 44 ��, ����������������� A, ������ ������, 13 ��������" }, new Item { Id = 8, Name = "���������� ������ Bosch WLG2426WOE", Description = "�������������� ���������� ������, �������� �� 5 ��, ����� 1200 ��/���, ������� 40 ��, ����������������� A, ������ �� ��������, 15 ��������" } }
                },
                new Store { Id=5,
                    Name ="AppleStore",
                    Address ="���������, ����������, ���",
                    OpenningTimes ="��-�� 10.00-20.00",
                    Items =new List<Item>()

                    },
            };
            stores.ForEach(x => db.Stores.AddOrUpdate(x));
            db.SaveChanges();
        }
    }
}
