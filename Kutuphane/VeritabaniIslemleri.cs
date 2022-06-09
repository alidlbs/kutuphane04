using System;
using System.Data;
using System.Data.SqlClient;

namespace kutuphane
{
    class VeritabaniIslemleri    
    {
     
        public SqlConnection baglanti = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|\\KutuphaneOtomasyonu.mdf; Integrated Security = True;");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kullaniciAdi"></param>
        /// <param name="Sifre"></param>
        /// <returns></returns>


        public string[] kullaniciGirisKontrolu(string kullaniciAdi, string Sifre)
        {


            string[] bilgiler = new string[4];
            SqlCommand komut = new SqlCommand("SELECT KullaniciAdi,Yonetici,Uye_No FROM Kullanicilar WHERE KullaniciAdi=\'" + kullaniciAdi + "\' AND Sifre=\'" + Sifre + "\'; ", baglanti);
            baglanti.Open();

            SqlDataReader okuyucu = komut.ExecuteReader();

            if (okuyucu.HasRows)
            {
                okuyucu.Read();
                bilgiler[0] = "1";
                bilgiler[1] = okuyucu.GetString(0);
                bilgiler[2] = okuyucu.GetString(1);
                bilgiler[3] = okuyucu.GetInt32(2).ToString();

            }
            else
            {
                bilgiler[0] = "0";
                bilgiler[1] = "0";
                bilgiler[2] = "0";
                bilgiler[3] = "0";
            }
            baglanti.Close();
            return bilgiler;

        }

