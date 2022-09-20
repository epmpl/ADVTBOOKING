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
public class datesave
{
    public datesave()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string getDate(string dateformat, string dateValue)
    {
        //splitting of date
        string dateReturn = "";
        if(dateValue.IndexOf('-')>0)
            dateValue=getMonthFormat(dateformat, dateValue);
        
        char[] splitterfrom = { '/' };
        string[] myarrayfrom = dateValue.Split(splitterfrom);
        string dd, mm, yyyy;
        if (dateValue != "")
        {
            if (dateformat == "dd/mm/yyyy")
            {
                //for from date
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                yyyy = myarrayfrom[2];

                dateReturn = dd + "/" + mm + "/" + yyyy;


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

                dateReturn = mm + "/" + dd + "/" + yyyy;

            }
        }
        if (dateformat == "" || dateformat == null)
        {
            dateReturn = dateValue;
        }
        return dateReturn;
    }

    //*25Aug* 
    public string getMonthFormat(string dateformat,string ddate)
    {       
        string mmon="";
        string dday = "";
        string yyear = "";
        if (ddate.IndexOf('-') > 0)
        {
            switch (ddate.Split('-')[1].ToUpper())
            {
                case "JAN":
                    mmon="01";
                    break;
                case "FEB":
                    mmon="02";
                    break;
                case "MAR":
                    mmon="03";
                    break;
                case "APR":
                    mmon = "04";
                    break;
                case "MAY":
                    mmon = "05";
                    break;
                case "JUN":
                    mmon = "06";
                    break;
                case "JUL":
                    mmon = "07";
                    break;
                case "AUG":
                    mmon = "08";
                    break;
                case "SEP":
                    mmon = "09";
                    break;
                case "OCT":
                    mmon = "10";
                    break;
                case "NOV":
                    mmon = "11";
                    break;
                case "DEC":
                    mmon = "12";
                    break;
            }
            dday=ddate.Split('-')[0];
            yyear = ddate.Split('-')[2];
            if (dateformat == "dd/mm/yyyy")
                ddate=dday+"/"+mmon+"/"+yyear;
            else if (dateformat == "mm/dd/yyyy")
                 ddate=mmon+"/"+dday+"/"+yyear;
            else
                ddate=yyear+"/"+mmon+"/"+dday;
        }
        return ddate;
    }
    //****************************
}
