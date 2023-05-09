using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
public class TreeNode
{
    public int id; // ID của nút
    public string ho; // Họ của nút
    public string ten; // Tên của nút
    public string phai; // Giới tính của nút
    public string trangThai; // Trạng thái của nút
    public TreeNode left; // Con trái của nút
    public TreeNode right; // Con phải của nút


    // Hàm khởi tạo cho lớp TreeNode
    public TreeNode(int id, string ho, string ten, string phai, string trangThai)
    {
        this.id = id;
        this.ho = ho;
        this.ten = ten;
        this.phai = phai;
        this.trangThai = trangThai;
        this.left = null;
        this.right = null;
    }
}

public class BinarySearchTree
{
     public TreeNode root; // Gốc của cây nhị phân tìm kiếm

    // Hàm khởi tạo cho lớp BinarySearchTree
    public BinarySearchTree()
    {
        this.root = null;
    }

    // Hàm chèn một nút mới vào cây nhị phân tìm kiếm
    public int Insert(int id, string ho, string ten, string phai, string trangThai)
    {
        Random random = new Random();
        id = random.Next(100000, 999999); // Tạo id ngẫu nhiên từ 100000 đến 999999
        TreeNode newNode = new TreeNode(id, ho, ten, phai, trangThai); // Tạo một nút mới
        if (root == null) // Nếu cây rỗng
        {
            root = newNode; // Đặt nút mới làm gốc của cây
            return id;
        }
        TreeNode current = root; // Bắt đầu từ gốc của cây
        while (true)
        {
            if (id < current.id) // Nếu ID của nút mới nhỏ hơn ID của nút hiện tại
            {
                if (current.left == null) // Nếu con trái của nút hiện tại rỗng
                {
                    current.left = newNode; // Đặt nút mới làm con trái của nút hiện tại
                    break;
                }
                current = current.left; // Di chuyển sang con trái của nút hiện tại
            }
            else if (id > current.id) // Nếu ID của nút mới lớn hơn ID của nút hiện tại
            {
                if (current.right == null) // Nếu con phải của nút hiện tại rỗng
                {
                    current.right = newNode; // Đặt nút mới làm con phải của nút hiện tại
                    break;
                }
                current = current.right; // Di chuyển sang con phải của nút hiện tại
            }
            else // Nếu ID của nút mới trùng với ID của nút hiện tại
            {
                Console.WriteLine("Doc gia co ID {0} da ton tai.", id);
                return id;
            }
        }
        return id;
    }

    // Hàm tìm nút có giá trị nhỏ nhất trong cây con có gốc là node
    private TreeNode FindMinNode(TreeNode node)
    {
        while (node.left != null) // Trong khi con trái của nút hiện tại không rỗng
        {
            node = node.left; // Di chuyển sang con trái của nút hiện tại
        }
        return node; // Trả về nút có giá trị nhỏ nhất
    }
    // Hàm in ra các nút trong cây con có gốc là node theo thứ tự tăng dần của tên
    public void PrintByNameAscending()
    {
        if (root != null) // Nếu cây không rỗng
        {
            List<TreeNode> nodes = new List<TreeNode>();
            BuildNodeList(root, nodes); // Xây dựng danh sách các nút trong cây
            nodes.Sort((a, b) => a.ten.CompareTo(b.ten)); // Sắp xếp danh sách các nút theo thứ tự tên từ A-Z
            PrintNodes(nodes); // In ra danh sách các nút đã sắp xếp
        }
    }

    // Hàm xây dựng danh sách các nút trong cây con có gốc là node
    private void BuildNodeList(TreeNode node, List<TreeNode> nodes)
    {
        if (node.left != null) // Nếu con trái của nút hiện tại không rỗng
        {
            BuildNodeList(node.left, nodes); // Xây dựng danh sách các nút trong cây con có gốc là con trái của nút hiện tại
        }
        nodes.Add(node); // Thêm nút hiện tại vào danh sách
        if (node.right != null) // Nếu con phải của nút hiện tại không rỗng
        {
            BuildNodeList(node.right, nodes); // Xây dựng danh sách các nút trong cây con có gốc là con phải của nút hiện tại
        }
    }

    // Hàm in ra thông tin của các nút trong danh sách
    private void PrintNodes(List<TreeNode> nodes)
    {
        foreach (TreeNode node in nodes)
        {
            Console.WriteLine("ID: {0}, Ho: {1}, Ten: {2}", node.id, node.ho, node.ten); // In ra thông tin của nút
        }
    }

