using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace BTL
{
    class DanhSachSK
    {
        public List<SuKien> DSSK = new List<SuKien>();
        public int TongSoSK
        {
            get { return DSSK.Count; }
        }
        public void Them()
        {
            SuKien SK;
            int soluong = Menu.HoiYeuCau(9999, "Nhap so luong su kien: ");
            for (int i = 0; i < soluong; i++)
            {
                Menu.TaoHeader(10, "SU KIEN " + (i + 1).ToString());
                Console.Write("  1. Cuoc hop    2. Hoi thao\n\n");
                int chon = Menu.HoiYeuCau(2, "Chon loai su kien: ");
                if (chon == 1) SK = new CuocHop();
                else SK = new HoiThao();
                try
                {
                    SK.Nhap();
                    DSSK.Add(SK);
                }
                catch { Program.XuatMauDo("    Them that bai!\n"); }
            }
        }
        public void ThemTuFile(string path)
        {
            CuocHop CH;
            HoiThao HT;

            string[] lines = File.ReadAllLines(path);
            if (lines != null)
            {
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    int j = parts.Length;
                    for (int i = 0; i < j; i++) parts[i] = parts[i].Trim();
                    if (parts[1] == "Cuoc hop")
                    {
                        CH = new CuocHop();
                        CH.ThemTuMang(parts);
                        DSSK.Add(CH);
                    }
                    else if (parts[1] == "Hoi thao")
                    {
                        HT = new HoiThao();
                        HT.ThemTuMang(parts);
                        DSSK.Add(HT);
                    }
                }
            }
        }
        public void ThemTuFile_KemThongBao()
        {
            Console.Write(" >> Nhap duong dan file text: ");
            try
            {
                ThemTuFile(Console.ReadLine());
                Program.XuatMauXanh("    Them thanh cong!\n");
            }
            catch { Program.XuatMauDo("    Them that bai!\n"); }
        }
        public SuKien Tim_MaSo(string prompt)
        {
            if (Rong()) return null;
            Program.XuatMauTrang(" >> " + prompt);
            string maso = Console.ReadLine();
            SuKien suKien = DSSK.Find(sk => sk.Maso == maso);
            if (suKien != null)
            {
                if (suKien.Loai == "Cuoc hop") XuatHeader_CH();
                else XuatHeader_HT();
                suKien.Xuat();
                return suKien;
            }
            XuatKhongTimThay();
            return null;
        }
        public void Tim_Thang()
        {
            if (!Rong())
            {
                int thang = Menu.HoiYeuCau(12, "Nhap thang can tim: ");
                bool timthay = false;
                int count = 0;
                foreach (SuKien sk in DSSK)
                    if (sk.NgayGio.Month == thang)
                    {
                        timthay = true; break;
                    }
                if (timthay)
                {
                    XuatHeader();
                    foreach (SuKien sk in DSSK)
                        if (sk.NgayGio.Month == thang)
                        {
                            sk.Xuat();
                            count++;
                        }
                    Program.XuatMauTrang(" Tong: " + count + "\n");
                }
                else Program.XuatMauDo("    Khong tim thay!\n");
            }
        }
        public void Tim_Nam()
        {
            if (!Rong())
            {
                int nam = Menu.HoiYeuCau(9999, "Nhap nam can tim: ");
                bool timthay = false;
                int count = 0;
                foreach (SuKien sk in DSSK)
                    if (sk.NgayGio.Year == nam)
                    {
                        timthay = true; break;
                    }
                if (timthay)
                {
                    XuatHeader();
                    foreach (SuKien sk in DSSK)
                        if (sk.NgayGio.Year == nam)
                        {
                            sk.Xuat();
                            count++;
                        }
                    Program.XuatMauTrang(" Tong: " + count + "\n");
                }
                else Program.XuatMauDo("    Khong tim thay!\n");
            }
        }
        public void Tim_DiaDiem()
        {
            if (!Rong())
            {
                Console.Write(" >> Nhap dia diem can tim: ");
                string dd = Console.ReadLine();
                bool timthay = false;
                int count = 0;
                foreach (SuKien sk in DSSK)
                    if (sk.DiaDiem == dd)
                    {
                        timthay = true; break;
                    }
                if (timthay)
                {
                    XuatHeader();
                    foreach (SuKien sk in DSSK)
                        if (sk.DiaDiem == dd)
                        {
                            sk.Xuat();
                            count++;
                        }
                    Program.XuatMauTrang(" Tong: " + count + "\n");
                }
                else Program.XuatMauDo("    Khong tim thay!\n");
            }
        }
        public void Xoa()
        {
            SuKien sk = Tim_MaSo("Nhap ma so su kien can xoa: ");
            if (sk != null)
            {
                Console.WriteLine("\n    1. Co      2. Khong");
                int x = Menu.HoiYeuCau(2, "Ban muon xoa su kien nay: ");
                if (x == 1 && DSSK.Remove(sk)) Program.XuatMauXanh("    Xoa thanh cong!\n");
            }
        }
        public void Sua()
        {
            SuKien sk = Tim_MaSo("Nhap ma so su kien can sua: ");
            if (sk != null)
            {
                try
                {
                    sk.Sua();
                    Program.XuatMauXanh("    Da sua thong tin!\n");
                    if (sk.Loai == "Cuoc hop") XuatHeader_CH();
                    else XuatHeader_HT();
                    sk.Xuat();
                }
                catch { Program.XuatMauDo("    Loi! Khong the sua!\n"); }

            }
        }
        void XuatKhongTimThay() { Program.XuatMauDo("    Khong tim thay su kien!\n"); }
        public void XuatDS()
        {
            if (!Rong())
            {
                Console.WriteLine(" Tong su kien: " + TongSoSK.ToString());
                XuatHeader();
                foreach (SuKien SK in DSSK) SK.Xuat();
            }
        }
        void SortMaSo()
        {
            DSSK.Sort(delegate (SuKien sk1, SuKien sk2)
            {
                return sk1.Maso.CompareTo(sk2.Maso);
            });
        }
        void SortNgay()
        {
            DSSK.Sort(delegate (SuKien sk1, SuKien sk2)
            {
                int ss = sk1.NgayGio.Year.CompareTo(sk2.NgayGio.Year);
                if (ss == 0)
                {
                    int ss2 = sk1.NgayGio.Month.CompareTo(sk2.NgayGio.Month);
                    if (ss2 == 0) return sk1.NgayGio.Day.CompareTo(sk2.NgayGio.Day);
                    return ss2;
                }
                return ss;
            });
        }
        public void XuatTheoMaSo()
        {
            if (!Rong())
            {
                DanhSachSK DSdem = new DanhSachSK();
                foreach (SuKien sk in DSSK) DSdem.DSSK.Add(sk);
                DSdem.SortMaSo();
                DSdem.XuatDS();
                HoiChepDeDanhSach(DSdem);
            }
        }
        public void XuatTheoNgay()
        {
            if (!Rong())
            {
                DanhSachSK DSdem = new DanhSachSK();
                foreach (SuKien sk in DSSK) DSdem.DSSK.Add(sk);
                DSdem.SortNgay();
                DSdem.XuatDS();
                HoiChepDeDanhSach(DSdem);
            }
        }
        public void HoiChepDeDanhSach(DanhSachSK DSdem)
        {
            Console.WriteLine("\n    1. Co            2. Khong");
            int x = Menu.HoiYeuCau(2, "Xep danh sach hien tai theo thu tu nay: ");
            if (x == 1)
            {
                DSSK = DSdem.DSSK;
                Program.XuatMauXanh("    Xep thanh cong!\n");
            }
        }
        public void XuatFileTxt()
        {
            if (!Rong())
            {
                Program.XuatMauTrang(" >> Nhap ten file text: ");
                string path = Console.ReadLine() + ".txt";
                try
                {
                    List<string> DSdem = new List<string>();
                    foreach (SuKien sk in DSSK) DSdem.Add(sk.ToStringFile());
                    File.WriteAllLines(path, DSdem);
                    Program.XuatMauXanh("    Tao file thanh cong!\n");
                }
                catch { Program.XuatMauDo("    Xuat file that bai!\n"); }
            }
        }
        bool Rong()
        {
            if (TongSoSK != 0) return false;
            Program.XuatMauDo("    Danh sach rong!\n");
            return true;
        }
        void XuatHeader()
        {
            Program.XuatMauTrang("\n " + "MA SO".PadRight(9, ' ') + "LOAI".PadRight(12, ' ') + "TEN SU KIEN".PadRight(25, ' ') + "NGAY".PadRight(14, ' ')
            + "GIO".PadRight(12, ' ') + "DIA DIEM".PadRight(12, ' ') + "VIP".PadRight(12, ' ') + "KHAC\n");
        }
        void XuatHeader_CH()
        {
            Program.XuatMauTrang("\n " + "MA SO".PadRight(9, ' ') + "LOAI".PadRight(12, ' ') + "TEN SU KIEN".PadRight(25, ' ') + "NGAY".PadRight(14, ' ')
            + "GIO".PadRight(12, ' ') + "DIA DIEM".PadRight(12, ' ') + "CHU TRI".PadRight(12, ' ') + "THOI LUONG\n");
        }
        void XuatHeader_HT()
        {
            Program.XuatMauTrang("\n " + "MA SO".PadRight(9, ' ') + "LOAI".PadRight(12, ' ') + "TEN SU KIEN".PadRight(25, ' ') + "NGAY".PadRight(14, ' ')
            + "GIO".PadRight(12, ' ') + "DIA DIEM".PadRight(12, ' ') + "DIEN GIA".PadRight(12, ' ') + "SO LUONG\n");
        }
    }
}