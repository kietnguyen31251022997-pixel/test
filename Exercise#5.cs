using System;
using System.Collections.Generic;
//BAI 1
public class ChuyenXe
{
    public string MaSoChuyen { get; set; }
    public string HoTenTaiXe { get; set; }
    public string SoXe { get; set; }
    public double DoanhThu { get; set; }

    public ChuyenXe(string maSoChuyen, string hoTenTaiXe,
                    string soXe, double doanhThu)
    {
        MaSoChuyen = maSoChuyen;
        HoTenTaiXe = hoTenTaiXe;
        SoXe = soXe;
        DoanhThu = doanhThu;
    }
}
public class ChuyenXeNoiThanh : ChuyenXe
{
    public int SoTuyen { get; set; }
    public double SoKm { get; set; }

    public ChuyenXeNoiThanh(
        string maSoChuyen,
        string hoTenTaiXe,
        string soXe,
        int soTuyen,
        double soKm,
        double doanhThu)
        : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
    {
        SoTuyen = soTuyen;
        SoKm = soKm;
    }
}
public class ChuyenXeNgoaiThanh : ChuyenXe
{
    public string NoiDen { get; set; }
    public int SoNgay { get; set; }

    public ChuyenXeNgoaiThanh(
        string maSoChuyen,
        string hoTenTaiXe,
        string soXe,
        string noiDen,
        int soNgay,
        double doanhThu)
        : base(maSoChuyen, hoTenTaiXe, soXe, doanhThu)
    {
        NoiDen = noiDen;
        SoNgay = soNgay;
    }
}
class Program1
{
    static void Main1(string[] args)
    {
        List<ChuyenXe> danhSach = new List<ChuyenXe>();
        danhSach.Add(new ChuyenXeNoiThanh(
            "N01", "Phuong Trang", "51A-12345",
            10, 50, 1000000));
        danhSach.Add(new ChuyenXeNoiThanh(
            "N02", "Nam Lanh", "51B-67890",
            15, 70, 1500000));
        danhSach.Add(new ChuyenXeNgoaiThanh(
            "N11", "Hong Hoang", "51C-11111",
            "Tien Giang", 2, 3000000));

        danhSach.Add(new ChuyenXeNgoaiThanh(
            "NG02", "Van Phu", "51D-22222",
            "Da Lat", 3, 5000000));
        double tongDoanhThu = 0;
        double tongNoiThanh = 0;
        double tongNgoaiThanh = 0;

        foreach (ChuyenXe xe in danhSach)
        {
            tongDoanhThu += xe.DoanhThu;

            if (xe is ChuyenXeNoiThanh)
            {
                tongNoiThanh += xe.DoanhThu;
            }
            else if (xe is ChuyenXeNgoaiThanh)
            {
                tongNgoaiThanh += xe.DoanhThu;
            }
        }

        Console.WriteLine("TONG DOANH THU TAT CA CHUYEN XE: "
                          + tongDoanhThu);

        Console.WriteLine("TONG DOANH THU NOI THANH: "
                          + tongNoiThanh);

        Console.WriteLine("TONG DOANH THU NGOAI THANH: "
                          + tongNgoaiThanh);
    }
}
// BAI 2
public class Sach
{
    public string MaSach { get; set; }
    public DateTime NgayNhap { get; set; }
    public double DonGia { get; set; }
    public int SoLuong { get; set; }
    public string NhaXuatBan { get; set; }

    public Sach(
        string maSach,
        DateTime ngayNhap,
        double donGia,
        int soLuong,
        string nhaXuatBan)
    {
        MaSach = maSach;
        NgayNhap = ngayNhap;
        DonGia = donGia;
        SoLuong = soLuong;
        NhaXuatBan = nhaXuatBan;
    }

    public virtual double ThanhTien()
    {
        return 0;
    }
}

public class SachGiaoKhoa : Sach
{
    public string TinhTrang { get; set; }

