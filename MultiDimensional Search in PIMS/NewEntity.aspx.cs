using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewEntity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Btn_Faculty_Click(object sender, EventArgs e)
    {
        Faculty faculty = new Faculty(); 
        faculty.FirstName = TxtBx_F_FName.Text;
        faculty.LastName = TxtBx_F_LName.Text; 
        faculty.Department.ID = Convert.ToInt32(selectFDept.Value); 
        faculty.Qualification = TxtBx_F_Q.Text; 
        faculty.Position = TxtBx_F_P.Text; 
        faculty.Experience = Convert.ToInt32(selectExpYears.Value); 
        faculty.Accomplishments = TxtBx_F_Acc.Text; 

        string query = @"INSERT INTO Faculty VALUES ('" 
                    + faculty.FirstName + "', '" + faculty.LastName + "', " + faculty.Department.ID  + ", '"
                    + faculty.Qualification + "', '" + faculty.Position + "', " +faculty.Experience + ", '"
                    +  faculty.Accomplishments + "',0,'')";

        DatabaseHelper db = new DatabaseHelper();
        int recordCount = db.InsertIntoTable(query);

        Response.Redirect("Info.aspx?m=" + recordCount.ToString() + " Faculty memeber Added to Database"); 
        
    }
    protected void Btn_Student_Click(object sender, EventArgs e)
    {
        Student student = new Student();

        student.FirstName = TxtBx_S_FName.Text;
        student.LastName = TxtBx_S_LName.Text;
        student.Department.ID = Convert.ToInt32(slectSDept.Value); 

        string query = @"INSERT INTO Students VALUES ('" 
            +  student.FirstName + "', '" + student.LastName + "', " + student.Department.ID + ", 0, '')"; 

        DatabaseHelper db = new DatabaseHelper();
        int recordCount = db.InsertIntoTable(query);

        Response.Redirect("Info.aspx?m=" + recordCount.ToString() + " Student Added to Database"); 


    }
    protected void Btn_Staff_Click(object sender, EventArgs e)
    {

    }
    protected void Btn_Contractors_Click(object sender, EventArgs e)
    {

    }
}




