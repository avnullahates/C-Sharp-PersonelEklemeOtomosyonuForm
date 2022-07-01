using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _01_PersonEklemeOtomosyonu
{
    public enum Unvan
    {
        //TODO: Combobox ta display name ozelligindeki metinler gorunsun
        [Display(Name = "Mudur")] Mudur,
        [Display(Name = "Yonetici")] Yonetici,
        [Display(Name = "CEO")] CEO,
        [Display(Name = "Temizlik Yoneticisi")] TemizlikYoneticisi,
        [Display(Name = "Danisman")] Danisman,
        [Display(Name = "Musteri Temsilcisi")] MusteriTemsilcisi,
        [Display(Name = "Egitmen")] Egitmen,
        Belirtilmedi
    }
}
