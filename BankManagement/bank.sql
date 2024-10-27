CREATE DATABASE QLBank
use QLBank
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


-- Bảng login
CREATE TABLE Login (
    MaNhanVien nvarchar(20) PRIMARY KEY,
    username NVARCHAR(50) ,
    password NVARCHAR(255),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);
-- Thêm 6 bản ghi vào bảng KhachHang
INSERT INTO KhachHang VALUES 
('KH001', 'Nguyen Van A', '012345678901', '0901234567', 'Nam', '1990-01-01', 'vana@example.com', 'Ha Noi', 'Lap trinh vien', 'KH001.jpg'),
('KH002', 'Le Thi B', '012345678902', '0902234567', 'Nu', '1992-02-02', 'bthi@example.com', 'Hai Phong', 'Nhan vien ke toan', 'KH002.jpg'),
('KH003', 'Tran Van C', '012345678903', '0903234567', 'Nam', '1994-03-03', 'vanc@example.com', 'Da Nang', 'Kinh doanh', 'KH003.jpg'),
('KH004', 'Pham Thi D', '012345678904', '0904234567', 'Nu', '1996-04-04', 'thid@example.com', 'Ho Chi Minh', 'Ban hang', 'KH004.jpg'),
('KH005', 'Nguyen Van E', '012345678905', '0905234567', 'Nam', '1998-05-05', 'vane@example.com', 'Can Tho', 'Giao vien', 'KH005.jpg'),
('KH006', 'Le Van F', '012345678906', '0906234567', 'Nam', '2000-06-06', 'vaf@example.com', 'Quang Ninh', 'Ky su', 'KH006.jpg');
INSERT INTO AnhKhachHang VALUES 
('KH001', 'KH001.jpg'),
('KH002', 'KH002.jpg'),
('KH003', 'KH003.jpg'),
('KH004', 'KH004.jpg'),
('KH005', 'KH005.jpg'),
('KH006', 'KH006.jpg');
-- Thêm 6 bản ghi vào bảng NhanVien
INSERT INTO NhanVien VALUES 
('NV001', 'Tran Van A', 'Giam Doc', '2020-01-01', '1980-01-01', 'Nam', 'Ha Noi', '012345678901', '0901234561', 'vana@bank.com'),
('NV002', 'Nguyen Thi B', 'Truong Phong', '2020-02-01', '1982-02-02', 'Nu', 'Hai Phong', '012345678902', '0902234561', 'thib@bank.com'),
('NV003', 'Pham Van C', 'Nhan Vien', '2020-03-01', '1984-03-03', 'Nam', 'Da Nang', '012345678903', '0903234561', 'vanc@bank.com'),
('NV004', 'Le Thi D', 'Nhan Vien', '2020-04-01', '1986-04-04', 'Nu', 'Ho Chi Minh', '012345678904', '0904234561', 'thid@bank.com'),
('NV005', 'Bui Van E', 'Nhan Vien', '2020-05-01', '1988-05-05', 'Nam', 'Can Tho', '012345678905', '0905234561', 'vane@bank.com'),
('NV006', 'Dang Thi F', 'Nhan Vien', '2020-06-01', '1990-06-06', 'Nu', 'Quang Ninh', '012345678906', '0906234561', 'thif@bank.com');

-- Thêm 6 bản ghi vào bảng TaiKhoan
INSERT INTO TaiKhoan VALUES 
('TK001', 'ThanhToan', 1000000, '2023-01-01', 'KH001', 200000, 500000),
('TK002', 'TietKiem', 5000000, '2023-02-01', 'KH002', 300000, 1000000),
('TK003', 'VayVon', 2000000, '2023-03-01', 'KH003', 150000, 3000000),
('TK004', 'ThanhToan', 3000000, '2023-04-01', 'KH004', 500000, 1500000),
('TK005', 'TietKiem', 1000000, '2023-05-01', 'KH005', 700000, 2000000),
('TK006', 'VayVon', 4000000, '2023-06-01', 'KH006', 600000, 2500000);

-- Thêm 6 bản ghi vào bảng GiaoDich
INSERT INTO GiaoDich VALUES 
('GD001', 'Nhan Tien', 'NV001', 'Nguyen Van A', 'KH001', '2023-01-15', 500000),
('GD002', 'Chuyen Tien', 'NV002', 'Le Thi B', 'KH002', '2023-02-15', 1000000),
('GD003', 'Gui Tiet Kiem', 'NV003', 'Tran Van C', 'KH003', '2023-03-15', 1500000),
('GD004', 'Rut Tien Tiet Kiem', 'NV004', 'Pham Thi D', 'KH004', '2023-04-15', 2000000),
('GD005', 'Vay Von', 'NV005', 'Nguyen Van E', 'KH005', '2023-05-15', 2500000),
('GD006', 'Tra No', 'NV006', 'Le Van F', 'KH006', '2023-06-15', 3000000);


-- Thêm 6 bản ghi vào bảng Login
INSERT INTO Login VALUES 
('NV001', 'tranvana', 'pass123'),
('NV002', 'nguyenthib', 'pass123'),
('NV003', 'phamvanc', 'pass123'),
('NV004', 'lethid', 'pass123'),
('NV005', 'buivane', 'pass123'),
('NV006', 'dangthif', 'pass123');

