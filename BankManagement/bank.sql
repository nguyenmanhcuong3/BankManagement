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
('NV006', 'Dang Thi F', 'Nhan Vien', '2020-06-01', '1990-06-06', 'Nu', 'Quang Ninh', '012345678906', '0906234561', 'thif@bank.com'),
('NV007', 'Nguyen Van G', 'Nhan Vien', '2020-07-01', '1992-07-07', 'Nam', 'Ninh Binh', '012345678907', '0907234561', 'gang@bank.com'),
('NV008', 'Tran Thi H', 'Nhan Vien', '2020-08-01', '1994-08-08', 'Nu', 'Ha Nam', '012345678908', '0908234561', 'h@bank.com'),
('NV009', 'Pham Van I', 'Nhan Vien', '2020-09-01', '1995-09-09', 'Nam', 'Nam Dinh', '012345678909', '0909234561', 'i@bank.com'),
('NV010', 'Le Thi J', 'Nhan Vien', '2020-10-01', '1996-10-10', 'Nu', 'Thai Binh', '012345678910', '0910234561', 'j@bank.com'),
('NV011', 'Bui Van K', 'Nhan Vien', '2020-11-01', '1997-11-11', 'Nam', 'Ninh Thuan', '012345678911', '0911234561', 'k@bank.com'),
('NV012', 'Nguyen Thi L', 'Nhan Vien', '2020-12-01', '1998-12-12', 'Nu', 'Bac Ninh', '012345678912', '0912234561', 'l@bank.com'),
('NV013', 'Tran Van M', 'Nhan Vien', '2021-01-01', '1999-01-13', 'Nam', 'Quang Tri', '012345678913', '0913234561', 'm@bank.com'),
('NV014', 'Pham Thi N', 'Nhan Vien', '2021-02-01', '1993-02-14', 'Nu', 'Dak Lak', '012345678914', '0914234561', 'n@bank.com'),
('NV015', 'Le Van O', 'Nhan Vien', '2021-03-01', '1991-03-15', 'Nam', 'Gia Lai', '012345678915', '0915234561', 'o@bank.com'),
('NV016', 'Bui Thi P', 'Nhan Vien', '2021-04-01', '1990-04-16', 'Nu', 'Ninh Binh', '012345678916', '0916234561', 'p@bank.com'),
('NV017', 'Nguyen Van Q', 'Nhan Vien', '2021-05-01', '1989-05-17', 'Nam', 'Ha Tinh', '012345678917', '0917234561', 'q@bank.com'),
('NV018', 'Tran Thi R', 'Nhan Vien', '2021-06-01', '1992-06-18', 'Nu', 'Lang Son', '012345678918', '0918234561', 'r@bank.com'),
('NV019', 'Pham Van S', 'Nhan Vien', '2021-07-01', '1990-07-19', 'Nam', 'Thai Nguyen', '012345678919', '0919234561', 's@bank.com'),
('NV020', 'Le Thi T', 'Nhan Vien', '2021-08-01', '1993-08-20', 'Nu', 'Son La', '012345678920', '0920234561', 't@bank.com'),
('NV021', 'Bui Van U', 'Nhan Vien', '2021-09-01', '1991-09-21', 'Nam', 'Bac Kan', '012345678921', '0921234561', 'u@bank.com'),
('NV022', 'Nguyen Thi V', 'Nhan Vien', '2021-10-01', '1994-10-22', 'Nu', 'Hoa Binh', '012345678922', '0922234561', 'v@bank.com'),
('NV023', 'Tran Van W', 'Nhan Vien', '2021-11-01', '1995-11-23', 'Nam', 'Ha Giang', '012345678923', '0923234561', 'w@bank.com'),
('NV024', 'Pham Thi X', 'Nhan Vien', '2021-12-01', '1996-12-24', 'Nu', 'Quang Nam', '012345678924', '0924234561', 'x@bank.com'),
('NV025', 'Le Van Y', 'Nhan Vien', '2022-01-01', '1998-01-25', 'Nam', 'Binh Duong', '012345678925', '0925234561', 'y@bank.com'),
('NV026', 'Bui Thi Z', 'Nhan Vien', '2022-02-01', '1997-02-26', 'Nu', 'Da Nang', '012345678926', '0926234561', 'z@bank.com'),
('NV027', 'Nguyen Van AA', 'Nhan Vien', '2022-03-01', '1993-03-27', 'Nam', 'Quang Ninh', '012345678927', '0927234561', 'aa@bank.com'),
('NV028', 'Tran Thi AB', 'Nhan Vien', '2022-04-01', '1994-04-28', 'Nu', 'Ha Tinh', '012345678928', '0928234561', 'ab@bank.com'),
('NV029', 'Pham Van AC', 'Nhan Vien', '2022-05-01', '1995-05-29', 'Nam', 'Ha Noi', '012345678929', '0929234561', 'ac@bank.com'),
('NV030', 'Le Thi AD', 'Nhan Vien', '2022-06-01', '1996-06-30', 'Nu', 'Ho Chi Minh', '012345678930', '0930234561', 'ad@bank.com'),
('NV031', 'Bui Van AE', 'Nhan Vien', '2022-07-01', '1997-07-31', 'Nam', 'Bac Ninh', '012345678931', '0931234561', 'ae@bank.com'),
('NV032', 'Nguyen Thi AF', 'Nhan Vien', '2022-08-01', '1998-08-01', 'Nu', 'Hai Phong', '012345678932', '0932234561', 'af@bank.com'),
('NV033', 'Tran Van AG', 'Nhan Vien', '2022-09-01', '1999-09-02', 'Nam', 'Da Nang', '012345678933', '0933234561', 'ag@bank.com'),
('NV034', 'Pham Thi AH', 'Nhan Vien', '2022-10-01', '1990-10-03', 'Nu', 'Quang Binh', '012345678934', '0934234561', 'ah@bank.com'),
('NV035', 'Le Van AI', 'Nhan Vien', '2022-11-01', '1989-11-04', 'Nam', 'Gia Lai', '012345678935', '0935234561', 'ai@bank.com'),
('NV036', 'Bui Thi AJ', 'Nhan Vien', '2022-12-01', '1988-12-05', 'Nu', 'Dak Lak', '012345678936', '0936234561', 'aj@bank.com'),
('NV037', 'Nguyen Van AK', 'Nhan Vien', '2023-01-01', '1987-01-06', 'Nam', 'Ninh Binh', '012345678937', '0937234561', 'ak@bank.com'),
('NV038', 'Tran Thi AL', 'Nhan Vien', '2023-02-01', '1990-02-07', 'Nu', 'Nam Dinh', '012345678938', '0938234561', 'al@bank.com'),
('NV039', 'Pham Van AM', 'Nhan Vien', '2023-03-01', '1989-03-08', 'Nam', 'Quang Nam', '012345678939', '0939234561', 'am@bank.com'),
('NV040', 'Le Thi AN', 'Nhan Vien', '2023-04-01', '1991-04-09', 'Nu', 'Hai Duong', '012345678940', '0940234561', 'an@bank.com'),
('NV041', 'Bui Van AO', 'Nhan Vien', '2023-05-01', '1992-05-10', 'Nam', 'Ha Nam', '012345678941', '0941234561', 'ao@bank.com'),
('NV042', 'Nguyen Thi AP', 'Nhan Vien', '2023-06-01', '1993-06-11', 'Nu', 'Thai Nguyen', '012345678942', '0942234561', 'ap@bank.com'),
('NV043', 'Tran Van AQ', 'Nhan Vien', '2023-07-01', '1994-07-12', 'Nam', 'Hai Phong', '012345678943', '0943234561', 'aq@bank.com'),
('NV044', 'Pham Thi AR', 'Nhan Vien', '2023-08-01', '1995-08-13', 'Nu', 'Quang Ninh', '012345678944', '0944234561', 'ar@bank.com'),
('NV045', 'Le Van AS', 'Nhan Vien', '2023-09-01', '1996-09-14', 'Nam', 'Bac Giang', '012345678945', '0945234561', 'as@bank.com'),
('NV046', 'Bui Thi AT', 'Nhan Vien', '2023-10-01', '1997-10-15', 'Nu', 'Nam Dinh', '012345678946', '0946234561', 'at@bank.com'),
('NV047', 'Nguyen Van AU', 'Nhan Vien', '2023-11-01', '1998-11-16', 'Nam', 'Ha Nam', '012345678947', '0947234561', 'au@bank.com'),
('NV048', 'Tran Thi AV', 'Nhan Vien', '2023-12-01', '1999-12-17', 'Nu', 'Bac Ninh', '012345678948', '0948234561', 'av@bank.com'),
('NV049', 'Pham Van AW', 'Nhan Vien', '2024-01-01', '1990-01-18', 'Nam', 'Dak Lak', '012345678949', '0949234561', 'aw@bank.com'),
('NV050', 'Le Thi AX', 'Nhan Vien', '2024-02-01', '1991-02-19', 'Nu', 'Gia Lai', '012345678950', '0950234561', 'ax@bank.com');

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

