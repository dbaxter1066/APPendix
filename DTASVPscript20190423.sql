USE [DTaS_LaunchPad]
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetUserDetails]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPGetUserDetails]
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetFullBDAppDetail]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPGetFullBDAppDetail]
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetBDAppReviews]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPGetBDAppReviews]
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetBDAppDGVs]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPGetBDAppDGVs]
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetBDAppDetail]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPGetBDAppDetail]
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetBDAppComp]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPGetBDAppComp]
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetAppFormCombos]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPGetAppFormCombos]
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetAllBDApps]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPGetAllBDApps]
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetAllApps]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPGetAllApps]
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetAllAppNos]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPGetAllAppNos]
GO
/****** Object:  StoredProcedure [dbo].[qryVPAddNewUser]    Script Date: 23/04/2019 16:16:28 ******/
DROP PROCEDURE [dbo].[qryVPAddNewUser]
GO
/****** Object:  StoredProcedure [dbo].[qryVPAddNewUser]    Script Date: 23/04/2019 16:16:28 ******/
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
/****** Object:  StoredProcedure [dbo].[qryVPGetAllAppNos]    Script Date: 23/04/2019 16:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Graham Shrives
-- Create date: 04/12/2018
-- Description:	List all apps
-- =============================================
CREATE PROCEDURE [dbo].[qryVPGetAllAppNos] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT BDApp_Number
FROM            tblApplications
ORDER BY BDApp_Number
END
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetAllApps]    Script Date: 23/04/2019 16:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Graham Shrives
-- Create date: 04/12/2018
-- Description:	List all apps
-- =============================================
CREATE PROCEDURE [dbo].[qryVPGetAllApps] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        tblApplications.BDApp_ID, tblApplications.BDApp_Number, tblApplications.BDApp_Name, tblApplications.BDApp_Friendly_Name, tblApplications.Restricted_BDApp, tblApplications.BDApp_Governing_DL, 
                         tblApplications.BDApp_Admin_Contact, tblApplications.BDApp_Version_Number, tblApplications.BDApp_Source_Folder, tblApplications.BDApp_Status, tblApplications.Updated_By, tblApplications.Date_Updated, 
                         tblApplications.Update_Process, tblStatus.Status_Description, tblGoverning_DLs.Governing_DL, tblGoverning_DLs.List_Managers, tblApplications.BDApp_Command, tblApplications.BDApp_Command_Args, 
                         tblApplications.User_Install_Location, tblApplications.Available_Via_Launcher
FROM            tblApplications INNER JOIN
                         tblGoverning_DLs ON tblApplications.BDApp_Governing_DL = tblGoverning_DLs.GDL_ID INNER JOIN
                         tblStatus ON tblApplications.BDApp_Status = tblStatus.Status_ID
ORDER BY tblApplications.BDApp_Number
END
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetAllBDApps]    Script Date: 23/04/2019 16:16:28 ******/
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

	declare @now datetime
	declare @fortnight datetime
	declare @fourweeks datetime
	Set @now = getdate()
	set @fortnight = dateadd(day, 14, @now)
	set @fourweeks = dateadd(day, 28, @now)

	

    -- Insert statements for procedure here
	SELECT        tblApplications.BDApp_ID, tblApplications.BDApp_Number, tblApplications.BDApp_Name, tblApplications.Available_Via_Launcher, CASE WHEN tblVPBART_Rank.BART_Rank IS NULL 
                         THEN 0 ELSE tblVPBART_Rank.BART_Rank END AS BART_Ranking, CASE WHEN tblVPCompliance.GDPR = 1 THEN 1 ELSE 0 END AS GDPR, CASE WHEN tblVPCompliance.DPIA = 1 THEN 1 ELSE 0 END AS DPIA, 
                         CASE WHEN tblVPCompliance.SLA = 1 THEN 1 ELSE 0 END AS SLA, tblApplications.BDApp_Status, tblStatus.Status_Image, tblStatus.Status_Description, lvwNextBDAppReview.Next_Review_Date, 
                         CASE WHEN tblVPDetails.Directorate IS NULL THEN '' ELSE tblVPDetails.Directorate END AS Directorate, CASE WHEN tblVPDetails.CGroup IS NULL THEN '' ELSE tblVPDetails.CGroup END AS CGroup, 
                         CASE WHEN tblVPDetails.BDAppReg IS NULL THEN 0 ELSE tblVPDetails.BDAppReg END AS BDAppReg, CASE WHEN tblVPDetails.ProductOwner IS NULL THEN '' ELSE tblVPDetails.ProductOwner END AS ProductOwner, 
                         CASE WHEN tblVPDetails.BusinessSME IS NULL THEN '' ELSE tblVPDetails.BusinessSME END AS BusinessSME, CASE WHEN tblVPDetails.BusinessContact IS NULL 
                         THEN '' ELSE tblVPDetails.BusinessContact END AS BusinessContact, CASE WHEN tblUsers.Full_Name IS NULL THEN '' ELSE tblUsers.Full_Name END AS Full_Name, CASE WHEN tblVPDetails.DataGuardian IS NULL 
                         THEN '' ELSE tblVPDetails.DataGuardian END AS DataGuardian, CASE WHEN tblVPDetails.BDAppDescription IS NULL THEN '' ELSE tblVPDetails.BDAppDescription END AS BDAppDescription, 
                         CASE WHEN tblVPDetails.BDAppNotes IS NULL THEN '' ELSE tblVPDetails.BDAppNotes END AS BDAppNotes, Case When lvwNextBDAppReview.Next_Review_Date = '01/01/1900' Then '' When lvwNextBDAppReview.Next_Review_Date < @now Then 'R' When lvwNextBDAppReview.Next_Review_Date < @fortnight then 'A' When lvwNextBDAppReview.Next_Review_Date < @fourweeks then 'G' Else '' END  AS RAG
