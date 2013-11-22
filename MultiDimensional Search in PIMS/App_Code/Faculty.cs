using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Faculty
/// </summary>
public class Faculty : FuzzyEntity
{
	public Faculty()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string Qualification { get; set; }
    public string Position { get; set; }
    public int Experience { get; set; }
    public string Accomplishments { get; set; }

}

public class Staff : FuzzyEntity
{
    public Staff()
    {

    }
    public string StaffType { get; set; }

}

public class Contractor : FuzzyEntity
{
    public Contractor()
    {

    }
    public string ContractorType { get; set; }
}