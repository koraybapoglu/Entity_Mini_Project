using System;
using System.Linq;
using Entity_Musteri_Siparis_Project;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Entity_Musteri_Siparis_Project.DataServices
{
	public static class MusteriService
	{
		public static void UyeGuncelle()
		{
			using (var context = new MusteriSiparisDbContext())
			{
				Entities.Musteri musteri = new();
				Console.Clear();
				UyeGetir();
				Console.WriteLine("----------------------------");
				Console.WriteLine("Lütfen Güncellemek istediğiniz Üyenin Adını Giriniz:");
				musteri.MusteriAdi = Console.ReadLine();
				Console.WriteLine("Lütfen Güncellemek istediğiniz Üyenin Soyadını Giriniz:");
				musteri.MusteriSoyadi = Console.ReadLine();
				Entities.Musteri guncellenecekuye = context.Musteriler.FirstOrDefault(j => j.MusteriAdi == musteri.MusteriAdi && j.MusteriSoyadi == musteri.MusteriSoyadi);
				if (guncellenecekuye != null)
				{
					Console.Clear();

					Console.WriteLine("Lütfen Üyenin Yeni Adını Giriniz:");
					guncellenecekuye.MusteriAdi = Console.ReadLine();
					Console.WriteLine("Lütfen Üyenin Yeni Soyadını Giriniz:");
					guncellenecekuye.MusteriSoyadi = Console.ReadLine();
					Console.WriteLine("Lütfen Üyenin Yeni E-Postasını Giriniz:");
					guncellenecekuye.MusteriEmail = Console.ReadLine();
					Console.WriteLine("Lütfen Üyenin Yeni Tel Numarasını Giriniz:");
					guncellenecekuye.MusteriTel = Convert.ToInt64(Console.ReadLine());
					Console.WriteLine("Lütfen Üyenin Yeni Adresini Giriniz:");
					guncellenecekuye.MusteriAdres = Console.ReadLine();
					context.Musteriler.Update(guncellenecekuye);
					context.SaveChanges();
				}
				else
				{
					Console.WriteLine("Böyle Bir Üye Bulunamadı Lütfen Tekrar Deneyiniz.");
				}

			}
		}
		public static void UyeCikar()
		{
			using (var context = new MusteriSiparisDbContext())
			{
				Console.WriteLine("Lütfen Silinecek olan Üyenin Adını Giriniz:");
				string adi = Console.ReadLine();
				Console.WriteLine("Lütfen Silinecek olan Üyenin Soyadını Giriniz:");
				string soyadi = Console.ReadLine();
				Entities.Musteri musteri = context.Musteriler.FirstOrDefault(j => j.MusteriAdi == adi && j.MusteriSoyadi == soyadi);
				if (musteri != null)
				{
					context.Musteriler.Remove(musteri);
					context.SaveChanges();
					Console.WriteLine("Başarılı Bir Şekilde " + musteri.MusteriAdi + " " + musteri.MusteriSoyadi + " Adlı Kişi Veritabanından Silindi !");
					Console.ReadLine();
				}
				else
				{
					Console.WriteLine("Müşteriyi Yanlış Girdiniz Tekrar Deneyiniz.");
				}

			}
		}
		public static void UyeGetir()
		{
			Console.Clear();
			using (var context = new MusteriSiparisDbContext())
			{
				List<Entities.Musteri> musteriler = context.Musteriler.ToList();
				foreach (var item in musteriler)
				{
					Console.WriteLine("------------------------------");
					Console.WriteLine(item.MusteriID);
					Console.WriteLine(item.MusteriAdi);
					Console.WriteLine(item.MusteriSoyadi);
					Console.WriteLine(item.MusteriTel);
					Console.WriteLine(item.MusteriEmail);
					Console.WriteLine();
					Console.WriteLine("------------------------------");
				}
			}

		}
		public static void UyeGiris()
		{
			using (var context = new MusteriSiparisDbContext())
			{

				Console.WriteLine("E-postayı Giriniz:");
				string musterieposta = Console.ReadLine();
				Console.WriteLine("Şifrenizi Giriniz:");
				string musterisifre = Console.ReadLine();
				Entities.Musteri musterigiris = context.Musteriler.FirstOrDefault(j => j.MusteriEmail == musterieposta && j.MusteriSifre == musterisifre);
				if (musterigiris != null)
				{
					Console.Clear();
					bool deger = true;
					while (deger == true)
					{
						Console.Clear();
						Console.WriteLine("1-Sipariş Vermek İçin,");
						Console.WriteLine("2-Siparişlerini Görmek için,");
						Console.WriteLine("3-Geri Dönmek İçin Tuşlayınız.");
						switch (int.Parse(Console.ReadLine()))
						{
							case 1:
								MusteriSiparisService.SiparisEkle(musterigiris.MusteriID);
								Console.ReadLine();
								break;
							case 2:
								MusteriSiparisService.SiparisGor(musterigiris.MusteriID);
								Console.ReadLine();
								break;
							case 3:
								deger = false;
								break;
							default:
								Console.WriteLine("Bir Hata Meydana Geldi Tekrar Deneyiniz.");
								break;
						}
					}
				}
				else
				{
					Console.WriteLine("Giriş Başarısız Tekrar Deneyiniz.");
				}
				Console.ReadLine();
			}
		}
		public static void UyeEkle()
		{
			Entities.Musteri musteriekle = new Entities.Musteri();

			Console.WriteLine("Lütfen Adınızı Giriniz:");
			musteriekle.MusteriAdi = Console.ReadLine();

			Console.WriteLine("Lütfen Soyadınız Giriniz:");
			musteriekle.MusteriSoyadi = Console.ReadLine();

			Console.WriteLine("Lütfen Mail Giriniz:");
			musteriekle.MusteriEmail = Console.ReadLine();

			Console.WriteLine("Lütfen Telefon Numaranızı Giriniz:");
			musteriekle.MusteriTel = Convert.ToInt64(Console.ReadLine());

			Console.WriteLine("Lütfen Adresinizi Giriniz:");
			musteriekle.MusteriAdres = Console.ReadLine();

			Console.WriteLine("Lütfen Şifrenizi Giriniz:");
			musteriekle.MusteriSifre = Console.ReadLine();

			using (var context = new MusteriSiparisDbContext())
			{
				context.Musteriler.Add(musteriekle);
				context.SaveChanges();
			}

			Console.WriteLine("---------------------------------------------------");
			Console.WriteLine("Başarılı Bir Şekilde Kaydoldunuz. Tebrikler!");
			Console.WriteLine("Anasayfaya Dönmek İçin Herhangi Bir Tuşa Basınız...");
			Console.WriteLine("---------------------------------------------------");
			Console.ReadLine();
		}
	}
}
