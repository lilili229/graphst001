using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Do_An_Graph
{
    class Program
    {
    /*    static void Effect(EText[] ET)
        {
            Console.CursorVisible = false;
            string[] str = new string[]
             {           @" _    _  _____  __    __",
                       @"| |  | ||  ___||  |  |  |",
                       @"| |  | || |__  |  |__|  |",
                       @"| |  | ||  __| |   __   |",
                       @"\ \__/ /| |___ |  |  |  |",
                       @" \____/ |_____||__|  |__|" };


            int n = str.Length;
            ET = new EText[n];
            int w, e,i;
            w = 15;
            e = 8;
            for (i = 0; i < n; i++)
            {
                ET[i] = new EText(str[i], w, e + i);
            }
            while(i <= 30)
            {
                foreach (EText et in ET)
                {
                    et.ve();
                }
            }
        }*/
        public static void Main(string[] args)
        {
            Console.Clear();
            
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Graph theGraph = new Graph();
            theGraph.AddVertex(new Location("1", 10.782967f, 106.6926484f, "Đại Học UEH Cơ Sở A", "Hồ Chí Minh", "3")); //0
            theGraph.AddVertex(new Location("2", 10.760905f, 106.6657665f, "Đại Học UEH Cơ Sở B", "Hồ Chí Minh", "10")); //1
            theGraph.AddVertex(new Location("3", 10.773177f, 106.6753573f, "Đại Học UEH Cơ Sở C", "Hồ Chí Minh", "10")); //2
            theGraph.AddVertex(new Location("4", 10.791699f, 106.6862103f, "Đại Học UEH Cơ Sở D", "Hồ Chí Minh", "1")); //3
            theGraph.AddVertex(new Location("5", 10.790476f, 106.6971515f, "Đại Học UEH Cơ Sở E", "Hồ Chí Minh", "1")); //4
            theGraph.AddVertex(new Location("6", 10.760462f, 106.6700192f, "Đại Học UEH Cơ Sở H", "Hồ Chí Minh", "Phú Nhuận")); //5
            theGraph.AddVertex(new Location("7", 10.782586f, 106.6932257f, "Đại Học UEH Cơ Sở I", "Hồ Chí Minh", "3")); //6
            theGraph.AddVertex(new Location("8", 10.781823f, 106.6851013f, "Đại Học UEH Cơ Sở V", "Hồ Chí Minh", "3")); //7
            theGraph.AddVertex(new Location("9", 10.722329f, 106.6194257f, "Đại Học UEH Cơ Sở GDTC", "Hồ Chí Minh", "8")); //8
            theGraph.AddVertex(new Location("10", 10.705942f, 106.6379664f, "Đại Học UEH Cơ Sở N", "Hồ Chí Minh", "Bình Chánh")); //9

            theGraph.AddEdge(0, 1, 4); theGraph.AddEdge(0, 3, 1);
            theGraph.AddEdge(1, 2, 2); theGraph.AddEdge(1, 6, 4); theGraph.AddEdge(1, 4, 5);
            theGraph.AddEdge(2, 6, 3); theGraph.AddEdge(2, 5, 5);
            theGraph.AddEdge(3, 4, 2); theGraph.AddEdge(3, 7, 2);
            theGraph.AddEdge(4, 6, 1); theGraph.AddEdge(4, 9, 15);
            theGraph.AddEdge(6, 8, 12); theGraph.AddEdge(6, 5, 3);
            theGraph.AddEdge(5, 8, 14); theGraph.AddEdge(5, 9, 17);
            theGraph.AddEdge(7, 9, 15);
            theGraph.AddEdge(8, 9, 16);

            
            // Console.WriteLine("Shortest paths:");
            // Console.WriteLine();

            // Console.WriteLine();
            //--------------------------------------------------------------------------------------------------------
            //    EText[] ET = new EText[30];
            //    Effect(ET);
            //    Console.SetWindowSize(100, 40);
                Console.WriteLine("{0,56}", "ĐỒ ÁN: CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT");
                Console.WriteLine("{0,48}", "CHỦ ĐỀ: ĐỒ THỊ ĐỊA ĐIỂM");
                Console.WriteLine("{0,46}", "*****************\n");
                Console.WriteLine("{0,34}\t{1,20}", "DANH SÁCH NHÓM:", "TRẦN HOÀNG THANH THY");
                Console.WriteLine("{0,58}{1,88}", "NGUYỄN THỊ THẢO LY", "LÂM THỊ YẾN DƯƠNG");
                Console.WriteLine("{0,58}{1,91}", "NGUYỄN LA HUỆ UYÊN", "PHẠM LÊ PHƯƠNG TRINH");
                Console.WriteLine(">> Danh sách địa điểm:\n");
                theGraph.ShowVerts();   Console.WriteLine("------------------------------------------------\n");

                Console.WriteLine("Option 1: Tìm đường đi ngắn nhất");
                Console.WriteLine("Option 2: Tìm kiếm địa điểm theo thuật toán Depth First Search");
                Console.WriteLine("Option 3: Tìm kiếm địa điểm theo thuật toán Breadth First Search");
                Console.WriteLine("Nhập vào option:");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Điểm xuất phát: Đại Học UEH Cơ Sở A");
                        Console.WriteLine("Nhập vào điểm đến theo ký hiệu tên cơ sở:\nVí dụ: Đại Học UEH Cơ Sở A -> Nhập 'A'");
                        string cs = Console.ReadLine();
                        theGraph.DisplayPaths2(cs);
                        break;

                }
            Console.ReadLine();
        }
    }
}
