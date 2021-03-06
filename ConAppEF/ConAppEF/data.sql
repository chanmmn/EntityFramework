USE [poc]
GO
/****** Object:  Table [dbo].[Standard]    Script Date: 5/2/2021 12:15:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Standard](
	[StandardID] [int] NOT NULL,
	[StandardName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Standard] PRIMARY KEY CLUSTERED 
(
	[StandardID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 5/2/2021 12:15:30 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] NOT NULL,
	[StudentName] [nvarchar](50) NULL,
	[StandardID] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Standard] ([StandardID], [StandardName]) VALUES (1, N'Standard 1')
INSERT [dbo].[Standard] ([StandardID], [StandardName]) VALUES (2, N'Standard 2')
INSERT [dbo].[Standard] ([StandardID], [StandardName]) VALUES (3, N'Standard 3')
GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardID]) VALUES (1, N'John', 1)
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardID]) VALUES (2, N'Moin', 1)
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardID]) VALUES (3, N'Bill', 2)
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardID]) VALUES (4, N'Ran', 2)
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardID]) VALUES (5, N'Rin', NULL)
GO
