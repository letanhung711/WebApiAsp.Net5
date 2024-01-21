using System;
using System.Collections.Generic;

namespace WebApiNet5._0.Data
{
    public enum TrinhTrangDonDatHang
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }
    public class DonHang
    {
        public Guid MaDh {  get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public TrinhTrangDonDatHang TrinhTrangDonHang { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiGiao { get; set; }
        public string SoDienThoai {  get; set; }

        public ICollection<ChiTietDonHang> ChiTietDonHangs {  get; set; }
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }
    }
}
