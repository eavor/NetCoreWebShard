USE [your_DB]
GO
/****** Object:  Table [dbo].[u_login_user]    Script Date: 2025/2/19 16:51:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[u_login_user](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserCode] [varchar](20) NOT NULL,
	[UserName] [varchar](30) NOT NULL,
	[Tel] [varchar](11) NOT NULL,
	[PassWord] [varchar](50) NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateID] [int] NOT NULL,
	[ShopID] [int] NULL,
	[CompanyID] [int] NOT NULL,
	[IsAdmin] [bit] NOT NULL,
	[SuperAdmin] [bit] NOT NULL,
	[Effective] [bit] NOT NULL,
	[ModifyTime] [datetime] NULL,
	[UserImg] [varchar](max) NULL,
	[OpenID] [varchar](50) NULL,
 CONSTRAINT [PK_u_login_user] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[u_train_plan]    Script Date: 2025/2/19 16:51:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[u_train_plan](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[BillState] [int] NOT NULL,
	[BillDate] [date] NOT NULL,
	[BillType] [int] NOT NULL,
	[CompanyID] [int] NOT NULL,
	[CreateDeptID] [int] NOT NULL,
	[PlanCompleteTime] [date] NULL,
	[CreateID] [int] NOT NULL,
	[CreateTime] [datetime] NOT NULL,
	[MakeID] [int] NULL,
	[MakeTime] [datetime] NULL,
	[CheckID] [int] NULL,
	[CheckTime] [datetime] NULL,
	[RatifyID] [int] NULL,
	[RatifyTime] [datetime] NULL,
	[CompleteID] [int] NULL,
	[CompleteTime] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[u_train_plan_b]    Script Date: 2025/2/19 16:51:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[u_train_plan_b](
	[ID] [int] NOT NULL,
	[SeqID] [int] IDENTITY(1,1) NOT NULL,
	[CourseID] [int] NOT NULL,
	[ClassID] [int] NOT NULL,
	[CourseName] [nvarchar](1000) NOT NULL,
	[Channels] [int] NOT NULL,
	[DeptID] [int] NOT NULL,
	[Examineway] [int] NOT NULL,
	[PlanClasshour] [int] NOT NULL,
	[PlanTrainDate] [date] NULL,
	[Memo] [nvarchar](1000) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SeqID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
