using System;

namespace BTL
{
    class Menu
    {
        public string ID;
        public Menu(string ID = "")
        {
            this.ID = ID;
        }
        public void XuatMenu()
        {
            ID = "";
            Console.Clear();
            Branch.ShowTree(ID);
            TaoHeader(6, "QUAN LY NHAN SU");
            Console.WriteLine("  1. Thong tin Nhan vien");
            Console.WriteLine("  2. Thong tin Su kien");
            Console.WriteLine("\n  x. Thoat\n");
            LayYeuCau(2);
        }
        public void XuatMenu1()
        {
            ID = "1";
            Console.Clear();
            Branch.ShowTree(ID);
            TaoHeader(6, "THONG TIN NHAN VIEN");
            Console.WriteLine("  1. Them         4. Tim");
            Console.WriteLine("  2. Xoa          5. Xuat");
            Console.WriteLine("  3. Sua          6. Luu");
            Console.WriteLine("\n  q. Tro lai      x. Thoat\n");
            LayYeuCau(6);
        }
        public void XuatMenu11()
        {
            ID = "11";
            Console.Clear();
            TaoHeader(6, "THEM NHAN VIEN");
            Console.WriteLine("  1. Nhap tu ban phim");
            Console.WriteLine("  2. Them tu file");
            Console.WriteLine("\n  q. Tro lai      x. Thoat\n");
            LayYeuCau(2);
        }
        public void XuatMenu14()
        {
            ID = "14";
            Console.Clear();
            TaoHeader(7, "TIM KIEM NHAN VIEN");
            Branch.ShowTree(ID);
            TaoHeader(6, "TIM KIEM NHAN VIEN");
            Console.WriteLine("  1. ID");
            Console.WriteLine("  2. Ten");
            Console.WriteLine("  3. Gioi tinh");
            Console.WriteLine("  4. Vi tri");
            Console.WriteLine("\n  q. Tro lai      x. Thoat\n");
            LayYeuCau(4);
        }
        public static void XuatMenu131()
        {
            Console.WriteLine("  1. ID                 5. So dien thoai");
            Console.WriteLine("  2. Ho va Ten          6. Email");
            Console.WriteLine("  3. Gioi tinh          7. Luong co ban");
            Console.WriteLine("  4. Ngay sinh          8. Doanh so");
        }
        public static void XuatMenu132()
        {
            Console.WriteLine("  1. ID                 5. So dien thoai");
            Console.WriteLine("  2. Ho va Ten          6. Email");
            Console.WriteLine("  3. Gioi tinh          7. Luong");
            Console.WriteLine("  4. Ngay sinh          ");
        }
        public void XuatMenu15()
        {
            Console.Clear();
            ID = "15";
            TaoHeader(7, "XUAT NHAN VIEN");
            Console.WriteLine("  1. Xuat danh sach hien tai");
            Console.WriteLine("  2. Xuat danh sach chi tiet");
            Console.WriteLine("  3. Xuat danh sach tang dan theo ma so");
            Console.WriteLine("  4. Xuat danh sach tang dan theo bang chu cai");
            Console.WriteLine("  5. Xuat danh sach tang dan theo luong");
            Console.WriteLine("\n  q. Tro lai    x. Thoat\n");
            LayYeuCau(5);
        }
        public void XuatMenu2()
        {
            ID = "2";
            Console.Clear();            
            Branch.ShowTree(ID);
            TaoHeader(6, "THONG TIN SU KIEN");
            Console.WriteLine("  1. Them         4. Tim");
            Console.WriteLine("  2. Xoa          5. Xuat");
            Console.WriteLine("  3. Sua          6. Luu");
            Console.WriteLine("\n  q. Tro lai      x. Thoat\n");
            LayYeuCau(6);
        }
        public void XuatMenu21()
        {
            ID = "21";
            Console.Clear();
            Branch.ShowTree(ID);
            TaoHeader(6, "THEM SU KIEN");
            Console.WriteLine("  1. Nhap tu ban phim");
            Console.WriteLine("  2. Them tu file text");
            Console.WriteLine("\n  q. Tro lai      x. Thoat\n");
            LayYeuCau(2);
        }
        public static void XuatMenu231()
        {
            Console.WriteLine("\n  1. Ten su kien          4. Dia diem");
            Console.WriteLine("  2. Ngay (dd MM yyyy)    5. Chu tri");
            Console.WriteLine("  3. Gio (HH mm)          6. Thoi luong\n");
        }
        public static void XuatMenu232()
        {
            Console.WriteLine("\n  1. Ten su kien          4. Dia diem");
            Console.WriteLine("  2. Ngay (dd MM yyyy)    5. Dien gia");
            Console.WriteLine("  3. Gio (HH mm)          6. So luong\n");
        }

