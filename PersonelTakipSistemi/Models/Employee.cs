using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelTakipSistemi.Models
{
    public class Employee
    {
        [Key]
        public int PersonelId { get; set; }
        public Int64 TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string DogumYeri { get; set; }
        public string Adres { get; set; }
        public Int64 Telefon { get; set; }
        public string OgrenimDurumu { get; set; }

        public int DepartmanId { get; set; }
        public Department Departman { get; set; }

    }
}
