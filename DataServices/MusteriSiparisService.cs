using Entity_Musteri_Siparis_Project.Entities;
using Entity_Musteri_Siparis_Project.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Musteri_Siparis_Project.DataServices
{
	public class MusteriSiparisService
	{
		public static void SiparisEkle(int musteriID)
		{
			using (var context = new MusteriSiparisDbContext())
			{
				Siparis siparisekle = new();
				Console.WriteLine("----------MENÜ---------------");
				UrunService.UrunGetir();
				Console.WriteLine("----------------------------");
				Console.WriteLine("Sipariş Vermek İstediğiniz Ürünün Adını Giriniz:");
				Urun urunidgetir = context.Urunler.FirstOrDefault(u => u.UrunAdi == Console.ReadLine());
				if (urunidgetir != null)
				{
					siparisekle.UrunID = urunidgetir.UrunID;
					siparisekle.MusteriID = musteriID;
					siparisekle.SiparisTarihi = DateTime.Now;
					siparisekle.SiparisDurumu = "Onay Bekliyor...";
					context.Siparisler.Add(siparisekle);
					context.SaveChanges();
					Console.WriteLine("Başarılı Bir Şekilde Siparişiniz Oluşturuldu !");
				}
				else
				{
					Console.WriteLine("Girmiş Olduğunuz Ürün Bulunamadı Lütfen Tekrar Deneyiniz.");
				}
			}
		}
		public static void SiparisGor(int musteriID)
		{
			using (var context = new MusteriSiparisDbContext())
			{
				List<Siparis> siparisler = context.Siparisler.Where(j => j.MusteriID == musteriID).ToList();
				Urun urun = new Urun();
				Musteri musteri = new Musteri();

				foreach (var siparis in siparisler)
				{
					Console.WriteLine("-------- SİPARİŞ -----------------------------------------------------");

					urun = context.Urunler.FirstOrDefault(u => u.UrunID == siparis.UrunID);
					Console.WriteLine($"Ürün Adı: {urun.UrunAdi}");
					Console.WriteLine($"Ürün Fiyatı: {urun.Fiyat}");
					Console.WriteLine($"Sipariş Durumu: {siparis.SiparisDurumu}");
					Console.WriteLine($"Sipariş Tarihi: {siparis.SiparisTarihi}");

					musteri = context.Musteriler.FirstOrDefault(k => k.MusteriID == siparis.MusteriID);
					Console.WriteLine("-------- Kişi Bilgileri --------");
					Console.WriteLine($"Ad: {musteri.MusteriAdi}");
					Console.WriteLine($"Soyad: {musteri.MusteriSoyadi}");
					Console.WriteLine($"Telefon: {musteri.MusteriTel}");
					Console.WriteLine($"Adres: {musteri.MusteriAdres}");
					Console.WriteLine("---------------------------------------------------------------------");
				}
			}

		}
	}
}
