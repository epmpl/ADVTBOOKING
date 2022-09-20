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
/// Summary description for datesavemysql
/// </summary>
public class datesavemysql
{
	public datesavemysql()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string getDate(string dateformat, string dateValue)
    {
        //splitting of date
        string dateReturn = "";
        char[] splitterfrom = { '/' };
        string[] myarrayfrom = dateValue.Split(splitterfrom);
        string dd, mm, yyyy;
        if (dateformat == "dd/mm/yyyy")
        {
            //for from date
            dd = myarrayfrom[0];
            mm = myarrayfrom[1];
            yyyy = myarrayfrom[2];

            dateReturn = yyyy + "/" + mm + "/" + dd;


        }

        if (dateformat == "yyyy/mm/dd")
        {
            dateReturn = dateValue;

        }

        if (dateformat == "mm/dd/yyyy")
        {



            //for from date
            mm = myarrayfrom[0];
            dd = myarrayfrom[1];
            yyyy = myarrayfrom[2];

            dateReturn = yyyy + "/" + mm + "/" + dd;

        }
        if (dateformat == "" || dateformat == null)
        {
            dateReturn = dateValue;
        }
        return dateReturn;
    }
}
