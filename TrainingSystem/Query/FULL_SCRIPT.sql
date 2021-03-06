USE [TrainDb]
GO
ALTER TABLE [dbo].[TrainerTopic] DROP CONSTRAINT [FK__TrainerTo__UserI__2E1BDC42]
GO
ALTER TABLE [dbo].[TrainerTopic] DROP CONSTRAINT [FK__TrainerTo__Topic__2F10007B]
GO
ALTER TABLE [dbo].[TraineeCourse] DROP CONSTRAINT [FK__TraineeCo__UserI__31EC6D26]
GO
ALTER TABLE [dbo].[TraineeCourse] DROP CONSTRAINT [FK__TraineeCo__Cours__32E0915F]
GO
ALTER TABLE [dbo].[Topic] DROP CONSTRAINT [FK__Topic__CourseID__2B3F6F97]
GO
ALTER TABLE [dbo].[Course] DROP CONSTRAINT [FK__Course__Category__286302EC]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2020-08-27 2:41:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
DROP TABLE [dbo].[Users]
GO
/****** Object:  Table [dbo].[TrainerTopic]    Script Date: 2020-08-27 2:41:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TrainerTopic]') AND type in (N'U'))
DROP TABLE [dbo].[TrainerTopic]
GO
/****** Object:  Table [dbo].[TraineeCourse]    Script Date: 2020-08-27 2:41:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TraineeCourse]') AND type in (N'U'))
DROP TABLE [dbo].[TraineeCourse]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 2020-08-27 2:41:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Topic]') AND type in (N'U'))
DROP TABLE [dbo].[Topic]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2020-08-27 2:41:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Course]') AND type in (N'U'))
DROP TABLE [dbo].[Course]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2020-08-27 2:41:41 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Category]') AND type in (N'U'))
DROP TABLE [dbo].[Category]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2020-08-27 2:41:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
	[Image] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Course]    Script Date: 2020-08-27 2:41:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
	[Image] [varchar](255) NULL,
	[CategoryID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic]    Script Date: 2020-08-27 2:41:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic](
	[TopicID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Description] [varchar](255) NULL,
	[CourseID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[TopicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TraineeCourse]    Script Date: 2020-08-27 2:41:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TraineeCourse](
	[UserID] [varchar](255) NOT NULL,
	[CourseID] [int] NOT NULL,
 CONSTRAINT [PK_TraineeCourse] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TrainerTopic]    Script Date: 2020-08-27 2:41:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrainerTopic](
	[UserID] [varchar](255) NOT NULL,
	[TopicID] [int] NOT NULL,
 CONSTRAINT [PK_TrainerTopic] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC,
	[TopicID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2020-08-27 2:41:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [varchar](255) NOT NULL,
	[Password] [varchar](255) NOT NULL,
	[Role] [varchar](255) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Email] [varchar](255) NULL,
	[DOB] [datetime] NULL,
	[Education] [varchar](255) NULL,
	[ProgrammingLanguage] [varchar](255) NULL,
	[TOEIC] [int] NULL,
	[Experience] [varchar](255) NULL,
	[Department] [varchar](255) NULL,
	[Location] [varchar](255) NULL,
	[Type] [varchar](255) NULL,
	[Phone] [varchar](255) NULL,
	[Workplace] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryID], [Name], [Description], [Image]) VALUES (1, N'C#', N'C# (C-Sharp) is a programming language developed by Microsoft that runs on the .NET Framework. C# is used to develop web apps, desktop apps, mobile apps ...', N'1852299Csharp.jpg')
INSERT [dbo].[Category] ([CategoryID], [Name], [Description], [Image]) VALUES (2, N'Python', N'Python is powerful... and fast; plays well with others; runs everywhere; is friendly & easy to learn; is Open.', N'7603393python.jpg')
INSERT [dbo].[Category] ([CategoryID], [Name], [Description], [Image]) VALUES (3, N'Artificial Intelligence', N'Artificial intelligence (AI), sometimes called machine intelligence, is intelligence demonstrated by machines, unlike the natural intelligence displayed by humans ...', N'16221243ai-01.jpg')
INSERT [dbo].[Category] ([CategoryID], [Name], [Description], [Image]) VALUES (4, N'Web development', N'Web development is the work involved in developing a Web site for the Internet (World Wide Web) or an intranet (a private network).', N'8987187web-developer.jpg')
INSERT [dbo].[Category] ([CategoryID], [Name], [Description], [Image]) VALUES (5, N'Internet of Things', N'The Internet of things (IoT) is a system of interrelated computing devices, mechanical and digital machines provided with unique identifiers (UIDs) and the ability to transfer data over a network', N'2319110iot.jpg')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Course] ON 

INSERT [dbo].[Course] ([CourseID], [Name], [Description], [Image], [CategoryID]) VALUES (1, N'Introduction to C#', N'Basic C# programming course', N'course1.jpg', 1)
INSERT [dbo].[Course] ([CourseID], [Name], [Description], [Image], [CategoryID]) VALUES (2, N'Introduction to Python', N'Basic python course', N'course2.jpg', 2)
INSERT [dbo].[Course] ([CourseID], [Name], [Description], [Image], [CategoryID]) VALUES (8, N'Introduction to Machine Learning', N'Machine learning is the subfield of computer science that “gives computers the ability to learn without being', N'17925016phan-biet-ai-mc-dl4.jpg', 3)
INSERT [dbo].[Course] ([CourseID], [Name], [Description], [Image], [CategoryID]) VALUES (9, N'Introduction Deep Learning', N'Deep learning is part of a broader family of machine learning methods based on artificial neural networks with representation learning', N'3448585td-deep-learning.jpg', 3)
INSERT [dbo].[Course] ([CourseID], [Name], [Description], [Image], [CategoryID]) VALUES (10, N'Angular development', N'Angular is a platform for building mobile and desktop web applications. Join the community of millions of developers who build compelling user interfaces with', N'149276the-seo-guide-to-angular-760x400.png', 4)
INSERT [dbo].[Course] ([CourseID], [Name], [Description], [Image], [CategoryID]) VALUES (11, N'React development', N'Declarative. React makes it painless to create interactive UIs. Design simple views for each state in your application, and React will efficiently update and render ...', N'8076076react-dev-tools-logo.jpg', 4)
INSERT [dbo].[Course] ([CourseID], [Name], [Description], [Image], [CategoryID]) VALUES (12, N'Getting started with Pandas library', N'pandas is a fast, powerful, flexible and easy to use open source data analysis and manipulation tool, built on top of the Python programming language. Install pandas now!', N'16244509download.png', 2)
INSERT [dbo].[Course] ([CourseID], [Name], [Description], [Image], [CategoryID]) VALUES (13, N'Introduction to IOT', N'The IoT can be described as an extension of the internet and other network connections to different sensors and devices affording even simple objects a higher ...', N'12423310iot-la-gi-mang-luoi-van-vat-ket-noi-la-gi-1.png', 5)
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Topic] ON 

INSERT [dbo].[Topic] ([TopicID], [Name], [Description], [CourseID]) VALUES (1, N'C# overview', N'Overview of C# language', 1)
INSERT [dbo].[Topic] ([TopicID], [Name], [Description], [CourseID]) VALUES (2, N'C# program structure', N'Structure of a C# program', 1)
INSERT [dbo].[Topic] ([TopicID], [Name], [Description], [CourseID]) VALUES (3, N'Python overview', N'Overview of python language', 2)
INSERT [dbo].[Topic] ([TopicID], [Name], [Description], [CourseID]) VALUES (4, N'Python program structure', N'Structure of a python program', 2)
SET IDENTITY_INSERT [dbo].[Topic] OFF
GO
INSERT [dbo].[TraineeCourse] ([UserID], [CourseID]) VALUES (N'trainee01', 1)
INSERT [dbo].[TraineeCourse] ([UserID], [CourseID]) VALUES (N'trainee02', 1)
GO
INSERT [dbo].[TrainerTopic] ([UserID], [TopicID]) VALUES (N'trainer01', 3)
INSERT [dbo].[TrainerTopic] ([UserID], [TopicID]) VALUES (N'trainer01', 4)
INSERT [dbo].[TrainerTopic] ([UserID], [TopicID]) VALUES (N'trainer02', 1)
INSERT [dbo].[TrainerTopic] ([UserID], [TopicID]) VALUES (N'trainer02', 2)
GO
INSERT [dbo].[Users] ([UserID], [Password], [Role], [Name], [Email], [DOB], [Education], [ProgrammingLanguage], [TOEIC], [Experience], [Department], [Location], [Type], [Phone], [Workplace]) VALUES (N'admin01', N'2', N'Administrator', N'Jordon DuBuque V', N'tad00@maliesed.com', CAST(N'2000-01-30T00:00:00.000' AS DateTime), N'', N'', NULL, N'', N'', N'', N'', N'', N'')
INSERT [dbo].[Users] ([UserID], [Password], [Role], [Name], [Email], [DOB], [Education], [ProgrammingLanguage], [TOEIC], [Experience], [Department], [Location], [Type], [Phone], [Workplace]) VALUES (N'staff01', N'1', N'TrainingStaff', N'Janice Beatty', N'oreinger@best566.xyz', CAST(N'2000-01-30T00:00:00.000' AS DateTime), N'', N'', NULL, N'', N'', N'', N'', N'', N'')
INSERT [dbo].[Users] ([UserID], [Password], [Role], [Name], [Email], [DOB], [Education], [ProgrammingLanguage], [TOEIC], [Experience], [Department], [Location], [Type], [Phone], [Workplace]) VALUES (N'trainee01', N'1', N'Trainee', N'Anh Hoàng', N'yawdehm@khoastore.net', CAST(N'2000-01-30T00:00:00.000' AS DateTime), N'B.A', N'C#', 450, N'1 year', N'Department of ABC', N'Earth', NULL, N'0981643719', NULL)
INSERT [dbo].[Users] ([UserID], [Password], [Role], [Name], [Email], [DOB], [Education], [ProgrammingLanguage], [TOEIC], [Experience], [Department], [Location], [Type], [Phone], [Workplace]) VALUES (N'trainee02', N'1', N'Trainee', N'Elda Durgan', N'yboi@khd.net', CAST(N'2000-04-23T00:00:00.000' AS DateTime), N'B.A', N'Brainfuck', 369, N'2 years', N'Department of XYZ', N'Earth', NULL, N'0981643737', NULL)
INSERT [dbo].[Users] ([UserID], [Password], [Role], [Name], [Email], [DOB], [Education], [ProgrammingLanguage], [TOEIC], [Experience], [Department], [Location], [Type], [Phone], [Workplace]) VALUES (N'trainer01', N'1', N'Trainer', N'Arianna Armstrong', N'jeramy83@tguide.site', CAST(N'2000-01-30T00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, N'Internal', N'0981663736', N'Building 23123')
INSERT [dbo].[Users] ([UserID], [Password], [Role], [Name], [Email], [DOB], [Education], [ProgrammingLanguage], [TOEIC], [Experience], [Department], [Location], [Type], [Phone], [Workplace]) VALUES (N'trainer02', N'1', N'Trainer', N'Mr. Jedidiah Gulgowski', N'yboehm@khoastore.net', CAST(N'2000-01-30T00:00:00.000' AS DateTime), N'', N'', NULL, N'', N'', N'', N'External', N'0981693637', N'Building 2')
GO
ALTER TABLE [dbo].[Course]  WITH CHECK ADD FOREIGN KEY([CategoryID])
REFERENCES [dbo].[Category] ([CategoryID])
GO
ALTER TABLE [dbo].[Topic]  WITH CHECK ADD FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[TraineeCourse]  WITH CHECK ADD FOREIGN KEY([CourseID])
REFERENCES [dbo].[Course] ([CourseID])
GO
ALTER TABLE [dbo].[TraineeCourse]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[TrainerTopic]  WITH CHECK ADD FOREIGN KEY([TopicID])
REFERENCES [dbo].[Topic] ([TopicID])
GO
ALTER TABLE [dbo].[TrainerTopic]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