    public SachGiaoKhoa(
        string maSach,
        DateTime ngayNhap,
        double donGia,
        int soLuong,
        string nhaXuatBan,
        string tinhTrang)
        : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
    {
        TinhTrang = tinhTrang;
    }

    public override double ThanhTien()
    {
        if (TinhTrang.ToLower() == "Hang moi")
        {
            return SoLuong * DonGia;
        }
        else
        {
            return SoLuong * DonGia * 0.5;
        }
    }
}

public class SachThamKhao : Sach
{
    public double Thue { get; set; }

    public SachThamKhao(
        string maSach,
        DateTime ngayNhap,
        double donGia,
        int soLuong,
        string nhaXuatBan,
        double thue)
        : base(maSach, ngayNhap, donGia, soLuong, nhaXuatBan)
    {
        Thue = thue;
    }

    public override double ThanhTien()
    {
        return SoLuong * DonGia + Thue;
    }
}
class Program2
{
    static void Main2(string[] args)
    {
        List<Sach> danhSach = new List<Sach>();

        danhSach.Add(new SachGiaoKhoa(
            "GK01",
            new DateTime(2026, 9, 1),
            50000,
            10,
            "K",
            "mới"));

        danhSach.Add(new SachGiaoKhoa(
            "GK02",
            new DateTime(2026, 9, 2),
            60000,
            5,
            "NXB A",
            "cũ"));

        danhSach.Add(new SachGiaoKhoa(
            "GK03",
            new DateTime(2026, 9, 3),
            70000,
            8,
            "K",
            "mới"));

        danhSach.Add(new SachThamKhao(
            "TK01",
            new DateTime(2026, 9, 1),
            80000,
            5,
            "NXB B",
            20000));

        danhSach.Add(new SachThamKhao(
            "TK02",
            new DateTime(2026, 9, 2),
            90000,
            10,
            "NXB C",
            30000));

        danhSach.Add(new SachThamKhao(
            "TK03",
            new DateTime(2026, 9, 3),
            100000,
            6,
            "NXB D",
            25000));


        double tongGiaoKhoa = 0;
        double tongThamKhao = 0;

        foreach (Sach sach in danhSach)
        {
            if (sach is SachGiaoKhoa)
            {
                tongGiaoKhoa += sach.ThanhTien();
            }
            else if (sach is SachThamKhao)
            {
                tongThamKhao += sach.ThanhTien();
            }
        }

        Console.WriteLine("Tong thanh tien sach giao khoa: "
                          + tongGiaoKhoa);

        Console.WriteLine("Tong thanh tien sach tham khao: "
                          + tongThamKhao);
        Console.Write("\nNhap nha xuat ban K: ");
        string K = Console.ReadLine();

        Console.WriteLine("\nCac sach giao khoa cua NXB " + K + ":");

        foreach (Sach sach in danhSach)
        {
            if (sach is SachGiaoKhoa &&
                sach.NhaXuatBan.Equals(K,
                StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(
                    "Ma sach: " + sach.MaSach +
                    " - NXB: " + sach.NhaXuatBan +
                    " - Thanh tien: " + sach.ThanhTien());
            }
        }
        Sach sachMax = danhSach[0];

        foreach (Sach sach in danhSach)
        {
            if (sach.ThanhTien() > sachMax.ThanhTien())
            {
                sachMax = sach;
            }
        }

        Console.WriteLine("\nSach co thanh tien cao nhat:");
        Console.WriteLine("Ma sach: " + sachMax.MaSach);
        Console.WriteLine("Nha xuat ban: " + sachMax.NhaXuatBan);
        Console.WriteLine("Thanh tien: " + sachMax.ThanhTien());
    }
}
// BAI 3
public class GiaoDich
{
    public string MaGiaoDich { get; set; }
    public DateTime NgayGiaoDich { get; set; }
    public double DonGia { get; set; }
    public int SoLuong { get; set; }

