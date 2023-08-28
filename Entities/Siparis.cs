using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Musteri_Siparis_Project.Entities
{
	class Siparis
	{
		public int SiparisID { get; set; }
		public DateTime SiparisTarihi { get; set; }
		public string SiparisDurumu { get; set; }
		public int UrunID { get; set; }
		public int MusteriID { get; set; }
		public ICollection<Musteri> Musteri { get; set; }
	}
}
