using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace BTL
{
    class DSNV
    {
        public List<NhanVien> DanhSachNV = new List<NhanVien>();
        public int SoLuongNhanVien { get; set; }
        NhanVien nv;

        public void Them()
        {
            int SoLuong;
            Console.Write(" >> Nhap so luong nhan vien can them: ");
            SoLuong = int.Parse(Console.ReadLine());
            for (int i = 0; i < SoLuong; i++)
            {
                Menu.TaoHeader(6, "THEM NHAN VIEN");
                Console.Write("  1. Nhan vien kinh doanh\n");
                Console.Write("  2. Nhan vien van phong\n");
                Console.Write("  3. Nhan vien ke toan\n\n");
                int LuaChon = Menu.HoiYeuCau(3, "Nhap vi tri muon them: ");
                Console.WriteLine("\n --- NHAP NHAN VIEN {0} --- \n", i + 1);
                NhanVien nv;
                try
                {
                    switch (LuaChon)
                    {
                        case 1:
                            {
                                nv = new NhanVienKinhDoanh();
                                nv.Nhap();
                                DanhSachNV.Add(nv);
                            }
                            break;
                        case 2:
                            {
                                nv = new NhanVienVanPhong();
                                nv.Nhap();
                                DanhSachNV.Add(nv);
                            }
                            break;
                        case 3:
                            {
                                nv = new NhanVienKeToan();
                                nv.Nhap();
                                DanhSachNV.Add(nv);
                            }
                            break;
                    }
                    Program.XuatMauXanh("\nNhap thanh cong\n");
                }
                catch
                {
                    Program.XuatMauDo("\n  Du lieu nhap vao khong dung dinh dang");
                    Program.XuatMauDo("\n  Du lieu vua nhap se khong duoc luu\n");
                }
            }
        }

        public void TimNhanVienTheoID()
        {
            Menu.TaoHeader(10, "TIM KIEM");
            if (!KiemTraDanhSach(DanhSachNV))
                Program.XuatMauTrang("  Danh sach hien tai rong\n");
            else
            {
                Console.Write(" >> Nhap ID nhan vien can tim: ");
                string Maso = Console.ReadLine();
                Console.WriteLine();
                NhanVien KetQua = DanhSachNV.Find(delegate (NhanVien nv)
                {
                    return nv.ID == Maso;
                });
                if (KetQua != null)
                {
                    XuatHeader();
                    KetQua.xuat();
                }
                else
                    Program.XuatMauDo("  Khong tim thay nhan vien\n");
            }
        }

        public void TimNhanVienTheoTen()
        {
            Menu.TaoHeader(10, "TIM KIEM");
            if (!KiemTraDanhSach(DanhSachNV))
                Program.XuatMauTrang("  Danh sach hien tai rong\n");
            else
            {
                Console.Write(" >> Nhap ten nhan vien can tim: ");
                string Ten = Console.ReadLine();
                Console.WriteLine();
                List<NhanVien> KetQua = DanhSachNV.FindAll(
                    delegate (NhanVien nv)
                    {
                        return TachTen(nv.HoTen) == Ten;
                    });
                XuatKetQua(KetQua);
            }
        }

        public void TimNhanVienTheoGioiTinh()
        {
            Menu.TaoHeader(10, "TIM KIEM");
            if (!KiemTraDanhSach(DanhSachNV))
                Program.XuatMauTrang("  Danh sach hien tai rong\n");
            else
            {
                Console.Write(" >> Nhap gioi tinh: ");
                string Gioitinh = Console.ReadLine();
                Console.WriteLine();
                List<NhanVien> KetQua = DanhSachNV.FindAll(
                   delegate (NhanVien nv)
                   {
                       return nv.GioiTinh == Gioitinh;
                   });
                XuatKetQua(KetQua);
            }
        }

        public void TimNhanVienTheoViTri()
        {
            Menu.TaoHeader(10, "TIM KIEM");
            if (!KiemTraDanhSach(DanhSachNV))
                Program.XuatMauTrang("  Danh sach hien tai rong\n");
            else
            {
                Console.Write("  1. Nhan vien kinh doanh\n");
                Console.Write("  2. Nhan vien van phong\n");
                Console.Write("  3. Nhan vien ke toan\n\n");
                int LuaChon = Menu.HoiYeuCau(3, "Nhap vi tri can tim: ");
                Console.WriteLine();
                string ViTri = "";
                switch (LuaChon)
                {
                    case 1: ViTri = "NVKD"; break;
                    case 2: ViTri = "NVVP"; break;
                    case 3: ViTri = "NVKD"; break;
                }
                List<NhanVien> KetQua = DanhSachNV.FindAll(
                 delegate (NhanVien nv)
                 {
                     return nv.ViTri == ViTri;
                 });
                XuatKetQua(KetQua);
            }
        }

        public void XuatDanhDach()
        {
            Menu.TaoHeader(12, "DANH SACH NHAN VIEN");
            if (!KiemTraDanhSach(DanhSachNV))
                Program.XuatMauTrang("  Danh sach hien tai rong\n");
            else
            {
                XuatHeader();
                foreach (NhanVien nv in DanhSachNV)
                {
                    nv.xuat();
                }
            }

        }

        public void XuatDanhSach_ThongBao()
        {
            Menu.TaoHeader(12, "DANH SACH NHAN VIEN");
            if (!KiemTraDanhSach(DanhSachNV))
                Program.XuatMauTrang("  Danh sach hien tai rong\n");
            else
            {
                XuatHeader();
                foreach (NhanVien nv in DanhSachNV)
                {
                    nv.xuat();
                }
                Program.XuatMauTrang("\n >> Luu thong tin\n");
                Console.Write(" 1. Co       2. Khong\n");
                int anw = Menu.HoiYeuCau(2, "Tra loi: ");
                try
                {
                    if (anw == 1)
                        NhapDuongDanLuuFile();
                }
                catch
                {
                    Program.XuatMauDo("\n  Luu file that bai\n");
                }
            }
        }

        public void XuatDanhSach_ChiTiet()
        {
            Menu.TaoHeader(8, "DANH SACH NHAN VIEN");
            if (!KiemTraDanhSach(DanhSachNV))
                Program.XuatMauTrang("  Danh sach hien tai rong\n");
            else
            {
                foreach (NhanVien nv in DanhSachNV)
                {
                    nv.XuatThongTinChiTiet();
                    Console.WriteLine();
                }
            }
        }

        public void XuatDanhSach_ChiTiet_ThongBao()
        {
            Menu.TaoHeader(8, "DANH SACH NHAN VIEN");
            if (!KiemTraDanhSach(DanhSachNV))
                Program.XuatMauTrang("  Danh sach hien tai rong\n");
            else
            {
                foreach (NhanVien nv in DanhSachNV)
                {
                    nv.XuatThongTinChiTiet();
                    Console.WriteLine();
                }
                Program.XuatMauTrang(" >> Luu thong tin\n");
                Console.Write(" 1. Co       2. Khong\n");
                int anw = Menu.HoiYeuCau(2, "Tra loi: ");
                try
                {
                    if (anw == 1)
                        NhapDuongDanLuuFile();
                }
                catch
                {
                    Program.XuatMauDo("\n  Luu file that bai\n");
                }
            }
        }

        public void XuatDanhSach_Ten_BangChuCai()
        {
            Program.XuatMauTrang(" >> Xuat danh theo ten tang dan\n");
            if (KiemTraDanhSach(DanhSachNV))
            {
                DanhSachNV.Sort(
                    delegate (NhanVien nv1, NhanVien nv2)
                    {
                        if (TachTen(nv1.HoTen).CompareTo(TachTen(nv2.HoTen)) == 0)
                            return nv1.ID.CompareTo(nv2.ID);
                        else
                            return TachTen(nv1.HoTen).CompareTo(TachTen(nv2.HoTen));
                    });
                XuatDanhSach_ThongBao();
            }
            else
            {
                Program.XuatMauTrang("\n  Danh sach hien tai rong\n");
            }
        }

        public void XuatDanhSach_Luong_TangDan()
        {
            Program.XuatMauTrang(" >> Xuat danh theo luong tang dan\n");
            if (KiemTraDanhSach(DanhSachNV))
            {
                DanhSachNV.Sort(
                   delegate (NhanVien nv1, NhanVien nv2)
                   {
                       if (nv1.Luong.CompareTo(nv2.Luong) == 0)
                           return nv1.ID.CompareTo(nv2.ID);
                       else
                           return nv1.Luong.CompareTo(nv2.Luong);
                   });
                XuatDanhSach_ThongBao();
            }
            else
            {
                Program.XuatMauTrang("\n  Danh sach hien tai rong\n");
            }
        }

        public void XuatDanhSach_ID_TangDan()
        {
            if (KiemTraDanhSach(DanhSachNV))
            {
                Program.XuatMauTrang(" >> Xuat danh sach theo ID tang dan\n");
                DanhSachNV.Sort(
                    delegate (NhanVien nv1, NhanVien nv2)
                    {
                        return nv1.ID.CompareTo(nv2.ID);
                    });
                XuatDanhSach_ThongBao();
            }
            else
            {
                Program.XuatMauTrang("\n  Danh sach hien tai rong\n");
            }
        }

        public void Xoa()
        {
            Menu.TaoHeader(10, "XOA NHAN VIEN");
            string Maso;
            XuatDanhDach();
            if (KiemTraDanhSach(DanhSachNV))
            {
                Console.Write("\n >> Nhap ID nhan vien muon xoa: ");
                Maso = Console.ReadLine();
                NhanVien KetQua = DanhSachNV.Find(delegate (NhanVien nv)
                {
                    return nv.ID == Maso;
                });
                if (KetQua == null)
                    Program.XuatMauDo("\n  Khong tim thay nhan vien\n");
                else
                {
                    DanhSachNV.Remove(KetQua);
                    Program.XuatMauXanh("\n  Xoa thanh cong\n");
                }
            }
        }

        public void Sua()
        {
            string Maso;
            int LuaChon = 0;
            Menu.TaoHeader(6, "SUA THONG TIN NHAN VIEN");
            Console.WriteLine();
            XuatDanhSach_ChiTiet();
            if (KiemTraDanhSach(DanhSachNV))
            {
                Console.Write(" >> Nhap ID nhan vien muon sua: ");
                Maso = Console.ReadLine();
                Console.WriteLine();
                NhanVien KetQua = DanhSachNV.Find(delegate (NhanVien nv)
                {
                    return nv.ID == Maso;
                });
                if (KetQua != null)
                {
                    switch (nv.ViTri)
                    {
                        case "NVKD":
                            {
                                Menu.XuatMenu131();
                                Console.WriteLine();
                                LuaChon = Menu.HoiYeuCau(8, "Chon thong tin can sua: ");
                                Console.WriteLine(); break;
                            }
                        case "NVVP":
                        case "NVKT":
                            {
                                Menu.XuatMenu132();
                                Console.WriteLine();
                                LuaChon = Menu.HoiYeuCau(7, "Chon thong tin can sua: ");
                                Console.WriteLine(); break;
                            }
                    }
                    KetQua.SuaThongTin(LuaChon);
                    Console.Clear();
                    Program.XuatMauTrang("THONG TIN NHAN VIEN SAU CHINH SUA\n");
                    KetQua.XuatThongTinChiTiet();
                }
                else
                    Program.XuatMauDo("  Khong tim thay nhan vien\n");
            }
        }

        public void DocFile(string DuongDan)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(@DuongDan);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts[6].Trim(' ') == "NVKD")
                    {
                        nv = new NhanVienKinhDoanh();
                        nv.ThemTuMang(parts);
                    }
                    else if (parts[6].Trim(' ') == "NVVP")
                    {
                        nv = new NhanVienVanPhong();
                        nv.ThemTuMang(parts);
                    }
                    else if (parts[6].Trim(' ') == "NVKT")
                    {
                        nv = new NhanVienKeToan();
                        nv.ThemTuMang(parts);
                    }
                    DanhSachNV.Add(nv);
                }
                Program.XuatMauXanh("\n  Doc file thanh cong\n");
            }
            catch
            {
                Program.XuatMauDo("\n  Doc file that bai\n");
            }
        }

        public void NhapDuongDanDocFile()
        {
            Menu.TaoHeader(10, "THEM DU LIEU");
            Console.Write(" >> Nhap duong dan file: ");
            string DuongDan = Console.ReadLine();
            int KiemTra = KiemTraFile(DuongDan);
            if (KiemTra == 0)
            {
                Program.XuatMauDo("\n  File hien tai rong\n");
            }
            else if (KiemTra == 1)
                DocFile(DuongDan);
        }

        public void LuuFile(string DuongDan)
        {
            List<string> list = new List<string>();
            try
            {
                foreach (NhanVien nv in DanhSachNV)
                    list.Add(nv.ToStringFile());
                File.WriteAllLines(DuongDan, list);
                Program.XuatMauXanh("\n  Luu file thanh cong\n");
            }
            catch
            {
                Program.XuatMauDo("\n  Luu file that bai\n");
            }
        }

        public void NhapDuongDanLuuFile()
        {
            Menu.TaoHeader(10, "LUU DU LIEU");
            Console.Write(" >> Nhap duong dan file: ");
            string DuongDan = Console.ReadLine();
            if (KiemTraFile(DuongDan) == -1)
            {
                Program.XuatMauTrang("\n >> Ban co muon tao file moi khong\n");
                Console.Write(" 1. Co       2. Khong\n");
                int LuaChon = Menu.HoiYeuCau(2, "Tra loi: ");
                if (LuaChon == 1)
                    LuuFile(DuongDan);
            }
            else if (KiemTraFile(DuongDan) == 1)
            {
                Program.XuatMauTrang("\n  File hien tai dang chua du lieu\n");
                Program.XuatMauTrang("\n >> Ban co muon thay the du lieu cu khong\n");
                Console.Write(" 1. Co       2. Khong\n");
                int LuaChon = Menu.HoiYeuCau(2, "Tra loi: ");
                if (LuaChon == 1)
                    LuuFile(DuongDan);
            }
            else
                LuuFile(DuongDan);
        }

        public void XuatHeader()
        {
            Program.XuatMauTrang("ID".PadRight(10, ' ') + "HoTen".PadRight(22, ' ') + "GioiTinh".PadRight(11, ' ') + "NTNSinh".PadRight(13, ' ') + "ViTri".PadRight(10, ' ') + "LuongCoBan".PadRight(14, ' ') + "Them".PadRight(12, ' ') + "Luong" + "\n");
        }

        public override string ToString()
        {
            return "ID".PadRight(10, ' ') + "HoTen".PadRight(22, ' ') + "GioiTinh".PadRight(11, ' ') + "NTNSinh".PadRight(13, ' ') + "ViTri".PadRight(10, ' ') + "LuongCoBan".PadRight(14, ' ') + "Them".PadRight(12, ' ') + "Luong" + "\n";
        }

        public int KiemTraFile(string DuongDan)
        {
            try
            {
                if (new FileInfo(@DuongDan).Length == 0)
                    return 0;
                return 1;
            }
            catch
            {
                Program.XuatMauDo("\n  File khong ton tai\n");
                return -1;
            }
        }

        public bool KiemTraDanhSach(List<NhanVien> DanhSachNV)
        {
            if (DanhSachNV.Count == 0)
                return false;
            return true;
        }

        public void XuatKetQua(List<NhanVien> KetQua)
        {
            if (KetQua.Count != 0)
            {
                XuatHeader();
                foreach (NhanVien nv in KetQua)
                    nv.xuat();
            }
            else
                Program.XuatMauDo("  Khong tim thay nhan vien\n");
        }

        public string TachTen(string Hoten)
        {
            string[] arr = Hoten.Split(' ');
            int N = arr.Length;
            return arr[N - 1];
        }
    }
}
