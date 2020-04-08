using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace DTaS_APPendix
{
    class Apps : IEnumerable
    {
        public IList<BDApp> BDAppList { get { return this._apps ; } }
        private List<BDApp> _apps = new List<BDApp>();

        // Public methods.  
        public void Add(BDApp c)
        {
            _apps.Add(c);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (BDApp _app in _apps)
            {
                yield return _app;
            }
        }

        public void GetAllApps()
        {
            BDApp _app = null;
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryGetAllApps", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                //OleDbDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr != null)
                {
                    // Call Read before accessing data.
                    while (dr.Read())
                    {
                        _app = new BDApp();
                        _app.BDApp_ID = Convert.ToInt32(dr["BDApp_ID"].ToString());
                        _app.BDApp_Number = Convert.ToInt32(dr["BDApp_Number"].ToString());
                        _app.BDApp_Name = dr["BDApp_Name"].ToString();
                        _app.BDApp_Friendly_Name = dr["BDApp_Friendly_Name"].ToString();
                        _app.Restricted_BDApp = Convert.ToBoolean(dr["Restricted_BDApp"].ToString());
                        _app.BDApp_Governing_DL = dr["BDApp_Governing_DL"].ToString();
                        _app.BDApp_Admin_Contact = dr["BDApp_Admin_Contact"].ToString();
                        _app.BDApp_Version_Number = dr["BDApp_Version_Number"].ToString();
                        _app.BDApp_Source_Folder = dr["BDApp_Source_Folder"].ToString();
                        _app.BDApp_Status = Convert.ToInt16(dr["BDApp_Status"].ToString());
                        _app.Updated_By = Convert.ToInt32(dr["Updated_By"].ToString());
                        try
                        {
                            _app.Date_Updated = Convert.ToDateTime(dr["Date_Updated"].ToString());
                        }
                        catch
                        {
                            _app.Date_Updated = Convert.ToDateTime("01/01/1900 00:00:00");
                        }
                        _app.Update_Process = dr["Update_Process"].ToString();
                        _app.Status_Description = dr["Status_Description"].ToString();
                        _app.Governing_DL = dr["Governing_DL"].ToString();
                        _app.List_Managers = dr["List_Managers"].ToString();
                        _apps.Add(_app);
                    }
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == -2) // connection time-out
                {
                    System.Windows.Forms.MessageBox.Show("The application could not connect to the database, and will now close.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    // Close the application
                    Environment.Exit(1);
                }
            }
        }


        public void GetUserApps(int intPID)
        {
            BDApp _app = null;
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryGetUserApps", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                SqlParameter prmID253 = cmd.Parameters.Add("@PID", SqlDbType.Int);
                prmID253.Value = intPID;

                con.Open();

                //OleDbDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr = cmd.ExecuteReader();
                

                if (dr != null)
                {
                    // Call Read before accessing data.
                    while (dr.Read())
                    {
                        _app = new BDApp();
                        _app.BDApp_ID = Convert.ToInt32(dr["BDApp_ID"].ToString());
                        _app.BDApp_Number = Convert.ToInt32(dr["BDApp_Number"].ToString());
                        _app.App_Fav = Convert.ToInt16(dr["Favourite_App"].ToString());
                        _app.BDApp_Name = _app.App_Fav == 1 ? dr["BDAppName"].ToString() + " #" : dr["BDAppName"].ToString();  /* Toggled with friendly name.  Favourites flagged with #. */
                        _app.Restricted_BDApp = Convert.ToBoolean(dr["Restricted_BDApp"].ToString());
                        _app.BDApp_Governing_DL = dr["Governing_DL"].ToString();
                        _app.BDApp_Source_Folder = dr["BDApp_Source_Folder"].ToString();
                        _app.BDApp_Command = dr["BDApp_Command"].ToString();
                        _app.BDApp_Command_Args = dr["BDApp_Command_Args"].ToString();
                        _app.BDApp_Admin_Contact = dr["BDApp_Admin_Contact"].ToString();
                        _app.BDApp_Version_Number = dr["BDApp_Version_Number"].ToString();
                        _app.BDApp_Source_Folder = dr["BDApp_Source_Folder"].ToString();
                        _app.BDApp_Status = Convert.ToInt16(dr["BDApp_Status"].ToString());
                        _app.Updated_By = Convert.ToInt32(dr["Updated_By"].ToString());
                        try
                        {
                            _app.Date_Updated = Convert.ToDateTime(dr["Date_Updated"].ToString());
                        }
                        catch
                        {
                            _app.Date_Updated = Convert.ToDateTime("01/01/1900 00:00:00");
                        }
                        _app.Update_Process = dr["Update_Process"].ToString();
                        _app.App_Odr = Convert.ToInt16(dr["odr"].ToString());
                        byte[] img = (byte[])dr["BDApp_Image"]; /*read image*/
                        MemoryStream ms = new MemoryStream(img); /*set as MemoryStream e*/
                        _app.App_Img = new Bitmap(ms);  /*assign as bitmap*/
                        //_app.Governing_DL = dr["Governing_DL"].ToString();
                        //_app.List_Managers = dr["List_Managers"].ToString();
                        _apps.Add(_app);
                    }
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == -2) // connection time-out
                {
                    System.Windows.Forms.MessageBox.Show("The application could not connect to the database, and will now close.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    // Close the application
                    Environment.Exit(1);
                }
            }
        }


        public void GetUserAllocatedApps(int intPID)
        {
            BDApp _app = null;
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryGetUserAllocatedApps", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                SqlParameter prmID253 = cmd.Parameters.Add("@PID", SqlDbType.Int);
                prmID253.Value = intPID;

                con.Open();

                //OleDbDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr != null)
                {
                    // Call Read before accessing data.
                    while (dr.Read())
                    {
                        _app = new BDApp();
                        _app.BDApp_ID = Convert.ToInt32(dr["BDApp_ID"].ToString());
                        _app.BDApp_Number = Convert.ToInt32(dr["BDApp_Number"].ToString());
                        _app.App_Fav = Convert.ToInt16(dr["Favourite_App"]);
                        _app.BDApp_Name = _app.App_Fav == 1 ? dr["BDAppName"].ToString() + " #" : dr["BDAppName"].ToString();  /* Toggled with friendly name.  Favourites flagged with #. */
                        _app.Restricted_BDApp = Convert.ToBoolean(dr["Restricted_BDApp"].ToString());
                        _app.BDApp_Governing_DL = dr["Governing_DL"].ToString();
                        _app.BDApp_Source_Folder = dr["BDApp_Source_Folder"].ToString();
                        _app.BDApp_Command = dr["BDApp_Command"].ToString();
                        _app.BDApp_Command_Args = dr["BDApp_Command_Args"].ToString();
                        _app.BDApp_Admin_Contact = dr["BDApp_Admin_Contact"].ToString();
                        _app.BDApp_Version_Number = dr["BDApp_Version_Number"].ToString();
                        _app.BDApp_Source_Folder = dr["BDApp_Source_Folder"].ToString();
                        _app.BDApp_Status = Convert.ToInt16(dr["BDApp_Status"].ToString());
                        _app.Status_Description = dr["Status_Description"].ToString();
                        byte[] statusimg = (byte[])dr["Status_Image"]; /*read image*/
                        MemoryStream statusms = new MemoryStream(statusimg); /*set as MemoryStream e*/
                        _app.Status_Img = new Bitmap(statusms);  /*assign as bitmap*/
                        _app.Updated_By = Convert.ToInt32(dr["Updated_By"].ToString());
                        _app.User_Install_Location = dr["User_Install_Location"].ToString();
                        try
                        {
                            _app.Date_Updated = Convert.ToDateTime(dr["Date_Updated"].ToString());
                        }
                        catch
                        {
                            _app.Date_Updated = Convert.ToDateTime("01/01/1900 00:00:00");
                        }
                        _app.Update_Process = dr["Update_Process"].ToString();
                        _app.App_Odr = Convert.ToInt16(dr["odr"].ToString());
                        byte[] img = (byte[])dr["BDApp_Image"]; /*read image*/
                        MemoryStream ms = new MemoryStream(img); /*set as MemoryStream e*/
                        _app.App_Img = new Bitmap(ms);  /*assign as bitmap*/
                                                        //_app.Governing_DL = dr["Governing_DL"].ToString();
                                                        //_app.List_Managers = dr["List_Managers"].ToString();
                        _apps.Add(_app);
                    }
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == -2) // connection time-out
                {
                    System.Windows.Forms.MessageBox.Show("The application could not connect to the database, and will now close.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    // Close the application
                    Environment.Exit(1);
                }
            }
        }


        public void GetUserUnAllocatedApps(int intPID)
        {
            BDApp _app = null;
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryGetUserUnAllocatedApps", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                SqlParameter prmID253 = cmd.Parameters.Add("@PID", SqlDbType.Int);
                prmID253.Value = intPID;

                con.Open();

                //OleDbDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr = cmd.ExecuteReader();


                if (dr != null)
                {
                    // Call Read before accessing data.
                    while (dr.Read())
                    {
                        _app = new BDApp();
                        _app.BDApp_ID = Convert.ToInt32(dr["BDApp_ID"].ToString());
                        _app.BDApp_Number = Convert.ToInt32(dr["BDApp_Number"].ToString());
                        _app.App_Fav = Convert.ToInt16(dr["Favourite_App"]);
                        _app.BDApp_Name = _app.App_Fav == 1 ? dr["BDAppName"].ToString() + " #" : dr["BDAppName"].ToString();  /* Toggled with friendly name.  Favourites flagged with #. */
                        _app.Restricted_BDApp = Convert.ToBoolean(dr["Restricted_BDApp"].ToString());
                        _app.BDApp_Governing_DL = dr["Governing_DL"].ToString();
                        _app.BDApp_Source_Folder = dr["BDApp_Source_Folder"].ToString();
                        _app.BDApp_Command = dr["BDApp_Command"].ToString();
                        _app.BDApp_Command_Args = dr["BDApp_Command_Args"].ToString();
                        _app.BDApp_Admin_Contact = dr["BDApp_Admin_Contact"].ToString();
                        _app.BDApp_Version_Number = dr["BDApp_Version_Number"].ToString();
                        _app.BDApp_Source_Folder = dr["BDApp_Source_Folder"].ToString();
                        _app.BDApp_Status = Convert.ToInt16(dr["BDApp_Status"].ToString());
                        _app.Status_Description = dr["Status_Description"].ToString();
                        byte[] statusimg = (byte[])dr["Status_Image"]; /*read image*/
                        MemoryStream statusms = new MemoryStream(statusimg); /*set as MemoryStream e*/
                        _app.Status_Img = new Bitmap(statusms);  /*assign as bitmap*/
                        _app.Updated_By = Convert.ToInt32(dr["Updated_By"].ToString());
                        try
                        {
                            _app.Date_Updated = Convert.ToDateTime(dr["Date_Updated"].ToString());
                        }
                        catch
                        {
                            _app.Date_Updated = Convert.ToDateTime("01/01/1900 00:00:00");
                        }
                        _app.Update_Process = dr["Update_Process"].ToString();
                        _app.App_Odr = Convert.ToInt16(dr["odr"].ToString());
                        byte[] img = (byte[])dr["BDApp_Image"]; /*read image*/
                        MemoryStream ms = new MemoryStream(img); /*set as MemoryStream e*/
                        _app.App_Img = new Bitmap(ms);  /*assign as bitmap*/
                        //_app.Governing_DL = dr["Governing_DL"].ToString();
                        //_app.List_Managers = dr["List_Managers"].ToString();
                        _apps.Add(_app);
                    }
                }
                con.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == -2) // connection time-out
                {
                    System.Windows.Forms.MessageBox.Show("The application could not connect to the database, and will now close.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    // Close the application
                    Environment.Exit(1);
                }
            }
        }

        public void AddBDAppIcon(int BDApp_No)
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                OpenFileDialog fop = new OpenFileDialog();
                fop.InitialDirectory = @"H:\Icons\Windows 8 Metro Icons\Metro ICO\Other\";
                fop.Filter = "[Icon]|*.ico";
                if (fop.ShowDialog() == DialogResult.OK)
                {
                    FileStream FS = new FileStream(@fop.FileName, FileMode.Open, FileAccess.Read);
                    byte[] img = new byte[FS.Length];
                    FS.Read(img, 0, Convert.ToInt32(FS.Length));

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("qryAddBDAppIcon", con);
                    cmd.CommandTimeout = Global.TimeOut;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nBDApp_No", BDApp_No);
                    cmd.Parameters.Add("@nBDApp_Icon", SqlDbType.Image).Value = img;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Image Save Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Image save aborted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void AddBDAppZIP(int BDApp_No)
        {
            SqlConnection con = new SqlConnection(Global.ConnectionString);

            try
            {
                OpenFileDialog fop = new OpenFileDialog();
                fop.InitialDirectory = @"C:\Users\USER2\Documents";
                fop.Filter = "ZIP Files|*.zip";
                if (fop.ShowDialog() == DialogResult.OK)
                {
                    FileStream FS = new FileStream(@fop.FileName, FileMode.Open, FileAccess.Read);
                    byte[] bytes = new byte[FS.Length];
                    FS.Read(bytes, 0, Convert.ToInt32(FS.Length));

                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    SqlCommand cmd = new SqlCommand("qryAddBDAppPackage", con);
                    cmd.CommandTimeout = Global.TimeOut;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@nBDApp_No", BDApp_No);
                    cmd.Parameters.Add("@nBDApp_Package", SqlDbType.Image).Value = bytes;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Zip Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Zip save aborted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        public void ToggleUserFavourite(int intPID, int intBDAppID, bool blnIsFavourite)
        {
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryAmendUserFavourite", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@iPID", intPID);
                cmd.Parameters.AddWithValue("@iBDApp_ID", intBDAppID);
                cmd.Parameters.AddWithValue("@bIsFavourite", blnIsFavourite);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();
                return;
            }
            catch
            {
                MessageBox.Show("There was an error. Your Favourite preference could not be changed", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public void UpdateUserAppLastUsed(long iBDApp_ID, int intPID)
        {
            try
            {

                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryUpdateUserAppLastUsed", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nBDApp_ID", iBDApp_ID);
                cmd.Parameters.AddWithValue("@nPID", intPID);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();
            }
            catch
            {
                //MessageBox.Show("There was an error.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        public void AddBDAppApprovalRequest(long BDApp_No, int intPID)
        {
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryAddBDAppApprovalRequest", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@nBDApp_No", BDApp_No);
                cmd.Parameters.AddWithValue("@nUser_PID", intPID);
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();
            }
            catch
            {
                //MessageBox.Show("There was an error.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public Boolean UpdateAddBDApp(int intBDAppID, int intBDAppNo, string strBDAppName, string strBDApp_Friendly, bool blnRestBDApp, int intGoverningDL, string strContact, string strVersionNo, string strBDAppFolder, string strSourceFolder, int intStatus, string strInstallFile, int intUpdatedBy, string strUpdateProcess, string strCommand, string strCommandArgs, bool blnAvailable_LaunchPad, bool blnGDPR, bool blnDPIA, bool blnSLA, string strDPIARef, string strDPIALink, string strSLALink, string strDirectorate, string strGroup, int intCriticality, bool blnBDAppReg, string strProductOwner, string strBusSME, string strBusContact, int intLeadDev, string strDataGuardian, string strBDAppDes, string strBDAppNotes, string strSQlPreProd, string strSQLLive, string strFrontEnd, string strBackEnd)
        { 
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPAddBDAppApplication", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                SqlParameter prmBDAppID = cmd.Parameters.Add("@nBDAppID", SqlDbType.Int);
                prmBDAppID.Value = intBDAppID;
                SqlParameter prmBDAppNo = cmd.Parameters.Add("@nBDAppNo", SqlDbType.Int);
                prmBDAppNo.Value = intBDAppNo;
                SqlParameter prmBDAppName = cmd.Parameters.Add("@nBDAppName", SqlDbType.NVarChar);
                prmBDAppName.Value = strBDAppName;
                SqlParameter prmBDAppFriendly = cmd.Parameters.Add("@nBDApp_Friendly", SqlDbType.NVarChar);
                prmBDAppFriendly.Value = strBDApp_Friendly;
                SqlParameter prmRestBDApp = cmd.Parameters.Add("@nRestBDApp", SqlDbType.Bit);
                prmRestBDApp.Value = blnRestBDApp;
                SqlParameter prmGoverningDL = cmd.Parameters.Add("@nGoverningDL", SqlDbType.Int);
                prmGoverningDL.Value =  intGoverningDL;
                SqlParameter prmContact = cmd.Parameters.Add("@nContact", SqlDbType.NVarChar);
                prmContact.Value = strContact;
                SqlParameter prmVersionNo = cmd.Parameters.Add("@nVersionNo", SqlDbType.NVarChar);
                prmVersionNo.Value = strVersionNo;
                SqlParameter prmBDAppFolder = cmd.Parameters.Add("@nBDAppFolder", SqlDbType.NVarChar);
                prmBDAppFolder.Value = strBDAppFolder;
                SqlParameter prmSource = cmd.Parameters.Add("@nSourceFolder", SqlDbType.NVarChar);
                prmSource.Value = strSourceFolder;
                SqlParameter prmStatus = cmd.Parameters.Add("@nStatus", SqlDbType.Int);
                prmStatus.Value = intStatus;
                SqlParameter prmInstall = cmd.Parameters.Add("@nUser_Install", SqlDbType.NVarChar);
                prmInstall.Value = strInstallFile ;
                SqlParameter prmUpdatedBy = cmd.Parameters.Add("@nUpdatedBy", SqlDbType.Int);
                prmUpdatedBy.Value = intUpdatedBy;
                SqlParameter prmUpdateProcess = cmd.Parameters.Add("@nUpdateProcess", SqlDbType.NVarChar);
                prmUpdateProcess.Value =  strUpdateProcess;
                SqlParameter prmCommand = cmd.Parameters.Add("@nCommand", SqlDbType.NVarChar);
                prmCommand.Value =  strCommand;
                SqlParameter prmCommandArgs = cmd.Parameters.Add("@nCommandArgs", SqlDbType.NVarChar);
                prmCommandArgs.Value =  strCommandArgs;
                SqlParameter prmAvailableLauncher = cmd.Parameters.Add("@nAvailable_Launcher", SqlDbType.Bit);
                prmAvailableLauncher.Value = blnAvailable_LaunchPad;
                SqlParameter prmGDPR = cmd.Parameters.Add("@nGDPR", SqlDbType.Bit);
                prmGDPR.Value = blnGDPR;
                SqlParameter prmDPIA = cmd.Parameters.Add("@nDPIA", SqlDbType.Bit);
                prmDPIA.Value = blnDPIA;
                SqlParameter prmSLA = cmd.Parameters.Add("@nSLA", SqlDbType.Bit);
                prmSLA.Value = blnSLA;
                SqlParameter prmDPIARef = cmd.Parameters.Add("@nDPIARef", SqlDbType.NVarChar);
                prmDPIARef.Value =  strDPIARef;
                SqlParameter prmDPIALink = cmd.Parameters.Add("@nDPIALink", SqlDbType.NVarChar);
                prmDPIALink.Value = strDPIALink;
                SqlParameter prmSLALink = cmd.Parameters.Add("@nSLALink", SqlDbType.NVarChar);
                prmSLALink.Value = strSLALink;
                SqlParameter prmDirectorate = cmd.Parameters.Add("@nDirectorate", SqlDbType.NVarChar);
                prmDirectorate.Value = strDirectorate;
                SqlParameter prmGroup = cmd.Parameters.Add("@nGroup", SqlDbType.NVarChar);
                prmGroup.Value = strGroup;
                SqlParameter prmCriticality = cmd.Parameters.Add("@nCriticality", SqlDbType.Int);
                prmCriticality.Value = intCriticality;
                SqlParameter prmBDAppReg = cmd.Parameters.Add("@nBDAppReg", SqlDbType.Bit);
                prmBDAppReg.Value = blnBDAppReg;
                SqlParameter prmProductOwner = cmd.Parameters.Add("@nProductOwner", SqlDbType.NVarChar);
                prmProductOwner.Value = strProductOwner;
                SqlParameter prmBusSME = cmd.Parameters.Add("@nBusSME", SqlDbType.NVarChar);
                prmBusSME.Value = strBusSME;
                SqlParameter prmBusContact = cmd.Parameters.Add("@nBusContact", SqlDbType.NVarChar);
                prmBusContact.Value = strBusContact;
                SqlParameter prmLeadDev = cmd.Parameters.Add("@nLeadDev", SqlDbType.Int);
                prmLeadDev.Value = intLeadDev;
                SqlParameter prmDataGuardian = cmd.Parameters.Add("@nDataGuardian", SqlDbType.NVarChar);
                prmDataGuardian.Value = strDataGuardian;
                SqlParameter prmBDAppDes = cmd.Parameters.Add("@nBDAppDescription", SqlDbType.NVarChar);
                prmBDAppDes.Value = strBDAppDes;
                SqlParameter prmBDAppNotes = cmd.Parameters.Add("@nBDAppNotes", SqlDbType.NVarChar);
                prmBDAppNotes.Value = strBDAppNotes;
                SqlParameter prmSQlPreProd = cmd.Parameters.Add("@nSQlPreProd", SqlDbType.NVarChar);
                prmSQlPreProd.Value = strSQlPreProd;
                SqlParameter prmSQLLive = cmd.Parameters.Add("@nSQLLive", SqlDbType.NVarChar);
                prmSQLLive.Value = strSQLLive;
                SqlParameter prmFrontEnd = cmd.Parameters.Add("@nFrontEnd", SqlDbType.NVarChar);
                prmFrontEnd.Value = strFrontEnd;
                SqlParameter prmBackEnd = cmd.Parameters.Add("@nBackEnd", SqlDbType.NVarChar);
                prmBackEnd.Value = strBackEnd;
                var returnParameter = cmd.Parameters.Add("@nBDAppID", SqlDbType.Int);
                returnParameter.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                Global.gblResult = Convert.ToInt16(returnParameter.Value);
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();

                MessageBox.Show("Application data successfully saved.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                MessageBox.Show("Application failed to add Application.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        public Boolean DeleteBDApp(int intBDAppNo)
        {
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryVPDeleteBDAppApplication", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.Clear();
                SqlParameter prmBDAppNo = cmd.Parameters.Add("@nBDAppNo", SqlDbType.Int);
                prmBDAppNo.Value = intBDAppNo;
                cmd.ExecuteNonQuery();
                con.Close();
                cmd.Dispose();
                cmd.Parameters.Clear();

                MessageBox.Show("Application data successfully deleted.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch
            {
                MessageBox.Show("Application failed to delete Application.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false; ;
            }
        }

        public Boolean UpdateAddAppAdmin(int intBDAppNo, int intAdminPID, bool blnActive)
        {
            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryAddApplicationAdministrator", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                SqlParameter prmBDAppNo = cmd.Parameters.Add("@nBDAppNo", SqlDbType.Int);
                prmBDAppNo.Value = intBDAppNo;
                SqlParameter prmAdminPID = cmd.Parameters.Add("@nAdminPID", SqlDbType.Int);
                prmAdminPID.Value = intAdminPID;
                SqlParameter prmActive = cmd.Parameters.Add("@nActive", SqlDbType.Bit);
                prmActive.Value = blnActive;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Application saved Application Administrator.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return true;
            }
            catch
            {
                MessageBox.Show("Application failed to save Application Administrator.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
        public Boolean DeleteAppAdmin(int intBDAppNo, int intAdminPID)
        {

            try
            {
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand cmd = new SqlCommand("qryDeleteApplicationAdministrator", con);
                cmd.CommandTimeout = Global.TimeOut;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                SqlParameter prmBDAppNo = cmd.Parameters.Add("@nBDAppNo", SqlDbType.Int);
                prmBDAppNo.Value = intBDAppNo;
                SqlParameter prmAdminPID = cmd.Parameters.Add("@nAdminPID", SqlDbType.Int);
                prmAdminPID.Value = intAdminPID;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Application deleted Application Administrator.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return true;
            }
            catch
            {
                MessageBox.Show("Application failed to delete Application Administrator.", Global.ApplicationName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }
    }

    public class BDApp
    {

        private Int32 _bdappId;
        private Int32 _bdappNumber;
        private string _bdappName;
        private string _bdappFriendlyName;
        private bool _restrictedBdapp;
        private string _bdappGoverningDl;
        private string _bdappAdminContact;
        private string _bdappVersionNumber;
        private string _bdappSourceFolder;
        private Int16 _bdappStatus;
        private Int32 _updatedBy;
        private DateTime _dateUpdated;
        private string _updateProcess;
        private string _statusDescription;
        private string _userInstallLocation;
        private Bitmap _statusImg;
        private string _governingDl;
        private string _listManagers;
        private Int16 _appOdr;
        private Int16 _appFav;
        private Bitmap _appImg;
        private string _bdappCommand;
        private string _bdappCommandArgs;

        public BDApp()
        {

        }

        public BDApp(int _bdappid, int _bdappnumber, string _bdappname, string _bdappfriendlyname, bool _restrictedbdapp, string _bdappgoverningdl, 
            string _bdappadmincontact, string _bdappversionnumber, string _bdappsourcefolder, short _bdappstatus, short _updatedby, 
            DateTime _dateupdated, string _updateprocess, string _statusdescription, string _userinstalllocation, Bitmap _statusimg, string _governingdl, string _listmanagers, 
            short _appodr, short _appfav, Bitmap _appimg, string _bdappcommand, string _bdappcommandargs)
        {
            this._bdappId = _bdappid;
            this._bdappNumber = _bdappnumber;
            this._bdappName = _bdappname;
            this._bdappFriendlyName = _bdappfriendlyname;
            this._restrictedBdapp = _restrictedbdapp;
            this._bdappGoverningDl = _bdappgoverningdl;
            this._bdappAdminContact = _bdappadmincontact;
            this._bdappVersionNumber = _bdappversionnumber;
            this._bdappSourceFolder = _bdappsourcefolder;
            this._bdappStatus = _bdappstatus;
            this._updatedBy = _updatedby;
            this._dateUpdated = _dateupdated;
            this._updateProcess = _updateprocess;
            this._statusDescription = _statusdescription;
            this._statusImg = _statusimg;
            this._governingDl = _governingdl;
            this._listManagers = _listmanagers;
            this._appOdr = _appodr;
            this._appFav = _appfav;
            this._appImg = _appimg;
            this._bdappCommand = _bdappcommand;
            this._bdappCommandArgs = _bdappcommandargs;
        }

        public Int32 BDApp_ID
        {
            get
            {
                return _bdappId;
            }
            set
            {
                _bdappId = value;
            }
        }

        public Int32 BDApp_Number {
            get
            {
                return _bdappNumber;
            }
            set
            {
                _bdappNumber = value;
            }
        }

        public string BDApp_Name
        {
            get
            {
                return _bdappName;
            }
            set
            {
                _bdappName = value;
            }
        }

        public string BDApp_Friendly_Name
        {
            get
            {
                return _bdappFriendlyName;
            }
            set
            {
                _bdappFriendlyName = value;
            }
        }

        public bool Restricted_BDApp
        {
            get
            {
                return _restrictedBdapp;
            }
            set
            {
                _restrictedBdapp = value;
            }
        }

        public string BDApp_Governing_DL
        {
            get
            {
                return _bdappGoverningDl;
            }
            set
            {
                _bdappGoverningDl = value;
            }
        }

        public string BDApp_Admin_Contact
        {
            get
            {
                return _bdappAdminContact;
            }
            set
            {
                _bdappAdminContact = value;
            }
        }

        public string BDApp_Version_Number
        {
            get
            {
                return _bdappVersionNumber;
            }
            set
            {
                _bdappVersionNumber = value;
            }
        }

        public string BDApp_Source_Folder
        {
            get
            {
                return _bdappSourceFolder;
            }
            set
            {
                _bdappSourceFolder = value;
            }
        }

        public Int16 BDApp_Status
        {
            get
            {
                return _bdappStatus;
            }
            set
            {
                _bdappStatus = value;
            }
        }

        public Int32 Updated_By
        {
            get
            {
                return _updatedBy;
            }
            set
            {
                _updatedBy = value;
            }
        }

        public DateTime Date_Updated
        {
            get
            {
                return _dateUpdated;
            }
            set
            {
                _dateUpdated = value;
            }
        }

        public string Update_Process
        {
            get
            {
                return _updateProcess;
            }
            set
            {
                _updateProcess = value;
            }
        }

        public string Status_Description
        {
            get
            {
                return _statusDescription;
            }
            set
            {
                _statusDescription = value;
            }
        }

        public string User_Install_Location
        {
            get
            {
                return _userInstallLocation;
            }
            set
            {
                _userInstallLocation = value;
            }
        }

        public Bitmap Status_Img
        {
            get
            {
                return _statusImg;
            }
            set
            {
                _statusImg = value;
            }
        }

        public string Governing_DL
        {
            get
            {
                return _governingDl;
            }
            set
            {
                _governingDl = value;
            }
        }

        public string List_Managers
        {
            get
            {
                return _listManagers;
            }
            set
            {
                _listManagers = value;
            }
        }

        public Int16 App_Odr
        {
            get
            {
                return _appOdr;
            }
            set
            {
                _appOdr = value;
            }
        }

        public Int16 App_Fav
        {
            get
            {
                return _appFav;
            }
            set
            {
                _appFav = value;
            }
        }

        public Bitmap App_Img
        {
            get
            {
                return _appImg;
            }
            set
            {
                _appImg = value;
            }
        }

        public string BDApp_Command
        {
            get
            {
                return _bdappCommand;
            }
            set
            {
                _bdappCommand = value;
            }
        }


        public string BDApp_Command_Args
        {
            get
            {
                return _bdappCommandArgs;
            }
            set
            {
                _bdappCommandArgs = value;
            }
        }

    }
}