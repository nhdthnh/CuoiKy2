using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class TreeNode
{
    public int id;
    public string ho;
    public string ten;
    public string phai;
    public string trangThai;
    public TreeNode left;
    public TreeNode right;
    public List<string> borrowedBooks;
    public TreeNode(int id, string ho, string ten, string phai, string trangThai)
    {
        this.id = id;
        this.ho = ho;
        this.ten = ten;
        this.phai = phai;
        this.trangThai = trangThai;
        this.borrowedBooks = new List<string>();
        this.left = null;
        this.right = null;
    }
}

    class BinarySearchTree
    {
    private TreeNode root;

    public BinarySearchTree()
{
    this.root = null;
}

public void Insert(int id, string ho, string ten, string phai, string trangThai)
{
    Random rnd = new Random();
    int newId = rnd.Next(10000, 99999);
    TreeNode newNode = new TreeNode(newId, ho, ten, phai, trangThai);
    if (root == null)
    {
        root = newNode;
        return;
    }
    TreeNode current = root;
    while (true)
    {
        if (newId < current.id)
        {
            if (current.left == null)
            {
                current.left = newNode;
                break;
            }
            current = current.left;
        }
        else
        {
            if (current.right == null)
            {
                current.right = newNode;
                break;
            }
            current = current.right;
        }
    }
}


    public void Delete(int id)
    {
        root = DeleteHelper(root, id);
    }

    private TreeNode DeleteHelper(TreeNode node, int id)
    {
        if (node == null)
        {
            return null;
        }
        if (id < node.id)
        {
            node.left = DeleteHelper(node.left, id);
        }
        else if (id > node.id)
        {
            node.right = DeleteHelper(node.right, id);
        }
        else
        {
            if (node.left == null && node.right == null)
            {
                node = null;
            }
            else if (node.left == null)
            {
                node = node.right;
            }
            else if (node.right == null)
            {
                node = node.left;
            }
            else
            {
                TreeNode minNode = FindMinNode(node.right);
                node.id = minNode.id;
                node.ho = minNode.ho;
                node.ten = minNode.ten;
                node.phai = minNode.phai;
                node.trangThai = minNode.trangThai;
                node.right = DeleteHelper(node.right, minNode.id);
            }
        }
        return node;
    }

    private TreeNode FindMinNode(TreeNode node)
    {
        while (node.left != null)
        {
            node = node.left;
        }
        return node;
    }

    private void PrintByNameHelper(TreeNode node)
    {
        if (node.left != null)
        {
            PrintByNameHelper(node.left);
        }
        Console.WriteLine("ID: {0}, Ho: {1}, Ten: {2}", node.id, node.ho, node.ten);
        if (node.right != null)
        {
            PrintByNameHelper(node.right);
        }
    }

    public void PrintByNameAscending()
    {
        if (root != null)
        {
            PrintByNameAscendingHelper(root);
        }
    }

    private void PrintByNameAscendingHelper(TreeNode node)
    {
        if (node.left != null)
        {
            PrintByNameAscendingHelper(node.left);
        }
        Console.WriteLine("ID: {0}, Ho: {1}, Ten: {2}", node.id, node.ho, node.ten);
        if (node.right != null)
        {
            PrintByNameAscendingHelper(node.right);
        }
    }



    private void InOrderTraversal(TreeNode node, List<TreeNode> nodes)
    {
        if (node == null)
        {
            return;
        }

        InOrderTraversal(node.left, nodes);
        nodes.Add(node);
        InOrderTraversal(node.right, nodes);
    }

    public void PrintByID()
    {
        if (root != null)
        {
            PrintByIDHelper(root);
        }
    }
    private void PrintByIDHelper(TreeNode node)
    {
        if (node.left != null)
        {
            PrintByIDHelper(node.left);
        }
        Console.WriteLine("ID: {0}, Ho: {1}, Ten: {2}", node.id, node.ho, node.ten);
        if (node.right != null)
        {
            PrintByIDHelper(node.right);
        }
    }
}

public class Sach
{

    public int MaSach { get; private set; }
    public string TenSach { get; set; }
    public string TacGia { get; set; }
    public int NamXuatBan { get; set; }
    public string TheLoai { get; set; }
    public int SoTrang { get; set; }
    public int TrangThai { get; set; } // 0 : cho mượn được, 1 : đã có độc giả mượn, 2 : sách đã thanh lý
    public string ViTri { get; set; }

