-- Tạo cơ sở dữ liệu
CREATE DATABASE QlBank_end;
USE QlBank_end;
Go

-- Bảng đăng nhập
CREATE TABLE DangNhap (
    TaiKhoan VARCHAR(255) PRIMARY KEY,
    MatKhau VARCHAR(255),
	Role VARCHAR(255)
);

-- Bảng khách hàng
CREATE TABLE KhachHang (
	SoTaiKhoan int PRIMARY KEY,
    TenKhachHang VARCHAR(255),
    NgaySinh DATE,
    SoCCCD VARCHAR(12),
    SoDienThoai VARCHAR(15),
    GioiTinh varchar(20),
    Email VARCHAR(255),
    DiaChi VARCHAR(255),
    NgheNghiep VARCHAR(255),
    TaiKhoan VARCHAR(255),
    SoDu int,
    Anh varchar(255),
	FOREIGN KEY (TaiKhoan) REFERENCES DangNhap(TaiKhoan) ON DELETE CASCADE
);


-- Bảng giao dịch
CREATE TABLE GiaoDich (
    MaGiaoDich varchar(100)  PRIMARY KEY,
    ThoiGian DATE,
    SoTaiKhoan int,
    TaiKhoanNhan int,
    SoTien int,
    FOREIGN KEY (SoTaiKhoan) REFERENCES KhachHang(SoTaiKhoan) ON DELETE CASCADE
);

-- Bảng tiết kiệm
CREATE TABLE TietKiem (
    MaTietKiem varchar(100)  PRIMARY KEY,
    SoTaiKhoan int,
    SoTien int,
    ThoiGian DATE,
    KyHan INT,
    LaiSuat DECIMAL(5, 2),
    SoTienDuKienNhan  int,
    FOREIGN KEY (SoTaiKhoan) REFERENCES KhachHang(SoTaiKhoan) ON DELETE CASCADE
);

-- Bảng chi tiết tiết kiệm
CREATE TABLE ChiTietTietKiem (
    MaTietKiem varchar(100),
    HoatDong VARCHAR(255),
    SoTien int,
	ThoiGianGiaoDich date,
    FOREIGN KEY (MaTietKiem) REFERENCES TietKiem(MaTietKiem) ON DELETE CASCADE
);

-- Bảng khoản vay
CREATE TABLE KhoanVay (
    MaKhoanVay varchar(100)  PRIMARY KEY,
    SoTaiKhoan int,
    SoTien int,
    ThoiGian DATE,
    KyHan INT,
    LaiSuat DECIMAL(5, 2),
    SoTienPhaiTra Int,
    FOREIGN KEY (SoTaiKhoan) REFERENCES KhachHang(SoTaiKhoan) ON DELETE CASCADE
);

-- Bảng chi tiết khoản vay
CREATE TABLE ChiTietKhoanVay (
    MaKhoanVay varchar(100),
    HoatDong VARCHAR(255),
    SoTien int,
	ThoiGianGiaoDich date,
    FOREIGN KEY (MaKhoanVay) REFERENCES KhoanVay(MaKhoanVay) ON DELETE CASCADE
);

--alter table [dbo].[ChiTietKhoanVay]
--add ThoiGianGiaoDich date
--alter table [dbo].[ChiTietTietKiem]
--add ThoiGianGiaoDich date

-- Chèn dữ liệu vào bảng DangNhap
INSERT INTO DangNhap (TaiKhoan, MatKhau,Role) 
VALUES 
('user1','password1','Admin'),
('user2', 'password2','User'),
('user3', 'password3','User');


-- Chèn dữ liệu vào bảng KhachHang
INSERT INTO KhachHang (SoTaiKhoan, TenKhachHang, NgaySinh, SoCCCD, SoDienThoai, GioiTinh, Email, DiaChi, NgheNghiep, TaiKhoan, SoDu, Anh)
VALUES 
(1001, 'Tran Thi B', '1995-10-20', '098765432109', '0912345678', 'Nu', 'tranthib@example.com', '456 Hai Ba Trung, HCM', 'Giao vien', 'user1', 7000000, 'anhb.jpg'),
(1002, 'Tran Thi B', '1995-10-20', '098765432109', '0912345678', 'Nu', 'tranthib@example.com', '456 Hai Ba Trung, HCM', 'Giao vien', 'user2', 7000000, 'anhb.jpg'),
(1003, 'Le Van C', '1988-03-25', '123456789012', '0976543210', 'Nam', 'levanc@example.com', '789 Tran Hung Dao, Da Nang', 'Ky su', 'user3', 10000000, 'anhc.jpg');

-- Chèn dữ liệu vào bảng GiaoDich
INSERT INTO GiaoDich (MaGiaoDich, ThoiGian, SoTaiKhoan, TaiKhoanNhan, SoTien) 
VALUES 
('GD001', '2024-11-10', 1001, 1002, 200000),
('GD002', '2024-11-11', 1002, 1003, 500000),
('GD003', '2024-11-12', 1003, 1001, 300000);

-- Chèn dữ liệu vào bảng TietKiem
INSERT INTO TietKiem (MaTietKiem, SoTaiKhoan, SoTien, ThoiGian, KyHan, LaiSuat, SoTienDuKienNhan) 
VALUES 
('TK001', 1001, 2000000, '2024-01-01', 12, 5.00, 2100000),
('TK002', 1002, 3000000, '2024-02-01', 6, 4.50, 3135000),
('TK003', 1003, 5000000, '2024-03-01', 24, 6.00, 5600000);

-- Chèn dữ liệu vào bảng ChiTietTietKiem
INSERT INTO ChiTietTietKiem (MaTietKiem, HoatDong, SoTien,ThoiGianGiaoDich) 
VALUES 
('TK001', 'Nap tien tiet kiem', 2000000, '2024-05-01'),
('TK002', 'Nap tien tiet kiem', 3000000, '2024-05-01'),
('TK003', 'Nap tien tiet kiem', 5000000, '2024-05-01');

-- Chèn dữ liệu vào bảng KhoanVay
INSERT INTO KhoanVay (MaKhoanVay, SoTaiKhoan, SoTien, ThoiGian, KyHan, LaiSuat, SoTienPhaiTra) 
VALUES 
('KV001', 1001, 1000000, '2024-05-01', 12, 7.00, 1070000),
('KV002', 1002, 2000000, '2024-06-01', 24, 6.50, 2130000),
('KV003', 1003, 3000000, '2024-07-01', 36, 5.75, 3172500);

-- Chèn dữ liệu vào bảng ChiTietKhoanVay
INSERT INTO ChiTietKhoanVay (MaKhoanVay, HoatDong, SoTien,ThoiGianGiaoDich) 
VALUES 
('KV001', 'Vay tien', 1000000,'2024-05-01'),
('KV002', 'Vay tien', 2000000,'2024-05-01'),
('KV003', 'Vay tien', 3000000,'2024-05-01');








