using AltYapi.AraBirimler;
using AltYapi.Enumlar;
using AltYapi.Sýnýflar;
using System.ComponentModel;

namespace WFABankaProjesi
{
    // BingingList :BindingList, genellikle DataGridView gibi veri baðlama denetimleri ile kullanýlýr
    // ve bu denetimlerle birlikte çalýþýrken verileri dinamik olarak güncellemeyi kolaylaþtýrýr.
    public partial class Form1 : Form
    {
        Banka banka = new Banka();
        List<IMusteri> musteriler = new List<IMusteri>();
        public Form1()
        {
            InitializeComponent();
            cmbMusteriler.Items.Add("Müþteri Türü Seçiniz");
            cmbMusteriler.Items.AddRange(Enum.GetNames(typeof(MusteriTipi)));
            cmbMusteriler.SelectedIndex = 0;

            cmbÝstatistikTürü.Items.Add("Ýstatiði Seçiniz");
            cmbÝstatistikTürü.Items.Add("Tüm Müþterilerin Ýstatistikleri");
            cmbÝstatistikTürü.Items.Add("Ýþleme Alýnan Müþterilerin Ýstatistikleri");
            cmbÝstatistikTürü.SelectedIndex = 0;

            banka.Musteriler = new BindingList<IMusteri>();
            banka.Numerator = new Numerator();
            banka.Numerator.BekleyenMusteriler = new BindingList<IMusteri>();
        }

        private void cmbMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMusteriler.Items[0] == "Müþteri Türü Seçiniz" && cmbMusteriler.SelectedIndex != 0)
            {
                cmbMusteriler.Items.Remove(cmbMusteriler.Items[0]);
                btnEkleVeSirayaGir.Enabled = true;
                btnSiradaki.Enabled = true;
            }
        }

        private void btnEkleVeSirayaGir_Click(object sender, EventArgs e)
        {

            if (txtMusteriTCKimlikNo.Text.Trim() == "")
            {
                MessageBox.Show("T.C Boþ olamaz!");
                return;
            }

            if (txtMusteriTCKimlikNo.Text.Trim().Length == 11 && txtMusteriTCKimlikNo.Text[0] != 0 && txtMusteriTCKimlikNo.Text[(txtMusteriTCKimlikNo.Text.Length-1)] % 2 ==0)
            {
                long sonuc;
                if (!long.TryParse(txtMusteriTCKimlikNo.Text, out sonuc))
                {
                    MessageBox.Show("T.C'de Lütfen sadece Rakam Kullanýnýz.");
                    return;
                }

                if (banka.Musteriler.Any(m => m.TCKimlikNumarasi == sonuc.ToString()))
                {
                    MessageBox.Show("Yazdýðýnýz TC Kimlik Numarasý Bulunmaktadýr.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("TC Kimlik Numarý 11 Haneli Olmalý ve 0 ile baþlamamalýdýr.Girdiðiniz Veri Bir TC Kimlik Numarasý deðildir");
                return;
            }



            Musteri yeniMusteri = new Musteri();
            yeniMusteri.MusteriTuru = (MusteriTipi)Enum.Parse(typeof(MusteriTipi), cmbMusteriler.Text /*.cmbMusteriler.SelectedItem.ToString()*/);
            yeniMusteri.TCKimlikNumarasi = txtMusteriTCKimlikNo.Text;

            banka.Musteriler.Add(yeniMusteri);
            banka.Numerator.BekleyenMusteriler.Add(yeniMusteri);

            yeniMusteri.NumaratoreGit += banka.Numerator.NumaraUret;
            yeniMusteri.SiraNumarasi = yeniMusteri.NumaraAl();

            ListeyiGuncelle(banka.Numerator.BekleyenMusteriler);

        }
        private void ListeyiGuncelle(BindingList<IMusteri> liste)
        {
            dvgBekleyenler.Refresh();
            dvgBekleyenler.DataSource = liste;

            if (dvgBekleyenler.Columns[0].Visible == true)
                dvgBekleyenler.Columns[0].Visible = false;
        }

        private void btnSiradaki_Click(object sender, EventArgs e)
        {
            lblIslem.Text = banka.Numerator.SiradakiniGetir();
        }

        private string ButunMusteriIstatislikleriGetir()
        {
            int vipMusteriSayisi = banka.Musteriler.Count(m => m.MusteriTuru == MusteriTipi.Vip);
            int bireyselMusteriSayisi = banka.Musteriler.Count(m => m.MusteriTuru == MusteriTipi.Bireysel);
            int giseMusteriSayisi = banka.Musteriler.Count(m => m.MusteriTuru == MusteriTipi.Gise);
            return "Bankadaki VIP Müþteri Sayýsý: " + vipMusteriSayisi + "\n" + "Bankadaki Bireysel Müþteri Sayýsý: "
                + bireyselMusteriSayisi + "\n" + "Bankadaki Gise Müþteri Sayýsý: " + giseMusteriSayisi;
        }
        private string IslemiBitenleriGetir()
        {
            int islemiBitenVipMusteriSayisi = banka.Musteriler.Count(m => m.MusteriTuru == MusteriTipi.Vip && m.IslemTammalandiMi);
            int islemiBitenBireyselMusteriSayisi = banka.Musteriler.Count(m => m.MusteriTuru == MusteriTipi.Bireysel && m.IslemTammalandiMi);
            int islemiBitengiseMusteriSayisi = banka.Musteriler.Count(m => m.MusteriTuru == MusteriTipi.Gise && m.IslemTammalandiMi);
            return "Bankadaki VIP Müþteri Sayýsý: " + islemiBitenVipMusteriSayisi + "\n" + "Bankadaki Bireysel Müþteri Sayýsý: "
                + islemiBitenBireyselMusteriSayisi + "\n" + "Bankadaki Gise Müþteri Sayýsý: " + islemiBitengiseMusteriSayisi;
        }

        private void cmbÝstatistikTürü_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbÝstatistikTürü.SelectedItem == "Tüm Müþterilerin Ýstatistikleri")
                lblTumIstatislik.Text = ButunMusteriIstatislikleriGetir();
            else if (cmbÝstatistikTürü.SelectedItem == "Ýþleme Alýnan Müþterilerin Ýstatistikleri")
                lblTumIstatislik.Text = IslemiBitenleriGetir();
        }
    }
}








