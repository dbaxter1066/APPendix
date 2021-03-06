USE [Lloyds_rPt_110687]
GO
/****** Object:  Table [dbo].[tblVPBART_Rank]    Script Date: 20/03/2019 15:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVPBART_Rank](
	[BDApp_Number] [int] NOT NULL,
	[BART_Rank] [int] NOT NULL,
 CONSTRAINT [PK_tblVPBART_Prioirty] PRIMARY KEY CLUSTERED 
(
	[BDApp_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblVPCompliance]    Script Date: 20/03/2019 15:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVPCompliance](
	[BDApp_Number] [int] NOT NULL,
	[GDPR] [bit] NOT NULL,
	[DPI] [bit] NOT NULL,
	[DPI_Link] [nvarchar](max) NULL,
	[SLA] [bit] NOT NULL,
	[SLA_Link] [nvarchar](max) NULL,
 CONSTRAINT [PK_tblVPCompliance] PRIMARY KEY CLUSTERED 
(
	[BDApp_Number] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblVPReviews]    Script Date: 20/03/2019 15:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblVPReviews](
	[Review_ID] [int] IDENTITY(1,1) NOT NULL,
	[BDApp_Number] [int] NOT NULL,
	[Review_Date] [date] NOT NULL,
	[Review_Description] [nvarchar](100) NOT NULL,
	[Notes] [nvarchar](max) NULL,
	[Actioned] [date] NULL,
 CONSTRAINT [PK_tblVPReviews] PRIMARY KEY CLUSTERED 
(
	[Review_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  StoredProcedure [dbo].[qryVPAddNewUser]    Script Date: 20/03/2019 15:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[qryVPAddNewUser] 
	-- Add the parameters for the stored procedure here
	@nPID int, 
	@nFullName nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO tblUsers
                         (PID, Full_Name, Active, App_Launcher_Admin, VP_Admin)
VALUES        (@nPID, @nFullName, 1, 0, 1)
END

GO
/****** Object:  StoredProcedure [dbo].[qryVPGetAllBDApps]    Script Date: 20/03/2019 15:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Graham Shrives
-- Create date: 04/12/2018
-- Description:	List all apps
-- =============================================
CREATE PROCEDURE [dbo].[qryVPGetAllBDApps] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	

    -- Insert statements for procedure here
	SELECT        tblApplications.BDApp_ID, tblApplications.BDApp_Number, tblApplications.BDApp_Name, tblApplications.Available_Via_Launcher, CASE WHEN tblVPBART_Rank.BART_Rank IS NULL 
                         THEN 0 ELSE tblVPBART_Rank.BART_Rank END AS BART_Ranking, CASE WHEN tblVPCompliance.GDPR = 1 THEN 1 ELSE 0 END AS GDPR, CASE WHEN tblVPCompliance.DPI = 1 THEN 1 ELSE 0 END AS DPI, 
                         CASE WHEN tblVPCompliance.SLA = 1 THEN 1 ELSE 0 END AS SLA, tblApplications.BDApp_Status, tblStatus.Status_Image, tblStatus.Status_Description, tblNextReviewDetails.Review_Date, 
                         tblNextReviewDetails.Review_Description, tblNextReviewDetails.Notes
FROM            tblApplications LEFT OUTER JOIN
                             (SELECT        tblVPReviews_2.BDApp_Number, tblVPReviews_2.Review_Date, tblVPReviews_2.Review_Description, tblVPReviews_2.Notes
                               FROM            tblVPReviews AS tblVPReviews_2 INNER JOIN
                                                             (SELECT        Review_ID, BDApp_Number, MIN(Review_Date) AS Next_Review_Date
                                                               FROM            tblVPReviews AS tblVPReviews_1
                                                               WHERE        (Actioned IS NULL)
                                                               GROUP BY BDApp_Number, Review_ID) AS NextReview ON tblVPReviews_2.Review_ID = NextReview.Review_ID AND tblVPReviews_2.BDApp_Number = NextReview.BDApp_Number) 
                         AS tblNextReviewDetails ON tblApplications.BDApp_Number = tblNextReviewDetails.BDApp_Number LEFT OUTER JOIN
                         tblVPBART_Rank ON tblApplications.BDApp_Number = tblVPBART_Rank.BDApp_Number LEFT OUTER JOIN
                         tblStatus ON tblApplications.BDApp_Status = tblStatus.Status_ID LEFT OUTER JOIN
                         tblVPCompliance ON tblApplications.BDApp_Number = tblVPCompliance.BDApp_Number
ORDER BY tblVPBART_Rank.BART_Rank, tblApplications.BDApp_Number
END

GO
/****** Object:  StoredProcedure [dbo].[qryVPGetUserDetails]    Script Date: 20/03/2019 15:47:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[qryVPGetUserDetails] 
	-- Add the parameters for the stored procedure here
	@PID Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        PID, Full_Name, Active, VP_Admin
FROM            tblUsers
WHERE        (PID = @PID) AND (VP_Admin = 1)
END

GO
