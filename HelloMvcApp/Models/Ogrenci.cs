﻿namespace HelloMvcApp.Models
{
    public class Ogrenci
    {
        public static int sayac = 0;
        public Ogrenci()
        {
            sayac++ ;
        }
        public int Ogrenciid { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Numara { get; set; }

    }
}
