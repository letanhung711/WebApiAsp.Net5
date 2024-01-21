using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiNet5._0.Data
{
    [Table("HangHoa")]
    public class HangHoa
    {
        [Key]
        public Guid MaHH { get; set; }

        [Required]
        //Required bat buoc phai nhap
        [MaxLength(100)]
        public string TenHH { get; set; }

        public string MoTa { get; set; }

        [Range(0, double.MaxValue)]
        public double DonGia {  get; set; }

        public byte GiamGia {  get; set; }

        public int? MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public Loai loai { get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }
}
