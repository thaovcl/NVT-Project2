USE [NguyenVanThao_K22CNT1_Project2]
GO
/****** Object:  Table [dbo].[DANH_GIA]    Script Date: 10/28/2024 3:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DANH_GIA](
	[Ma_danh_gia] [int] NOT NULL,
	[Ma_tour] [int] NULL,
	[Ma_KH] [int] NULL,
	[Noi_dung] [text] NULL,
	[Diem_so] [tinyint] NULL,
	[Ngay_danh_gia] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_danh_gia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DAT_TOUR]    Script Date: 10/28/2024 3:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DAT_TOUR](
	[Ma_dat_tour] [int] NOT NULL,
	[Ma_tour] [int] NULL,
	[Ma_KH] [int] NULL,
	[So_luong] [int] NULL,
	[Ngay_dat] [datetime] NULL,
	[Trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_dat_tour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOA_DON]    Script Date: 10/28/2024 3:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOA_DON](
	[Ma_hoa_don] [int] NOT NULL,
	[Ma_dat_tour] [int] NULL,
	[Ngay_thanh_toan] [datetime] NULL,
	[Tong_tien] [decimal](10, 2) NULL,
	[Phuong_thuc] [varchar](50) NULL,
	[Trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_hoa_don] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACH_HANG]    Script Date: 10/28/2024 3:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACH_HANG](
	[Ma_KH] [int] NOT NULL,
	[Ho_ten] [varchar](100) NULL,
	[Tai_khoan] [varchar](50) NULL,
	[Mat_khau] [varchar](32) NULL,
	[Dia_chi] [varchar](200) NULL,
	[Dien_thoai] [varchar](30) NULL,
	[Email] [varchar](50) NULL,
	[Ngay_tao] [datetime] NULL,
	[Trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_KH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QUAN_TRI]    Script Date: 10/28/2024 3:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QUAN_TRI](
	[Tai_khoan] [varchar](50) NOT NULL,
	[Mat_khau] [varchar](32) NULL,
	[Trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Tai_khoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TOUR]    Script Date: 10/28/2024 3:53:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOUR](
	[Ma_Tour] [int] NOT NULL,
	[Ten_tour] [varchar](100) NULL,
	[Mo_ta] [text] NULL,
	[Gia_tour] [decimal](10, 2) NULL,
	[Thoi_gian] [int] NULL,
	[Diem_khoi_hanh] [varchar](100) NULL,
	[Diem_den] [varchar](100) NULL,
	[Trang_thai] [tinyint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Ma_Tour] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[DANH_GIA]  WITH CHECK ADD FOREIGN KEY([Ma_KH])
REFERENCES [dbo].[KHACH_HANG] ([Ma_KH])
GO
ALTER TABLE [dbo].[DANH_GIA]  WITH CHECK ADD FOREIGN KEY([Ma_tour])
REFERENCES [dbo].[TOUR] ([Ma_Tour])
GO
ALTER TABLE [dbo].[DAT_TOUR]  WITH CHECK ADD FOREIGN KEY([Ma_KH])
REFERENCES [dbo].[KHACH_HANG] ([Ma_KH])
GO
ALTER TABLE [dbo].[DAT_TOUR]  WITH CHECK ADD FOREIGN KEY([Ma_tour])
REFERENCES [dbo].[TOUR] ([Ma_Tour])
GO
ALTER TABLE [dbo].[HOA_DON]  WITH CHECK ADD FOREIGN KEY([Ma_dat_tour])
REFERENCES [dbo].[DAT_TOUR] ([Ma_dat_tour])
GO
ALTER TABLE [dbo].[KHACH_HANG]  WITH CHECK ADD FOREIGN KEY([Tai_khoan])
REFERENCES [dbo].[QUAN_TRI] ([Tai_khoan])
GO
