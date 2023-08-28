using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Musteri_Siparis_Project.Entities
{
	class Musteri
	{
		public int MusteriID { get; set; }
		public string MusteriAdi { get; set; }
		public string MusteriSoyadi { get; set; }
		public string MusteriEmail { get; set; }
		public long MusteriTel { get; set; }
		public string MusteriAdres { get; set; }
		public string MusteriSifre { get; set; }
		public Siparis? Siparis { get; set; }
	}
}
