using System;
using System.Threading;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace BTL
{
    class Program
    {
        public static bool tinhTrangLuuDSNV = true; //true da dc luu, false chua dc luu
        public static bool tinhTrangLuuDSSK = true;
        string pathSaveFileNV = "save/NV.sav";
        string pathSaveFileSK = "save/SK.sav";
        void KhoiDong(DSNV DSNV, DanhSachSK DSSK)
        {
            Console.CursorVisible = false;

            ThietLapUI();
            KiemTraFileSave(DSNV, DSSK);

            Console.CursorVisible = true;
        }
        void ThietLapUI()
        {
            Console.SetWindowSize(110, 20);
            Console.SetCursorPosition(40, 3);
            XuatMauTrang(" CHUONG TRINH QUAN LY NHAN SU");
            Console.SetCursorPosition(42, 4);
            Console.WriteLine("---- BAI TAP LON  OOP ----");
            Thread.Sleep(3000);
        }
        public static void XuatMauDo(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void XuatMauTrang(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text);
            Console.ResetColor();
        }
        public static void XuatMauXanh(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(text);
            Console.ResetColor();
        }
        void KiemTraFileSave(DSNV DSNV, DanhSachSK DSSK)
        {
            try
            {
                DSNV.DocFile(pathSaveFileNV);
                DSSK.ThemTuFile(pathSaveFileSK);
            }
            catch
            {
                Console.SetCursorPosition(42, 6);
                XuatMauDo("  Tai file luu that bai!");
                Thread.Sleep(3000);
            }
        }
        void LuuFileNV_CoThongBao(DSNV DSNV)
        {
            Menu.TaoHeader(8, "Luu File");
            Console.WriteLine("    1. Co     2. Khong\n");
            int y = Menu.HoiYeuCau(2, "Luu danh sach hien tai: ");
            if (y == 1)
            {
                if (DSNV.KiemTraFile(pathSaveFileNV) == -1)
                {
                    Program.XuatMauTrang("\n >> Ban co muon tao file moi khong\n");
                    Console.Write(" 1. Co       2. Khong\n");
                    int LuaChon = Menu.HoiYeuCau(2, "Tra loi: ");
                    if (LuaChon == 1)
                        DSNV.LuuFile(pathSaveFileNV);
                }
                else if (DSNV.KiemTraFile(pathSaveFileNV) == 1)
                {
                    Program.XuatMauTrang("\n  File hien tai dang chua du lieu\n");
                    Program.XuatMauTrang("\n >> Ban co muon thay the du lieu cu khong\n");
                    Console.Write(" 1. Co       2. Khong\n");
                    int LuaChon = Menu.HoiYeuCau(2, "Tra loi: ");
                    if (LuaChon == 1)
                        DSNV.LuuFile(pathSaveFileNV);
                }
                else
                    DSNV.LuuFile(pathSaveFileNV);
            }
        }
        void LuuFileNV(DSNV DSNV)
        {
            List<string> DSdem = new List<string>();
            foreach (NhanVien nv in DSNV.DanhSachNV)
                DSdem.Add(nv.ToStringFile());
            File.WriteAllLines(pathSaveFileNV, DSdem);
            tinhTrangLuuDSSK = true;
        }
        void LuuFileSK_CoThongBao(DanhSachSK DSSK)
        {
            Console.WriteLine("    1. Co     2. Khong");
            int y = Menu.HoiYeuCau(2, "Luu danh sach hien tai: ");
            if (y == 1)
            {
                try
                {
                    LuuFileSK(DSSK);
                    XuatMauXanh("    Luu thanh cong!\n");
                }
                catch { XuatMauDo("    Luu that bai!\n"); }
            }
        }
        void LuuFileSK(DanhSachSK DSSK)
        {
            List<string> DSdem = new List<string>();
            foreach (SuKien sk in DSSK.DSSK) DSdem.Add(sk.ToStringFile());
            File.WriteAllLines(pathSaveFileSK, DSdem);
            tinhTrangLuuDSSK = true;
        }
        bool ChuyenMenu(Menu menu)  //Reflection here
        {
            MethodInfo menuChucNang = (typeof(Menu)).GetMethod("XuatMenu" + menu.ID);
            if (menuChucNang == null) return false;
            menuChucNang.Invoke(menu, null);
            return true;
        }
        void ThongBaoChucNangKhongTonTai()
        {
            Console.Clear();
            XuatMauDo("\n    Chuc nang khong ton tai!\n");
        }
        void ThongBaoKetThucChucNang(string prompt)
        {
            Console.CursorVisible = false;
            XuatMauTrang("\n >> " + prompt);
            Console.ReadKey();
            Console.CursorVisible = true;
        }
        public void ThoatChuongTrinhCoLuu(DSNV DSNV, DanhSachSK DSSK)
        {
            try
            {
                if (!tinhTrangLuuDSNV) LuuFileNV(DSNV);
                if (!tinhTrangLuuDSSK) LuuFileSK(DSSK);
                XuatMauXanh("    Luu thanh cong!\n");
            }
            catch { XuatMauDo("    Luu that bai!\n"); }
            ThongBaoKetThucChucNang("Nhan phim bat ki de thoat");
            Environment.Exit(0);
        }
        void ChayChucNang(string ID, DSNV DSNV, DanhSachSK DSSK)
        {
            if (ID[ID.Length - 1] == 'x') ThoatChuongTrinhCoLuu(DSNV, DSSK);

            Console.Clear();
            Console.WriteLine();
            if (ID[0] == '1') ChayChucNangNhanVien(ID, DSNV);
            else if (ID[0] == '2') ChayChucNangSuKien(ID, DSSK);
            ThongBaoKetThucChucNang("Nhan phim bat ki de tiep tuc");
        }
        void ChayChucNangNhanVien(string ID, DSNV DSNV)
        {
            switch (ID)
            {
                case "111": DSNV.Them(); break;
                case "112": DSNV.NhapDuongDanDocFile(); break;
                case "12": DSNV.Xoa(); break;
                case "13": DSNV.Sua(); break;
                case "141": DSNV.TimNhanVienTheoID(); break;
                case "142": DSNV.TimNhanVienTheoTen(); break;
                case "143": DSNV.TimNhanVienTheoGioiTinh(); break;
                case "144": DSNV.TimNhanVienTheoViTri(); break;
                case "151": DSNV.XuatDanhSach_ThongBao(); break;
                case "152": DSNV.XuatDanhSach_ChiTiet_ThongBao(); break;
                case "153": DSNV.XuatDanhSach_ID_TangDan(); break;
                case "154": DSNV.XuatDanhSach_Ten_BangChuCai(); break;
                case "155": DSNV.XuatDanhSach_Luong_TangDan(); break;
                case "16": LuuFileNV_CoThongBao(DSNV); break;
                default: ThongBaoChucNangKhongTonTai(); break;
            }
            KiemtraThayDoiDuLieuDSNV(ID);
        }
        void ChayChucNangSuKien(string ID, DanhSachSK DSSK)
        {
            switch (ID)
            {
                case "22": DSSK.Xoa(); break;
                case "211": DSSK.Them(); break;
                case "212": DSSK.ThemTuFile_KemThongBao(); break;
                case "23": DSSK.Sua(); break;
                case "241": DSSK.Tim_MaSo("Nhap ma so su kien can tim: "); break;
                case "242": DSSK.Tim_Thang(); break;
                case "243": DSSK.Tim_Nam(); break;
                case "244": DSSK.Tim_DiaDiem(); break;
                case "251": DSSK.XuatDS(); break;
                case "252": DSSK.XuatTheoMaSo(); break;
                case "253": DSSK.XuatTheoNgay(); break;
                case "254": DSSK.XuatFileTxt(); break;
                case "26": LuuFileSK_CoThongBao(DSSK); break;
                default: ThongBaoChucNangKhongTonTai(); break;
            }
            KiemtraThayDoiDuLieuDSSK(ID);

        }
        void KiemtraThayDoiDuLieuDSNV(string ID)
        {
            string[] ChucNangThayDoiDuLieu = { "111", "112", "12", "13" };
            foreach (string cn in ChucNangThayDoiDuLieu)
                if (ID == cn)
                {
                    tinhTrangLuuDSNV = false;
                    break;
                }
        }
        void KiemtraThayDoiDuLieuDSSK(string ID)
        {
            string[] ChucNangThayDoiDuLieu = { "22", "211", "212", "23" };
            foreach (string cn in ChucNangThayDoiDuLieu)
                if (ID == cn)
                {
                    tinhTrangLuuDSSK = false;
                    break;
                }
        }

        static void Main()
        {
            Program chuongTrinh = new Program();
            Menu menu = new Menu();
            DSNV DSNV = new DSNV();
            DanhSachSK DSSK = new DanhSachSK();

            chuongTrinh.KhoiDong(DSNV, DSSK);

            while (true)
            {
                if (!chuongTrinh.ChuyenMenu(menu))
                {
                    chuongTrinh.ChayChucNang(menu.ID, DSNV, DSSK);
                    menu.LuiMenuID();
                }
            }
        }
    }
}

