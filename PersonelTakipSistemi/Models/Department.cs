using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonelTakipSistemi.Models
{
    public class Department
    {
        [Key]
        public int DepartmanId { get; set; }
        public string DepartmanAd { get; set; }
        public IList<Employee> Personel { get; set; }
    }
}
