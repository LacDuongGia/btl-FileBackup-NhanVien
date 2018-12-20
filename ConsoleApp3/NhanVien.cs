using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL
{
    abstract class NhanVien
    {        
        public string ID { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgayThangNamSinh { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public virtual string ViTri { get; set; }
        public double LuongCoBan { get; set; }
        public virtual double Luong { get; set; }
        public virtual void Nhap()
        {
            Console.Write("Nhap ID: ");
            ID = Console.ReadLine();
            Console.Write("Nhap ho va ten: ");
            HoTen = Console.ReadLine();
            int GT = Menu.HoiYeuCau(2, "Nhap gioi tinh (1-Nam,2-Nu): ");             
            if (GT == 1)
                GioiTinh = "Nam";
            else if(GT == 2)
                GioiTinh = "Nu";
            Console.Write("Nhap ngay thang nam sinh (dd/MM/yyyy): ");
            NgayThangNamSinh = DateTime.ParseExact(Console.ReadLine(), "dd/mm/yyyy", null);
            Console.Write("Nhap so dien thoai: ");
            Sdt = Console.ReadLine();
            Console.Write("Nhap E-mail: ");
            Email = Console.ReadLine();
            Console.Write("Nhap luong co ban: ");
            LuongCoBan = double.Parse(Console.ReadLine());
        }
        public virtual void xuat()
        {
            Console.Write(ID.PadRight(10, ' ') + HoTen.PadRight(22, ' ') + GioiTinh.PadRight(11, ' ') + NgayThangNamSinh.ToString("dd - mm - yyyy").PadRight(13, ' ') + ViTri.PadRight(10) + LuongCoBan + "\n");
        }
        public abstract void SuaThongTin(int LuaChon);
        public abstract void XuatThongTinChiTiet();
        public abstract void ThemTuMang(string []parts);
        public abstract string ToStringFile();

    }

    class NhanVienVanPhong : NhanVien
    {
        public override double Luong
        {
            get
            {
                return LuongCoBan + PhuCap;
            }
            set
            {
                Luong = value;
            }
        }
        public override string ViTri
        {
            get
            {
                return ViTri = "NVVP";
            }
        }
        public double PhuCap
        {
            get
            {
                return 0.1 * LuongCoBan;
            }
            set
            {
                PhuCap = value;
            }
        }
        public override void Nhap()
        {
            base.Nhap();
        }
        public override void xuat()
        {
            Console.Write(ID.PadRight(10, ' ') + HoTen.PadRight(22, ' ') + GioiTinh.PadRight(11, ' ') + NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(13, ' ') + ViTri.PadRight(10) +
                   LuongCoBan.ToString().PadRight(14, ' ') + PhuCap.ToString().PadRight(12, ' ') + Luong + "\n");
        }
        public override void XuatThongTinChiTiet()
        {
            Console.Write("Nhan vien:{0}\n", HoTen);
            Console.Write("ID                Gioi tinh\n");
            Console.Write(ID.PadRight(18) + GioiTinh + "\n");
            Console.Write("Ngay sinh         Vi tri\n");
            Console.Write(NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(18) + ViTri + "\n");
            Console.Write("Luong co ban      Phu cap\n");
            Console.Write(LuongCoBan.ToString().PadRight(18) + PhuCap + "\n");
            Console.Write("Luong\n");
            Console.Write(Luong + "\n");
            Console.Write("--- Thong tin lien lac ---\n");
            Console.Write("So dien thoai:{0}\n", Sdt);
            Console.Write("Email:{0}\n", Email);
        }
        public override void SuaThongTin(int LuaChon)
        {

            switch (LuaChon)
            {
                case 1:
                    {
                        Console.Write("Nhap ID moi:");
                        ID = Console.ReadLine();
                    }
                    break;
                case 2:
                    {
                        Console.Write("Nhap Ten moi:");
                        HoTen = Console.ReadLine();
                    }
                    break;
                case 3:
                    {
                        Console.Write("Nhap Gioi tinh moi:");
                        GioiTinh = Console.ReadLine();
                    }
                    break;
                case 4:
                    {
                        Console.Write("Nhap ngay sinh moi:");
                        NgayThangNamSinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    }
                    break;
                case 5:
                    {
                        Console.Write("Nhap so dien thoai moi:");
                        Sdt = Console.ReadLine();
                    }
                    break;
                case 6:
                    {
                        Console.Write("Nhap Email moi:");
                        Email = Console.ReadLine();
                    }
                    break;
                case 7:
                    {
                        Console.Write("Nhap luong co ban moi:");
                        LuongCoBan = double.Parse(Console.ReadLine());
                    }
                    break;
            }
        }
        public override void ThemTuMang(string[] parts)
        {
            ID = parts[0].Trim(' ');
            HoTen = parts[1].Trim(' ');
            GioiTinh = parts[2].Trim(' ');
            NgayThangNamSinh = DateTime.ParseExact(parts[3].Trim(' '), "dd/MM/yyyy", null);
            Sdt = parts[4].Trim(' ');
            Email = parts[5].Trim(' ');
            ViTri = parts[6].Trim(' ');
            LuongCoBan = double.Parse(parts[7]);
        }
        public override string ToString()
        {
            return ID.PadRight(10, ' ') + HoTen.PadRight(22, ' ') + GioiTinh.PadRight(11, ' ') + NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(13, ' ') + ViTri.PadRight(10) +
                   LuongCoBan.ToString().PadRight(14, ' ') + PhuCap.ToString().PadRight(12, ' ') + Luong + "\n";
        }
        public override string ToStringFile()
        {
            string s = ",";
            return ID.PadRight(10, ' ') + s + HoTen.PadRight(22, ' ') + s + GioiTinh.PadRight(11, ' ') + s + NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(13, ' ') + s + Sdt.ToString().PadRight(12, ' ') + s + Email.PadRight(20, ' ') + s + ViTri.PadRight(10) +
                   s + LuongCoBan.ToString().PadRight(14, ' ') + s + PhuCap.ToString().PadRight(12, ' ') + s + Luong + "\n";
        }
    }

    class NhanVienKeToan : NhanVien
    {
        public override double Luong
        {
            get
            {
                return LuongCoBan + PhuCap;
            }
            set
            {
                Luong = value;
            }
        }
        public override string ViTri
        {
            get
            {
                return ViTri = "NVKT";
            }
        }
        public double PhuCap
        {
            get
            {
                return 0.15 * LuongCoBan;
            }
            set
            {
                PhuCap = value;
            }
        }
        public override void Nhap()
        {
            base.Nhap();
        }
        public override void xuat()
        {
            Console.Write(ID.PadRight(10, ' ') + HoTen.PadRight(22, ' ') + GioiTinh.PadRight(11, ' ') + NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(13, ' ') + ViTri.PadRight(10) +
                   LuongCoBan.ToString().PadRight(14, ' ') + PhuCap.ToString().PadRight(12, ' ') + Luong + "\n");
        }
        public override void XuatThongTinChiTiet()
        {
            Console.Write("Nhan vien:{0}\n", HoTen);
            Console.Write("ID                Gioi tinh\n");
            Console.Write(ID.PadRight(18) + GioiTinh + "\n");
            Console.Write("Ngay sinh         Vi tri\n");
            Console.Write(NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(18) + ViTri + "\n");
            Console.Write("Luong co ban      Phu cap\n");
            Console.Write(LuongCoBan.ToString().PadRight(18) + PhuCap + "\n");
            Console.Write("Luong\n");
            Console.Write(Luong + "\n");
            Console.Write("--- Thong tin lien lac ---\n");
            Console.Write("So dien thoai:{0}\n", Sdt);
            Console.Write("Email:{0}\n", Email);
        }
        public override void SuaThongTin(int LuaChon)
        {

            switch (LuaChon)
            {
                case 1:
                    {
                        Console.Write("Nhap ID moi:");
                        ID = Console.ReadLine();
                    }
                    break;
                case 2:
                    {
                        Console.Write("Nhap Ten moi:");
                        HoTen = Console.ReadLine();
                    }
                    break;
                case 3:
                    {
                        Console.Write("Nhap Gioi tinh moi:");
                        GioiTinh = Console.ReadLine();
                    }
                    break;
                case 4:
                    {
                        Console.Write("Nhap ngay sinh moi:");
                        NgayThangNamSinh = DateTime.ParseExact(Console.ReadLine(), "dd-mm-yyyy", null);
                    }
                    break;
                case 5:
                    {
                        Console.Write("Nhap so dien thoai moi:");
                        Sdt = Console.ReadLine();
                    }
                    break;
                case 6:
                    {
                        Console.Write("Nhap Email moi:");
                        Email = Console.ReadLine();
                    }
                    break;
                case 7:
                    {
                        Console.Write("Nhap luong co ban moi:");
                        LuongCoBan = double.Parse(Console.ReadLine());
                    }
                    break;
            }
        }
        public override void ThemTuMang(string[] parts)
        {
            ID = parts[0].Trim(' ');
            HoTen = parts[1].Trim(' ');
            GioiTinh = parts[2].Trim(' ');
            NgayThangNamSinh = DateTime.ParseExact(parts[3].Trim(' '), "dd/MM/yyyy", null);
            Sdt = parts[4].Trim(' ');
            Email = parts[5].Trim(' ');
            ViTri = parts[6].Trim(' ');
            LuongCoBan = double.Parse(parts[7]);
        }
        public override string ToString()
        {
            return ID.PadRight(10, ' ') + HoTen.PadRight(22, ' ') + GioiTinh.PadRight(11, ' ') + NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(13, ' ') + ViTri.PadRight(10) +
                   LuongCoBan.ToString().PadRight(14, ' ') + PhuCap.ToString().PadRight(12, ' ') + Luong + "\n";
        }
        public override string ToStringFile()
        {
            string s = ",";
            return ID.PadRight(10, ' ') + s + HoTen.PadRight(22, ' ') + s + GioiTinh.PadRight(11, ' ') + s + NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(13, ' ') + s + Sdt.ToString().PadRight(12, ' ') + s + Email.PadRight(20, ' ') + s + ViTri.PadRight(10) +
                   s + LuongCoBan.ToString().PadRight(14, ' ') + s + PhuCap.ToString().PadRight(12, ' ') + s + Luong;
        }
    }

    class NhanVienKinhDoanh : NhanVien
    {
        public override double Luong
        {
            get
            {
                return LuongCoBan + HoaHong;
            }
            set
            {
                Luong = value;
            }
        }
        public override string ViTri
        {
            get
            {
                return ViTri = "NVKD";
            }
        }
        public int DoanhSo { get; set; }
        public double HoaHong
        {
            get
            {
                return 0.2 * DoanhSo;
            }
            set
            {
                HoaHong = value;
            }
        }
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap doanh so ban hang:");
            DoanhSo = int.Parse(Console.ReadLine());
        }
        public override void xuat()
        {
            Console.Write(ID.PadRight(10, ' ') + HoTen.PadRight(22, ' ') + GioiTinh.PadRight(11, ' ') + NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(13, ' ') + ViTri.PadRight(10) +
                   LuongCoBan.ToString().PadRight(14, ' ') + HoaHong.ToString().PadRight(12, ' ') + Luong + "\n");
        }
        public override void XuatThongTinChiTiet()
        {
            Console.Write("Nhan vien:{0}\n", HoTen);
            Console.Write("ID                Gioi tinh\n");
            Console.Write(ID.PadRight(18) + GioiTinh + "\n");
            Console.Write("Ngay sinh         Vi tri\n");
            Console.Write(NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(18) + ViTri + "\n");
            Console.Write("Luong co ban      Doanh so\n");
            Console.Write(LuongCoBan.ToString().PadRight(18) + DoanhSo + "\n");
            Console.Write("Luong\n");
            Console.Write(Luong + "\n");
            Console.Write("--- Thong tin lien lac ---\n");
            Console.Write("So dien thoai:{0}\n", Sdt);
            Console.Write("Email:{0}\n", Email);
        }
        public override void SuaThongTin(int LuaChon)
        {
            switch (LuaChon)
            {
                case 1:
                    {
                        Console.Write("Nhap ID moi:");
                        ID = Console.ReadLine();
                    }
                    break;
                case 2:
                    {
                        Console.Write("Nhap Ten moi:");
                        HoTen = Console.ReadLine();
                    }
                    break;
                case 3:
                    {
                        Console.Write("Nhap Gioi tinh moi:");
                        GioiTinh = Console.ReadLine();
                    }
                    break;
                case 4:
                    {
                        Console.Write("Nhap ngay sinh moi:");
                        NgayThangNamSinh = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                    }
                    break;
                case 5:
                    {
                        Console.Write("Nhap so dien thoai moi:");
                        Sdt = Console.ReadLine();
                    }
                    break;
                case 6:
                    {
                        Console.Write("Nhap Email moi:");
                        Email = Console.ReadLine();
                    }
                    break;
                case 7:
                    {
                        Console.Write("Nhap luong co ban moi:");
                        LuongCoBan = double.Parse(Console.ReadLine());
                    }
                    break;
                case 8:
                    {
                        Console.Write("Nhap doanh so moi:");
                        DoanhSo = int.Parse(Console.ReadLine());
                    }
                    break;
            }
        }
        public override void ThemTuMang(string[] parts)
        {
            ID = parts[0].Trim(' ');
            HoTen = parts[1].Trim(' ');
            GioiTinh = parts[2].Trim(' ');
            NgayThangNamSinh = DateTime.ParseExact(parts[3].Trim(' '), "dd/MM/yyyy", null);
            Sdt = parts[4].Trim(' ');
            Email = parts[5].Trim(' ');
            ViTri = parts[6].Trim(' ');
            LuongCoBan = double.Parse(parts[7].Trim(' '));
            DoanhSo = int.Parse(parts[8].Trim(' '));
        }
        public override string ToString()
        {
            return ID.PadRight(10, ' ') + HoTen.PadRight(22, ' ') + GioiTinh.PadRight(11, ' ') + NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(13, ' ') + ViTri.PadRight(10) +
                   LuongCoBan.ToString().PadRight(14, ' ') + HoaHong.ToString().PadRight(12, ' ') + Luong + "\n";
        }
        public override string ToStringFile()
        {
            string s = ",";
            return ID.PadRight(10, ' ') + s + HoTen.PadRight(22, ' ') + s + GioiTinh.PadRight(11, ' ') + s + NgayThangNamSinh.ToString("dd/MM/yyyy").PadRight(13, ' ') + s + Sdt.ToString().PadRight(12, ' ') + s + Email.PadRight(20,' ') + s + ViTri.PadRight(10) +
                   s + LuongCoBan.ToString().PadRight(14, ' ') + s + HoaHong.ToString().PadRight(12, ' ') + s + Luong;
        }
    }
}
