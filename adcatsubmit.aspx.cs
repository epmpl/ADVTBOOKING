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

public partial class adcatsubmit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        string compcode, userid, adcatcode, catname, catalias, advtype, f, filename, status, productivity, hrs, min, discount, amount, ffdisc, ffdiscamt, cashdisc, cashamt,ldgendays, ldgenflag,eddiscflag;
        compcode = Session["compcode"].ToString();

        adcatcode = Request.QueryString["adcatcode"].ToString();
        catname = Request.QueryString["catname"].ToString();
        catalias = Request.QueryString["catalias"].ToString();
        advtype = Request.QueryString["advtype"].ToString();
        filename = Request.QueryString["filename"].ToString();
        string regclient = Request.QueryString["regclient"].ToString();
        f = Request.QueryString["f"].ToString();
        productivity = Request.QueryString["productivity"].ToString();
        hrs = Request.QueryString["hrs"].ToString();
        min = Request.QueryString["min"].ToString();

        status = Request.QueryString["status"].ToString();
        discount = Request.QueryString["discount"].ToString();
        amount = Request.QueryString["amount"].ToString();
        ffdisc = Request.QueryString["ffdiscount"].ToString();
        ffdiscamt = Request.QueryString["ffdamount"].ToString();
        cashdisc = Request.QueryString["casdisc"].ToString();
        cashamt = Request.QueryString["cshdiscamount"].ToString();
        ldgendays = Request.QueryString["ldgendays"].ToString();
        ldgenflag = Request.QueryString["ldgenflag"].ToString();
        eddiscflag = Request.QueryString["eddiscflag"].ToString();
        if (Session["compcode"] != null)
        {
            compcode = Session["compcode"].ToString();
            userid = Session["userid"].ToString();
        }
        else
        {
            //Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }

        if (f == "1")
        {
            DataSet ds = new DataSet();
            string err = "";
            try
            {
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.AdCategoryMaster insert = new NewAdbooking.Classes.AdCategoryMaster();

                    ds = insert.advcatinsert1(compcode, userid, adcatcode, catalias, catname, advtype, regclient, filename, status, productivity, hrs, min, "", discount, amount, ffdisc, ffdiscamt, cashdisc, cashamt, ldgendays, ldgenflag,eddiscflag);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.AdCategoryMaster insert = new NewAdbooking.classesoracle.AdCategoryMaster();

                    ds = insert.advcatinsert1(compcode, userid, adcatcode, catalias, catname, advtype, regclient, filename, status, productivity, hrs, min, "", discount, amount, ffdisc, ffdiscamt, cashdisc, cashamt, ldgendays, ldgenflag, eddiscflag);
                }
                else
                {
                   // NewAdbooking.classmysql.AdCategoryMaster insert = new NewAdbooking.classmysql.AdCategoryMaster();

                   // ds = insert.advcatinsert1(compcode, userid, adcatcode, catalias, catname, advtype, regclient);

                    string procedureName = "advinsert";
                    string[] parameterValueArray = { compcode, userid, adcatcode, catalias, catname, advtype, regclient, filename, status, productivity, hrs, min, null, null };
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
     
                }
                if (Session["editionsave"] == "" || Session["editionsave"] == null)
                {
                }
                else
                {
                    DataSet db = (DataSet)Session["editionsave"];
                    int er = db.Tables[0].Rows.Count;
                    int gf = db.Tables.Count;
                    for (int b = 0; b <= gf - 1; b++)
                    {
                        // string edition = db.Tables[b].Rows[0].ItemArray[0].ToString();
                        string edition = db.Tables[b].Rows[0].ItemArray[1].ToString();
                        string chk1 = db.Tables[b].Rows[0].ItemArray[2].ToString();
                        string chk2 = db.Tables[b].Rows[0].ItemArray[3].ToString();
                        string chk3 = db.Tables[b].Rows[0].ItemArray[4].ToString();
                        string chk4 = db.Tables[b].Rows[0].ItemArray[5].ToString();
                        string chk5 = db.Tables[b].Rows[0].ItemArray[6].ToString();
                        string chk6 = db.Tables[b].Rows[0].ItemArray[7].ToString();
                        string chk7 = db.Tables[b].Rows[0].ItemArray[8].ToString();
                        string chk8 = db.Tables[b].Rows[0].ItemArray[9].ToString();

                        DataSet ds1 = new DataSet();
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                        {
                            NewAdbooking.Classes.AdCategoryMaster edsubmit = new NewAdbooking.Classes.AdCategoryMaster();
                            //ds1 = edsubmit.selectaddaysave(compcode, adcatcode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
                            ds1 = edsubmit.editionsubmit(compcode, userid, adcatcode, edition, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8);
                        }
                        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                            NewAdbooking.classesoracle.AdCategoryMaster edsubmit = new NewAdbooking.classesoracle.AdCategoryMaster();

                            //ds1 = edsubmit.selectaddaysave(compcode, adcatcode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
                            ds1 = edsubmit.editionsubmit(compcode, userid, adcatcode, edition, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8);
                        }
                        else
                        {
                            NewAdbooking.classmysql.AdCategoryMaster edsubmit = new NewAdbooking.classmysql.AdCategoryMaster();
                            //ds1 = edsubmit.selectaddaysave(compcode, adcatcode, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8, userid);
                            ds1 = edsubmit.editionsubmit(compcode, userid, adcatcode, edition, chk1, chk2, chk3, chk4, chk5, chk6, chk7, chk8);
                        }
                    }

                }
            }
          
           catch (Exception k)
        {
            err = k.Message;
        }
        string adcatcode1 = "Inserted Ad Category " + adcatcode;
        clsconnection dconnect = new clsconnection();
        string sqldd = "insert into log_new (DATE1,USERID,PROCESSNAME,ERR_DESCRIPTION,OBJECT_PROCESS_ID,DESCRIPTION,IP) values($date,'" + Session["userid"].ToString() + "','Ad Category ','" + err.Replace("'", "''") + "','Ad Category Created','" + adcatcode1;
        sqldd = sqldd + "','" + Request.ServerVariables["REMOTE_ADDR"] + "')";
        dconnect.executenonquery1(sqldd);
        }

        else if (f == "0")
        {
            Session["editionsave"] = null;
        }


    }
}
