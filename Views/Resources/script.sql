USE [Club]
GO
/****** Object:  Table [dbo].[Children]    Script Date: 17.05.2022 6:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Children](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[IDParent] [int] NULL,
 CONSTRAINT [PK_Children] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChildrenClub]    Script Date: 17.05.2022 6:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChildrenClub](
	[IDChildren] [int] NOT NULL,
	[IDClub] [int] NOT NULL,
 CONSTRAINT [PK_ChildrenClub] PRIMARY KEY CLUSTERED 
(
	[IDChildren] ASC,
	[IDClub] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Club]    Script Date: 17.05.2022 6:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Club](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[MaxChildren] [int] NOT NULL,
	[CountChildren] [int] NOT NULL,
 CONSTRAINT [PK_Club] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Parent]    Script Date: 17.05.2022 6:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Parent](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](12) NULL,
	[Address] [nvarchar](50) NULL,
	[IDUser] [int] NULL,
 CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 17.05.2022 6:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[Firstname] [nvarchar](50) NOT NULL,
	[Patronymic] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nvarchar](12) NULL,
	[Address] [nvarchar](50) NULL,
	[IDUser] [int] NULL,
 CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 17.05.2022 6:52:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Access] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Children] ON 

INSERT [dbo].[Children] ([ID], [Surname], [Firstname], [Patronymic], [IDParent]) VALUES (1, N'Смирнов', N'Владимир', N'Андреевич', 1)
SET IDENTITY_INSERT [dbo].[Children] OFF
GO
INSERT [dbo].[ChildrenClub] ([IDChildren], [IDClub]) VALUES (1, 2)
INSERT [dbo].[ChildrenClub] ([IDChildren], [IDClub]) VALUES (1, 4)
GO
SET IDENTITY_INSERT [dbo].[Club] ON 

INSERT [dbo].[Club] ([ID], [Title], [MaxChildren], [CountChildren]) VALUES (1, N'Вокал', 18, 0)
INSERT [dbo].[Club] ([ID], [Title], [MaxChildren], [CountChildren]) VALUES (2, N'Танцы', 18, 0)
INSERT [dbo].[Club] ([ID], [Title], [MaxChildren], [CountChildren]) VALUES (3, N'Театральная студия', 18, 0)
INSERT [dbo].[Club] ([ID], [Title], [MaxChildren], [CountChildren]) VALUES (4, N'Кулинария', 18, 0)
INSERT [dbo].[Club] ([ID], [Title], [MaxChildren], [CountChildren]) VALUES (5, N'Лепка', 18, 0)
SET IDENTITY_INSERT [dbo].[Club] OFF
GO
SET IDENTITY_INSERT [dbo].[Parent] ON 

INSERT [dbo].[Parent] ([ID], [Surname], [Firstname], [Patronymic], [Email], [Phone], [Address], [IDUser]) VALUES (1, N'Смирнов', N'Андрей', N'Владимирович', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Parent] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Login], [Password], [Access]) VALUES (1, N'1', N'1', 2)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Club] ADD  CONSTRAINT [DF_Club_MaxChildren]  DEFAULT ((1)) FOR [MaxChildren]
GO
ALTER TABLE [dbo].[Club] ADD  CONSTRAINT [DF_Club_CountChildren]  DEFAULT ((0)) FOR [CountChildren]
GO
ALTER TABLE [dbo].[Children]  WITH CHECK ADD  CONSTRAINT [FK_Children_Parent] FOREIGN KEY([IDParent])
REFERENCES [dbo].[Parent] ([ID])
GO
ALTER TABLE [dbo].[Children] CHECK CONSTRAINT [FK_Children_Parent]
GO
ALTER TABLE [dbo].[ChildrenClub]  WITH CHECK ADD  CONSTRAINT [FK_ChildrenClub_Children] FOREIGN KEY([IDChildren])
REFERENCES [dbo].[Children] ([ID])
GO
ALTER TABLE [dbo].[ChildrenClub] CHECK CONSTRAINT [FK_ChildrenClub_Children]
GO
ALTER TABLE [dbo].[ChildrenClub]  WITH CHECK ADD  CONSTRAINT [FK_ChildrenClub_Club] FOREIGN KEY([IDClub])
REFERENCES [dbo].[Club] ([ID])
GO
ALTER TABLE [dbo].[ChildrenClub] CHECK CONSTRAINT [FK_ChildrenClub_Club]
GO
ALTER TABLE [dbo].[Parent]  WITH CHECK ADD  CONSTRAINT [FK_Parent_User] FOREIGN KEY([IDUser])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Parent] CHECK CONSTRAINT [FK_Parent_User]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_User] FOREIGN KEY([IDUser])
REFERENCES [dbo].[User] ([ID])
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_User]
GO
