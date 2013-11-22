using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FuzzyEntityCollection
/// </summary>
public class FuzzyEntityCollection
{
	public FuzzyEntityCollection()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public List<Student> Students = new List<Student>();
    public List<Faculty> FacultyCollection = new List<Faculty>();
    public List<Staff> StaffCollection = new List<Staff>();
    public List<Contractor> ContractorCollection = new List<Contractor>(); 
}