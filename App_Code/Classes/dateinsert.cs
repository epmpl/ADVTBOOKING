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
    /// Summary description for dateinsert
    /// </summary>
    public class dateinsert 
    {
        public dateinsert()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public string getMonth(int month)
        {
            string monthname = "";
            if (month == 1)
            {
                monthname = "Jan";
            }
            else if (month == 2)
            {
                monthname = "Feb";
            }
            else if (month == 3)
            {
                monthname = "Mar";
            }
            else if (month == 4)
            {
                monthname = "Apr";
            }
            else if (month == 5)
            {
                monthname = "May";
            }
            else if (month == 6)
            {
                monthname = "Jun";
            }
            else if (month == 7)
            {
                monthname = "Jul";
            }
            else if (month == 8)
            {
                monthname = "Aug";
            }
            else if (month == 9)
            {
                monthname = "Sep";
            }
            else if (month == 10)
            {
                monthname = "Oct";
            }
            else if (month == 11)
            {
                monthname = "Nov";
            }
            else if (month == 12)
            {
                monthname = "Dec";
            }
            return monthname;
        }
        public string getDate(string dateformat, string dateValue)
        {
            //splitting of date

            string dateReturn = "";
            string monthname = "";
            char[] splitterfrom = { '/' };
            string[] myarrayfrom = dateValue.Split(splitterfrom);
            string dd, mm, yyyy;
            if (dateValue == "" || dateValue == "0")
            {
                return dateReturn;
            }
            if (dateformat == "dd/mm/yyyy")
            {
                //for from date comment by rinki 
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                monthname = getMonth(Convert.ToInt32(mm));
                yyyy = myarrayfrom[2];
                dateReturn = dd + "-" + monthname + "-" + yyyy;

                //dd = myarrayfrom[1];
                //mm = myarrayfrom[0];
                //monthname = getMonth(Convert.ToInt32(mm));
                //yyyy = myarrayfrom[2];

                //dateReturn = dd + "/" + mm + "/" + yyyy;



            }

            if (dateformat == "yyyy/mm/dd")
            {
                //for from date
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                monthname = getMonth(Convert.ToInt32(mm));
                yyyy = myarrayfrom[2];

                dateReturn = yyyy + "-" + monthname + "-" + dd;

            }

            if (dateformat == "mm/dd/yyyy")
            {
                // dateReturn = dateValue;
                //for from date
                dd = myarrayfrom[1];
                mm = myarrayfrom[0];
                monthname = getMonth(Convert.ToInt32(mm));
                yyyy = myarrayfrom[2];

                //dateReturn = dd + "-" + monthname + "-" + yyyy;
                dateReturn = monthname + "-" + dd + "-" + yyyy;

            }
            if (dateformat == "" || dateformat == null)
            {
                dateReturn = dateValue;
            }
            return dateReturn;
        }
        public string getDateScheme(string dateformat, string dateValue)
        {
            //splitting of date

            string dateReturn = "";
            string monthname = "";
            char[] splitterfrom = { '/' };
            string[] myarrayfrom = dateValue.Split(splitterfrom);
            string dd, mm, yyyy;
            if (dateValue == "" || dateValue == "0")
            {
                return dateReturn;
            }
            if (dateformat == "dd/mm/yyyy")
            {
                //for from date comment by rinki 
                //dd = myarrayfrom[0];
                //mm = myarrayfrom[1];
                //monthname = getMonth(Convert.ToInt32(mm));
                //yyyy = myarrayfrom[2];
                //dateReturn = dd + "-" + monthname + "-" + yyyy;

                dd = myarrayfrom[1];
                mm = myarrayfrom[0];
                monthname = getMonth(Convert.ToInt32(mm));
                yyyy = myarrayfrom[2];

                dateReturn = dd + "/" + mm + "/" + yyyy;



            }

            if (dateformat == "yyyy/mm/dd")
            {
                //for from date
                dd = myarrayfrom[1];
                mm = myarrayfrom[0];
                monthname = getMonth(Convert.ToInt32(mm));
                yyyy = myarrayfrom[2];


                dateReturn = yyyy + "/" + mm + "/" + dd;

            }

            if (dateformat == "mm/dd/yyyy")
            {
                // dateReturn = dateValue;
                //for from date
                dd = myarrayfrom[1];
                mm = myarrayfrom[0];
                monthname = getMonth(Convert.ToInt32(mm));
                yyyy = myarrayfrom[2];


                dateReturn = dd + "/" + mm + "/" + yyyy;

            }
            if (dateformat == "" || dateformat == null)
            {
                dateReturn = dateValue;
            }
            return dateReturn;
        }
        public string getDatedisp(string dateformat, string dateValue)
        {
            //splitting of date

            string dateReturn = "";
            string monthname = "";
            char[] splitterfrom = { '/' };
            string[] myarrayfrom = dateValue.Split(splitterfrom);
            string dd, mm, yyyy;
            if (dateValue == "" || dateValue == "0")
            {
                return dateReturn;
            }
            if (dateformat == "dd/mm/yyyy")
            {
                //for from date
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                //monthname = getMonth(Convert.ToInt32(mm));
                yyyy = myarrayfrom[2];

                dateReturn = dd + "/" + mm + "/" + yyyy;


            }

            if (dateformat == "yyyy/mm/dd")
            {
                //for from date
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                //monthname = getMonth(Convert.ToInt32(mm));
                yyyy = myarrayfrom[2];

                dateReturn = dd + "/" + mm + "/" + yyyy;

            }

            if (dateformat == "mm/dd/yyyy")
            {
                // dateReturn = dateValue;
                //for from date
                dd = myarrayfrom[0];
                mm = myarrayfrom[1];
                //monthname = getMonth(Convert.ToInt32(mm));
                yyyy = myarrayfrom[2];

                dateReturn = dd + "/" + mm + "/" + yyyy;

            }
            if (dateformat == "" || dateformat == null)
            {
                dateReturn = dateValue;
            }
            return dateReturn;
        }
      
    }
