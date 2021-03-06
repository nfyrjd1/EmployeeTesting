Create Database EmployeeTesting;
GO
USE [EmployeeTesting]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 21.10.2020 16:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[ID_Employee] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
	[Surname] [nvarchar](80) NOT NULL,
	[Middlename] [nvarchar](80) NOT NULL,
	[ID_Position] [int] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[ID_Employee] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 21.10.2020 16:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Position](
	[ID_Position] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[ID_Position] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test]    Script Date: 21.10.2020 16:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test](
	[ID_Test] [int] IDENTITY(1,1) NOT NULL,
	[Test_Title] [nvarchar](100) NOT NULL,
	[Passing_Points] [int] NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[ID_Test] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_Question]    Script Date: 21.10.2020 16:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Question](
	[ID_Test_Question] [int] IDENTITY(1,1) NOT NULL,
	[ID_Test] [int] NOT NULL,
	[Question] [nvarchar](max) NOT NULL,
	[Answer] [nvarchar](max) NOT NULL,
	[Points] [int] NULL,
 CONSTRAINT [PK_Test_Question] PRIMARY KEY CLUSTERED 
(
	[ID_Test_Question] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_Result]    Script Date: 21.10.2020 16:55:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Result](
	[ID_Test_Result] [int] IDENTITY(1,1) NOT NULL,
	[ID_Employee] [int] NOT NULL,
	[ID_Test] [int] NOT NULL,
	[Points] [int] NULL,
 CONSTRAINT [PK_Test_Result] PRIMARY KEY CLUSTERED 
(
	[ID_Test_Result] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 
GO
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middlename], [ID_Position]) VALUES (1, N'Синдеева', N'Рада', N'Тихоновна', 4)
GO
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middlename], [ID_Position]) VALUES (2, N'Углова', N'Розалия', N'Александровна', 5)
GO
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middlename], [ID_Position]) VALUES (3, N'Тэна', N'Агафья', N'Павеловна', 5)
GO
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middlename], [ID_Position]) VALUES (4, N'Жикин', N'Феофан', N'Сократович', 6)
GO
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middlename], [ID_Position]) VALUES (5, N'Уржумцев', N'Елисей', N'Егорович', 1)
GO
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middlename], [ID_Position]) VALUES (6, N'Тихомиров', N'Роман', N'Ильевич', 2)
GO
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middlename], [ID_Position]) VALUES (7, N'Висенина', N'Лилия', N'Серафимовна', 4)
GO
INSERT [dbo].[Employee] ([ID_Employee], [Surname], [Name], [Middlename], [ID_Position]) VALUES (8, N'Волошин', N'Давид', N'Геннадиевич', 3)
GO
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Position] ON 
GO
INSERT [dbo].[Position] ([ID_Position], [Name]) VALUES (1, N'Уборщик')
GO
INSERT [dbo].[Position] ([ID_Position], [Name]) VALUES (2, N'Секретарь')
GO
INSERT [dbo].[Position] ([ID_Position], [Name]) VALUES (3, N'Бухгалтер')
GO
INSERT [dbo].[Position] ([ID_Position], [Name]) VALUES (4, N'Сварщик')
GO
INSERT [dbo].[Position] ([ID_Position], [Name]) VALUES (5, N'Программист на C#')
GO
INSERT [dbo].[Position] ([ID_Position], [Name]) VALUES (6, N'Экономист')
GO
SET IDENTITY_INSERT [dbo].[Position] OFF
GO
SET IDENTITY_INSERT [dbo].[Test] ON 
GO
INSERT [dbo].[Test] ([ID_Test], [Test_Title], [Passing_Points]) VALUES (1, N'Богословие', 25)
GO
SET IDENTITY_INSERT [dbo].[Test] OFF
GO
SET IDENTITY_INSERT [dbo].[Test_Question] ON 
GO
INSERT [dbo].[Test_Question] ([ID_Test_Question], [ID_Test], [Question], [Answer], [Points]) VALUES (1, 1, N' Принято ли было в древней Церкви сидеть во время богослужения при чтении или пении псалмов?', N'Нет', 5)
GO
INSERT [dbo].[Test_Question] ([ID_Test_Question], [ID_Test], [Question], [Answer], [Points]) VALUES (2, 1, N'Является ли абортом, т. е. тяжким грехом, операция при внематочной беременности?', N'Нет', 5)
GO
INSERT [dbo].[Test_Question] ([ID_Test_Question], [ID_Test], [Question], [Answer], [Points]) VALUES (3, 1, N'Иоанн Кассиан Римлянин говорил, что тот, кто не преодолел эту страсть, не вступил даже на первую ступень веры. Что это за страсть?', N'Чревоугодие', 5)
GO
INSERT [dbo].[Test_Question] ([ID_Test_Question], [ID_Test], [Question], [Answer], [Points]) VALUES (4, 1, N'О Введении во Храм Пресвятой Богородицы сообщает:', N'Священное Предание', 5)
GO
INSERT [dbo].[Test_Question] ([ID_Test_Question], [ID_Test], [Question], [Answer], [Points]) VALUES (5, 1, N'Аборт по большей части совершается по причине:', N'Сребролюбия', 5)
GO
INSERT [dbo].[Test_Question] ([ID_Test_Question], [ID_Test], [Question], [Answer], [Points]) VALUES (6, 1, N'Какое установление имеет Таинство Миропомазания?', N'Божественное', 5)
GO
INSERT [dbo].[Test_Question] ([ID_Test_Question], [ID_Test], [Question], [Answer], [Points]) VALUES (7, 1, N'С какой части новоначальному лучше начинать чтение Библии?', N'С Нового Завета', 5)
GO
SET IDENTITY_INSERT [dbo].[Test_Question] OFF
GO
SET IDENTITY_INSERT [dbo].[Test_Result] ON 
GO
INSERT [dbo].[Test_Result] ([ID_Test_Result], [ID_Employee], [ID_Test], [Points]) VALUES (1, 1, 1, 25)
GO
INSERT [dbo].[Test_Result] ([ID_Test_Result], [ID_Employee], [ID_Test], [Points]) VALUES (2, 2, 1, 20)
GO
INSERT [dbo].[Test_Result] ([ID_Test_Result], [ID_Employee], [ID_Test], [Points]) VALUES (3, 3, 1, 35)
GO
SET IDENTITY_INSERT [dbo].[Test_Result] OFF
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Position] FOREIGN KEY([ID_Position])
REFERENCES [dbo].[Position] ([ID_Position])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Position]
GO
ALTER TABLE [dbo].[Test_Question]  WITH CHECK ADD  CONSTRAINT [FK_Test_Question_Test] FOREIGN KEY([ID_Test])
REFERENCES [dbo].[Test] ([ID_Test])
GO
ALTER TABLE [dbo].[Test_Question] CHECK CONSTRAINT [FK_Test_Question_Test]
GO
ALTER TABLE [dbo].[Test_Result]  WITH CHECK ADD  CONSTRAINT [FK_Test_Result_Employee] FOREIGN KEY([ID_Employee])
REFERENCES [dbo].[Employee] ([ID_Employee])
GO
ALTER TABLE [dbo].[Test_Result] CHECK CONSTRAINT [FK_Test_Result_Employee]
GO
ALTER TABLE [dbo].[Test_Result]  WITH CHECK ADD  CONSTRAINT [FK_Test_Result_Test] FOREIGN KEY([ID_Test])
REFERENCES [dbo].[Test] ([ID_Test])
GO
ALTER TABLE [dbo].[Test_Result] CHECK CONSTRAINT [FK_Test_Result_Test]
GO
