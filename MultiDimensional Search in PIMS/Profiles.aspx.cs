using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Specialized;

public partial class Profiles : System.Web.UI.Page
{
    DatabaseHelper db = new DatabaseHelper();
    NameValueCollection queryStringCollection = null; 
    protected void Page_Load(object sender, EventArgs e)
    {        
        queryStringCollection = Request.QueryString;
        if(!Page.IsPostBack)
        UpdateScore(queryStringCollection); 
        LoadProfile(queryStringCollection); 
       
    }

    //Load Profile on the page
    private void LoadProfile(NameValueCollection queryStringCollection)
    {
        string EntityType = queryStringCollection["EntityType"];
        string EntityID = queryStringCollection["Id"];
        FuzzyEntityCollection fuzzyCollection = (FuzzyEntityCollection)Session["FuzzyEntityCollection"];

        switch (EntityType.ToLower())
        {
            case "student":
                Student student = fuzzyCollection.Students.Find(s => s.ID == Convert.ToInt32(EntityID));
                Lbl_Name.Text = student.FirstName + ", " + student.LastName; 
                Lbl_EntityType.Text = "Student";
                Lbl_Dept.Text = student.Department.DepartmentName;
                Lbl_Score.Text = student.Score.ToString();
                if(!String.IsNullOrEmpty(student.ImageUrl))
                    Img_profilePhoto.ImageUrl = student.ImageUrl; 

                break;
            case "faculty":
                Faculty faculty = fuzzyCollection.FacultyCollection.Find(f => f.ID == Convert.ToInt32(EntityID));
                Lbl_Name.Text = faculty.FirstName + ", " + faculty.LastName; 
                Lbl_EntityType.Text = "Faculty Member";
                Lbl_Dept.Text = faculty.Department.DepartmentName;
                Lbl_Score.Text = faculty.Score.ToString();
                Lbl_Accomplishments.Text = faculty.Accomplishments;
                Lbl_Exp.Text = faculty.Experience.ToString();
                Lbl_Position.Text = faculty.Position;
                Lbl_Qualification.Text = faculty.Qualification;
                if (!String.IsNullOrEmpty(faculty.ImageUrl))
                    Img_profilePhoto.ImageUrl = faculty.ImageUrl; 

                break;
            case "staff":
                Staff staff = fuzzyCollection.StaffCollection.Find(s=> s.ID == Convert.ToInt32(EntityID));
                Lbl_Name.Text = staff.FirstName + ", " + staff.LastName; 
                Lbl_EntityType.Text = "Staff";
                Lbl_Dept.Text = staff.StaffType; 
                Lbl_Score.Text = staff.Score.ToString();
                if (!String.IsNullOrEmpty(staff.ImageUrl))
                    Img_profilePhoto.ImageUrl = staff.ImageUrl; 

                break;
            case "contractor":
                Contractor contractor = fuzzyCollection.ContractorCollection.Find(c => c.ID == Convert.ToInt32(EntityID));
                Lbl_Name.Text = contractor.FirstName + ", " + contractor.LastName; 
                Lbl_EntityType.Text = "Staff";
                Lbl_Dept.Text = contractor.ContractorType;
                Lbl_Score.Text = contractor.Score.ToString();
                if (!String.IsNullOrEmpty(contractor.ImageUrl))
                    Img_profilePhoto.ImageUrl = contractor.ImageUrl; 

                break;
        }
    }

    //Here we need to update Entity's score
    private void UpdateScore(NameValueCollection queryStringCollection)
    {
        string EntityType = queryStringCollection["EntityType"];
        string EntityID = queryStringCollection["Id"]; 

        switch (EntityType.ToLower())
        {
            case "student"  : db.UpdateTable("Update Students Set score = score +1 Where ID = " + EntityID); 
                break;
            case "faculty" : db.UpdateTable("Update Faculty Set score = score +1 Where ID = " + EntityID); 
                break;
            case "staff": db.UpdateTable("Update Staff Set score = score +1 Where ID = " + EntityID);
                break;
            case "contractor": db.UpdateTable("Update Contractors Set score = score +1 Where ID = " + EntityID);
                break;
        }
    }


    //
    protected void Btn_ImageUpload_Click(object sender, EventArgs e)
    {
        string EntityType = queryStringCollection["EntityType"];
        string EntityID = queryStringCollection["Id"]; 

        String path = @"~/images/"; 

        switch (EntityType.ToLower())
        {
            case "faculty":
                path += "Faculty/";
                db.UpdateTable("UPDATE Faculty SET ImageUrl = '" + path + FileUploadImage.FileName + "'WHERE ID = " + EntityID); 
                break;
            case "student":
                path += "Students/";
                db.UpdateTable("UPDATE Students SET ImageUrl = '" + path + FileUploadImage.FileName + "' WHERE ID = " + EntityID);
                break;
            case "staff":
                path += "Staff/";
                db.UpdateTable("UPDATE Staff SET ImageUrl = '" + path + FileUploadImage.FileName + "'WHERE ID = " + EntityID); 
                break;
            case "contractor":
                path += "Contractor/";
                db.UpdateTable("UPDATE Contractors SET ImageUrl = '" + path + FileUploadImage.FileName + "'WHERE ID = " + EntityID); 
                break;
        }
        if (SaveAndUpload(path))
            Img_profilePhoto.ImageUrl = path + FileUploadImage.FileName; 
    }

    public bool SaveAndUpload(string path)
    {
        path = Server.MapPath(path);

        Boolean fileOK = false;

        if (FileUploadImage.HasFile)
        {
            String fileExtension =
                System.IO.Path.GetExtension(FileUploadImage.FileName).ToLower();
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i])
                {
                    fileOK = true;
                }
            }
        }

        if (fileOK)
        {
            try
            {
                FileUploadImage.PostedFile.SaveAs(path
                    + FileUploadImage.FileName);
                Lbl_info.Text = "File uploaded!";
                fileOK = true; 
            }
            catch (Exception ex)
            {
                Lbl_info.Text = "File could not be uploaded.";
                fileOK = false; 
            }
        }
        else
        {
            Lbl_info.Text = "Cannot accept files of this type.";
            fileOK = false; 
        }
        return fileOK; 
    }
}

/*
         NameValueCollection queryStringCollection =  Request.QueryString;

        foreach (string key in queryStringCollection.Keys)
        {
            string value = queryStringCollection[key]; 

        }
 */