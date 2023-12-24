using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EntityLayer.Entities
{
    public class Servisler
    {
        [Key]
        public int Servis_Id { get; set; }
        public string? Servis_Ad { get; set; }
        [ForeignKey("Kategoriler")]
        public int Kategori_Id { get; set; }
        public virtual Kategoriler? Kategoriler { get; set; }
        public double? Fiyat { get; set; }
        public string? Servis_Image { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
        public virtual List<Adisyon>? Adisyons { get; set; }
    }
}
