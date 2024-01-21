using System;

namespace WebApiNet5._0.Data
{
    public class ChiTietDonHang
    {
        public Guid MaHH { get; set; }
        public Guid MaDh { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        //relationship
        public DonHang DonHang { get; set; }
        public HangHoa HangHoa {  get; set; }
    }
}
