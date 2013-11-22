using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data; 

/// <summary>
/// Summary description for DatabaseHelper
/// </summary>
public class DatabaseHelper
{
   // private SqlConnection sConn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString); 
    private SqlConnection sConn= new SqlConnection(@"Data Source= AZIM\SQLEXPRESS;AttachDbFilename=|DataDirectory|\MultiFuzzySearchDB.mdf;Integrated Security=SSPI;User Instance=True");
	
    public DatabaseHelper()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetData(string query)
    {
        DataTable rv = new DataTable("resultTable"); 

        try
        {
            sConn.Open();
            SqlCommand sCommand = new SqlCommand(query, sConn);
            SqlDataAdapter sdAdapter = new SqlDataAdapter(sCommand);
            sdAdapter.Fill(rv);
            return rv; 

        }
        catch(Exception ex)
        {
            return rv;
        }
        finally
        {
            sConn.Close();
        }
    }

    public int UpdateTable(string Query)
    {
        int numberofRowsUpdated = 0;

        try
        {
            sConn.Open();
            SqlCommand sCommand = new SqlCommand(Query, sConn);
            numberofRowsUpdated = sCommand.ExecuteNonQuery(); 

        }
        catch(Exception ex)
        {

        }
        finally
        {
            sConn.Close();
        }

        return numberofRowsUpdated; 
    }

    public int InsertIntoTable(string query)
    {
        int numberofRowsUpdated = 0;

        try
        {
            sConn.Open();
            SqlCommand sCommand = new SqlCommand(query, sConn);
            numberofRowsUpdated = sCommand.ExecuteNonQuery();

        }
        catch (Exception ex)
        {

        }
        finally
        {
            sConn.Close();
        }

        return numberofRowsUpdated; 
    }
}