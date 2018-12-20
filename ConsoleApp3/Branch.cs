using System;

namespace BTL
{
    static class Branch
    {
        static void PrintAt(string s, int level)
        {

            Console.SetCursorPosition(60, 3 + level);
            Program.XuatMauTrang(s);
        }
        static void ShowBranch(string ID)
        {
            switch (ID)
            {
                case "":
                    PrintAt("o", ID.Length - 2);
                    PrintAt("|", ID.Length - 1);
                    PrintAt("|_ QUAN LY NHAN SU", ID.Length);
                    break;
                case "1":
                    PrintAt("|", ID.Length * 2 - 1);
                    PrintAt("|_ THONG TIN NHAN VIEN", ID.Length * 2);
                    break;
                case "2":
                    PrintAt("|", ID.Length * 2 - 1);
                    PrintAt("|_ THONG TIN SU KIEN", ID.Length * 2);
                    break;
                case "21":
                    PrintAt("|", ID.Length * 2 - 1);
                    PrintAt("|_ THEM SU KIEN", ID.Length * 2);
                    break;
                case "24":
                    PrintAt("|", ID.Length * 2 - 1);
                    PrintAt("|_ TIM SU KIEN", ID.Length * 2);
                    break;
                case "25":
                    PrintAt("|", ID.Length * 2 - 1);
                    PrintAt("|_ XUAT SU KIEN", ID.Length * 2);
                    break;

            }
        }
        static public void ShowTree(string ID)
        {
            Program.XuatMauTrang("\n -".PadRight(61, '-'));
            if (ID == "") ShowBranch(ID);
            else
            {
                char[] IDchar = ID.ToCharArray();
                int IDlength = IDchar.Length;
                string realID = "";
                ShowBranch(realID);
                for (int i = 1; i <= IDlength; i++)
                {
                    realID = "";
                    for (int j = 0; j < i; j++)
                    {
                        realID += IDchar[j].ToString();
                    }
                    ShowBranch(realID);
                }
            }
            Console.SetCursorPosition(0, 0);
        }
    }
}