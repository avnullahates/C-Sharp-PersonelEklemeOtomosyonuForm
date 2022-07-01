using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_PersonEklemeOtomosyonu
{
    public class Personel
    {

        public int ID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TCKN { get; set; }
        public string TelNo { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Email { get; set; }
        public DateTime IseGirisTarihi { get; set; }
        public Unvan Unvan { get; set; }
        public string PersonelResmi { get; set; }
        public string Adres { get; set; }

        public object Tag { get; set; } //Satira eklnene personelin bilgilerinin bir kopyasini ya da herhangi bir bilginin bir kopyasini icerisinde tutacak.
    }
}