    public Sach(string tenSach, string tacGia, int namXuatBan, int soTrang, string theLoai, string viTri, int trangThai)
    {
        MaSach = new Random().Next(100000, 999999);
        TenSach = tenSach;
        TacGia = tacGia;
        NamXuatBan = namXuatBan;
        SoTrang = soTrang;
        TheLoai = theLoai;
        ViTri = viTri;
        TrangThai = trangThai;
    }
}
public class Node
{
    public Sach data;
    public Node next;

    public Node(Sach data)
    {
        this.data = data;
        this.next = null;
    }
}

public class ThuVien
{
    private Node head = null;

    public void ThemSach()
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

        Sach sach = new Sach (tenSach, tacGia, namXuatBan, soTrang, theLoai, viTri, trangThai);
        Node newNode = new Node(sach);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node current = head;
            while (current.next != null)
            {
                current = current.next;
            }
            current.next = newNode;
        }

        Console.WriteLine("Them sach thanh cong. Ma sach: {0}", sach.MaSach);
    }
    public void SortByName()
    {
        Node current = head;
        Node index = null;
        Sach temp;

        if (head == null)
        {
            return;
        }
        else
        {
            while (current != null)
            {
                index = current.next;

                while (index != null)
                {
                    if (string.Compare(current.data.TenSach, index.data.TenSach) > 0)
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
    public void PrintList()
    {
        Node current = head;

        while (current != null)
        {
            Console.WriteLine("Ma sach: {0}, Ten sach: {1}, Tac gia: {2}", current.data.MaSach, current.data.TenSach, current.data.TacGia);
            current = current.next;
        }
    }
    public void TimSachTheoTen(string tenSach)
    {
        Node current = head;
        bool found = false;

        while (current != null)
        {
            if (current.data.TenSach == tenSach)
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
                Node temp = head;
                while (temp != null)
                {
                    if (temp.data.TenSach == tenSach && temp.data.MaSach != current.data.MaSach)
                    {
                        Console.WriteLine("{0}", temp.data.MaSach);
                    }
                    temp = temp.next;
                }

                found = true;
                break;
            }
            current = current.next;
        }

        if (!found)
        {
            Console.WriteLine("Khong tim thay sach co ten \"{0}\" trong thu vien.", tenSach);
        }
    }
    public void ThayDoiTrangThai(string tenSach, int trangThaiMoi)
    {
        Node current = head;
        bool found = false;

        while (current != null)
        {
            if (current.data.TenSach == tenSach)
            {
                current.data.TrangThai = trangThaiMoi;
                Console.WriteLine("Thay doi trang thai sach thanh cong.");
                found = true;
                break;
            }
            current = current.next;
        }

        if (!found)
        {
            Console.WriteLine("Khong tim thay sach co ten {0} trong thu vien.", tenSach);
        }

    }
    public void ThayDoiViTri(string tenSach, string viTriMoi)
    {
        Node current = head;
        bool found = false;

        while (current != null)
        {
            if (current.data.TenSach == tenSach)
            {
                current.data.ViTri = viTriMoi;
                Console.WriteLine("Thay doi vi tri sach thanh cong.");
                found = true;
                break;
            }
            current = current.next;
        }

        if (!found)
        {
            Console.WriteLine("Khong tim thay sach co ten {0} trong thu vien.", tenSach);
        }

    }

}


class Program
{
    BinarySearchTree bst = new BinarySearchTree();
    Random rnd = new Random();
    public void NhapTen()
    {
        while (true)
        {
            Console.WriteLine("Nhap ho: ");
            string ho = Console.ReadLine();
            Console.WriteLine("Nhap ten: ");
            string ten = Console.ReadLine();
            Console.WriteLine("Nhap gioi tinh: ");
            string gioitinh = Console.ReadLine();
            Console.WriteLine("Nhap trang thai the: ");
            string trangthai = Console.ReadLine();
            bst.Insert(rnd.Next(1000, 9999), ho, ten,gioitinh, trangthai);
            break;
        }
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
        Console.WriteLine(" ");
        while (true)
        {
            Console.WriteLine("Chon chuc nang:");
            Console.WriteLine("1. Them doc gia.");
            Console.WriteLine("2. In danh sach doc gia theo id.");
            Console.WriteLine("3. In danh sach doc gia theo ten.");
            Console.WriteLine("4. Them dau sach.");
            Console.WriteLine("5. In ra cac dau sach theo ten.");
            Console.WriteLine("6. Tim sach theo ten.");
            Console.Write("Chon: ");
            int choice = int.Parse(Console.ReadLine()); //Parse là một phương thức được sử dụng để chuyển đổi một chuỗi thành một kiểu dữ liệu số khác như int, long, double
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
                    library.ThemSach();
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
            }
        }
        Console.WriteLine(" ");
    }
}