        public bool YoneticiUyeEkleme(string Adi, string Soyadi, string Tel, string Adres, string Eposta, string DogumTarihi, string UyelikTarihi, string KullaniciAdi, string Sifre, string Yonetici)
        {
            try
            {
                SqlCommand uyeEklemeKomutu = new SqlCommand("INSERT INTO Uyeler(Adi,Soyadi,Telefon,Adres,Eposta,UyelikTarihi,DogumTarihi)VALUES(\'" + Adi + "\',\'" + Soyadi + "\',\'" + Tel + "\',\'" + Adres + "\',\'" +
                Eposta + "\',\'" + UyelikTarihi + "\',\'" + DogumTarihi + "\');", baglanti);
                SqlCommand uyeNoGetir = new SqlCommand("Select Uye_No FROM Uyeler WHERE Adi=\'" + Adi + "\' AND Soyadi = \'" + Soyadi + "\' AND Telefon=\'" + Tel + "\';", baglanti);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(uyeNoGetir);
                baglanti.Open();
                uyeEklemeKomutu.ExecuteNonQuery();
                da.Fill(dt);
                DataRow dr = dt.Rows[0];
                string Uye_No = dr[0].ToString();
                SqlCommand kullaniciEklemeKomutu = new SqlCommand("INSERT INTO Kullanicilar(KullaniciAdi,Sifre,Uye_No,Yonetici)VALUES(\'" + KullaniciAdi + "\',\'" + Sifre + "\',\'" + Uye_No + "\',\'" + Yonetici + "\');", baglanti);
                kullaniciEklemeKomutu.ExecuteNonQuery();
                baglanti.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable YoneticiComboboxDataTable()
        {
            SqlCommand uyeleriGetir = new SqlCommand("SELECT Uye_No,Adi AS[Üye Adı],Soyadi[SoyAdı],Eposta AS[Üye E-Posta Adresi],Telefon AS[Üye Telefonu],DogumTarihi AS[ÜyeDogumGünü],UyelikTarihi AS[ÜyelikTarihi],Adres AS[Üye Adresi] FROM Uyeler;", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            return dt;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uye_No"></param>
        /// <returns></returns>
        public string[] YoneticiUyeNoyaGoreUyeBilgisi(string uye_No)
        {
            string[] bilgiler = new string[8];
            try
            {
                SqlCommand uyeleriGetir = new SqlCommand("SELECT Uye_No,Adi AS[Üye Adi],Soyadi AS[Soyadi],Eposta AS[Üye E-posta Adresi ]," + "Telefon AS[Üye Telefonu],DogumTarihi AS[Üye Dogum Günü],UyelikTarihi AS[Üyelik Tarihi,Adres AS[Üye Adresi]FROM Uyeler WHERE Uye_No=\'" + uye_No + "\';", baglanti);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
                baglanti.Open();
                da.Fill(dt);
                baglanti.Close();
                DataRow dr = dt.Rows[0];
                bilgiler[0] = dr[0].ToString();
                bilgiler[1] = dr[1].ToString();
                bilgiler[2] = dr[2].ToString();
                bilgiler[3] = dr[3].ToString();
                bilgiler[4] = dr[4].ToString();
                bilgiler[5] = dr[5].ToString();
                bilgiler[6] = dr[6].ToString();
                bilgiler[7] = dr[7].ToString();
            }
            catch
            {
                bilgiler[0] = "-1";
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
            return bilgiler;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Uye_No"></param>
        /// <param name="uye_adi"></param>
        /// <param name="uye_soyadi"></param>
        /// <param name="tel"></param>
        /// <param name="adres"></param>
        /// <param name="eposta"></param>
        /// <param name="dogumTarihi"></param>
        /// <param name="uyelikTarihi"></param>
        /// <returns></returns>
        public bool YoneticiUyeGuncelleme(string Uye_No, string uye_adi, string uye_soyadi, string tel, string adres, string eposta, string dogumTarihi, string uyelikTarihi)
        {
            try
            {
                SqlCommand UyeGuncellemeKomutu = new SqlCommand("UPDATE Uyeler SET Adi=\'" + uye_adi + "\',Soyadi=\'" + uye_soyadi + "\',Telefon=\'" + tel + "\',Adres=\'" + adres + "\',Eposta=\'" + eposta + "\',UyelikTarihi=\'" + uyelikTarihi + "\',DogumTarihi=\'" + dogumTarihi + "\' WHERE Uye_No=\'" + Uye_No + "\';", baglanti);
                baglanti.Open();
                UyeGuncellemeKomutu.ExecuteNonQuery();
                baglanti.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Uye_No"></param>
        /// <returns></returns>
        public bool YoneticiUyeSilme(string Uye_No)
        {
            try
            {
                SqlCommand AlinanKitaplardanSil = new SqlCommand("DELETE FROM AlinanKitaplar WHERE Uye_No=\'" + Uye_No + "\';", baglanti);
                SqlCommand KullaniciyiSil = new SqlCommand("DELETE FROM Kullanicilar WHERE Uye_No=\'" + Uye_No + "\';", baglanti);
                SqlCommand UyeyiSil = new SqlCommand("DELETE FROM Uyeler WHERE Uye_No=\'" + Uye_No + "\';", baglanti);
                baglanti.Open();
                AlinanKitaplardanSil.ExecuteNonQuery();
                KullaniciyiSil.ExecuteNonQuery();
                UyeyiSil.ExecuteNonQuery();
                baglanti.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataTable YoneticiUyeListesi()
        {
            SqlCommand uyeleriGetir = new SqlCommand("SELECT Uye_No,Adi AS[Üye Adi],Soyadi AS[Soyadi],Eposta AS[Üye E-posta Adresi ]," + "Telefon AS[Üye Telefonu],DogumTarihi AS[Üye Dogum Günü],UyelikTarihi AS[Üyelik Tarihi,Adres AS[Üye Adresi]FROM Uyeler;", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            return dt;
        }
        public bool KitapGuncelleme(String Kitap_id, string kitapAdi, string kitapYazari, string kitapYayinEvi, string kitapBasimYili, string kitapSayisi)
        {
            try
            {
                SqlCommand UyeGuncellemeKomutu = new SqlCommand("UPDATE Kitaplar SET KitapAdi=\'" + kitapAdi + "\',KitapYazari=\'" + kitapYazari + "\',KitapYayinEvi=\'" + kitapYayinEvi + "\',KitapBasimYili=\'" + kitapBasimYili + "\',KitapSayisi=\'" + kitapSayisi + "\' WHERE Kitap_id=\'" + Kitap_id + "\';", baglanti);
                baglanti.Open();
                UyeGuncellemeKomutu.ExecuteNonQuery();
                baglanti.Close();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public DataTable KitapComboboxDataTable()
        {
            SqlCommand uyeleriGetir = new SqlCommand("SELECT Kitap_id,KitapAdi AS[KitapAdi],KitapYazari AS [KitapYazari],KitapYayinEvi AS[YayinEvi],KitapBasimYili AS[BasimYili],KitapSayisi  FROM Kitaplar;", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            return dt;
        }
        public string[] KitapaGoreUyeBilgisi(string Kitap_id)
        {
            string[] bilgiler = new string[8];
            try
            {
                SqlCommand uyeleriGetir = new SqlCommand("SELECT Kitap_id,KitapAdi AS[ KitapAdi],KitapYazari AS[YazarAdi],KitapYayinEvi AS[YayinEvi ] ,KitapBasimEvi AS[BasimEvi],KitapSayisi FROM Kitaplar WHERE Kitap_id=\'" + Kitap_id + "\';", baglanti);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
                baglanti.Open();
                da.Fill(dt);
                baglanti.Close();
                DataRow dr = dt.Rows[0];
                bilgiler[0] = dr[0].ToString();
                bilgiler[1] = dr[1].ToString();
                bilgiler[2] = dr[2].ToString();
                bilgiler[3] = dr[3].ToString();
                bilgiler[4] = dr[4].ToString();
                bilgiler[5] = dr[5].ToString();

            }
            catch
            {
                bilgiler[0] = "-1";
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }
            }
            return bilgiler;
        }
        public bool KitapUyeEkleme(string KitapAdi, string KitapYazari, string KitapYayinEvi, string KitapBasimYili, string KitapSayisi)
        {
            try
            {
                SqlCommand KitapeklemeKomutu = new SqlCommand("INSERT INTO Kitaplar(KitapAdi,KitapYazari,KitapYayinEvi,KitapBasimYili,KitapSayisi)VALUES(\'" + KitapAdi + "\',\'" + KitapYazari + "\',\'" + KitapYayinEvi + "\',\'" + KitapBasimYili + "\',\'" +
               KitapSayisi + "\');", baglanti);
                baglanti.Open();
                KitapeklemeKomutu.ExecuteNonQuery();
                baglanti.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Kitap_id"></param>
        /// <returns></returns>
        public bool KitapiUyeSilme(string Kitap_id)
        {
            try
            {
                SqlCommand AlinanKitaplardanSil = new SqlCommand("DELETE FROM Kitaplar WHERE Kitap_id=\'" + Kitap_id + "\';", baglanti);
                SqlCommand KullaniciyiSil = new SqlCommand("DELETE FROM Kullanicilar WHERE Kitap_id=\'" + Kitap_id + "\';", baglanti);
                SqlCommand UyeyiSil = new SqlCommand("DELETE FROM Kitaplar WHERE Kitap_id=\'" + Kitap_id + "\';", baglanti);
                baglanti.Open();
                AlinanKitaplardanSil.ExecuteNonQuery();
                KullaniciyiSil.ExecuteNonQuery();
                UyeyiSil.ExecuteNonQuery();
                baglanti.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
            public DataTable KitapiUyeListesi()
            {
            SqlCommand uyeleriGetir = new SqlCommand("SELECT Kitap_id,KitapAdi AS[ KitapAdi],KitapYazari AS[YazarAdi],KitapYayinEvi AS[YayinEvi ]," + "KitapYayinEvi AS[BasimEvi],KitapSayisi FROM Kitaplar ;", baglanti);
            DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(uyeleriGetir);
                baglanti.Open();
                da.Fill(dt);
                baglanti.Close();
                return dt;
            }
      
        public bool KullaniciGuncelleme(string kullanici_adi, string kullanici_sifre, string yonetici)
        {
            try
            {
                SqlCommand KullaniciGuncellemeKomutu = new SqlCommand("UPDATE Kullanicilar SET KullaniciAdi=\'" + kullanici_adi + "\'" + ",Sifre=\'" + kullanici_sifre + "\',Yonetici=\'" + yonetici + "\' WHERE KullaniciAdi=\'" + kullanici_adi + "\';", baglanti);

                baglanti.Open();
                KullaniciGuncellemeKomutu.ExecuteNonQuery();
                baglanti.Close();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            }
            public string[] KullaniciAdinaGoreCagirma(string kullaniciadi)
            {
                string[] kullanicilar = new string[4];
                try
                {
                    SqlCommand kullanicigetir = new SqlCommand("SELECT KullaniciAdi as [Kullanıcı Adı],Sifre as [Şifre] from Kullanicilar WHERE KullaniciAdi=\'" + kullaniciadi + "\';", baglanti);
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(kullanicigetir);
                    baglanti.Open();
                    da.Fill(dt);
                    baglanti.Close();
                    DataRow dr = dt.Rows[0];
                    kullanicilar[0] = dr[0].ToString();
                    kullanicilar[1] = dr[1].ToString();

                }
                catch (Exception)
                {

                    kullanicilar[0] = "-1";
                    if (baglanti.State == ConnectionState.Open)
                    {
                        baglanti.Close();
                    }
                }
                return kullanicilar;
            }
        public DataTable KullaniciComboBoxDataTable()
        {
            SqlCommand kullanicigetir = new SqlCommand("SELECT KullaniciAdi as [Kullanıcı Adı],Sifre as [Şifre] from Kullanicilar;", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(kullanicigetir);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            return dt;
        }
        public DataTable KullaniciListesi()
        {
            SqlCommand kullanicigetir = new SqlCommand("SELECT KullaniciAdi as [ADi], Sifre as [ ŞİFRE], Yonetici as [Yonetici] from Kullanicilar;", baglanti);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(kullanicigetir);
            baglanti.Open();
            da.Fill(dt);
            baglanti.Close();
            return dt;
        }
    }
    }






