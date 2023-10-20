using AltYapi.AraBirimler;
using AltYapi.Enumlar;
using AltYapi.S�n�flar;
using System.ComponentModel;

namespace WFABankaProjesi
{
    // BingingList :BindingList, genellikle DataGridView gibi veri ba�lama denetimleri ile kullan�l�r
    // ve bu denetimlerle birlikte �al���rken verileri dinamik olarak g�ncellemeyi kolayla�t�r�r.
    public partial class Form1 : Form
    {
        Banka banka = new Banka();
        List<IMusteri> musteriler = new List<IMusteri>();
        public Form1()
        {
            InitializeComponent();
            cmbMusteriler.Items.Add("M��teri T�r� Se�iniz");
            cmbMusteriler.Items.AddRange(Enum.GetNames(typeof(MusteriTipi)));
            cmbMusteriler.SelectedIndex = 0;

            cmb�statistikT�r�.Items.Add("�stati�i Se�iniz");
            cmb�statistikT�r�.Items.Add("T�m M��terilerin �statistikleri");
            cmb�statistikT�r�.Items.Add("��leme Al�nan M��terilerin �statistikleri");
            cmb�statistikT�r�.SelectedIndex = 0;

            banka.Musteriler = new BindingList<IMusteri>();
            banka.Numerator = new Numerator();
            banka.Numerator.BekleyenMusteriler = new BindingList<IMusteri>();
        }

        private void cmbMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMusteriler.Items[0] == "M��teri T�r� Se�iniz" && cmbMusteriler.SelectedIndex != 0)
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
                MessageBox.Show("T.C Bo� olamaz!");
                return;
            }

            if (txtMusteriTCKimlikNo.Text.Trim().Length == 11 && txtMusteriTCKimlikNo.Text[0] != 0 && txtMusteriTCKimlikNo.Text[(txtMusteriTCKimlikNo.Text.Length-1)] % 2 ==0)
            {
                long sonuc;
                if (!long.TryParse(txtMusteriTCKimlikNo.Text, out sonuc))
                {
                    MessageBox.Show("T.C'de L�tfen sadece Rakam Kullan�n�z.");
                    return;
                }

                if (banka.Musteriler.Any(m => m.TCKimlikNumarasi == sonuc.ToString()))
                {
                    MessageBox.Show("Yazd���n�z TC Kimlik Numaras� Bulunmaktad�r.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("TC Kimlik Numar� 11 Haneli Olmal� ve 0 ile ba�lamamal�d�r.Girdi�iniz Veri Bir TC Kimlik Numaras� de�ildir");
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
            return "Bankadaki VIP M��teri Say�s�: " + vipMusteriSayisi + "\n" + "Bankadaki Bireysel M��teri Say�s�: "
                + bireyselMusteriSayisi + "\n" + "Bankadaki Gise M��teri Say�s�: " + giseMusteriSayisi;
        }
        private string IslemiBitenleriGetir()
        {
            int islemiBitenVipMusteriSayisi = banka.Musteriler.Count(m => m.MusteriTuru == MusteriTipi.Vip && m.IslemTammalandiMi);
            int islemiBitenBireyselMusteriSayisi = banka.Musteriler.Count(m => m.MusteriTuru == MusteriTipi.Bireysel && m.IslemTammalandiMi);
            int islemiBitengiseMusteriSayisi = banka.Musteriler.Count(m => m.MusteriTuru == MusteriTipi.Gise && m.IslemTammalandiMi);
            return "Bankadaki VIP M��teri Say�s�: " + islemiBitenVipMusteriSayisi + "\n" + "Bankadaki Bireysel M��teri Say�s�: "
                + islemiBitenBireyselMusteriSayisi + "\n" + "Bankadaki Gise M��teri Say�s�: " + islemiBitengiseMusteriSayisi;
        }

        private void cmb�statistikT�r�_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmb�statistikT�r�.SelectedItem == "T�m M��terilerin �statistikleri")
                lblTumIstatislik.Text = ButunMusteriIstatislikleriGetir();
            else if (cmb�statistikT�r�.SelectedItem == "��leme Al�nan M��terilerin �statistikleri")
                lblTumIstatislik.Text = IslemiBitenleriGetir();
        }
    }
}