    public GiaoDich(
        string maGiaoDich,
        DateTime ngayGiaoDich,
        double donGia,
        int soLuong)
    {
        MaGiaoDich = maGiaoDich;
        NgayGiaoDich = ngayGiaoDich;
        DonGia = donGia;
        SoLuong = soLuong;
    }

    public virtual double ThanhTien()
    {
        return 0;
    }
}
public class GiaoDichVang : GiaoDich
{
    public string LoaiVang { get; set; }

    public GiaoDichVang(
        string maGiaoDich,
        DateTime ngayGiaoDich,
        double donGia,
        int soLuong,
        string loaiVang)
        : base(maGiaoDich, ngayGiaoDich, donGia, soLuong)
    {
        LoaiVang = loaiVang;
    }

    public override double ThanhTien()
    {
        return SoLuong * DonGia;
    }
}
public class GiaoDichTienTe : GiaoDich
{
    public double TiGia { get; set; }
    public string LoaiTienTe { get; set; }

    public GiaoDichTienTe(
        string maGiaoDich,
        DateTime ngayGiaoDich,
        double donGia,
        int soLuong,
        double tiGia,
        string loaiTienTe)
        : base(maGiaoDich, ngayGiaoDich, donGia, soLuong)
    {
        TiGia = tiGia;
        LoaiTienTe = loaiTienTe;
    }

    public override double ThanhTien()
    {
        if (LoaiTienTe == "VN")
        {
            return SoLuong * DonGia;
        }
        else
        {
            return SoLuong * DonGia * TiGia;
        }
    }
}

class Program3
{
    static void Main3(string[] args)
    {
        List<GiaoDich> danhSach = new List<GiaoDich>();

        danhSach.Add(new GiaoDichVang(
            "V01",
            new DateTime(2026, 9, 1),
            850000000,
            2,
            "Vàng 24K"));

        danhSach.Add(new GiaoDichVang(
            "V02",
            new DateTime(2026, 9, 2),
            1200000000,
            3,
            "Vàng 18K"));

        danhSach.Add(new GiaoDichVang(
            "V03",
            new DateTime(2026, 9, 3),
            950000000,
            1,
            "Vàng 24K"));

        danhSach.Add(new GiaoDichTienTe(
            "T01",
            new DateTime(2026, 9, 1),
            25000,
            1000,
            1,
            "VN"));

        danhSach.Add(new GiaoDichTienTe(
            "T02",
            new DateTime(2026, 9, 2),
            25,
            2000,
            25000,
            "USD"));

        danhSach.Add(new GiaoDichTienTe(
            "T03",
            new DateTime(2026, 9, 3),
            30,
            1500,
            29000,
            "Euro"));

        int tongSoLuongVang = 0;
        int tongSoLuongTienTe = 0;

        double tongThanhTienTienTe = 0;
        int soGiaoDichTienTe = 0;

        foreach (GiaoDich gd in danhSach)
        {
            if (gd is GiaoDichVang)
            {
                tongSoLuongVang += gd.SoLuong;
            }
            else if (gd is GiaoDichTienTe)
            {
                tongSoLuongTienTe += gd.SoLuong;
                tongThanhTienTienTe += gd.ThanhTien();
                soGiaoDichTienTe++;
            }
        }

        double trungBinhTienTe =
            tongThanhTienTienTe / soGiaoDichTienTe;

        Console.WriteLine("Tong so luong giao dich vang: "
            + tongSoLuongVang);

        Console.WriteLine("Tong so luong giao dich tien te: "
            + tongSoLuongTienTe);

        Console.WriteLine("Trung binh thanh tien giao dich tien te: "
            + trungBinhTienTe);

        Console.WriteLine();
        Console.WriteLine("Cac giao dich co don gia > 1 ty:");

        foreach (GiaoDich gd in danhSach)
        {
            if (gd.DonGia > 1000000000)
            {
                Console.WriteLine(
                    "Ma giao dich: " + gd.MaGiaoDich
                    + " - Don gia: " + gd.DonGia
                    + " - Thanh tien: " + gd.ThanhTien());
            }
        }
    }
}
// BAI 7
public class Person
{
    public string HoTen { get; set; }
    public string DiaChi { get; set; }

