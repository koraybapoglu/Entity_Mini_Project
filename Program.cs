using Entity_Musteri_Siparis_Project.DataServices;
using System;

namespace Entity_Musteri_Siparis_Project
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool isRunning = true;
			while (isRunning)
			{
				Console.Clear();
				Console.WriteLine("1- Üye Olmak için,");
				Console.WriteLine("2- Admin Giriş için,");
				Console.WriteLine("3- Üye Giriş İçin Tuşlayınız.");
				int choice = Convert.ToInt32(Console.ReadLine());
				switch (choice)
				{
					case 1:
						MusteriService.UyeEkle();
						break;
					case 2:
						bool girisonay = AdminService.AdminGiris();
						if (girisonay)
						{
							AdminMenu();
						}
						else
						{
							Console.Clear();
							Console.WriteLine("Giriş Başarısız Lütfen Tekrar Deneyiniz.");
							Console.ReadLine();
						}
						break;
					case 3:
						MusteriService.UyeGiris();
						break;
					default:
						Console.WriteLine("Geçersiz Seçim!");
						break;
				}
			}
		}

		static void AdminMenu()
		{
			bool deger = true;
			while (deger==true)
			{
				Console.Clear();
				Console.WriteLine("1- Üyeleri Görmek İçin,");
				Console.WriteLine("2- Üye İşlemleri İçin,");
				Console.WriteLine("3- Siparişleri Görmek İçin,");
				Console.WriteLine("4- Menü İşlemleri İçin,");
                Console.WriteLine("5- Diğer İşlemlere Dönüş Yapmak İçin Tuşlayınız.");

                int choice2 = Convert.ToInt32(Console.ReadLine());
				switch (choice2)
				{
					case 1:
						MusteriService.UyeGetir();
						break;
					case 2:
						UyeIslemleri();
						break;
					case 3:
						Console.WriteLine("1-Siparişleri Görmek için,");
                        Console.WriteLine("2-Sipariş İşlemleri İçin Tuşlayınız.");
						switch (int.Parse(Console.ReadLine()))
						{
							case 1:
								AdminSiparisService.SiparisleriGoruntule();
								Console.ReadLine();
								break;
							case 2:
								AdminSiparisService.Siparisİslemleri();
								Console.ReadLine();
								break;
						}
						break;
					case 4:
						UrunMenu();
						break;
					case 5:
						deger = false;
						break;
					default:
						Console.WriteLine("Geçersiz Seçim!");
						break;
				}

				Console.ReadLine();
			}
		}

		static void UyeIslemleri()
		{
			bool deger = true;
			while (deger == true)
			{
				Console.Clear();
				MusteriService.UyeGetir();
				Console.WriteLine("1-Çıkarma İşlemi İçin,");
				Console.WriteLine("2-Güncelleme İşlemi İçin");
				Console.WriteLine("3-Diğer İşlemlere Dönüş Yapmak İçin Tuşlayınız.");
				int secim = Convert.ToInt32(Console.ReadLine());
				switch (secim)
				{
					case 1:
						MusteriService.UyeCikar();
						break;
					case 2:
						MusteriService.UyeGuncelle();
						break;
					case 3:
						deger = false;
						break;
					default:
						Console.WriteLine("Hatalı Seçim !");
						break;
						
				}
			}
		}

		static void UrunMenu()
		{
			bool deger = true;
			while (deger==true)
			{
				Console.Clear();
				Console.WriteLine("1-Ürün Eklemek için,");
				Console.WriteLine("2-Ürün Çıkarmak için,");
				Console.WriteLine("3-Ürün Güncellemek için,");
				Console.WriteLine("4-Ürün Listelemek İçin,");
				Console.WriteLine("5-Diğer İşlemlere Dönüş Yapmak İçin Tuşlayınız.");

				int urunSecim = Convert.ToInt32(Console.ReadLine());
				switch (urunSecim)
				{
					case 1:
						UrunService.UrunEkle();
						Console.ReadLine();
						break;
					case 2:
						UrunService.UrunCikar();
						Console.ReadLine();
						break;
					case 3:
						UrunService.UrunGuncelle();
						Console.ReadLine();
						break;
					case 4:
						UrunService.UrunGetir();
						Console.ReadLine();
						break;
					case 5:
						deger = false;
						break;
					default:
						Console.WriteLine("Yanlış Bir Tuşlama Yaptınız. Lütfen Tekrar Deneyiniz.");
						Console.ReadLine();
						break;
				}
			}
		}
	}
}
