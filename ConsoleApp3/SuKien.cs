using System;

namespace BTL
{
    class SuKien
    {
        protected string maso;
        public string Maso { get { return maso; } }
        protected string loai;
        public string Loai { get { return loai; } }
        public string Ten { get; set; }
        public DateTime NgayGio { get; set; }
        public string DiaDiem { get; set; }
        protected string formatXuat = @"dd\/MM\/yyyy    HH:mm";   //verbatim string
        protected string formatFile = "d/M/yyyy    H:m";
        protected string formatNhap = "d M yyyy H m";
        public virtual void Nhap()
        {
            Console.Write(" >> Nhap ma so su kien: ");
            maso = Console.ReadLine();
            Console.Write(" >> Nhap ten su kien: ");
            Ten = Console.ReadLine();

            string ngay, gio;
            Console.Write(" >> Nhap ngay thang nam (dd MM yyyy): ");
            ngay = Console.ReadLine();
            Console.Write(" >> Nhap thoi gian (HH mm): ");
            gio = Console.ReadLine();
            NgayGio = DateTime.ParseExact(ngay + " " + gio, formatNhap, null);

            Console.Write(" >> Nhap dia diem: ");
            DiaDiem = Console.ReadLine();
        }
        public virtual void Xuat()
        {
            Console.WriteLine(Ten.PadRight(25, ' ') + NgayGio.ToString(formatXuat).PadRight(27, ' ') + DiaDiem);
        }
        public virtual void Sua() { }
        public virtual string ToStringFile() { return ""; }
    }
    class CuocHop : SuKien
    {
        public string ChuTri { get; set; }
        public int ThoiLuong { get; set; }
        public CuocHop() { loai = "Cuoc hop"; }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write(" >> Nhap ten nguoi chu tri: ");
            ChuTri = Console.ReadLine();
            Console.Write(" >> Nhap thoi luong (phut): ");
            ThoiLuong = Convert.ToInt32(Console.ReadLine());
        }
        public override string ToString()
        {
            return Maso.PadRight(9, ' ') + loai.PadRight(12, ' ') + Ten.PadRight(25, ' ') + NgayGio.ToString(formatXuat).PadRight(26, ' ')
            + DiaDiem.PadRight(12, ' ') + ChuTri.PadRight(12, ' ') + ThoiLuong;
        }
        public override void Xuat()
        {
            Console.WriteLine(" " + ToString());
        }
        public void ThemTuMang(string[] parts)
        {
            maso = parts[0];
            Ten = parts[2];
            NgayGio = DateTime.ParseExact(parts[3], formatFile, null);
            DiaDiem = parts[4];
            ChuTri = parts[5];
            ThoiLuong = int.Parse(parts[6]);
        }
        public override void Sua()
        {
            Menu.XuatMenu231();
            int y = Menu.HoiYeuCau(6, "Chon thong tin can sua: ");
            Program.XuatMauTrang(" >> Nhap thong moi: ");
            string moi = Console.ReadLine();
            if (y == 1) Ten = moi;
            else if (y == 4) DiaDiem = moi;
            else if (y == 5) ChuTri = moi;
            else if (y == 6) ThoiLuong = int.Parse(moi);
            else if (y == 2)
            {
                string gio = NgayGio.ToString("HH mm");
                NgayGio = DateTime.ParseExact(moi + " " + gio, formatNhap, null);
            }
            else
            {
                string date = NgayGio.ToString("dd MM yyyy");
                NgayGio = DateTime.ParseExact(date + " " + moi, formatNhap, null);
            }
        }
        public override string ToStringFile()
        {
            string s = ", ";
            return Maso.PadRight(7, ' ') + s + loai.PadRight(10, ' ') + s + Ten.PadRight(23, ' ') + s + NgayGio.ToString(formatXuat).PadRight(24, ' ')
            + s + DiaDiem.PadRight(10, ' ') + s + ChuTri.PadRight(10, ' ') + s + ThoiLuong;
        }
    }
    class HoiThao : SuKien
    {
        public string DienGia { get; set; }
        public int SoLuong { get; set; }
        public HoiThao() { loai = "Hoi thao"; }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write(" >> Nhap ten dien gia: ");
            DienGia = Console.ReadLine();
            Console.Write(" >> Nhap so luong nguoi tham du: ");
            SoLuong = Convert.ToInt32(Console.ReadLine());
        }
        public override string ToString()
        {
            return Maso.PadRight(9, ' ') + loai.PadRight(12, ' ') + Ten.PadRight(25, ' ') + NgayGio.ToString(formatXuat).PadRight(26, ' ')
            + DiaDiem.PadRight(12, ' ') + DienGia.PadRight(12, ' ') + SoLuong;
        }
        public override void Xuat()
        {
            Console.WriteLine(" " + ToString());
        }
        public void ThemTuMang(string[] parts)
        {
            maso = parts[0];
            Ten = parts[2];
            NgayGio = DateTime.ParseExact(parts[3], formatFile, null);
            DiaDiem = parts[4];
            DienGia = parts[5];
            SoLuong = int.Parse(parts[6]);
        }
        public override void Sua()
        {
            Menu.XuatMenu231();
            int y = Menu.HoiYeuCau(6, "Chon thong tin can sua: ");
            Program.XuatMauTrang(" >> Nhap thong moi: ");
            string moi = Console.ReadLine();
            if (y == 1) Ten = moi;
            else if (y == 4) DiaDiem = moi;
            else if (y == 5) DienGia = moi;
            else if (y == 6) SoLuong = int.Parse(moi);
            else if (y == 2)
            {
                string gio = NgayGio.ToString("HH mm");
                NgayGio = DateTime.ParseExact(moi + " " + gio, formatNhap, null);
            }
            else
            {
                string ngay = NgayGio.ToString("dd MM yyyy");
                NgayGio = DateTime.ParseExact(ngay + " " + moi, formatNhap, null);
            }
        }
        public override string ToStringFile()
        {
            string s = ", ";
            return Maso.PadRight(7, ' ') + s + loai.PadRight(10, ' ') + s + Ten.PadRight(23, ' ') + s + NgayGio.ToString(formatXuat).PadRight(24, ' ')
            + s + DiaDiem.PadRight(10, ' ') + s + DienGia.PadRight(10, ' ') + s + SoLuong;
        }
    }
}