        public void XuatMenu24()
        {
            ID = "24";
            Console.Clear();
            Branch.ShowTree(ID);
            TaoHeader(7, "TIM SU KIEN");
            Console.WriteLine("  1. Ma so      3. Nam");
            Console.WriteLine("  2. Thang      4. Dia diem");
            Console.WriteLine("\n  q. Tro lai    x. Thoat\n");
            LayYeuCau(4);
        }
        public void XuatMenu25()
        {
            ID = "25";
            Console.Clear();
            Branch.ShowTree(ID);
            TaoHeader(15, "XUAT SU KIEN");
            Console.WriteLine("  1. Xuat danh sach hien tai");
            Console.WriteLine("  2. Xuat danh sach theo thu tu ma so");
            Console.WriteLine("  3. Xuat danh sach theo thu tu thoi gian");
            Console.WriteLine("  4. Xuat danh sach thanh file text");
            Console.WriteLine("\n  q. Tro lai    x. Thoat\n");
            LayYeuCau(4);
        }
        public void XuatMenuTHoat()
        {
            Console.Clear();
            if (!Program.tinhTrangLuuDSNV || !Program.tinhTrangLuuDSSK)
            {
                TaoHeader(15, "THOAT?");
                if (!Program.tinhTrangLuuDSNV)
                    Program.XuatMauDo("  Danh sach Nhan vien da bi thay doi!\n");
                if (!Program.tinhTrangLuuDSSK)
                    Program.XuatMauDo("  Danh sach Su kien da bi thay doi!\n");
                Console.WriteLine("\n  1. Luu tat ca va Thoat");
                Console.WriteLine("  2. Khong luu va Thoat\n");
                Console.WriteLine("  3. Tro lai\n");

                int y = HoiYeuCau(3, "Nhap yeu cau: ");
                if (y == 1) ID = ID + "x";
                else if (y == 2) Environment.Exit(0);
            }
            else
            {
                TaoHeader(9, "THOAT?");
                Console.WriteLine("  1. Co");
                Console.WriteLine("  2. Khong\n");

                int y = HoiYeuCau(2, "Nhap yeu cau: ");
                if (y == 1) Environment.Exit(0);
            }
        }
        public static void TaoHeader(int numPad, string header)
        {
            char pad = '-';
            Program.XuatMauTrang("\n " + " ".PadLeft(numPad, pad));
            Program.XuatMauTrang(header);
            Program.XuatMauTrang(" ".PadRight(numPad, pad) + "\n\n");
        }
        string HoiYeuCau(int right)
        {
            int y;
            Program.XuatMauTrang(" >> Nhap yeu cau: ");
            string yeuCau = Console.ReadLine();
            if (yeuCau != "q" && yeuCau != "x" && (!int.TryParse(yeuCau, out y) || y < 1 || y > right))
            {
                do
                {
                    Program.XuatMauDo(" >> Khong hop le. Nhap lai yeu cau: ");
                    yeuCau = Console.ReadLine();
                } while (yeuCau != "q" && yeuCau != "x" && (!int.TryParse(yeuCau, out y) || y < 1 || y > right));
            }
            return yeuCau;
        }
        public static int HoiYeuCau(int right, string prompt)  //use in other classes
        {
            int y;
            Program.XuatMauTrang(" >> " + prompt);
            string yeuCau = Console.ReadLine();
            if ((!int.TryParse(yeuCau, out y) || y < 1 || y > right))
            {
                do
                {
                    Program.XuatMauDo(" >> Khong hop le. Nhap lai yeu cau: ");
                    yeuCau = Console.ReadLine();
                } while ((!int.TryParse(yeuCau, out y) || y < 1 || y > right));
            }
            return y;
        }
        public void LuiMenuID()
        {
            if (ID != "") ID = ID.Remove(ID.Length - 1);
        }
        bool KiemTraKiTu(string y)
        {
            bool isLetter = true;
            if (y == "q") LuiMenuID();
            else if (y == "x") XuatMenuTHoat();
            else isLetter = false;
            return isLetter;
        }
        void LayYeuCau(int right)
        {
            string y = HoiYeuCau(right);
            if (!KiemTraKiTu(y)) ID = ID + y; ;
        }
    }
}