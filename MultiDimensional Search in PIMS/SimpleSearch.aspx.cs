using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class SimpleSearch : System.Web.UI.Page
{
    FuzzyEntityCollection fuzzyEntityCollection = null; 

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Search Database and return results
    protected void Btn_Search_Click(object sender, EventArgs e)
    {
        fuzzyEntityCollection = new FuzzyEntityCollection();

        DatabaseHelper db = new DatabaseHelper();
        DataTable searchResultTable = db.GetData(@"SELECT        s.ID, s.FirstName, s.LastName,s.Score,s.ImageUrl, d.DepartmentName, 'students' AS EntityType
                    FROM            Students AS s INNER JOIN
                                             Departments AS d ON s.DepartmentID = d.ID
                    WHERE        s.FirstName LIKE '%" + TxtBx_Search.Text + "%'"
                    
                                                      + @"UNION ALL
                    SELECT        f.ID, f.FirstName, f.LastName,f.score,f.ImageUrl, d.DepartmentName, 'faculty' AS EntityType
                    FROM            Faculty AS f INNER JOIN
                                             Departments AS d ON f.DepartmentId = d.ID
                    WHERE        f.FirstName LIKE  '%" + TxtBx_Search.Text + "%' "
                    
                    + @"UNION ALL
                    SELECT        s.ID, s.FirstName, s.LastName,s.score,s.ImageUrl, s.StaffType, 'staff' AS EntityType
                    FROM            Staff AS s 
                    WHERE        s.FirstName LIKE  '%" + TxtBx_Search.Text + "%' "

                    + @"UNION ALL
                    SELECT        c.ID, c.FirstName, c.LastName,c.score,c.ImageUrl, c.ContractorType, 'contractor' AS EntityType
                    FROM            Contractors AS c 
                    WHERE        c.FirstName LIKE  '%" + TxtBx_Search.Text + "%' ORDER BY score DESC");



        BuildFuzzyEntities(searchResultTable);

        ShowSearchresults(fuzzyEntityCollection);
        //ShowSearchResults(searchResultTable); 
    }
    private void ShowSearchresults(FuzzyEntityCollection fuzzyEntityCollection)
    {
        HtmlTableRow trCount = new HtmlTableRow();
        HtmlTableCell tdCount = new HtmlTableCell();
        trCount.Cells.Add(tdCount);
        trCount.Attributes.Add("class", "lightcoloredText");
        Tbl_Search.Rows.Add(trCount);

        tdCount.InnerText = fuzzyEntityCollection.Students.Count + " students found, " + fuzzyEntityCollection.FacultyCollection.Count + " faculty found, " + fuzzyEntityCollection.StaffCollection.Count + " Staff , " + fuzzyEntityCollection.ContractorCollection.Count + " Contractors found";

        HtmlTableRow fR = new HtmlTableRow();
        HtmlTableCell fC = new HtmlTableCell();
        fR.Cells.Add(fC);
        fC.Attributes.Add("class", "lightcoloredText");
        Tbl_Search.Rows.Add(fR);
        fC.InnerHtml = "<b>Faculty</b>"; 


        foreach (Faculty currentFaculty in fuzzyEntityCollection.FacultyCollection)
        {
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell td = new HtmlTableCell();
            td.InnerHtml = "<a href='Profiles.aspx?Id=" + currentFaculty.ID + "&EntityType=faculty" + "'  class='greenText'>" + currentFaculty.FirstName + "," + currentFaculty.LastName + ", " + currentFaculty.Department.DepartmentName + ", " + currentFaculty.ID + "</a>";
            tr.Cells.Add(td);
            Tbl_Search.Rows.Add(tr);

        }

        HtmlTableRow sR = new HtmlTableRow();
        HtmlTableCell sC = new HtmlTableCell();
        sR.Cells.Add(sC);
        sC.Attributes.Add("class", "lightcoloredText");
        Tbl_Search.Rows.Add(sR);
        sC.InnerHtml = "<b>Students</b>"; 

        foreach (Student currentStudent in fuzzyEntityCollection.Students)
        {
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell td = new HtmlTableCell();
            td.InnerHtml = "<a href='Profiles.aspx?Id=" + currentStudent.ID + "&EntityType=Student" + " ' class='greenText'>" + currentStudent.FirstName + "," + currentStudent.LastName + "," + currentStudent.Department.DepartmentName + "," + currentStudent.ID + "</a>";
            tr.Cells.Add(td);
            Tbl_Search.Rows.Add(tr);
        }

        HtmlTableRow stR = new HtmlTableRow();
        HtmlTableCell stC = new HtmlTableCell();
        stR.Cells.Add(stC);
        stC.Attributes.Add("class", "lightcoloredText");
        Tbl_Search.Rows.Add(stR);
        stC.InnerHtml = "<b>Staff</b>";

        foreach (Staff staff in fuzzyEntityCollection.StaffCollection)
        {
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell td = new HtmlTableCell();
            td.InnerHtml = "<a href='Profiles.aspx?Id=" + staff.ID + "&EntityType=Student" + " ' class='greenText'>" + staff.FirstName + "," + staff.LastName + "," + staff.StaffType + "," + staff.Score + "</a>";
            tr.Cells.Add(td);
            Tbl_Search.Rows.Add(tr);
        }

        HtmlTableRow cR = new HtmlTableRow();
        HtmlTableCell cC = new HtmlTableCell();
        cR.Cells.Add(cC);
        cC.Attributes.Add("class", "lightcoloredText");
        Tbl_Search.Rows.Add(cR);
        cC.InnerHtml = "<b>Contractors</b>";

        foreach (Contractor contractor in fuzzyEntityCollection.ContractorCollection)
        {
            HtmlTableRow tr = new HtmlTableRow();
            HtmlTableCell td = new HtmlTableCell();
            td.InnerHtml = "<a href='Profiles.aspx?Id=" + contractor.ID + "&EntityType=Student" + " ' class='greenText'>" + contractor.FirstName + "," + contractor.LastName + "," + contractor.ContractorType + "," + contractor.Score + "</a>";
            tr.Cells.Add(td);
            Tbl_Search.Rows.Add(tr);
        }

    }

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
                    //faculty.Qualification = dr["Qualification"].ToString();
                    //faculty.Position = dr["Position"].ToString();
                    //faculty.Experience = Convert.ToInt32(dr["ExperienceYears"]);
                    //faculty.Accomplishments = dr["Accomplishments"].ToString();
                    faculty.ImageUrl = dr["ImageUrl"].ToString();
                    fuzzyEntityCollection.FacultyCollection.Add(faculty);
                    break;
                case "staff":
                    Staff staff = new Staff();
                    staff.ID = Convert.ToInt32(dr["ID"]);
                    staff.FirstName = dr["FirstName"].ToString();
                    staff.LastName = dr["LastName"].ToString();
                    //staff.StaffType = dr["StaffType"].ToString();
                    staff.Score = Convert.ToInt32(dr["Score"]);
                    staff.ImageUrl = dr["ImageUrl"].ToString();
                    fuzzyEntityCollection.StaffCollection.Add(staff);
                    break;
                case "contractor":
                    Contractor contractor = new Contractor();
                    contractor.ID = Convert.ToInt32(dr["ID"]);
                    contractor.FirstName = dr["FirstName"].ToString();
                    contractor.LastName = dr["LastName"].ToString();
                    //contractor.ContractorType = dr["ContractorType"].ToString();
                    contractor.Score = Convert.ToInt32(dr["Score"]);
                    contractor.ImageUrl = dr["ImageUrl"].ToString();
                    fuzzyEntityCollection.ContractorCollection.Add(contractor);
                    break;
            }

        }
        //if (Session["FuzzyEntityCollection"] == null)
        Session["FuzzyEntityCollection"] = fuzzyEntityCollection;

    }


}