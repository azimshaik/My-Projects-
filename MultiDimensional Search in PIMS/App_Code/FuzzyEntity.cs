using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FuzzyEntity
/// </summary>
public class FuzzyEntity
{
	public FuzzyEntity()
	{
        Department = new Department(); 
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Department Department { get; set; }
    public int Score { get; set; }
    public string ImageUrl { get; set; }
}