    public Person(string hoTen, string diaChi)
    {
        HoTen = hoTen;
        DiaChi = diaChi;
    }

    public override string ToString()
    {
        return "Ho ten: " + HoTen
            + " - Dia chi: " + DiaChi;
    }
}

public class Student : Person
{
    public double DiemMon1 { get; set; }
    public double DiemMon2 { get; set; }

    public Student(
        string hoTen,
        string diaChi,
        double diemMon1,
        double diemMon2)
        : base(hoTen, diaChi)
    {
        DiemMon1 = diemMon1;
        DiemMon2 = diemMon2;
    }

    public double TinhDiemTrungBinh()
    {
        return (DiemMon1 + DiemMon2) / 2;
    }

    public string DanhGia()
    {
        double diemTB = TinhDiemTrungBinh();

        if (diemTB >= 8)
            return "Gioi";
        else if (diemTB >= 6.5)
            return "Kha";
        else if (diemTB >= 5)
            return "Trung binh";
        else
            return "Yeu";
    }

    public override string ToString()
    {
        return "Sinh vien"
            + " - Ho ten: " + HoTen
            + " - Dia chi: " + DiaChi
            + " - Diem mon 1: " + DiemMon1
            + " - Diem mon 2: " + DiemMon2
            + " - Diem TB: " + TinhDiemTrungBinh()
            + " - Danh gia: " + DanhGia();
    }
}
public class Employee : Person
{
    public double HeSoLuong { get; set; }

    public Employee(
        string hoTen,
        string diaChi,
        double heSoLuong)
        : base(hoTen, diaChi)
    {
        HeSoLuong = heSoLuong;
    }

    public double TinhLuong()
    {
        return HeSoLuong * 1800000;
    }

    public string DanhGia()
    {
        double luong = TinhLuong();

        if (luong >= 20000000)
            return "Luong cao";
        else if (luong >= 10000000)
            return "Luong trung binh";
        else
            return "Luong thap";
    }

    public override string ToString()
    {
        return "Nhan vien"
            + " - Ho ten: " + HoTen
            + " - Dia chi: " + DiaChi
            + " - He so luong: " + HeSoLuong
            + " - Tien luong: " + TinhLuong()
            + " - Danh gia: " + DanhGia();
    }
}

public class Customer : Person
{
    public string TenCongTy { get; set; }
    public double TriGiaHoaDon { get; set; }
    public string DanhGiaKhachHang { get; set; }

    public Customer(
        string hoTen,
        string diaChi,
        string tenCongTy,
        double triGiaHoaDon,
        string danhGia)
        : base(hoTen, diaChi)
    {
        TenCongTy = tenCongTy;
        TriGiaHoaDon = triGiaHoaDon;
        DanhGiaKhachHang = danhGia;
    }

    public override string ToString()
    {
        return "Khach hang"
            + " - Ho ten: " + HoTen
            + " - Dia chi: " + DiaChi
            + " - Cong ty: " + TenCongTy
            + " - Tri gia hoa don: " + TriGiaHoaDon
            + " - Danh gia: " + DanhGiaKhachHang;
    }
}

public class Management
{
    private Person[] danhSach;
    private int soLuong;

    public Management(int n)
    {
        danhSach = new Person[n];
        soLuong = 0;
    }

    public void Them(Person person)
    {
        if (soLuong < danhSach.Length)
        {
            danhSach[soLuong] = person;
            soLuong++;

            Console.WriteLine("Them thanh cong");
        }
        else
        {
            Console.WriteLine("Danh sach day");
        }
    }