FROM            tblVPDetails LEFT OUTER JOIN
                         tblUsers ON tblVPDetails.LeadDeveloper = tblUsers.PID RIGHT OUTER JOIN
                         tblApplications ON tblVPDetails.BDApp_ID = tblApplications.BDApp_ID LEFT OUTER JOIN
                         lvwNextBDAppReview ON tblApplications.BDApp_ID = lvwNextBDAppReview.BDApp_ID LEFT OUTER JOIN
                         tblStatus ON tblApplications.BDApp_Status = tblStatus.Status_ID LEFT OUTER JOIN
                         tblVPCompliance ON tblApplications.BDApp_ID = tblVPCompliance.BDApp_ID LEFT OUTER JOIN
                         tblVPBART_Rank ON tblApplications.BDApp_Number = tblVPBART_Rank.BDApp_Number
ORDER BY tblApplications.BDApp_Number, tblApplications.BDApp_Name
END
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetAppFormCombos]    Script Date: 23/04/2019 16:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[qryVPGetAppFormCombos] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT Distinct       BDApp_Number
FROM            tblApplications

    -- Insert statements for procedure here
	SELECT Distinct       GDL_ID, Governing_DL
FROM            tblGoverning_DLs

SELECT Distinct       Status_ID, Status_Description
FROM            tblStatus

SELECT Distinct       Directorate
FROM            tblVPDirectorate
WHERE        (Active = 1)

SELECT        Directorate, CGroup
FROM            tblVPGroup
WHERE        (Active = 1)

SELECT        Full_Name, PID
FROM            tblUsers
WHERE        (VP_Admin = 1) AND (Active = 1)


End
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetBDAppComp]    Script Date: 23/04/2019 16:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[qryVPGetBDAppComp] 
	-- Add the parameters for the stored procedure here
	@BDAppID integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        tblApplications.BDApp_ID, tblApplications.BDApp_Number, CASE WHEN tblVPCompliance.GDPR IS NULL THEN 0 ELSE tblVPCompliance.GDPR END AS GDPR, CASE WHEN tblVPCompliance.DPIA IS NULL 
                         THEN 0 ELSE tblVPCompliance.DPIA END AS DPIA, CASE WHEN tblVPCompliance.SLA IS NULL THEN 0 ELSE tblVPCompliance.SLA END AS SLA
FROM            tblVPCompliance RIGHT OUTER JOIN
                         tblApplications ON tblVPCompliance.BDApp_ID = tblApplications.BDApp_ID
WHERE        (tblApplications.BDApp_ID = @BDAppID)
END
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetBDAppDetail]    Script Date: 23/04/2019 16:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[qryVPGetBDAppDetail]
	-- Add the parameters for the stored procedure here
	@BDAppID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        tblApplications.BDApp_ID, CASE WHEN tblVPDetails.Directorate IS NULL THEN '' ELSE tblVPDetails.Directorate END AS Directorate, CASE WHEN tblVPDetails.CGroup IS NULL THEN '' ELSE tblVPDetails.CGroup END AS CGroup, 
                         Case When tblVPDetails.BDAppReg is Null Then 0 else tblVPDetails.BDAppReg end as BDAppReg, CASE WHEN tblVPDetails.ProductOwner IS NULL THEN '' ELSE tblVPDetails.ProductOwner END AS ProductOwner, CASE WHEN tblVPDetails.BusinessSME IS NULL 
                         THEN '' ELSE tblVPDetails.BusinessSME END AS BusinessSME, CASE WHEN tblVPDetails.BusinessContact IS NULL THEN '' ELSE tblVPDetails.BusinessContact END AS BusinessContact, case when tblUsers.Full_Name is null then '' else tblUsers.Full_Name end as Full_Name, 
                         CASE WHEN tblVPDetails.DataGuardian IS NULL THEN '' ELSE tblVPDetails.DataGuardian END AS DataGuardian
