<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) 
    {
        SqlConnection myConnection = new SqlConnection(System.Configuration.ConfigurationManager.AppSettings["pawan"]);
        myConnection.Open();
        string sql = "select Photo from staffdetails where StaffID=@StaffID";
        SqlCommand cmd = new SqlCommand(sql, myConnection);
        cmd.Parameters.Add("@StaffID", SqlDbType.VarChar,50).Value = context.Request.QueryString["id"];
        cmd.Prepare();
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        context.Response.BinaryWrite((byte[])dr["Photo"]);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}