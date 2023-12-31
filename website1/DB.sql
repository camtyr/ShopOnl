USE [master]
GO
/****** Object:  Database [QLBH]    Script Date: 9/18/2023 10:53:35 PM ******/
CREATE DATABASE [QLBH]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLBH', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\QLBH.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLBH_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\QLBH_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [QLBH] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLBH].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLBH] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLBH] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLBH] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLBH] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLBH] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLBH] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLBH] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLBH] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLBH] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLBH] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLBH] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLBH] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLBH] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLBH] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLBH] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QLBH] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLBH] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLBH] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLBH] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLBH] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLBH] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLBH] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLBH] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QLBH] SET  MULTI_USER 
GO
ALTER DATABASE [QLBH] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLBH] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLBH] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLBH] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLBH] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QLBH] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QLBH] SET QUERY_STORE = ON
GO
ALTER DATABASE [QLBH] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [QLBH]
GO
/****** Object:  Table [dbo].[Account]    Script Date: 9/18/2023 10:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 9/18/2023 10:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[IDDonHang] [int] NULL,
	[MaSanPham] [int] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 9/18/2023 10:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[IDDH] [int] IDENTITY(1,1) NOT NULL,
	[NgayTao] [date] NULL,
	[DiaChi] [nvarchar](300) NULL,
	[MaTaiKhoan] [int] NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[IDDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 9/18/2023 10:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[IDGH] [int] IDENTITY(1,1) NOT NULL,
	[MaTaiKhoan] [int] NULL,
	[MaSanPham] [int] NULL,
	[TenSanPham] [nvarchar](300) NULL,
	[SoLuong] [int] NULL,
	[Gia] [money] NULL,
	[TongTien] [money] NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[IDGH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 9/18/2023 10:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](50) NULL,
	[SoDienThoai] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](200) NULL,
	[UserName] [varchar](50) NULL,
	[Email] [varchar](100) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 9/18/2023 10:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[MaLoaiSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenLoaiSanPham] [nvarchar](100) NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[MaLoaiSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaSanXuat]    Script Date: 9/18/2023 10:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaSanXuat](
	[MaNhaSanXuat] [int] IDENTITY(1,1) NOT NULL,
	[TenNhaSanXuat] [nvarchar](100) NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_NhaSanXuat] PRIMARY KEY CLUSTERED 
(
	[MaNhaSanXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 9/18/2023 10:53:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[MaLoaiSanPham] [int] NULL,
	[MaNhaSanXuat] [int] NULL,
	[TenSanPham] [nvarchar](300) NULL,
	[CauHinh] [nvarchar](300) NULL,
	[HinhChinh] [nvarchar](50) NULL,
	[Hinh1] [nvarchar](50) NULL,
	[Hinh2] [nvarchar](50) NULL,
	[Hinh3] [nvarchar](50) NULL,
	[Hinh4] [nvarchar](50) NULL,
	[Gia] [money] NULL,
	[SoLuongDaBan] [int] NULL,
	[TinhTrang] [bit] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Account] ([UserName], [Password]) VALUES (N'admin', N'Quataochan12345')
INSERT [dbo].[Account] ([UserName], [Password]) VALUES (N'duc1', N'Quataochan123')
INSERT [dbo].[Account] ([UserName], [Password]) VALUES (N'duc123', N'Quataochan123')
GO
SET IDENTITY_INSERT [dbo].[ChiTietDonHang] ON 

INSERT [dbo].[ChiTietDonHang] ([ID], [IDDonHang], [MaSanPham], [SoLuong]) VALUES (19, 16, 1, 1)
INSERT [dbo].[ChiTietDonHang] ([ID], [IDDonHang], [MaSanPham], [SoLuong]) VALUES (20, 16, 2012, 7)
SET IDENTITY_INSERT [dbo].[ChiTietDonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[DonHang] ON 

INSERT [dbo].[DonHang] ([IDDH], [NgayTao], [DiaChi], [MaTaiKhoan]) VALUES (16, CAST(N'2023-09-18' AS Date), N'Pho Vong', 8003)
SET IDENTITY_INSERT [dbo].[DonHang] OFF
GO
SET IDENTITY_INSERT [dbo].[GioHang] ON 

INSERT [dbo].[GioHang] ([IDGH], [MaTaiKhoan], [MaSanPham], [TenSanPham], [SoLuong], [Gia], [TongTien]) VALUES (2003, 8003, 1, N'Iphone 7', 2, 3950000.0000, 7900000.0000)
INSERT [dbo].[GioHang] ([IDGH], [MaTaiKhoan], [MaSanPham], [TenSanPham], [SoLuong], [Gia], [TongTien]) VALUES (2004, 8003, 2012, N'Iphone 6', 3, 3590000.0000, 10770000.0000)
SET IDENTITY_INSERT [dbo].[GioHang] OFF
GO
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([ID], [TenKhachHang], [SoDienThoai], [DiaChi], [UserName], [Email]) VALUES (8003, N'Bùi Văn Đức', N'0394674706', N'Hà Nội', N'duc123', N'duc123@gmail.com')
INSERT [dbo].[KhachHang] ([ID], [TenKhachHang], [SoDienThoai], [DiaChi], [UserName], [Email]) VALUES (8004, NULL, NULL, NULL, N'duc1', NULL)
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [TinhTrang]) VALUES (1, N'Cao cấp', 1)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [TinhTrang]) VALUES (2, N'Trung bình', 1)
INSERT [dbo].[LoaiSanPham] ([MaLoaiSanPham], [TenLoaiSanPham], [TinhTrang]) VALUES (5, N'Thấp', 0)
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[NhaSanXuat] ON 

INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (1, N'Iphone', 1)
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (2, N'Samsung', 1)
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (7, N'HP', 1)
INSERT [dbo].[NhaSanXuat] ([MaNhaSanXuat], [TenNhaSanXuat], [TinhTrang]) VALUES (10, N'Dell', 1)
SET IDENTITY_INSERT [dbo].[NhaSanXuat] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [TinhTrang]) VALUES (1, 2, 1, N'Iphone 7', N'<p>Màn hình: LED-backlit IPS LCD4.7"Retina HD</p><p>Hệ điều hành: iOS 14</p><p>Camera sau: 12 MP</p><p>Camera trước: 7 MP</p><p>Chip: Apple A10 Fusion</p><p>RAM: 2 GB</p><p>Dung lượng lưu trữ: 32 GB</p><p>SIM: 1 Nano SIM Hỗ trợ 4G</p><p>Pin, Sạc: 1960 mAh</p>', N'Iphone 7.png', NULL, NULL, NULL, NULL, 3950000.0000, 0, 1)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [TinhTrang]) VALUES (2012, 2, 2, N'Iphone 6', N'<p>Màn hình: LED-backlit IPS LCD4.7"Retina HD</p><p>Hệ điều hành: iOS 12</p><p>Camera sau: 8 MP</p><p>Camera trước: 1.2 MP</p><p>Chip:</p><p>Apple A8</p><p>RAM: 1 GB</p><p>Dung lượng lưu trữ: 32 GB</p><p>SIM: 1 Nano SIM</p><p>Pin, Sạc: 1810 mAh</p>', N'Iphone 6 32GB.png', NULL, NULL, NULL, NULL, 3590000.0000, 0, 1)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [TinhTrang]) VALUES (2013, 2, 2, N'iphone 5', NULL, N'iphone 5.png', NULL, NULL, NULL, NULL, 2550000.0000, 0, 1)
INSERT [dbo].[SanPham] ([MaSanPham], [MaLoaiSanPham], [MaNhaSanXuat], [TenSanPham], [CauHinh], [HinhChinh], [Hinh1], [Hinh2], [Hinh3], [Hinh4], [Gia], [SoLuongDaBan], [TinhTrang]) VALUES (2014, 1, 1, N'samsung', NULL, N'samsung.png', NULL, NULL, NULL, NULL, 12.0000, 0, 0)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
ALTER TABLE [dbo].[LoaiSanPham] ADD  CONSTRAINT [DF_LoaiSanPham_TinhTrang]  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[NhaSanXuat] ADD  CONSTRAINT [DF_NhaSanXuat_TinhTrang]  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_TinhTrang]  DEFAULT ((0)) FOR [TinhTrang]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [FK_KhachHang_Account] FOREIGN KEY([UserName])
REFERENCES [dbo].[Account] ([UserName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [FK_KhachHang_Account]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([MaLoaiSanPham])
REFERENCES [dbo].[LoaiSanPham] ([MaLoaiSanPham])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_NhaSanXuat] FOREIGN KEY([MaNhaSanXuat])
REFERENCES [dbo].[NhaSanXuat] ([MaNhaSanXuat])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_NhaSanXuat]
GO
USE [master]
GO
ALTER DATABASE [QLBH] SET  READ_WRITE 
GO
