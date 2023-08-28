using Entity_Musteri_Siparis_Project.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Musteri_Siparis_Project
{
	class MusteriSiparisDbContext : DbContext
	{
		public DbSet<Musteri> Musteriler { get; set; }
		public DbSet<Admin> Admin { get; set; }
		public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-RN1V6Q9;Database=MiniEntityProject;Trusted_Connection=True;TrustServerCertificate=true;");

		}
	}
}
