using System;
using Npgsql;

class kitap
{
    public string kitapID { get; set; }
    public string kitapAdi { get; set; }
    public string yazar { get; set; }
    public string basimYili { get; set; }
    public string yayinevi { get; set; }
    public bool oduncAlindiMi { get; set; }

    private string baglantiYolu = "Host=localhost;Port=5432;Database=kutuphane;Username=postgres;Password=ez1234gi";

    public static void kitapEkle(string kitapID, string kitapAdi, string yazar, string basimYili, string yayinevi, bool oduncAlindiMi)
    {
        kitapID = kitapID;
        kitapAdi = kitapAdi;
        yazar = yazar;
        basimYili = basimYili;
        yayinevi = yayinevi;
        oduncAlindiMi = oduncAlindiMi;
    }

    public void kitapEkle()
    {
        NpgsqlConnection baglanti = new NpgsqlConnection(baglantiYolu);
        string query = "INSERT INTO kitap(@kitap_id,@kitap_ad,@yazar_ad,@,@yayin_tarihi,@yayinevi,@durum) VALUES (@kitapID,@kitapAdi,@yazar,@basimYili,@yayinevi,@oduncAlindiMi)";
        NpgsqlCommand komut = new NpgsqlCommand(query, baglanti);

        komut.Parameters.AddWithValue("@kitap_id", kitapID);
        komut.Parameters.AddWithValue("@kitap_ad", kitapAdi);
        komut.Parameters.AddWithValue("@yazar_ad", yazar);
        komut.Parameters.AddWithValue("@yayin_tarihi", basimYili);
        komut.Parameters.AddWithValue("@yayinevi", yayinevi);
        komut.Parameters.AddWithValue("@durum", oduncAlindiMi);

        baglanti.Open();
        komut.ExecuteNonQuery();
        baglanti.Close();


    }

    public void kitapGuncelle(string yeniKitapID, string yeniKitapAdi, string yeniKitapYazar, string yeniKitaptarih, string yeniKitapYayinevi, bool yeniKitapDurum)
    {
        NpgsqlConnection baglanti = new NpgsqlConnection(baglantiYolu);
        string query = "UPDATE Kitaplar SET yeniKitapID = @kitapID,yeniKitapAdi=@kitapAdi,yeniKitapYazar= @Yazar,yeniKitapTarih= @basimYili,yeniKitapYayınevi=@yayinevi,yeniKitapDurum=@oduncAlindiMi";
        NpgsqlCommand komut = new NpgsqlCommand(query, baglanti);

        komut.Parameters.AddWithValue("@kitapID", yeniKitapID);
        komut.Parameters.AddWithValue("@kitapAdi", yeniKitapAdi);
        komut.Parameters.AddWithValue("@yazar", yeniKitapYazar);
        komut.Parameters.AddWithValue("@basimYili", yeniKitaptarih);
        komut.Parameters.AddWithValue("@yayinevi", yeniKitapYayinevi);
        komut.Parameters.AddWithValue("@durum", yeniKitapDurum);

        baglanti.Open();
        komut.ExecuteNonQuery();
        baglanti.Close();

        Console.WriteLine("Kitap bilgileri başarıyla güncellendi.");


    }

    public void kitapSil()
    {
        NpgsqlConnection baglanti = new NpgsqlConnection(baglantiYolu);
        string query = "DELETE FROM Kitaplar WHERE KitapID = @kitapID";
        NpgsqlCommand komut = new NpgsqlCommand(query, baglanti);
        komut.Parameters.AddWithValue("@KitapID", kitapID);
        baglanti.Open();
        komut.ExecuteNonQuery();
        Console.WriteLine("Kitap başarıyla silindi.");

    }

    public void kitapBilgileriniGoster()
    {
        NpgsqlConnection baglanti = new NpgsqlConnection(baglantiYolu);
        string query = "";
        NpgsqlCommand komut = new NpgsqlCommand(query, baglanti);
        komut.Parameters.AddWithValue("@KitapID", kitapID);

        baglanti.Open();
        NpgsqlDataReader reader = komut.ExecuteReader();
        baglanti.Close();

        if (reader.Read())
        {
            Console.WriteLine($"Kitap ID: {reader["KitapID"]}");
            Console.WriteLine($"Kitap Adı: {reader["KitapAdi"]}");
            Console.WriteLine($"Yazar: {reader["Yazar"]}");
            Console.WriteLine($"Basım Yılı: {reader["BasimYili"]}");
            Console.WriteLine($"Yayınevi: {reader["Yayinevi"]}");
            Console.WriteLine($"Ödünç Alındı Mı: {(Convert.ToBoolean(reader["OduncAlindiMi"]) ? "Evet" : "Hayır")}");
        }
        else
        {
            Console.WriteLine("Kitap bulunamadı.");
        }

    }

    public void KitapBul()
    {
        NpgsqlConnection baglanti = new NpgsqlConnection(baglantiYolu);

        string query = "UPDATE kitap SET oduncAlindiMi = @OduncAlindiMi WHERE kitapID = @KitapID";

        NpgsqlCommand command = new NpgsqlCommand(query, baglanti);
        command.Parameters.AddWithValue("@KitapID", kitapID);
        command.Parameters.AddWithValue("@OduncAlindiMi", true);

        baglanti.Open();
        int result = command.ExecuteNonQuery();

        Console.WriteLine(result > 0 ? "Kitap ödünç alındı." : "Kitap ödünç alınamadı.");


    }

}