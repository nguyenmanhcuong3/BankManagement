
-- Bảng KhachHang
CREATE TABLE KhachHang (
    MaKhachHang nvarchar(20) PRIMARY KEY ,
    TenKhachHang VARCHAR(100),
    SoCCCD VARCHAR(20),
    SoDienThoai VARCHAR(20),
    GioiTinh VARCHAR(20),
    NgaySinh datetime,
    Email VARCHAR(100),
    DiaChi nvarchar(100),
    NgheNghiep VARCHAR(100),
    AnhDaiDien VARCHAR(200)
);

CREATE TABLE AnhKhachHang (
    MaKhachHang nvarchar(20) PRIMARY KEY,
    AnhDaiDien VARCHAR(255) NOT NULL,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang) ON DELETE CASCADE
);
-- Bảng TaiKhoan
CREATE TABLE TaiKhoan (
    MaTaiKhoan nvarchar(20) PRIMARY KEY,
    LoaiTaiKhoan NVARCHAR(50),
    SoTien DECIMAL(18, 2),
    ThoiGianMo DATETIME,
    MaKhachHang nvarchar(20),
    SoTienGuiTietKiem int,
    SoTienVay int,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang)
);

-- Bảng GiaoDich
CREATE TABLE GiaoDich (
    MaGiaoDich nvarchar(20) PRIMARY KEY,
    LoaiGiaoDich NVARCHAR(50),
    MaNhanVien nvarchar(20),
    TenKhachHang NVARCHAR(100),
    MaKhachHang nvarchar(20),
    ThoiGianGiaoDich DATETIME,
    SoTienGiaoDich int,
    FOREIGN KEY (MaKhachHang) REFERENCES KhachHang(MaKhachHang),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

-- Bảng NhanVien
CREATE TABLE NhanVien (
    MaNhanVien nvarchar(20) PRIMARY KEY,
    TenNhanVien NVARCHAR(100),
    ChucVu NVARCHAR(50),
    NgayVaoLam datetime,
    NgaySinh datetime,
    GioiTinh NVARCHAR(10),
    DiaChi NVARCHAR(255),
    SoCCCD NVARCHAR(12) ,
    SoDienThoai NVARCHAR(15),
    Email NVARCHAR(100)
);

-- Bảng login
CREATE TABLE Login (
    MaNhanVien nvarchar(20) PRIMARY KEY,
    username NVARCHAR(50) ,
    password NVARCHAR(255),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
INSERT INTO KhachHang (MaKhachHang, TenKhachHang, SoCCCD, SoDienThoai, GioiTinh, NgaySinh, Email, DiaChi, NgheNghiep, AnhDaiDien)
VALUES 
('KH001', 'Nguyen Van A', '123456789012', '0901234567', 'Nam', '1990-01-01', 'nguyenvana@example.com', '123 Duong ABC, Quan 1', 'Ky su', 'anh1.jpg'),
('KH002', 'Tran Thi B', '234567890123', '0912345678', 'Nu', '1995-05-05', 'tranthib@example.com', '456 Duong DEF, Quan 2', 'Giao vien', 'anh2.jpg');
INSERT INTO AnhKhachHang (MaKhachHang, AnhDaiDien)
VALUES 
('KH001', 'anh1.jpg'),
('KH002', 'anh2.jpg');
INSERT INTO NhanVien (MaNhanVien, TenNhanVien, ChucVu, NgayVaoLam, NgaySinh, GioiTinh, DiaChi, SoCCCD, SoDienThoai, Email)
VALUES 
('NV001', 'Le Van C', 'Quan ly', '2020-01-01', '1985-02-02', 'Nam', '789 Duong GHI, Quan 3', '345678901234', '0923456789', 'levanc@example.com'),
('NV002', 'Nguyen Thi D', 'Nhan vien', '2021-05-15', '1990-08-08', 'Nu', '321 Duong JKL, Quan 4', '456789012345', '0934567890', 'nguyenthid@example.com');
INSERT INTO TaiKhoan (MaTaiKhoan, LoaiTaiKhoan, SoTien, ThoiGianMo, MaKhachHang, SoTienGuiTietKiem, SoTienVay)
VALUES 
('TK001', 'Tiet kiem', 10000.00, '2022-01-01', 'KH001', 5000, 0),
('TK002', 'Vay tin chap', 5000.00, '2023-03-01', 'KH002', 0, 2000);
INSERT INTO GiaoDich (MaGiaoDich, LoaiGiaoDich, MaNhanVien, TenKhachHang, MaKhachHang, ThoiGianGiaoDich, SoTienGiaoDich)
VALUES 
('GD001', 'Rut tien', 'NV001', 'Nguyen Van A', 'KH001', '2024-01-10', 2000),
('GD002', 'Gui tien', 'NV002', 'Tran Thi B', 'KH002', '2024-02-15', 3000);
INSERT INTO Login (MaNhanVien, username, password)
VALUES 
('NV001', 'admin', '123'),
('NV002', 'admin', '456');
