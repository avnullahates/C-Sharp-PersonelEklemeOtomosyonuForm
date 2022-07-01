using System;
using System.Collections.Generic;

using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_PersonEklemeOtomosyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region Form Load


        private void Form1_Load(object sender, EventArgs e)
        {
            cmbUnvan.Items.AddRange(Enum.GetNames(typeof(Unvan)));
        }
        #endregion

        #region Personel Ekleme


        private void btnEkle_Click(object sender, EventArgs e)
        {
            Personel p = new Personel();
            p = PersonelDoldur(p);

            ListViewItem lvi = ListViewDoldur(p); // Bir listView satiri olusturur.
            lstPersoneller.Items.Add(lvi); // Olusturulan satiri (item i) lslPersoneller e ekler
            Metot.Temizle(this.Controls); // bu formun control lerini ilgili metoda gonder. 
        }
        #endregion

        #region ListViewItem Dodura Metod

        private ListViewItem ListViewDoldur(Personel p)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = p.TCKN;
            lvi.SubItems.Add(p.Ad);
            lvi.SubItems.Add(p.Soyad);
            lvi.SubItems.Add(p.DogumTarihi.ToShortDateString());
            lvi.SubItems.Add(p.Email);
            lvi.SubItems.Add(p.IseGirisTarihi.ToShortDateString());
            lvi.SubItems.Add(p.Unvan.ToString());

            lvi.Tag = p;
            return lvi;

        }

        #endregion

        #region Personel Ekleme Metodu


        private Personel PersonelDoldur(Personel p)
        {
            p.Ad = txtAd.Text;
            p.Soyad = txtSoyad.Text;
            p.TCKN = txtTcNo.Text;
            p.TelNo = txtTelNo.Text;
            p.DogumTarihi = dtpDogumTarihi.Value;
            p.Unvan = cmbUnvan.Text == "" ? Unvan.Belirtilmedi : (Unvan)Enum.Parse(typeof(Unvan), cmbUnvan.Text);
            p.IseGirisTarihi = dtpIseGirisTarihi.Value;
            p.Email = txtEmail.Text;
            p.Adres = txtAdres.Text;

            if (pbResim.Tag != null)
            {
                //E39CB88F-C995-4EE6-8EB5-A3002FEB7CE1 ornek Guid
                //pbResim in Tag property sinde dosya uzantisini tutacaz. + oparatoru ile yeni bir Guid isim ve dosya uzantisini birlestirmis olduk. 
                p.PersonelResmi = Guid.NewGuid() + pbResim.Tag.ToString();


                //bin/debug icerisinde Images diye bir klasor acalim. Orada tutalim. Klasoru manuel olarak acalim
                //pbResim.Image.Save(Environment.CurrentDirectory);
                //pplication.StartupPath ve ya Environment.CurrentDirectory ile bin/debug a gidebiliriz.
                pbResim.Image.Save(Application.StartupPath + "/Images/" + p.PersonelResmi);//Tam olarak dosya yolu belrtildi. Dizin + DosyaAdi.DosyaUzantisi

            }

            return p;
        }
        #endregion

        #region Resim Secme


        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Personel Resmi(png,jpg, gif)| *.png;*.jpg;*.gif";
            DialogResult dr = ofd.ShowDialog();

            if (dr == DialogResult.OK)
            {
                pbResim.Image = Image.FromFile(ofd.FileName); // Rresim dosyasini pictureBox in Image propert sine ekledik.
                pbResim.Tag = Path.GetExtension(ofd.FileName); // GetExtension metodu, dosya secildiginde dosyanin uzantisini alir. (Noktadan sonrak kismini alir)


            }
        }

        #endregion

        #region Silme Isleme


        private void btnSil_Click(object sender, EventArgs e)
        {
            lstPersoneller.Items.RemoveAt(lstPersoneller.SelectedItems[0].Index);



        }


        #endregion

        #region Gucelleme Islemi

        Personel guncellenecek;
        int indexNo;
        private void lstPersoneller_DoubleClick(object sender, EventArgs e)
        {
            indexNo = lstPersoneller.SelectedItems[0].Index; // Secilen Personelin listView daki ondex i (Sirasi)
            guncellenecek = (Personel)lstPersoneller.SelectedItems[0].Tag;


            txtAd.Text = guncellenecek.Ad;
            txtAdres.Text = guncellenecek.Adres;
            txtSoyad.Text = guncellenecek.Soyad;
            txtTcNo.Text = guncellenecek.TCKN;
            txtTelNo.Text = guncellenecek.TelNo;
            txtEmail.Text = guncellenecek.Email;

            dtpDogumTarihi.Value = guncellenecek.DogumTarihi;
            dtpIseGirisTarihi.Value = guncellenecek.IseGirisTarihi;
            cmbUnvan.Text = guncellenecek.Unvan.ToString();

            if (!string.IsNullOrWhiteSpace(guncellenecek.PersonelResmi))
            {
                pbResim.Image = Image.FromFile("Images/" + guncellenecek.PersonelResmi);
                pbResim.Tag = Path.GetExtension(guncellenecek.PersonelResmi);
            }

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncellenecek = PersonelDoldur(guncellenecek); //Guncellenecek personel ilgili meott araciligyla yeni bir personel nesnesi olarak olusturuldu. Ve guncellencek icerisine atildi.
            lstPersoneller.Items.RemoveAt(indexNo); //Belirtilmis idexteki elemani siler
            lstPersoneller.Items.Insert(indexNo, ListViewDoldur(guncellenecek));// Belirttigimiz index eleman ekler. Sonrakileri bir sonraki index e dogru kaydirir.
            Metot.Temizle(this.Controls);
        }
        #endregion


    }
}