FROM            tblUsers INNER JOIN
                         tblVPDetails ON tblUsers.PID = tblVPDetails.LeadDeveloper RIGHT OUTER JOIN
                         tblApplications ON tblVPDetails.BDApp_ID = tblApplications.BDApp_ID
WHERE        (tblApplications.BDApp_ID = @BDAppID)
END
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetBDAppDGVs]    Script Date: 23/04/2019 16:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[qryVPGetBDAppDGVs]
	-- Add the parameters for the stored procedure here
	@BDAppID Integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	declare @now datetime
	declare @fortnight datetime
	declare @fourweeks datetime
	declare @aweek datetime
	declare @afortnight datetime	
	Set @now = getdate()
	set @fortnight = dateadd(day, 14, @now)
	set @fourweeks = dateadd(day, 28, @now)
	set @aweek = dateadd(day, -7, @now)
	set @afortnight = dateadd(day, -14, @now)
	

    -- Insert statements for procedure here
	SELECT DISTINCT tblApplications.BDApp_ID, tblApplications.BDApp_Number, tblVPReviews.Review_Date as RDate, Case When tblVPReviews.Review_Date < @now Then 'R' When tblVPReviews.Review_Date < @fortnight then 'A' When tblVPReviews.Review_Date < @fourweeks then 'G' Else '' End  as RRag, Case When tblVPReviews.Review_Description is null then '' else tblVPReviews.Review_Description end as RDescription, case when tblVPReviews.Notes is null then '' else tblVPReviews.Notes end as RNotes
FROM            tblVPReviews INNER JOIN
                         tblApplications ON tblVPReviews.BDApp_Number = tblApplications.BDApp_Number
WHERE        (tblVPReviews.Actioned IS NULL) AND (tblApplications.BDApp_ID = @BDAppID)
ORDER BY tblVPReviews.Review_Date

--SELECT        Work_Item_Start, Work_Item_Description, Work_Item_Target_Date
--FROM            tblVPWWorkOnHand
--WHERE        (BDApp_ID = @BDAppID) AND (Work_Item_Closed_Date IS NULL)
--ORDER BY Work_Item_Start

SELECT        Assyst_Reference as ASSRef, Assyst_Description As ASSDescription, Assyst_Open As ASSStart, Case When Assyst_Open < @afortnight then 'R' When Assyst_Open < @aweek then 'A' else 'G' End As ASSRag
FROM            tblVPAssyst
WHERE        (BDApp_ID = @BDAppID) AND (Assyst_Close IS NULL)
ORDER BY Assyst_Open

SELECT        tblUsers.Full_Name
FROM            tblVPBDAppOtherDevs INNER JOIN
                         tblUsers ON tblVPBDAppOtherDevs.Other_Dev = tblUsers.PID
WHERE        (tblVPBDAppOtherDevs.BDApp_ID = @BDAppID)
END
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetBDAppReviews]    Script Date: 23/04/2019 16:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[qryVPGetBDAppReviews]
	-- Add the parameters for the stored procedure here
	@BDAppID Integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT DISTINCT tblApplications.BDApp_ID, tblApplications.BDApp_Number, tblVPReviews.Review_Date, tblVPReviews.Review_Description, tblVPReviews.Notes
FROM            tblVPReviews INNER JOIN
                         tblApplications ON tblVPReviews.BDApp_Number = tblApplications.BDApp_Number
WHERE        (tblVPReviews.Actioned IS NULL) AND (tblApplications.BDApp_ID = @BDAppID)
ORDER BY tblVPReviews.Review_Date
END
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetFullBDAppDetail]    Script Date: 23/04/2019 16:16:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Graham Shrives
-- Create date: 04/12/2018
-- Description:	List all apps
-- =============================================
CREATE PROCEDURE [dbo].[qryVPGetFullBDAppDetail] 
	-- Add the parameters for the stored procedure here
	@nBDApp_No Int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT        BDApp_Number, BDApp_Name, BDApp_Friendly_Name, Restricted_BDApp, Governing_DL, BDApp_Admin_Contact, BDApp_Version_Number, BDApp_Source_Folder, Status_Description, User_Install_Location, Update_Process, 
                         BDApp_Command, BDApp_Command_Args, Available_Via_Launcher, GDPR, DPIA, SLA, SLA_Link, Directorate, CGroup, BDAppReg, ProductOwner, BusinessSME, BusinessContact, Full_Name, DataGuardian, BDAppDescription, 
                         BDAppNotes, SQLPreProdLocation, SQLLiveLocation, BDAppInstallFolder, FrontEndLanguage, BackEndLanguage
FROM            lvwBDAppDetail
WHERE        (BDApp_Number = @nBDApp_No)
END
GO
/****** Object:  StoredProcedure [dbo].[qryVPGetUserDetails]    Script Date: 23/04/2019 16:16:28 ******/
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