    // Hàm duyệt cây theo thứ tự giữa và lưu kết quả vào danh sách nodes
    private void InOrderTraversal(TreeNode node, List<TreeNode> nodes)
    {
        if (node == null) // Nếu cây rỗng
        {
            return;
        }

        InOrderTraversal(node.left, nodes); // Duyệt cây con có gốc là con trái của nút hiện tại và lưu kết quả vào danh sách nodes
        nodes.Add(node); // Thêm nút hiện tại vào danh sách nodes
        InOrderTraversal(node.right, nodes); // Duyệt cây con có gốc là con phải của nút hiện tại và lưu kết quả vào danh sách nodes
    }
    // Hàm in ra các nút trong cây theo thứ tự tăng dần của ID
    public void PrintByID()
    {
        if (root != null) // Nếu cây không rỗng
        {
            PrintByIDHelper(root); // In ra các nút trong cây có gốc là root
        }
    }

    // Hàm in ra các nút trong cây con có gốc là node theo thứ tự tăng dần của ID
    private void PrintByIDHelper(TreeNode node)
    {
        if (node.left != null) // Nếu con trái của nút hiện tại không rỗng
        {
            PrintByIDHelper(node.left); // In ra các nút trong cây con có gốc là con trái của nút hiện tại
        }
        Console.WriteLine("ID: {0}, Ho: {1}, Ten: {2}", node.id, node.ho, node.ten); // In ra thông tin của nút hiện tại
        if (node.right != null) // Nếu con phải của nút hiện tại không rỗng
        {
            PrintByIDHelper(node.right); // In ra các nút trong cây con có gốc là con phải của nút hiện tại
        }
    }
    public TreeNode Search(int id)
    {
        TreeNode current = root;
        while (current != null)
        {
            if (id == current.id)
            {
                return current;
            }
            else if (id < current.id)
            {
                current = current.left;
            }
            else
            {
                current = current.right;
            }
        }
        return null;
    }
    public string GetTrangThai(int id)
    {
        TreeNode current = root; // Bắt đầu từ gốc của cây
        while (current != null)
        {
            if (id < current.id) // Nếu ID cần tìm nhỏ hơn ID của nút hiện tại
            {
                current = current.left; // Di chuyển sang con trái của nút hiện tại
            }
            else if (id > current.id) // Nếu ID cần tìm lớn hơn ID của nút hiện tại
            {
                current = current.right; // Di chuyển sang con phải của nút hiện tại
            }
            else // Nếu ID cần tìm bằng với ID của nút hiện tại
            {
                return current.trangThai; // Trả về trạng thái của nút hiện tại
            }
        }
        return null; // Trả về null nếu không tìm thấy nút có ID cần tìm trong cây
    }
}


//Sáchhh
public class Sach
{
    public int MaSach { get; private set; } // Mã sách
    public string TenSach { get; set; } // Tên sách
    public string TacGia { get; set; } // Tác giả
    public int NamXuatBan { get; set; } // Năm xuất bản
    public string TheLoai { get; set; } // Thể loại
    public int SoTrang { get; set; } // Số trang
    public int TrangThai { get; set; } // Trạng thái (0: cho mượn được, 1: đã có độc giả mượn, 2: sách đã thanh lý)
    public string ViTri { get; set; } // Vị trí
    public string DocGiaMuon { get; set; } // Tên độc giả mượn sách
    public DateTime NgayMuon { get; set; }
    public DateTime NgayTra { get; set; }
    public int SoLuong { get; set; } //Thêm thuộc tính số lượng sách

    // Hàm khởi tạo cho lớp Sach
    public Sach(string tenSach, string tacGia, int namXuatBan, int soTrang, string theLoai, string viTri, int trangThai, string docGiaMuon = null)
    {
        MaSach = new Random().Next(100000, 999999); // Tạo một mã sách ngẫu nhiên
        TenSach = tenSach;
        TacGia = tacGia;
        NamXuatBan = namXuatBan;
        TheLoai = theLoai;
        SoTrang = soTrang;
        TrangThai = trangThai;
        ViTri = viTri;
        DocGiaMuon = docGiaMuon;
    }

}

public class Node
{
    public Sach data; // Dữ liệu của nút (một đối tượng Sach)
    public Node next; // Con trỏ tới nút tiếp theo

    // Hàm khởi tạo cho lớp Node
    public Node(Sach data)
    {
        this.data = data;
        this.next = null;
    }
}

public class ThuVien
{
    public Node head = null; // Đầu của danh sách liên kết
    BinarySearchTree bst = new BinarySearchTree();
    private string maDocGia;

