using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //
    protected void Btn_Login_Click(object sender, EventArgs e)
    {
        if (TxtBx_UserName.Text == "admin" && TxtBx_Password.Text == "password")
        {
            Response.Redirect("Home.aspx");
        }
        else
        {
            p_invalidUser.Visible = true;  
        }
    }
}