    public void Xoa(string hoTen)
    {
        for (int i = 0; i < soLuong; i++)
        {
            if (danhSach[i].HoTen.Equals(
                hoTen,
                StringComparison.OrdinalIgnoreCase))
            {
                for (int j = i; j < soLuong - 1; j++)
                {
                    danhSach[j] = danhSach[j + 1];
                }

                danhSach[soLuong - 1] = null;
                soLuong--;

                Console.WriteLine("Xoa thanh cong");
                return;
            }
        }

        Console.WriteLine("Khong tim thay nguoi can xoa");
    }

    public void SapXep()
    {
        for (int i = 0; i < soLuong - 1; i++)
        {
            for (int j = i + 1; j < soLuong; j++)
            {
                if (string.Compare(
                    danhSach[i].HoTen,
                    danhSach[j].HoTen,
                    StringComparison.OrdinalIgnoreCase) > 0)
                {
                    Person temp = danhSach[i];
                    danhSach[i] = danhSach[j];
                    danhSach[j] = temp;
                }
            }
        }

        Console.WriteLine("Sap xep thanh cong!");
    }

    public void Xuat()
    {
        if (soLuong == 0)
        {
            Console.WriteLine("Danh sach rong!");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("========== DANH SACH ==========");

        for (int i = 0; i < soLuong; i++)
        {
            Console.WriteLine(danhSach[i].ToString());
        }

        Console.WriteLine("===============================");
        Console.WriteLine("Tong so nguoi: " + soLuong);
    }
}

public class Test
{
    public static void Main(string[] args)
    {
        Management management = new Management(100);

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Them nhan vien");
            Console.WriteLine("3. Them khach hang");
            Console.WriteLine("4. Xoa nguoi");
            Console.WriteLine("5. Sap xep theo ho ten");
            Console.WriteLine("6. Xuat danh sach");
            Console.WriteLine("0. Thoat");
            Console.Write("Lua chon cua ban: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 0)
            {
                break;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Nhap ho ten: ");
                    string tenSV = Console.ReadLine();

                    Console.Write("Nhap dia chi: ");
                    string diaChiSV = Console.ReadLine();

                    Console.Write("Nhap diem mon 1: ");
                    double diem1 = double.Parse(Console.ReadLine());

                    Console.Write("Nhap diem mon 2: ");
                    double diem2 = double.Parse(Console.ReadLine());

                    Student student = new Student(
                        tenSV,
                        diaChiSV,
                        diem1,
                        diem2);

                    management.Them(student);
                    break;

                case 2:
                    Console.Write("Nhap ho ten: ");
                    string tenNV = Console.ReadLine();

                    Console.Write("Nhap dia chi: ");
                    string diaChiNV = Console.ReadLine();

                    Console.Write("Nhap he so luong: ");
                    double heSoLuong = double.Parse(Console.ReadLine());

                    Employee employee = new Employee(
                        tenNV,
                        diaChiNV,
                        heSoLuong);

                    management.Them(employee);
                    break;

                case 3:
                    Console.Write("Nhap ho ten: ");
                    string tenKH = Console.ReadLine();

                    Console.Write("Nhap dia chi: ");
                    string diaChiKH = Console.ReadLine();

                    Console.Write("Nhap ten cong ty: ");
                    string tenCongTy = Console.ReadLine();

                    Console.Write("Nhap tri gia hoa don: ");
                    double triGia = double.Parse(Console.ReadLine());

                    Console.Write("Nhap danh gia: ");
                    string danhGia = Console.ReadLine();

                    Customer customer = new Customer(
                        tenKH,
                        diaChiKH,
                        tenCongTy,
                        triGia,
                        danhGia);

                    management.Them(customer);
                    break;

                case 4:
                    Console.Write("Nhap ho ten can xoa: ");
                    string tenXoa = Console.ReadLine();

                    management.Xoa(tenXoa);
                    break;

                case 5:
                    management.SapXep();
                    break;

                case 6:
                    management.Xuat();
                    break;

                default:
                    Console.WriteLine("Lua chon khong hop le!");
                    break;
            }
        }
    }
}