    // Mảng lưu trữ các mã sách mà độc giả muốn mượn
    private string[] maSachMuon = new string[3];
    public void NhapThongTinMuonSach()
    {
        Console.Write("Nhap ma doc gia: ");
        maDocGia = Console.ReadLine();

        Console.WriteLine("Nhap cac ma sach muon (toi da 3 cuon): ");
        for (int i = 0; i < maSachMuon.Length; i++)
        {
            Console.Write("Nhap ma sach muon thu {0} (nhap 'q' de ket thuc): ", i + 1);
            string maSach = Console.ReadLine();
            if (maSach == "q")
            {
                break;
            }
            maSachMuon[i] = maSach;
        }
    }

    // Hàm thêm một cuốn sách mới vào thư viện
    public Sach ThemSach()
    {
        Console.Write("Nhap ten sach: ");
        string tenSach = Console.ReadLine();
        Console.Write("Nhap tac gia: ");
        string tacGia = Console.ReadLine();
        Console.Write("Nhap nam xuat ban: ");
        int namXuatBan = int.Parse(Console.ReadLine());
        Console.Write("Nhap so trang: ");
        int soTrang = int.Parse(Console.ReadLine());
        Console.Write("Nhap the loai: ");
        string theLoai = Console.ReadLine();
        Console.Write("Nhap trang thai: ");
        int trangThai = int.Parse(Console.ReadLine());
        Console.Write("Nhap vi tri: ");
        string viTri = Console.ReadLine();
        Sach sach = new Sach(tenSach, tacGia, namXuatBan, soTrang, theLoai, viTri, trangThai); // Tạo một đối tượng Sach mới
        Node newNode = new Node(sach); // Tạo một nút mới chứa đối tượng Sach mới

        if (head == null) // Nếu danh sách liên kết rỗng
        {
            head = newNode; // Đặt nút mới làm đầu của danh sách liên kết
        }
        else // Nếu danh sách liên kết không rỗng
        {
            Node current = head; // Bắt đầu từ đầu của danh sách liên kết
            while (current.next != null) // Trong khi con trỏ tới nút tiếp theo của nút hiện tại không rỗng
            {
                current = current.next; // Di chuyển sang nút tiếp theo của nút hiện tại
            }
            current.next = newNode; // Đặt nút mới làm con trỏ tới nút tiếp theo của nút cuối cùng trong danh sách liên kết
        }
        Console.WriteLine("Them sach thanh cong. Ma sach: {0}", sach.MaSach);
        return sach;
    }

    // Hàm sắp xếp các cuốn sách trong thư viện theo thứ tự tăng dần của tên sách
    public void SortByName()
    {
        Node current = head; // Bắt đầu từ đầu của danh sách liên kết
        Node index = null;
        Sach temp;

        if (head == null) // Nếu danh sách liên kết rỗng
        {
            return;
        }
        else
        {
            while (current != null) // Trong khi nút hiện tại không rỗng
            {
                index = current.next;

                while (index != null) // Trong khi con trỏ tới nút tiếp theo của nút hiện tại không rỗng
                {
                    if (string.Compare(current.data.TenSach, index.data.TenSach) > 0) // Nếu tên sách của nút hiện tại lớn hơn tên sách của nút tiếp theo
                    {
                        temp = current.data;
                        current.data = index.data;
                        index.data = temp;
                    }
                    index = index.next;
                }
                current = current.next;
            }
        }
    }
    // Hàm in ra danh sách các cuốn sách trong thư viện
    public void PrintList()
    {
        Node current = head; // Bắt đầu từ đầu của danh sách liên kết

        while (current != null) // Trong khi nút hiện tại không rỗng
        {
            Console.WriteLine("Ma sach: {0}, Ten sach: {1}, Tac gia: {2}", current.data.MaSach, current.data.TenSach, current.data.TacGia); // In ra thông tin của nút hiện tại
            current = current.next; // Di chuyển sang nút tiếp theo của nút hiện tại
        }
    }

