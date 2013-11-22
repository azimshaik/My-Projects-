using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Home : System.Web.UI.Page
{
    FuzzyEntityCollection fuzzyEntityCollection = null; 

    protected void Page_Load(object sender, EventArgs e)
     {

    }
    //Search Database and return results THIS IS MOVED TO SIMPLE SEARCH 
    /*
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        fuzzyEntityCollection = new FuzzyEntityCollection(); 
        
        DatabaseHelper db = new DatabaseHelper();
        DataTable searchResultTable = db.GetData(@"SELECT        s.ID, s.FirstName, s.LastName, d.DepartmentName, 'students' AS EntityType
                    FROM            Students AS s INNER JOIN
                                             Departments AS d ON s.DepartmentID = d.ID
                    WHERE        s.FirstName LIKE '%" + TxtBx_Search.Text + "%'"
                    + @"UNION ALL
                    SELECT        f.ID, f.FirstName, f.LastName, d.DepartmentName, 'faculty' AS EntityType
                    FROM            Faculty AS f INNER JOIN
                                             Departments AS d ON f.DepartmentId = d.ID
                    WHERE        f.FirstName LIKE  '%" + TxtBx_Search.Text + "%'");


        BuildFuzzyEntities(searchResultTable);

        ShowSearchresults(fuzzyEntityCollection); 
        //ShowSearchResults(searchResultTable); 
    }*/

    //Method to Display results
    private void ShowSearchresults(FuzzyEntityCollection fuzzyEntityCollection)
    {
        HtmlTableRow trCount = new HtmlTableRow();
        HtmlTableCell tdCount = new HtmlTableCell();
        trCount.Cells.Add(tdCount);
        trCount.Attributes.Add("class", "lightcoloredText");
        Tbl_Search.Rows.Add(trCount);

        tdCount.InnerText = fuzzyEntityCollection.Students.Count + " students found, " + fuzzyEntityCollection.FacultyCollection.Count + " faculty found"; 
            
        foreach(Faculty currentFaculty in fuzzyEntityCollection.FacultyCollection)
        {
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell td = new HtmlTableCell();
            td.InnerHtml = "<a href='Profiles.aspx?Id=" + currentFaculty.ID + "&EntityType=faculty" +"'  class='greenText'>" +currentFaculty.FirstName + "," + currentFaculty.LastName  + ", " + currentFaculty.Department.DepartmentName  + ", " + currentFaculty.ID+ "</a>";
            tr.Cells.Add(td);
            Tbl_Search.Rows.Add(tr); 

        }

        foreach(Student currentStudent in fuzzyEntityCollection.Students)
        {
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell td = new HtmlTableCell();
            td.InnerHtml = "<a href='Profiles.aspx?Id=" + currentStudent.ID + "&EntityType=Student" +" ' class='greenText'>" +currentStudent.FirstName+ ","+ currentStudent.LastName +"," + currentStudent.Department.DepartmentName + ","+currentStudent.ID+ "</a>";
                tr.Cells.Add(td);
            Tbl_Search.Rows.Add(tr);
        }


    }

    private void ShowEntitySearchresults(FuzzyEntityCollection fuzzyEntityCollection, string EntityName)
    {
        HtmlTableRow trLastestRes = new HtmlTableRow();
        HtmlTableCell tdLastestRes = new HtmlTableCell();
        tdLastestRes.InnerHtml = "Last Search result";
        trLastestRes.Cells.Add(tdLastestRes);
        Tbl_Search.Rows.Add(trLastestRes);

        HtmlTableRow trCount = new HtmlTableRow();
        HtmlTableCell tdCount = new HtmlTableCell();
        trCount.Cells.Add(tdCount);
        trCount.Attributes.Add("class", "lightcoloredText");
        Tbl_Search.Rows.Add(trCount);

        switch (EntityName.ToLower())
        {
            case "faculty" :

                tdCount.InnerText = fuzzyEntityCollection.FacultyCollection.Count + " faculty member(s) found";
                foreach (Faculty currentFaculty in fuzzyEntityCollection.FacultyCollection)
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    HtmlTableCell td = new HtmlTableCell();
                    td.InnerHtml = "<a href='Profiles.aspx?Id=" + currentFaculty.ID + "&EntityType=faculty" + "'  class='greenText'>" + currentFaculty.FirstName + "," + currentFaculty.LastName + ", " + currentFaculty.Department.DepartmentName + ", Score : " + currentFaculty.Score + "</a>";
                    tr.Cells.Add(td);
                    Tbl_Search.Rows.Add(tr);

                }
                break; 
            case "students":
                tdCount.InnerText = fuzzyEntityCollection.Students.Count + " students found"; 
                foreach (Student currentStudent in fuzzyEntityCollection.Students)
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    HtmlTableCell td = new HtmlTableCell();
                    td.InnerHtml = "<a href='Profiles.aspx?Id=" + currentStudent.ID + "&EntityType=Student" + " ' class='greenText'>" + currentStudent.FirstName + "," + currentStudent.LastName + "," + currentStudent.Department.DepartmentName + ", Score :" + currentStudent.Score + "</a>";
                    tr.Cells.Add(td);
                    Tbl_Search.Rows.Add(tr);
                }
                break;
            case "staff":
                tdCount.InnerText = fuzzyEntityCollection.StaffCollection.Count + " staff member(s) found";
                foreach (Staff currentStaff in fuzzyEntityCollection.StaffCollection)
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    HtmlTableCell td = new HtmlTableCell();
                    td.InnerHtml = "<a href='Profiles.aspx?Id=" + currentStaff.ID + "&EntityType=Staff" + " ' class='greenText'>" + currentStaff.FirstName + "," + currentStaff.LastName + "," + currentStaff.StaffType + ", Score :" + currentStaff.Score + "</a>";
                    tr.Cells.Add(td);
                    Tbl_Search.Rows.Add(tr);
                }
                break;
            case "contractors":
                tdCount.InnerText = fuzzyEntityCollection.ContractorCollection.Count + " staff member(s) found";
                foreach (Contractor currentContractor in fuzzyEntityCollection.ContractorCollection)
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    HtmlTableCell td = new HtmlTableCell();
                    td.InnerHtml = "<a href='Profiles.aspx?Id=" + currentContractor.ID + "&EntityType=Contractor" + " ' class='greenText'>" + currentContractor.FirstName + "," + currentContractor.LastName + "," + currentContractor.ContractorType + ", Score :" + currentContractor.Score + "</a>";
                    tr.Cells.Add(td);
                    Tbl_Search.Rows.Add(tr);
                }
                break;
        }



    }
    //Method to build All our Entity Objects and save in collection. 
    private void BuildFuzzyEntities(DataTable searchResultTable)
    {
        foreach (DataRow dr in searchResultTable.Rows)
        {
            string EntityType = dr["EntityType"].ToString();
            switch (EntityType.ToLower())
            {
                case "students":
                    Student student = new Student();
                    student.ID = Convert.ToInt32(dr["ID"]);
                    student.FirstName = dr["FirstName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                    student.Score = Convert.ToInt32(dr["Score"]); 
                    student.Department.DepartmentName = dr["DepartmentName"].ToString();
                    student.ImageUrl = dr["ImageUrl"].ToString();
                    fuzzyEntityCollection.Students.Add(student);
                    break;
                case "faculty":
                    Faculty faculty = new Faculty();
                    faculty.ID = Convert.ToInt32(dr["ID"]);
                    faculty.FirstName = dr["FirstName"].ToString();
                    faculty.LastName = dr["LastName"].ToString();
                    faculty.Score = Convert.ToInt32(dr["Score"]);
                    faculty.Department.DepartmentName = dr["DepartmentName"].ToString();
                    faculty.Qualification = dr["Qualification"].ToString();
                    faculty.Position = dr["Position"].ToString();
                    faculty.Experience = Convert.ToInt32(dr["ExperienceYears"]);
                    faculty.Accomplishments = dr["Accomplishments"].ToString();
                    faculty.ImageUrl = dr["ImageUrl"].ToString();
                    fuzzyEntityCollection.FacultyCollection.Add(faculty);
                    break;
                case "staff" :
                    Staff staff = new Staff();
                    staff.ID = Convert.ToInt32(dr["ID"]);
                    staff.FirstName = dr["FirstName"].ToString();
                    staff.LastName = dr["LastName"].ToString();
                    staff.StaffType = dr["StaffType"].ToString();
                    staff.Score = Convert.ToInt32(dr["Score"]);
                    staff.ImageUrl = dr["ImageUrl"].ToString();
                    fuzzyEntityCollection.StaffCollection.Add(staff);
                    break;
                case "contractor":
                    Contractor contractor = new Contractor();
                    contractor.ID = Convert.ToInt32(dr["ID"]);
                    contractor.FirstName = dr["FirstName"].ToString();
                    contractor.LastName = dr["LastName"].ToString();
                    contractor.ContractorType = dr["ContractorType"].ToString();
                    contractor.Score = Convert.ToInt32(dr["Score"]);
                    contractor.ImageUrl = dr["ImageUrl"].ToString();
                    fuzzyEntityCollection.ContractorCollection.Add(contractor);
                    break;
            }

        }
        //if (Session["FuzzyEntityCollection"] == null)
            Session["FuzzyEntityCollection"] = fuzzyEntityCollection; 

    }

    private void ShowSearchResults(DataTable searchResultTable)
    {
        HtmlTableRow trCount = new HtmlTableRow();
        HtmlTableCell tdCount = new HtmlTableCell();
        trCount.Cells.Add(tdCount);
        trCount.Attributes.Add("class", "lightcoloredText"); 
        Tbl_Search.Rows.Add(trCount); 

        tdCount.InnerText = searchResultTable.Rows.Count + " results found"; 

        foreach (DataRow dr in searchResultTable.Rows)
        {
            HtmlTableRow tr = new HtmlTableRow(); 
            HtmlTableCell td = new HtmlTableCell();
            td.InnerHtml = "<a href='Profiles.aspx?Id="+ dr["ID"].ToString() +"&EntityType="+ dr["EntityType"].ToString() +"'  class='greenText'>" +dr["ID"].ToString() + "," + dr["FirstName"].ToString() + ", " + dr["LastName"].ToString() + ", " + dr["DepartmentName"].ToString() + "," + dr["EntityType"].ToString() + "</a>";
            tr.Cells.Add(td); 
            Tbl_Search.Rows.Add(tr); 
        }
    }

    //If Entity type is changed display only related search items 
    protected void DropDown_entity_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    //faculty Search
    protected void Btn_Faculty_Click(object sender, EventArgs e)
    {
        if(fuzzyEntityCollection == null)
        fuzzyEntityCollection = new FuzzyEntityCollection();

        DatabaseHelper db = new DatabaseHelper();
        string query = @"
                    SELECT *, 'faculty'[EntityType]
                    FROM            Faculty AS f INNER JOIN
                                             Departments AS d ON f.DepartmentId = d.ID
                    WHERE        (f.FirstName LIKE  '%" + TxtBx_F_Name.Text + "%' OR f.LastName LIKE '%" + TxtBx_F_Name.Text + "%')"; 

        if(!string.IsNullOrEmpty(TxtBx_F_Dept.Text) || !string.IsNullOrEmpty(TxtBx_F_Q.Text) || !string.IsNullOrEmpty(TxtBx_F_P.Text) || !string.IsNullOrEmpty(TxtBx_F_Exp.Text))
        {
            query += " AND ( 1=1 ";
            
            if(!string.IsNullOrEmpty(TxtBx_F_Dept.Text))
                query += "AND d.DepartmentName LIKE '%" + TxtBx_F_Dept.Text + "%' "; 

            if(!string.IsNullOrEmpty(TxtBx_F_Q.Text))
                query += " AND  f.Qualification LIKE  '%" + TxtBx_F_Q.Text + "%'";

            if (!string.IsNullOrEmpty(TxtBx_F_P.Text))
                query += " AND  f.Position LIKE  '%" + TxtBx_F_P.Text + "%'";

            if (!string.IsNullOrEmpty(TxtBx_F_Exp.Text))
                query += "AND  f.ExperienceYears LIKE  '%" + TxtBx_F_Exp.Text + "%')"; 

            query += " AND 2=2)"; 
        }

        query += " Order by f.Score Desc"; 

        DataTable searchResultTable = db.GetData(query);
        BuildFuzzyEntities(searchResultTable);
        ShowEntitySearchresults(fuzzyEntityCollection, "Faculty"); 

    }
    //Student Search
    protected void Btn_StudentSearch_Click(object sender, EventArgs e)
    {
        if (fuzzyEntityCollection == null)
            fuzzyEntityCollection = new FuzzyEntityCollection();

        DatabaseHelper db = new DatabaseHelper();
        string query = @"
                    SELECT *, 'students'[EntityType]
                    FROM            Students AS s INNER JOIN
                                             Departments AS d ON s.DepartmentId = d.ID
                    WHERE        (s.FirstName LIKE  '%" + TxtBx_S_N.Text + "%' OR s.LastName LIKE '%" + TxtBx_S_N.Text + "%')";

        if (!string.IsNullOrEmpty(TxtBx_S_D.Text))
        {
            query += " AND (d.DepartmentName LIKE '%" + TxtBx_S_D.Text + "%' )";
        }

        query += " Order by s.Score Desc"; 

        DataTable searchResultTable = db.GetData(query);
        BuildFuzzyEntities(searchResultTable);
        ShowEntitySearchresults(fuzzyEntityCollection, "Students"); 

    }

    //Staff Search
    protected void Btn_Staff_Click(object sender, EventArgs e)
    {
        if (fuzzyEntityCollection == null)
            fuzzyEntityCollection = new FuzzyEntityCollection();

        DatabaseHelper db = new DatabaseHelper();
        string query = @"
                    SELECT *, 'staff'[EntityType]
                    FROM            Staff AS s 
                    WHERE        (s.FirstName LIKE  '%" + TxtBx_st_N.Text + "%' OR s.LastName LIKE '%" + TxtBx_st_N.Text + "%')";

        if (selectStaffType.SelectedIndex !=0)
        {
            query += " AND (s.StaffType LIKE '%" + selectStaffType.Value + "%' )";
        }

        query += " Order by s.Score Desc"; 

        DataTable searchResultTable = db.GetData(query);
        BuildFuzzyEntities(searchResultTable);
        ShowEntitySearchresults(fuzzyEntityCollection, "Staff"); 


    }    
    
    //Contractors Search
    protected void Btn_Contractors_Click(object sender, EventArgs e)
    {
        if (fuzzyEntityCollection == null)
            fuzzyEntityCollection = new FuzzyEntityCollection();

        DatabaseHelper db = new DatabaseHelper();
        string query = @"
                    SELECT *, 'contractor'[EntityType]
                    FROM            Contractors AS c 
                    WHERE        (c.FirstName LIKE  '%" + TxtBx_C_N.Text + "%' OR c.LastName LIKE '%" + TxtBx_C_N.Text + "%')";

        if (selectContractorType.SelectedIndex != 0)
        {
            query += " AND (c.ContractorType LIKE '%" + selectContractorType.Value + "%' )";
        }

        query += " Order by c.Score Desc"; 

        DataTable searchResultTable = db.GetData(query);
        BuildFuzzyEntities(searchResultTable);
        ShowEntitySearchresults(fuzzyEntityCollection, "contractors"); 

    }

}
