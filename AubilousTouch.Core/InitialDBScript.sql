ALTER TABLE [dbo].[MessagesGroupPerEmployee] DROP CONSTRAINT [FK_MessagesGroupPerEmployee_MessagesGroup]
GO
ALTER TABLE [dbo].[MessagesGroupPerEmployee] DROP CONSTRAINT [FK_MessagesGroupPerEmployee_Employee]
GO
ALTER TABLE [dbo].[MessagesChannelPerEmployee] DROP CONSTRAINT [FK_MessagesChannelPerEmployee_MessagesChannel]
GO
ALTER TABLE [dbo].[MessagesChannelPerEmployee] DROP CONSTRAINT [FK_MessagesChannelPerEmployee_Employee]
GO
ALTER TABLE [dbo].[MessagesChannelPerEmployee] DROP CONSTRAINT [DF_MessagesChannelPerEmployee_doNotDisturbEndHour]
GO
ALTER TABLE [dbo].[MessagesChannelPerEmployee] DROP CONSTRAINT [doNotDisturbStartHour]
GO
/***** Object:  Table [dbo].[MessagesGroupPerEmployee]    Script Date: 2022-11-19 11:26:25 AM *****/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MessagesGroupPerEmployee]') AND type in (N'U'))
DROP TABLE [dbo].[MessagesGroupPerEmployee]
GO
/***** Object:  Table [dbo].[MessagesGroup]    Script Date: 2022-11-19 11:26:25 AM *****/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MessagesGroup]') AND type in (N'U'))
DROP TABLE [dbo].[MessagesGroup]
GO
/***** Object:  Table [dbo].[MessagesChannelPerEmployee]    Script Date: 2022-11-19 11:26:25 AM *****/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MessagesChannelPerEmployee]') AND type in (N'U'))
DROP TABLE [dbo].[MessagesChannelPerEmployee]
GO
/***** Object:  Table [dbo].[MessagesChannel]    Script Date: 2022-11-19 11:26:25 AM *****/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MessagesChannel]') AND type in (N'U'))
DROP TABLE [dbo].[MessagesChannel]
GO
/***** Object:  Table [dbo].[Employee]    Script Date: 2022-11-19 11:26:25 AM *****/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO
/***** Object:  Table [dbo].[Employee]    Script Date: 2022-11-19 11:26:25 AM *****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](150) NOT NULL,
	[aubayid] [varchar](50) NULL,
	[address] [varchar](50) NULL,
	[role] [varchar](50) NULL,
	[mobilePhone] [varchar](50) NULL,
	[birthDate] [date] NULL,
	[taxNumber] [varchar](50) NULL,
	[hasChildren] [bit] NULL,
	[nationality] [varchar](50) NULL,
	[preferredCommunicationLanguage] [varchar](50) NULL,
	[admissionDate] [date] NULL,
	[cessationDate] [date] NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/***** Object:  Table [dbo].[MessagesChannel]    Script Date: 2022-11-19 11:26:26 AM *****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessagesChannel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[channelName] [varchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_MessagesChannel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/***** Object:  Table [dbo].[MessagesChannelPerEmployee]    Script Date: 2022-11-19 11:26:26 AM *****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessagesChannelPerEmployee](
	[id] [int] NOT NULL,
	[employeeId] [int] NOT NULL,
	[contactTag] [varchar](50) NULL,
	[doNotDisturbStartHour] [time](3) NULL,
	[doNotDisturbEndHour] [time](3) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_MessagesChannelPerEmployee] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[employeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/***** Object:  Table [dbo].[MessagesGroup]    Script Date: 2022-11-19 11:26:26 AM *****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessagesGroup](
	[id] [int] NOT NULL,
	[name] [varchar](50) NULL,
	[description] [varchar](50) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_MessagesGroup] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/***** Object:  Table [dbo].[MessagesGroupPerEmployee]    Script Date: 2022-11-19 11:26:26 AM *****/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MessagesGroupPerEmployee](
	[id] [int] NOT NULL,
	[employeeid] [int] NOT NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_MessagesGroupPerEmployee] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[employeeid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MessagesChannelPerEmployee] ADD  CONSTRAINT [doNotDisturbStartHour]  DEFAULT ('19:00:00') FOR [doNotDisturbStartHour]
GO
ALTER TABLE [dbo].[MessagesChannelPerEmployee] ADD  CONSTRAINT [DF_MessagesChannelPerEmployee_doNotDisturbEndHour]  DEFAULT ('08:00:00') FOR [doNotDisturbEndHour]
GO
ALTER TABLE [dbo].[MessagesChannelPerEmployee]  WITH CHECK ADD  CONSTRAINT [FK_MessagesChannelPerEmployee_Employee] FOREIGN KEY([employeeId])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[MessagesChannelPerEmployee] CHECK CONSTRAINT [FK_MessagesChannelPerEmployee_Employee]
GO
ALTER TABLE [dbo].[MessagesChannelPerEmployee]  WITH CHECK ADD  CONSTRAINT [FK_MessagesChannelPerEmployee_MessagesChannel] FOREIGN KEY([id])
REFERENCES [dbo].[MessagesChannel] ([id])
GO
ALTER TABLE [dbo].[MessagesChannelPerEmployee] CHECK CONSTRAINT [FK_MessagesChannelPerEmployee_MessagesChannel]
GO
ALTER TABLE [dbo].[MessagesGroupPerEmployee]  WITH CHECK ADD  CONSTRAINT [FK_MessagesGroupPerEmployee_Employee] FOREIGN KEY([employeeid])
REFERENCES [dbo].[Employee] ([id])
GO
ALTER TABLE [dbo].[MessagesGroupPerEmployee] CHECK CONSTRAINT [FK_MessagesGroupPerEmployee_Employee]
GO
ALTER TABLE [dbo].[MessagesGroupPerEmployee]  WITH CHECK ADD  CONSTRAINT [FK_MessagesGroupPerEmployee_MessagesGroup] FOREIGN KEY([id])
REFERENCES [dbo].[MessagesGroup] ([id])
GO
ALTER TABLE [dbo].[MessagesGroupPerEmployee] CHECK CONSTRAINT [FK_MessagesGroupPerEmployee_MessagesGroup]
GO