    // Hàm tìm kiếm sách theo tên sách
    public void TimSachTheoTen(string tenSach)
    {
        Node current = head; // Bắt đầu từ đầu của danh sách liên kết
        bool found = false;

        while (current != null) // Trong khi nút hiện tại không rỗng
        {
            if (current.data.TenSach == tenSach) // Nếu tên sách của nút hiện tại trùng với tên sách cần tìm
            {
                Console.WriteLine("Thong tin sach:");
                Console.WriteLine("Ma sach: {0}", current.data.MaSach);
                Console.WriteLine("Ten sach: {0}", current.data.TenSach);
                Console.WriteLine("Tac gia: {0}", current.data.TacGia);
                Console.WriteLine("Nam xuat ban: {0}", current.data.NamXuatBan);
                Console.WriteLine("The loai: {0}", current.data.TheLoai);
                Console.WriteLine("Trang thai: {0}", current.data.TrangThai);
                Console.WriteLine("Vi tri: {0}", current.data.ViTri);
                Console.WriteLine("Cac ma sach con trong thu vien:");
                Node temp = head; // Bắt đầu từ đầu của danh sách liên kết
                while (temp != null) // Trong khi nút hiện tại không rỗng
                {
                    if (temp.data.TenSach == tenSach && temp.data.MaSach != current.data.MaSach) // Nếu tên sách của nút hiện tại trùng với tên sách cần tìm và mã sách của nút hiện tại khác với mã sách của nút đã tìm thấy trước đó
                    {
                        Console.WriteLine("{0}", temp.data.MaSach); // In ra mã sách của nút hiện tại
                    }
                    temp = temp.next; // Di chuyển sang nút tiếp theo của nút hiện tại
                }

                found = true;
                break;
            }
            current = current.next;
        }

        if (!found) // Nếu không tìm thấy cuốn sách có tên trùng với tên sách cần tìm
        {
            Console.WriteLine("Khong tim thay sach co ten \"{0}\" trong thu vien.", tenSach);
        }
    }

    // Hàm thay đổi trạng thái của cuốn sách có tên trùng với tên sách cần tìm
    public void ThayDoiTrangThai(string tenSach, int trangThaiMoi)
    {
        Node current = head; // Bắt đầu từ đầu của danh sách liên kết
        bool found = false;

        while (current != null) // Trong khi nút hiện tại không rỗng
        {
            if (current.data.TenSach == tenSach) // Nếu tên sách của nút hiện tại trùng với tên sách cần tìm
            {
                current.data.TrangThai = trangThaiMoi; // Thay đổi trạng thái của nút hiện tại
                Console.WriteLine("Thay doi trang thai sach thanh cong.");
                found = true;
                break;
            }
            current = current.next; // Di chuyển sang nút tiếp theo của nút hiện tại
        }

        if (!found) // Nếu không tìm thấy cuốn sách có tên trùng với tên sách cần tìm
        {
            Console.WriteLine("Khong tim thay sach co ten {0} trong thu vien.", tenSach);
        }
    }

    // Hàm thay đổi vị trí của cuốn sách có tên trùng với tên sách cần tìm
    public void ThayDoiViTri(string tenSach, string viTriMoi)
    {
        Node current = head; // Bắt đầu từ đầu của danh sách liên kết
        bool found = false;

        while (current != null) // Trong khi nút hiện tại không rỗng
        {
            if (current.data.TenSach == tenSach) // Nếu tên sách của nút hiện tại trùng với tên sách cần tìm
            {
                current.data.ViTri = viTriMoi; // Thay đổi vị trí của nút hiện tại
                Console.WriteLine("Thay doi vi tri sach thanh cong.");
                found = true;
                break;
            }
            current = current.next; // Di chuyển sang nút tiếp theo của nút hiện tại
        }

        if (!found) // Nếu không tìm thấy cuốn sách có tên trùng với tên sách cần tìm
        {
            Console.WriteLine("Khong tim thay sach co ten {0} trong thu vien.", tenSach);
        }
    }
    public Sach LaySachTheoMa(int maSach)
    {
        Node current = head;
        while (current != null)
        {
            if (current.data.MaSach == maSach)
            {
                return current.data;
            }
            current = current.next;
        }
        return null;
    }
    public void NhapMaSachMuon(BinarySearchTree tree)
    {
        TreeNode node;
        Console.Write("Nhap ID doc gia: ");
        int id = int.Parse(Console.ReadLine());
        node = tree.Search(id);
        Console.WriteLine("Nhap cac ma sach muon (toi da 3 cuon): ");
        for (int i = 0; i < maSachMuon.Length; i++)
        {
            Console.Write("Nhap ma sach muon thu {0} (nhap 'q' de ket thuc): ", i + 1);
            string maSach = Console.ReadLine();
            if (maSach == "q")
            {
                break;
            }
            maSachMuon[i] = maSach;
        }
    }
    public void LietKeSachDangMuon(BinarySearchTree tree)
    {
        Console.Write("Nhap ID doc gia: ");
        int id = int.Parse(Console.ReadLine());
        TreeNode node = tree.Search(id);
        Console.WriteLine("Cac sach dang muon cua doc gia co ID {0}: ", id);
        foreach (string maSach in maSachMuon)
        {
            if (maSach != null)
            {
                Sach sach = LaySachTheoMa(int.Parse(maSach));
                if (sach != null)
                {
                    Console.WriteLine("- {0}", sach.TenSach);
                }
            }
        }
    }
    public void TraSach()
    {
        Console.Write("Nhap ma doc gia: ");
        string maDocGia = Console.ReadLine();
        Console.Write("Nhap ma sach muon tra: ");
        string maSachTra = Console.ReadLine();

        Node current = head;
        while (current != null)
        {
            if (current.data.MaSach.ToString() == maSachTra && current.data.DocGiaMuon == maDocGia)
            {
                current.data.TrangThai = 0;
                current.data.DocGiaMuon = null;
                current.data.NgayMuon = DateTime.MinValue;
                current.data.NgayTra = DateTime.MinValue;
                Console.WriteLine("Tra sach thanh cong.");
                return;
            }
            current = current.next;
        }
        Console.WriteLine("Khong tim thay sach hoac doc gia khong muon sach nay.");
    }
}



