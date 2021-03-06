USE [master]
GO
/****** Object:  Database [TadaEntryDB]    Script Date: 14-10-2021 05:11:17 PM ******/
CREATE DATABASE [TadaEntryDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TadaEntryDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TadaEntryDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TadaEntryDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\TadaEntryDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TadaEntryDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TadaEntryDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TadaEntryDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TadaEntryDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TadaEntryDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TadaEntryDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TadaEntryDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TadaEntryDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TadaEntryDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TadaEntryDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TadaEntryDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TadaEntryDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TadaEntryDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TadaEntryDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TadaEntryDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TadaEntryDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TadaEntryDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TadaEntryDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TadaEntryDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TadaEntryDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TadaEntryDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TadaEntryDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TadaEntryDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TadaEntryDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TadaEntryDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TadaEntryDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TadaEntryDB] SET  MULTI_USER 
GO
ALTER DATABASE [TadaEntryDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TadaEntryDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TadaEntryDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TadaEntryDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TadaEntryDB]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 14-10-2021 05:11:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TadaHistory]    Script Date: 14-10-2021 05:11:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TadaHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[TravelCost] [int] NOT NULL,
	[LunchCost] [int] NOT NULL,
	[InstrumentCost] [int] NOT NULL,
	[IsPaid] [bit] NOT NULL,
	[Date] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TadaHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[TadaHistoryView]    Script Date: 14-10-2021 05:11:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[TadaHistoryView]
AS
SELECT        TOP (100) PERCENT t.Id, t.Date, e.Name, t.TravelCost, t.LunchCost, t.InstrumentCost, t.IsPaid
FROM            dbo.TadaHistory AS t INNER JOIN
                         dbo.Employee AS e ON t.EmployeeId = e.Id

GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([Id], [Name]) VALUES (1, N'Md. Ruhul Amin')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (2, N'Naiyeem Ahmen')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (3, N'Rakib Uddin')
INSERT [dbo].[Employee] ([Id], [Name]) VALUES (4, N'Rahatul Alam')
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[TadaHistory] ON 

INSERT [dbo].[TadaHistory] ([Id], [EmployeeId], [TravelCost], [LunchCost], [InstrumentCost], [IsPaid], [Date]) VALUES (9, 4, 100, 200, 50, 0, N'12/10/2021')
INSERT [dbo].[TadaHistory] ([Id], [EmployeeId], [TravelCost], [LunchCost], [InstrumentCost], [IsPaid], [Date]) VALUES (10, 2, 1000, 100, 2000, 1, N'05/10/2021')
INSERT [dbo].[TadaHistory] ([Id], [EmployeeId], [TravelCost], [LunchCost], [InstrumentCost], [IsPaid], [Date]) VALUES (11, 3, 500, 300, 0, 0, N'07/10/2021')
INSERT [dbo].[TadaHistory] ([Id], [EmployeeId], [TravelCost], [LunchCost], [InstrumentCost], [IsPaid], [Date]) VALUES (12, 1, 20, 50, 100, 1, N'02/10/2021')
INSERT [dbo].[TadaHistory] ([Id], [EmployeeId], [TravelCost], [LunchCost], [InstrumentCost], [IsPaid], [Date]) VALUES (13, 1, 100, 20, 50, 0, N'12/10/2021')
INSERT [dbo].[TadaHistory] ([Id], [EmployeeId], [TravelCost], [LunchCost], [InstrumentCost], [IsPaid], [Date]) VALUES (14, 4, 200, 50, 500, 0, N'13/10/2021')
SET IDENTITY_INSERT [dbo].[TadaHistory] OFF
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "t"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 209
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "e"
            Begin Extent = 
               Top = 6
               Left = 247
               Bottom = 102
               Right = 417
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TadaHistoryView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'TadaHistoryView'
GO
USE [master]
GO
ALTER DATABASE [TadaEntryDB] SET  READ_WRITE 
GO
