using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for date
/// </summary>
public class date
{
	public date()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string getDate(string dateformat,string dateValue)
    {
        //splitting of date
        string dateReturn="";
        char[] splitterfrom = { '/' };
        string[] myarrayfrom = dateValue.Split(splitterfrom);
        string dd, mm, yyyy;
        if (dateformat == "dd/mm/yyyy")
        {
            //for from date
            mm = myarrayfrom[0];
            dd = myarrayfrom[1];
            yyyy = myarrayfrom[2];

            dateReturn= dd + "/" + mm + "/" + yyyy;

           
        }

        if (dateformat == "yyyy/mm/dd")
        {
            //for from date
            mm = myarrayfrom[0];
            dd = myarrayfrom[1];
            yyyy = myarrayfrom[2];

            dateReturn = yyyy + "/" + mm + "/" + dd;

                    }

        if (dateformat == "mm/dd/yyyy")
        {
            dateReturn = dateValue;

        }
        if (dateformat == "" || dateformat == null)
        {
            dateReturn = dateValue;
        }
        return dateReturn;
    }
}
