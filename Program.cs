using System;
using System.Collections.Generic;

// Lớp SinhVien
class SinhVien
{
    // Các thuộc tính được khởi tạo với giá trị mặc định để tránh cảnh báo CS8618
    public string HoTen { get; set; } = string.Empty; // Khởi tạo với giá trị mặc định
    public string MSSV { get; set; } = string.Empty;  // Khởi tạo với giá trị mặc định
    public double DiemTrungBinh { get; set; }

    // Phương thức nhập thông tin sinh viên
    public void NhapThongTin()
    {
        Console.Write("Nhập họ tên: ");
        HoTen = Console.ReadLine() ?? string.Empty; // Đảm bảo không nhận giá trị null

        Console.Write("Nhập MSSV: ");
        MSSV = Console.ReadLine() ?? string.Empty; // Đảm bảo không nhận giá trị null

        Console.Write("Nhập điểm trung bình: ");
        // Sử dụng TryParse để kiểm tra giá trị đầu vào và tránh lỗi CS8604
        if (!double.TryParse(Console.ReadLine(), out double diem))
        {
            Console.WriteLine("Điểm trung bình không hợp lệ. Mặc định là 0.");
            DiemTrungBinh = 0.0;
        }
        else
        {
            DiemTrungBinh = diem;
        }
    }

    // Phương thức hiển thị thông tin sinh viên
    public void HienThiThongTin()
    {
        Console.WriteLine($"Họ tên: {HoTen}, MSSV: {MSSV}, Điểm trung bình: {DiemTrungBinh}");
    }
}

// Lớp DanhSachSinhVien
class DanhSachSinhVien
{
    // Sử dụng List<SinhVien> để chứa danh sách sinh viên
    public List<SinhVien> DanhSach { get; set; } = new List<SinhVien>();

    // Phương thức thêm sinh viên vào danh sách
    public void ThemSinhVien()
    {
        SinhVien sv = new SinhVien();
        sv.NhapThongTin();
        DanhSach.Add(sv);
    }

    // Phương thức hiển thị danh sách sinh viên
    public void HienThiDanhSach()
    {
        foreach (SinhVien sv in DanhSach)
        {
            sv.HienThiThongTin();
        }
    }

    // Phương thức tìm sinh viên theo MSSV
    public void TimSinhVienTheoMSSV(string? mssv) // Sử dụng string? để tránh cảnh báo CS8604
    {
        if (string.IsNullOrEmpty(mssv))
        {
            Console.WriteLine("MSSV không hợp lệ!");
            return;
        }

        // Tìm kiếm sinh viên theo MSSV
        SinhVien? sv = DanhSach.Find(s => s.MSSV == mssv);
        if (sv != null)
        {
            sv.HienThiThongTin();
        }
        else
        {
            Console.WriteLine($"Không tìm thấy sinh viên với MSSV: {mssv}");
        }
    }

    // Phương thức tính sinh viên có điểm trung bình cao nhất
    public SinhVien? TinhDiemTrungBinhCaoNhat()
    {
        if (DanhSach.Count == 0) return null; // Kiểm tra danh sách rỗng để tránh lỗi CS8603

        SinhVien svMax = DanhSach[0];
        foreach (SinhVien sv in DanhSach)
        {
            if (sv.DiemTrungBinh > svMax.DiemTrungBinh)
            {
                svMax = sv;
            }
        }
        return svMax;
    }
}

class Program
{
    static void Main(string[] args)
    {
        DanhSachSinhVien danhSach = new DanhSachSinhVien();

        Console.WriteLine("Nhập thông tin cho ít nhất 3 sinh viên:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\nNhập thông tin sinh viên thứ {i + 1}:");
            danhSach.ThemSinhVien();
        }

        // Hiển thị danh sách sinh viên
        Console.WriteLine("\nDanh sách sinh viên đã nhập:");
        danhSach.HienThiDanhSach();

        // Tìm và hiển thị sinh viên có điểm trung bình cao nhất
        SinhVien? svMax = danhSach.TinhDiemTrungBinhCaoNhat();
        if (svMax != null)
        {
            Console.WriteLine("\nSinh viên có điểm trung bình cao nhất:");
            svMax.HienThiThongTin();
        }
        else
        {
            Console.WriteLine("Không có sinh viên trong danh sách.");
        }

        // Tìm kiếm sinh viên theo MSSV
        Console.Write("\nNhập MSSV sinh viên cần tìm: ");
        string? mssvTimKiem = Console.ReadLine();
        danhSach.TimSinhVienTheoMSSV(mssvTimKiem);
    }
}
