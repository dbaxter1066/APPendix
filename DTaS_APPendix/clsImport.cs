using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace DTaS_APPendix
{
    public class FileImport
    {
        public void ImportDatafromExcel(string dbTable, string exFilepath, string exInstruction)
        {
            //declare variables - edit these based on your particular situation
            string ssqltable = dbTable;

            string myexceldataquery = exInstruction;
            try
            {
                //create our connection strings
                string sexcelconnectionstring = String.Format("Provider=Microsoft.ACE.OLEDB.16.0;Data Source={0};Extended Properties=\"Excel 12.0 Xml;HDR=YES;IMEX=1;\"", exFilepath);
                //string sexcelconnectionstring = @"provider=microsoft.jet.oledb.4.0;data source=" + exFilepath + ";extended properties=" + "\"excel 8.0;hdr=yes;\"";
                
                //execute a query to erase any previous data from our destination table
                string sclearsql = "delete from " + ssqltable;
                SqlConnection con = new SqlConnection(Global.ConnectionString);
                SqlCommand sqlcmd = new SqlCommand(sclearsql, con);
                con.Open();
                sqlcmd.ExecuteNonQuery();
                con.Close();
                //series of commands to bulk copy data from the excel file into our sql table
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                //OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                //OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(Global.ConnectionString);
                bulkcopy.DestinationTableName = ssqltable;
                //while (dr.Read())
                //{
                //    bulkcopy.WriteToServer(dr);
                //}

                oledbconn.Close();
            }
            catch (Exception ex)
            {
                //handle exception
                MessageBox.Show("Error Text " + ex.Message);
            }
        }
        public void InsertFilesToDatabase(string dbTable, string[] dbTableColumns, string excsvFile, string exSheetName, string[] excsvColumnNames, bool blnExcel)
        {
            //name of database table
            string dbTableName = dbTable;

            if (blnExcel == true)
            {
                //Import excel to database

                SaveToDatabaseXlsx(excsvFile, exSheetName, excsvColumnNames, dbTableName, dbTableColumns);
            }
            else
            {
                //Import CSV to database
                SaveToDatabaseCsv(excsvFile, excsvColumnNames, dbTableName, dbTableColumns);
            }
        }

        public void SaveToDatabaseXlsx(string excelFilePath, string excelSheet, string[] excelColumns, string databaseTableName, string[] tableColumns)
        {

            string excelConnectionString =
                 $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={excelFilePath};Extended Properties=Excel 8.0";
            string sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLOCALDB;Initial Catalog=DatabaseName;Integrated Security=True";

            OleDbConnection connection = new OleDbConnection(excelConnectionString);

            string query = "Select * FROM [" + excelSheet + "$]";
            connection.Open();
            DataSet ds = new DataSet();
            OleDbDataAdapter oda = new OleDbDataAdapter(query, connection);
            connection.Close();
            oda.Fill(ds);
            DataTable excelDataTable = ds.Tables[0];

            SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlConnectionString)
            {
                DestinationTableName = databaseTableName
            };

            int i = 0;
            foreach (string excelColumn in excelColumns)
            {
                SqlBulkCopyColumnMapping mapItem = new SqlBulkCopyColumnMapping(excelColumn, tableColumns[i]);
                bulkCopy.ColumnMappings.Add(mapItem);
                i++;
            }

            SqlConnection sqlConnection = new SqlConnection { ConnectionString = sqlConnectionString };

            sqlConnection.Open();
            bulkCopy.WriteToServer(excelDataTable);
            sqlConnection.Close();
        }

        public void SaveToDatabaseCsv(string strCsvFilePath, string[] csvColumnNames, string strTableName, string[] tableColumns)
        {

            string csvConnectionString = "Driver={Microsoft Text Driver (*.txt; *.csv)};Dbq=" + Path.GetDirectoryName(strCsvFilePath) +
                                        ";Extensions=asc,csv,tab,txt;Persist Security Info=False";

            string sqlConnectionString = @"Data Source=(LocalDB)\MSSQLLOCALDB;Initial Catalog=DatabaseName;Integrated Security=True";

            OdbcConnection conn = new OdbcConnection(csvConnectionString.Trim());

            conn.Open();

            var sqlSelect = "select * from [" + Path.GetFileName(strCsvFilePath) + "]";
            OdbcCommand commandSourceData = new OdbcCommand(sqlSelect, conn);

            OdbcDataReader dataReader = commandSourceData.ExecuteReader();

            using (SqlBulkCopy bulkCopy =
                 new SqlBulkCopy(sqlConnectionString))
            {
                bulkCopy.DestinationTableName = strTableName;

                var intColumnCount = dataReader.FieldCount;

                if (!dataReader.HasRows)
                    return;

                // add the column mappings
                int i = 0;
                foreach (string csvCol in csvColumnNames)
                {
                    SqlBulkCopyColumnMapping mapItem = new SqlBulkCopyColumnMapping(csvCol, tableColumns[i]);
                    bulkCopy.ColumnMappings.Add(mapItem);
                    i++;
                }

                bulkCopy.WriteToServer(dataReader);
                bulkCopy.Close();
                conn.Close();
            }
        }
    }

}
