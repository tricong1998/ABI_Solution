USE [abiexam_db]
GO
/****** Object:  Table [dbo].[answer]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[answer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[answer_file] [nvarchar](255) NULL,
	[score] [int] NOT NULL,
	[description] [nvarchar](255) NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_answer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[chairman]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chairman](
	[user_id] [int] NOT NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_chairman] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[exam]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exam](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[description] [nvarchar](255) NULL,
	[customer] [nvarchar](255) NULL,
	[time_start] [datetime] NOT NULL,
	[duration] [int] NOT NULL CONSTRAINT [DF_exam_duration]  DEFAULT ((3600)),
	[number_question] [int] NOT NULL CONSTRAINT [DF_exam_number_question]  DEFAULT ((30)),
	[active] [tinyint] NOT NULL CONSTRAINT [DF_exam_active]  DEFAULT ((0)),
	[create_at] [datetime2](3) NOT NULL CONSTRAINT [DF_exam_create_at]  DEFAULT (sysdatetime()),
 CONSTRAINT [PK_exam] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[exam_chairman]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exam_chairman](
	[id] [int] NOT NULL,
	[chairman_id] [int] NOT NULL,
	[exam_id] [int] NOT NULL,
	[active] [tinyint] NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_exam_chairman] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[exam_examinee]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exam_examinee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[examinee_id] [int] NOT NULL,
	[exam_id] [int] NOT NULL,
	[joined] [tinyint] NULL,
	[active] [tinyint] NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_user_exam] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[exam_practice_type]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exam_practice_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[exam_id] [int] NOT NULL,
	[type_id] [int] NOT NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_exam_practice_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[exam_question]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exam_question](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[exam_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_exam_question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[exam_version]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[exam_version](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[exam_id] [int] NOT NULL,
	[office_id] [int] NOT NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_exam_version] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[examinee]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[examinee](
	[user_id] [int] NOT NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_examinee] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[examinee_answer]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[examinee_answer](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[examinee_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
	[answer_id] [int] NOT NULL,
	[exam_id] [int] NOT NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_examinee_answer] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[off_question_map_t2]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[off_question_map_t2](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[question_id] [int] NOT NULL,
	[type_l2_id] [int] NOT NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_off_question_map_t2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[off_question_type_l1]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[off_question_type_l1](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[practice_id] [int] NOT NULL,
	[description] [nvarchar](255) NULL,
	[create_at] [datetime2](3) NOT NULL CONSTRAINT [DF_off_question_type_l1_create_at]  DEFAULT (sysdatetime()),
 CONSTRAINT [PK_off_question_type_l1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[off_question_type_l2]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[off_question_type_l2](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[type_l1] [int] NOT NULL,
	[description] [nvarchar](255) NULL,
	[create_at] [datetime2](3) NOT NULL CONSTRAINT [DF_off_question_type_l2_create_at]  DEFAULT (sysdatetime()),
 CONSTRAINT [PK_off_question_type_l2] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[off_question_version]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[off_question_version](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[question_id] [int] NOT NULL,
	[office_id] [int] NOT NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_off_question_version] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[office_question]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[office_question](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](255) NULL,
	[html_content] [nvarchar](1024) NULL,
	[markdown_content] [nvarchar](1024) NULL,
	[file_question] [nvarchar](255) NULL,
	[file_correct_answer] [nvarchar](255) NULL,
	[active] [tinyint] NULL CONSTRAINT [DF_office_question_active]  DEFAULT ((1)),
	[description] [nvarchar](255) NULL,
	[image] [nvarchar](255) NULL,
	[request] [tinyint] NULL CONSTRAINT [DF_office_question_request]  DEFAULT ((1)),
	[create_at] [datetime2](3) NOT NULL CONSTRAINT [DF_office_question_create_at]  DEFAULT (sysdatetime()),
 CONSTRAINT [PK_office_question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[office_version]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[office_version](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](255) NULL,
	[create_at] [datetime2](3) NOT NULL,
 CONSTRAINT [PK_office_version] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[practice_type]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[practice_type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[create_at] [datetime2](3) NOT NULL CONSTRAINT [DF_practice_type_create_at]  DEFAULT (sysdatetime()),
 CONSTRAINT [PK_practice_type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[user]    Script Date: 8/6/2018 11:38:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](255) NOT NULL,
	[email] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[active] [tinyint] NULL,
	[create_at] [datetime2](3) NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[exam] ON 

GO
INSERT [dbo].[exam] ([id], [name], [description], [customer], [time_start], [duration], [number_question], [active], [create_at]) VALUES (1, N'Exam testing development', N'for development only', N'FIT UET', CAST(N'2018-12-01 08:00:00.000' AS DateTime), 3600, 30, 1, CAST(N'2018-08-05 14:44:37.7900000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[exam] OFF
GO
SET IDENTITY_INSERT [dbo].[off_question_type_l1] ON 

GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (1, N'Mở văn bản có sẵn, tạo văn bản mới, lưu, xóa văn bản', 1, NULL, CAST(N'2018-08-05 15:14:42.6390000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (2, N'Biên tập nội dung văn bản', 1, NULL, CAST(N'2018-08-05 15:14:42.6470000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (3, N'Xử lý lỗi hiển thị tiếng Việt', 1, NULL, CAST(N'2018-08-05 15:14:42.6500000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (4, N'Định dạng văn bản (text)', 1, NULL, CAST(N'2018-08-05 15:14:42.6530000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (5, N'Định dạng đoạn văn', 1, NULL, CAST(N'2018-08-05 15:14:42.6550000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (6, N'Kiểu dáng (style)', 1, NULL, CAST(N'2018-08-05 15:14:42.6570000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (7, N'Bảng', 1, NULL, CAST(N'2018-08-05 15:14:42.6600000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (8, N'Hình minh họa (đối tượng đồ họa)', 1, NULL, CAST(N'2018-08-05 15:14:42.6610000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (9, N'Hộp văn bản', 1, NULL, CAST(N'2018-08-05 15:14:42.6630000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (10, N'Tham chiếu (reference)', 1, NULL, CAST(N'2018-08-05 15:14:42.6650000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (11, N'Hoàn tất văn bản', 1, NULL, CAST(N'2018-08-05 15:14:42.6670000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (12, N'Kết xuất và phân phối văn bản', 1, NULL, CAST(N'2018-08-05 15:14:42.6680000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l1] ([id], [name], [practice_id], [description], [create_at]) VALUES (13, N'Phân phối văn bản', 1, NULL, CAST(N'2018-08-05 15:14:42.6700000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[off_question_type_l1] OFF
GO
SET IDENTITY_INSERT [dbo].[off_question_type_l2] ON 

GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (1, N'Mở một văn bản', 1, NULL, CAST(N'2018-08-05 15:25:55.4140000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (2, N'Đóng một văn bản', 1, NULL, CAST(N'2018-08-05 15:25:55.4220000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (3, N'Tạo một văn bản mới', 1, NULL, CAST(N'2018-08-05 15:25:55.4240000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (4, N'Lưu tài liệu đang mở vào một thư mục với tên cũ hoặc đổi tên mới', 1, NULL, CAST(N'2018-08-05 15:25:55.4250000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (5, N'Xóa một văn bản', 1, NULL, CAST(N'2018-08-05 15:25:55.4270000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (6, N'Cắt, dán, sao chép, di chuyển một đơn vị, một phần văn bản', 2, NULL, CAST(N'2018-08-05 15:25:55.4300000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (7, N'Undo, redo', 2, NULL, CAST(N'2018-08-05 15:25:55.4310000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (8, N'Autocorrect cho tiếng Việt', 3, NULL, CAST(N'2018-08-05 15:25:55.4320000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (9, N'Loại bỏ các hiển thị không mong muốn (ví dụ: đường sóng cho vb t.Việt)', 3, NULL, CAST(N'2018-08-05 15:25:55.4330000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (10, N'Thay đổi phông chữ (cỡ chữ, kiểu chữ, đậm, nghiêng, gạch dưới)', 4, NULL, CAST(N'2018-08-05 15:25:55.4330000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (11, N'Ghi chỉ số dưới (subscript), chỉ số trên (superscript)', 4, NULL, CAST(N'2018-08-05 15:25:55.4360000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (12, N'Thay đổi màu ký tự và màu nền văn bản (HightlightColor)', 4, NULL, CAST(N'2018-08-05 15:25:55.4370000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (13, N'Chuyển đổi chữ hoa/chữ thường', 4, NULL, CAST(N'2018-08-05 15:25:55.4390000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (14, N'Ngắt từ (hypernation) khi xuống dòng', 4, NULL, CAST(N'2018-08-05 15:25:55.4400000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (15, N'Chèn ký hiệu đặc biệt như ©, ®', 4, NULL, CAST(N'2018-08-05 15:25:55.4410000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (16, N'Thêm, bỏ các dấu đoạn (paragraph mark), dấu ngắt dòng (line break)', 5, NULL, CAST(N'2018-08-05 15:25:55.4420000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (17, N'Thụt lề (indent), căn lề (trái, giữa, phải, đều hai biên)', 5, NULL, CAST(N'2018-08-05 15:25:55.4430000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (18, N'Thiết lập, gỡ bỏ và sử dụng nhảy cách (tab) (ví dụ: căn trái, căn giữa, căn phải)', 5, NULL, CAST(N'2018-08-05 15:25:55.4450000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (19, N'điều chỉnh khoảng cách giữa các đoạn văn', 5, NULL, CAST(N'2018-08-05 15:25:55.4570000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (20, N'Điều chỉnh khoảng cách giãn dòng trong đoạn văn', 5, NULL, CAST(N'2018-08-05 15:25:55.4590000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (21, N'Tạo/bỏ bullet hoặc numbering, thay đổi các kiểu dấu tự động, kiểu đánh số tự động khác nhau, Đánh số tự động các đoạn văn bản', 5, NULL, CAST(N'2018-08-05 15:25:55.4610000' AS DateTime2))
GO
INSERT [dbo].[off_question_type_l2] ([id], [name], [type_l1], [description], [create_at]) VALUES (22, N'Tạo đường viền, bóng/nền cho một đoạn văn', 5, NULL, CAST(N'2018-08-05 15:25:55.4760000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[off_question_type_l2] OFF
GO
SET IDENTITY_INSERT [dbo].[office_question] ON 

GO
INSERT [dbo].[office_question] ([id], [title], [html_content], [markdown_content], [file_question], [file_correct_answer], [active], [description], [image], [request], [create_at]) VALUES (1, N'Mở văn bản', N'Mở văn bản tại đường dẫn', NULL, N'qfile_1.docx', NULL, 1, NULL, NULL, 1, CAST(N'2018-08-05 15:51:06.5010000' AS DateTime2))
GO
INSERT [dbo].[office_question] ([id], [title], [html_content], [markdown_content], [file_question], [file_correct_answer], [active], [description], [image], [request], [create_at]) VALUES (2, N'Định dạng', N'Thay đổi font chữ trong đoạn văn thành <b>Arial</b>, cỡ chữ <b>14pt</b>', NULL, N'qfile_2.docx', N'afile_2.docx', 1, NULL, NULL, 1, CAST(N'2018-08-05 15:51:06.5130000' AS DateTime2))
GO
INSERT [dbo].[office_question] ([id], [title], [html_content], [markdown_content], [file_question], [file_correct_answer], [active], [description], [image], [request], [create_at]) VALUES (3, N'Định dạng', N'Với bullet trong văn bản, thay đổi thụt đầu dòng (indent) của item <b>2</b>, <b>3</b>, <b>5</b> thành <b>2</b> level; các item còn lại thành 3 level', NULL, N'qfile_3.docx', N'afile_3.docx', 1, NULL, NULL, 1, CAST(N'2018-08-05 15:51:06.5190000' AS DateTime2))
GO
INSERT [dbo].[office_question] ([id], [title], [html_content], [markdown_content], [file_question], [file_correct_answer], [active], [description], [image], [request], [create_at]) VALUES (4, N'Định dạng', N'Thiết lập giãn dòng cho toàn bộ văn bản là <b>1.3</b>, khoảng cách giữa đoạn văn <b>1</b> và đoạn văn <b>2</b> là <b>8pt</b>, khoảng cách giữa đoạn văn <b>2</b> và đoạn văn <b>3</b> là <b>12pt</b>', NULL, N'qfile_4.docx', N'afile_4.docx', 1, NULL, NULL, 1, CAST(N'2018-08-05 15:51:06.5200000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[office_question] OFF
GO
SET IDENTITY_INSERT [dbo].[practice_type] ON 

GO
INSERT [dbo].[practice_type] ([id], [name], [create_at]) VALUES (1, N'Word', CAST(N'2018-08-04 16:55:19.5700000' AS DateTime2))
GO
INSERT [dbo].[practice_type] ([id], [name], [create_at]) VALUES (2, N'Excel', CAST(N'2018-08-04 16:55:22.6090000' AS DateTime2))
GO
INSERT [dbo].[practice_type] ([id], [name], [create_at]) VALUES (3, N'PowerPoint', CAST(N'2018-08-04 16:55:28.2340000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[practice_type] OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_user]    Script Date: 8/6/2018 11:38:40 AM ******/
ALTER TABLE [dbo].[user] ADD  CONSTRAINT [IX_user] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[answer] ADD  CONSTRAINT [DF_answer_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[chairman] ADD  CONSTRAINT [DF_chairman_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[exam_chairman] ADD  CONSTRAINT [DF_exam_chairman_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[exam_chairman] ADD  CONSTRAINT [DF_exam_chairman_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[exam_examinee] ADD  CONSTRAINT [DF_exam_examinee_joined]  DEFAULT ((1)) FOR [joined]
GO
ALTER TABLE [dbo].[exam_examinee] ADD  CONSTRAINT [DF_user_exam_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[exam_examinee] ADD  CONSTRAINT [DF_user_exam_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[exam_practice_type] ADD  CONSTRAINT [DF_exam_practice_type_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[exam_question] ADD  CONSTRAINT [DF_exam_question_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[exam_version] ADD  CONSTRAINT [DF_exam_version_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[examinee] ADD  CONSTRAINT [DF_examinee_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[examinee_answer] ADD  CONSTRAINT [DF_examinee_answer_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[off_question_map_t2] ADD  CONSTRAINT [DF_off_question_map_t2_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[off_question_version] ADD  CONSTRAINT [DF_off_question_version_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[office_version] ADD  CONSTRAINT [DF_office_version_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[user] ADD  CONSTRAINT [DF_user_active]  DEFAULT ((1)) FOR [active]
GO
ALTER TABLE [dbo].[user] ADD  CONSTRAINT [DF_user_create_at]  DEFAULT (sysdatetime()) FOR [create_at]
GO
ALTER TABLE [dbo].[chairman]  WITH CHECK ADD  CONSTRAINT [FK_chairman_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[chairman] CHECK CONSTRAINT [FK_chairman_user]
GO
ALTER TABLE [dbo].[exam_chairman]  WITH CHECK ADD  CONSTRAINT [FK_exam_chairman_chairman] FOREIGN KEY([chairman_id])
REFERENCES [dbo].[chairman] ([user_id])
GO
ALTER TABLE [dbo].[exam_chairman] CHECK CONSTRAINT [FK_exam_chairman_chairman]
GO
ALTER TABLE [dbo].[exam_chairman]  WITH CHECK ADD  CONSTRAINT [FK_exam_chairman_exam] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam] ([id])
GO
ALTER TABLE [dbo].[exam_chairman] CHECK CONSTRAINT [FK_exam_chairman_exam]
GO
ALTER TABLE [dbo].[exam_examinee]  WITH CHECK ADD  CONSTRAINT [FK_exam_examinee_examinee] FOREIGN KEY([examinee_id])
REFERENCES [dbo].[examinee] ([user_id])
GO
ALTER TABLE [dbo].[exam_examinee] CHECK CONSTRAINT [FK_exam_examinee_examinee]
GO
ALTER TABLE [dbo].[exam_examinee]  WITH CHECK ADD  CONSTRAINT [FK_user_exam_exam] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam] ([id])
GO
ALTER TABLE [dbo].[exam_examinee] CHECK CONSTRAINT [FK_user_exam_exam]
GO
ALTER TABLE [dbo].[exam_practice_type]  WITH CHECK ADD  CONSTRAINT [FK_exam_practice_type_exam] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam] ([id])
GO
ALTER TABLE [dbo].[exam_practice_type] CHECK CONSTRAINT [FK_exam_practice_type_exam]
GO
ALTER TABLE [dbo].[exam_practice_type]  WITH CHECK ADD  CONSTRAINT [FK_exam_practice_type_practice_type] FOREIGN KEY([type_id])
REFERENCES [dbo].[practice_type] ([id])
GO
ALTER TABLE [dbo].[exam_practice_type] CHECK CONSTRAINT [FK_exam_practice_type_practice_type]
GO
ALTER TABLE [dbo].[exam_question]  WITH CHECK ADD  CONSTRAINT [FK_exam_question_exam] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam] ([id])
GO
ALTER TABLE [dbo].[exam_question] CHECK CONSTRAINT [FK_exam_question_exam]
GO
ALTER TABLE [dbo].[exam_question]  WITH CHECK ADD  CONSTRAINT [FK_exam_question_office_question] FOREIGN KEY([question_id])
REFERENCES [dbo].[office_question] ([id])
GO
ALTER TABLE [dbo].[exam_question] CHECK CONSTRAINT [FK_exam_question_office_question]
GO
ALTER TABLE [dbo].[exam_version]  WITH CHECK ADD  CONSTRAINT [FK_exam_version_exam] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam] ([id])
GO
ALTER TABLE [dbo].[exam_version] CHECK CONSTRAINT [FK_exam_version_exam]
GO
ALTER TABLE [dbo].[exam_version]  WITH CHECK ADD  CONSTRAINT [FK_exam_version_office_version] FOREIGN KEY([office_id])
REFERENCES [dbo].[office_version] ([id])
GO
ALTER TABLE [dbo].[exam_version] CHECK CONSTRAINT [FK_exam_version_office_version]
GO
ALTER TABLE [dbo].[examinee]  WITH CHECK ADD  CONSTRAINT [FK_examinee_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[examinee] CHECK CONSTRAINT [FK_examinee_user]
GO
ALTER TABLE [dbo].[examinee_answer]  WITH CHECK ADD  CONSTRAINT [FK_examinee_answer_answer] FOREIGN KEY([answer_id])
REFERENCES [dbo].[answer] ([id])
GO
ALTER TABLE [dbo].[examinee_answer] CHECK CONSTRAINT [FK_examinee_answer_answer]
GO
ALTER TABLE [dbo].[examinee_answer]  WITH CHECK ADD  CONSTRAINT [FK_examinee_answer_exam] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam] ([id])
GO
ALTER TABLE [dbo].[examinee_answer] CHECK CONSTRAINT [FK_examinee_answer_exam]
GO
ALTER TABLE [dbo].[examinee_answer]  WITH CHECK ADD  CONSTRAINT [FK_examinee_answer_examinee] FOREIGN KEY([examinee_id])
REFERENCES [dbo].[examinee] ([user_id])
GO
ALTER TABLE [dbo].[examinee_answer] CHECK CONSTRAINT [FK_examinee_answer_examinee]
GO
ALTER TABLE [dbo].[examinee_answer]  WITH CHECK ADD  CONSTRAINT [FK_examinee_answer_office_question] FOREIGN KEY([question_id])
REFERENCES [dbo].[office_question] ([id])
GO
ALTER TABLE [dbo].[examinee_answer] CHECK CONSTRAINT [FK_examinee_answer_office_question]
GO
ALTER TABLE [dbo].[off_question_map_t2]  WITH CHECK ADD  CONSTRAINT [FK_off_question_map_t2_off_question_type_l2] FOREIGN KEY([type_l2_id])
REFERENCES [dbo].[off_question_type_l2] ([id])
GO
ALTER TABLE [dbo].[off_question_map_t2] CHECK CONSTRAINT [FK_off_question_map_t2_off_question_type_l2]
GO
ALTER TABLE [dbo].[off_question_map_t2]  WITH CHECK ADD  CONSTRAINT [FK_off_question_map_t2_office_question] FOREIGN KEY([question_id])
REFERENCES [dbo].[office_question] ([id])
GO
ALTER TABLE [dbo].[off_question_map_t2] CHECK CONSTRAINT [FK_off_question_map_t2_office_question]
GO
ALTER TABLE [dbo].[off_question_type_l1]  WITH CHECK ADD  CONSTRAINT [FK_off_question_type_l1_practice_type] FOREIGN KEY([practice_id])
REFERENCES [dbo].[practice_type] ([id])
GO
ALTER TABLE [dbo].[off_question_type_l1] CHECK CONSTRAINT [FK_off_question_type_l1_practice_type]
GO
ALTER TABLE [dbo].[off_question_type_l2]  WITH CHECK ADD  CONSTRAINT [FK_off_question_type_l2_off_question_type_l1] FOREIGN KEY([type_l1])
REFERENCES [dbo].[off_question_type_l1] ([id])
GO
ALTER TABLE [dbo].[off_question_type_l2] CHECK CONSTRAINT [FK_off_question_type_l2_off_question_type_l1]
GO
ALTER TABLE [dbo].[off_question_version]  WITH CHECK ADD  CONSTRAINT [FK_off_question_version_office_question] FOREIGN KEY([question_id])
REFERENCES [dbo].[office_question] ([id])
GO
ALTER TABLE [dbo].[off_question_version] CHECK CONSTRAINT [FK_off_question_version_office_question]
GO
ALTER TABLE [dbo].[off_question_version]  WITH CHECK ADD  CONSTRAINT [FK_off_question_version_office_version] FOREIGN KEY([office_id])
REFERENCES [dbo].[office_version] ([id])
GO
ALTER TABLE [dbo].[off_question_version] CHECK CONSTRAINT [FK_off_question_version_office_version]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'length of exam in second' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'exam', @level2type=N'COLUMN',@level2name=N'duration'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'store an exam' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'exam'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'indicate joined the exam or not' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'exam_examinee', @level2type=N'COLUMN',@level2name=N'joined'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 question can have more than one type level 2, so this table create' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'off_question_map_t2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'a question belong to one or more office version' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'off_question_version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'a question is requesting, wait for system review' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'office_question', @level2type=N'COLUMN',@level2name=N'request'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'word, excel, or pp, etc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'practice_type'
GO