class Program
{
    BinarySearchTree bst = new BinarySearchTree();
    Random rnd = new Random();
    public void NhapTen()
    {
        Console.Write("Nhap ho: ");
        string ho = Console.ReadLine();
        Console.Write("Nhap ten: ");
        string ten = Console.ReadLine();
        Console.Write("Nhap gioi tinh (Nam/Nu): ");
        string gioitinh = Console.ReadLine();
        Console.Write("Nhap trang thai the (1: the mo / 0: the dang bi khoa): ");
        string trangthai = Console.ReadLine();
        int id = bst.Insert(0, ho, ten, gioitinh, trangthai); // Thêm độc giả vào cây và nhận lại ID của độc giả
        Console.WriteLine("Da them doc gia co id " + id  + " vao thu vien.");

    }
    public void PrintByName()
    {
        Console.WriteLine("Print by name:");
        bst.PrintByNameAscending();
    }
    public void PrintById()
    {
        Console.WriteLine("\nPrint by ID:");
        bst.PrintByID();
    }

    static void Main(string[] args)
    {
        ThuVien library = new ThuVien();
        Program program = new Program();
        BinarySearchTree tree = new BinarySearchTree();
        Sach sachMoi;
       
        while (true)
        {

            Console.WriteLine("Chon chuc nang:");
            Console.WriteLine("1. Them doc gia.");
            Console.WriteLine("2. In danh sach doc gia theo id.");
            Console.WriteLine("3. In danh sach doc gia theo ten.");
            Console.WriteLine("4. Them dau sach.");
            Console.WriteLine("5. In ra cac dau sach theo ten.");
            Console.WriteLine("6. Tim sach theo ten.");
            Console.WriteLine("7. Thay doi trang thai sach.");
            Console.WriteLine("8. Thay doi vi tri sach.");
            Console.WriteLine("9. Muon sach.");
            Console.WriteLine("10. Liet ke sach dang muon.");
            Console.WriteLine("11. Tra sach.");
            Console.Write("Chon: ");
            int choice = int.Parse(Console.ReadLine()); //Parse là một phương thức được sử dụng để chuyển đổi một chuỗi thành một kiểu dữ liệu số khác như int, long, double

            Console.WriteLine(" ");
            switch (choice)
            {
                case 1:
                    program.NhapTen();
                    break;
                case 2:
                    program.PrintById();
                    break;
                case 3:
                    program.PrintByName();
                    break;
                case 4:
                    sachMoi = library.ThemSach(); // Thêm một cuốn sách mới vào thư viện
                    break;
                case 5:
                    library.PrintList();
                    break;
                case 6:
                    Console.Write("Nhap ten sach can tim: ");
                    string tenSach = Console.ReadLine();
                    library.TimSachTheoTen(tenSach);
                    break;
                case 7:
                    Console.WriteLine("Nhap ten sach can thay doi trang thai");
                    tenSach = Console.ReadLine();
                    Console.WriteLine("Nhap trang thai");
                    int trangthai = int.Parse(Console.ReadLine());
                    library.ThayDoiTrangThai(tenSach, trangthai);
                    break;
                case 8:
                    Console.WriteLine("Nhap ten sach can thay doi vi tri");
                    tenSach = Console.ReadLine();
                    Console.WriteLine("Nhap vi tri");
                    string vitri = Console.ReadLine();
                    library.ThayDoiViTri(tenSach, vitri);
                    break;
                case 9:
                    library.NhapMaSachMuon(tree);
                    break;
                case 10:
                    library.LietKeSachDangMuon(tree);
                    break;
                case 11:
                    library.TraSach();
                    break;
            }
            Console.WriteLine(" ");
        }

    }
}
