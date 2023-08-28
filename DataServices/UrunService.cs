using Entity_Musteri_Siparis_Project.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Musteri_Siparis_Project.DataServices
{
	internal class UrunService
	{
		public static void UrunEkle()
		{
			using(var context= new MusteriSiparisDbContext()) 
			{
				Urun urunekle = new();
				Console.Clear();
				Console.WriteLine("Lütfen Ürünün Adını Giriniz:");
				urunekle.UrunAdi = Console.ReadLine();
				Console.WriteLine("Lütfen " + urunekle.UrunAdi + " Adlı Ürünün Fiyatını Giriniz:");
				urunekle.Fiyat = float.Parse(Console.ReadLine());
				context.Urunler.Add(urunekle);
				context.SaveChanges();
				Console.WriteLine("Başarılı Bir Şekilde Ürününüz Eklendi !");
			}
			
		}
		public static void UrunCikar() 
		{
			using(var context=new MusteriSiparisDbContext()) 
			{
				Console.Clear();
				UrunGetir();
				Console.WriteLine("-----------------------------------");
				Console.WriteLine("Lütfen Çıkarmak İstediğiniz Ürünün Adını Giriniz:");
				Urun uruncikar = context.Urunler.FirstOrDefault(u => u.UrunAdi == Console.ReadLine());
				if (uruncikar!=null)
				{
					context.Urunler.Remove(uruncikar);
					context.SaveChanges();
					Console.WriteLine("Başarılı Bir Şekilde Ürün Çıkartıldı !");
				}
				else
				{
                    Console.WriteLine("Hatalı Giriş Yaptınız Ürün Bulunamadı !");
                }
			}
		}
		public static void UrunGuncelle() 
		{
			using (var context = new MusteriSiparisDbContext())
			{
				Console.Clear();
				UrunGetir();
				Console.WriteLine("-----------------------------------");
				Console.WriteLine("Lütfen Güncellenecek Ürünün Adını Giriniz:");
				Urun urunguncelle = context.Urunler.FirstOrDefault(j=>j.UrunAdi==Console.ReadLine());
				if (urunguncelle!=null)
				{
					Console.WriteLine("Lütfen "+urunguncelle.UrunAdi+" Adlı Ürünün Yeni Adını Giriniz:");
					urunguncelle.UrunAdi = Console.ReadLine();
					Console.WriteLine("Lütfen "+urunguncelle.UrunAdi+" Adlı Ürünün Yeni Fiyatını Giriniz:");
					urunguncelle.Fiyat = float.Parse(Console.ReadLine());
					context.Urunler.Update(urunguncelle);
					context.SaveChanges();
				}
				else
				{
                    Console.WriteLine("Böyle Bir Ürün bulunamadı Lütfen Daha Sonra Tekrar Deneyiniz.");
                }
			}	
        }
		public static void UrunGetir() 
		{
			using(var context= new MusteriSiparisDbContext()) 
			{
				Console.Clear();
				List<Urun> urunler = context.Urunler.ToList();
				foreach ( var item in urunler)
				{
					Console.WriteLine("-----------------------------");
					Console.WriteLine(item.UrunAdi);
					Console.WriteLine(item.Fiyat);
					Console.WriteLine("-----------------------------");
                    Console.WriteLine();
                }
			}

		}
	}
}
