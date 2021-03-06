USE [DTaS_LaunchPad]
GO
/****** Object:  View [dbo].[lvwBDAppDetail]    Script Date: 24/04/2019 14:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[lvwBDAppDetail]
AS
SELECT DISTINCT 
                         dbo.tblApplications.BDApp_Number, dbo.tblApplications.BDApp_Name, dbo.tblApplications.BDApp_Friendly_Name, dbo.tblApplications.Restricted_BDApp, dbo.tblGoverning_DLs.Governing_DL, 
                         dbo.tblApplications.BDApp_Admin_Contact, dbo.tblApplications.BDApp_Version_Number, dbo.tblApplications.BDApp_Source_Folder, dbo.tblStatus.Status_Description, dbo.tblApplications.User_Install_Location, 
                         dbo.tblApplications.Update_Process, dbo.tblApplications.BDApp_Command, dbo.tblApplications.BDApp_Command_Args, dbo.tblApplications.Available_Via_Launcher, dbo.tblVPCompliance.GDPR, dbo.tblVPCompliance.DPIA, 
                         dbo.tblVPCompliance.SLA, dbo.tblVPCompliance.SLA_Link, dbo.tblVPDetails.Directorate, dbo.tblVPDetails.CGroup, dbo.tblVPDetails.BDAppReg, dbo.tblVPDetails.ProductOwner, dbo.tblVPDetails.BusinessSME, 
                         dbo.tblVPDetails.BusinessContact, dbo.tblUsers.Full_Name, dbo.tblVPDetails.DataGuardian, dbo.tblVPDetails.BDAppDescription, dbo.tblVPDetails.BDAppNotes, dbo.tblVPDetails.SQLPreProdLocation, 
                         dbo.tblVPDetails.SQLLiveLocation, dbo.tblVPDetails.BDAppInstallFolder, dbo.tblVPDetails.FrontEndLanguage, dbo.tblVPDetails.BackEndLanguage
FROM            dbo.tblApplications LEFT OUTER JOIN
                         dbo.tblStatus ON dbo.tblApplications.BDApp_Status = dbo.tblStatus.Status_ID LEFT OUTER JOIN
                         dbo.tblGoverning_DLs ON dbo.tblApplications.BDApp_Governing_DL = dbo.tblGoverning_DLs.GDL_ID LEFT OUTER JOIN
                         dbo.tblVPCompliance ON dbo.tblApplications.BDApp_ID = dbo.tblVPCompliance.BDApp_ID LEFT OUTER JOIN
                         dbo.tblVPDetails ON dbo.tblApplications.BDApp_ID = dbo.tblVPDetails.BDApp_ID LEFT OUTER JOIN
                         dbo.tblUsers ON dbo.tblVPDetails.LeadDeveloper = dbo.tblUsers.PID
GO
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
         Begin Table = "tblApplications"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 238
               Right = 257
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "tblGoverning_DLs"
            Begin Extent = 
               Top = 0
               Left = 405
               Bottom = 113
               Right = 575
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblStatus"
            Begin Extent = 
               Top = 35
               Left = 477
               Bottom = 152
               Right = 663
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblVPCompliance"
            Begin Extent = 
               Top = 6
               Left = 727
               Bottom = 136
               Right = 899
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "tblVPDetails"
            Begin Extent = 
               Top = 143
               Left = 265
               Bottom = 273
               Right = 463
            End
            DisplayFlags = 280
            TopColumn = 12
         End
         Begin Table = "tblUsers"
            Begin Extent = 
               Top = 151
               Left = 514
               Bottom = 281
               Right = 720
            End
            DisplayFlags = 280
            TopColumn = 1
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
      ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'lvwBDAppDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'   Column = 1440
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'lvwBDAppDetail'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'lvwBDAppDetail'
GO
