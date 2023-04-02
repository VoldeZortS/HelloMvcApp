using HelloMvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Security.Cryptography.X509Certificates;

namespace HelloMvcApp.Controllers
{
    public class OgrenciController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult Mindex(int id)
        {
            var ogr = new Ogrenci();
            if (id == 1)
            {
                ogr.Ad = "Ali";
                ogr.Soyad = "Veli";
                ogr.Numara = 444;

            }
            else if (id == 2)
            {
                ogr.Ad = "Ahmet";
                ogr.Soyad = "Mehmet";
                ogr.Numara = 222;
            }
            else
            {
                ogr = null;
            }
            //ViewData["ogrenci"] = ogr;
            //ViewBag.Student = ogr;
            var ogretmen = new Ogretmen();
            ogretmen.Ad = "Ahmet";
            ogretmen.Soyad = "Mehmet";
            ogretmen.Tckimlik = "12345678910";

            //ViewBag.Ogretmen= ogretmen;
            var info = new InfoDTO(ogr, ogretmen);
            return View(info);

        }
        public ViewResult OgrenciListe()
        {

            var ogr = new Ogrenci();
            ogr.Ad = "Osman";
            ogr.Soyad = "Gündoğan";
            ogr.Numara = 1453;

            var ogr2 = new Ogrenci { Ad = "Ayşe", Soyad = "Yıldız", Numara = 354 };
            Ogrenci[] ogrenciler = new Ogrenci[Ogrenci.sayac];

            ogrenciler[0] = ogr;
            ogrenciler[1] = ogr2;

            return View(ogrenciler);

        }
    }
}
//ViewData: Collection- Key Value Pair
//Keyler tekil olmalıdır.
//Object tipinde değer taşırlar
//ViewBag arka planda ViewData koleksiyonunu kullanır. ViewData'da kullanılan bir key değeri, ViewBag'de kullanılmamalıdır.
//ViewBAg object tipinde veri taşır ancak ViewData'dan farkı kendisi dynamic'tir. Dynamic yapıların içindeki verilerin tipi, runtime sırasında tespit edilir.