using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Musteri_Siparis_Project.DataServices
{
    internal class AdminService
    {
        public static bool AdminGiris()
        {
            using (var context = new MusteriSiparisDbContext())
            {
                Console.WriteLine("Kullanıcı Adını Giriniz:");
                string adminkullaniciadi = Console.ReadLine();

                Console.WriteLine("Şifreyi Giriniz:");
                string adminSifre = Console.ReadLine();

                Entities.Admin admin = context.Admin.FirstOrDefault(u => u.AdminUserName == adminkullaniciadi && u.AdminPassword == adminSifre);

                if (admin != null)
                {
                    Console.WriteLine("Giriş Başarılı.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Giriş Başarısız. Lütfen Tekrar Deneyiniz.");
                    return false;
                }
                Console.ReadLine();
            }
        }
    }
}
