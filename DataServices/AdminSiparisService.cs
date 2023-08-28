using Entity_Musteri_Siparis_Project.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Musteri_Siparis_Project.DataServices
{
	internal class AdminSiparisService
	{
		public static void SiparisleriGoruntule() 
		{
			using (var context = new MusteriSiparisDbContext()) 
			{
				List<Siparis> siparisler = context.Siparisler.ToList();
				Urun urunler = new();
				Musteri Musteriler = new();
				foreach (var item in siparisler)
				{
					urunler = context.Urunler.FirstOrDefault(j=>j.UrunID==item.UrunID);
					Musteriler=context.Musteriler.FirstOrDefault(k=>k.MusteriID==item.MusteriID);
					Console.WriteLine("----------SİPARİŞ--------------------------------");
					Console.WriteLine("Sipariş Numarası: "+item.SiparisID);
					Console.WriteLine("Ürün Adı: "+urunler.UrunAdi);
					Console.WriteLine("Ürün Fiyatı: "+urunler.Fiyat);
					Console.WriteLine("Sipariş Verme Tarihi: "+item.SiparisTarihi);
					Console.WriteLine("Sipariş Durumu:"+item.SiparisDurumu);
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("-------KİŞİ BİLGİLERİ-----------------------------");
					Console.WriteLine("Müşteri Adı: "+Musteriler.MusteriAdi);
                    Console.WriteLine("Müşteri Soyadı: "+Musteriler.MusteriSoyadi);
                    Console.WriteLine("Müşteri Telefon NO: "+Musteriler.MusteriTel);
                    Console.WriteLine("MÜŞTERİ ADRES: "+Musteriler.MusteriAdres);
					Console.WriteLine("--------------------------------------------------");
				}
			}
		}
		public static void Siparisİslemleri() 
		{
			SiparisleriGoruntule();
			using(var context=new MusteriSiparisDbContext())
			{
				Console.WriteLine("SİPARİŞ DURUMUNU DEĞİŞTİRMEK İSTEDİĞİNİZ SİPARİŞİNİ SİPARİŞ NUARASINI GİRİNİZ:");
				Siparis siparisvarmi = context.Siparisler.FirstOrDefault(j => j.SiparisID == int.Parse(Console.ReadLine()));
				Siparis siparisdurumguncelle = new();
				if (siparisvarmi != null) 
				{
                    Console.WriteLine("Durumunu Ne Yapmak İstiyorsunuz ?");
                    Console.WriteLine("Reddedildi-Onaylandı");
					siparisdurumguncelle.SiparisDurumu = Console.ReadLine();
					context.Siparisler.Update(siparisdurumguncelle);
					context.SaveChanges();
					Console.WriteLine("Siparişin Durumu Başarıyla Güncellendi !");
                }
				else
				{
                    Console.WriteLine("Bir Hata Meydana Geldi.");
                }
			}
			
			
			
		}
	}
}
