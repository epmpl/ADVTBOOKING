using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class fontleading : System.Web.UI.Page
{
    int j = 0;

    string hiddentext="";
    protected void Page_Load(object sender, EventArgs e)
    {

        hiddenedition.Value = Request.QueryString["editioncode"].ToString();
        hiddentext = Request.QueryString["hiddentext"].ToString();
        Ajax.Utility.RegisterTypeForAjax(typeof(fontleading));
        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();





        if (!IsPostBack)
        {
            btnsubmit.Attributes.Add("onclick", "javascript:return saveclick();");

            // btnsubmit.Attributes.Add("onclick", "javascript:return bindgrid();");
        }



        if (hiddentext == "execute")
        {

            btnsubmit.Enabled = false;
        }




        Response.Expires = -1;

        if (Session["compcode"] == null)
        {
            Response.Redirect("login.aspx");
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        hiddencompcode.Value = Session["compcode"].ToString();
        hiddenuserid.Value = Session["userid"].ToString();
        hiddendateformat.Value = Session["dateformat"].ToString();



        if (hiddentext == "new" || hiddentext == "execute")
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.changeexecutive save = new NewAdbooking.classesoracle.changeexecutive();

                ds = save.bindfontleading(Session["compcode"].ToString(), hiddenedition.Value);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.changeexecutive save = new NewAdbooking.Classes.changeexecutive();

                    ds = save.bindfontleading(Session["compcode"].ToString(), hiddenedition.Value);
                }
                else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
                {
                    string procedureName = "bind_fontgrid";
                    string[] parameterValueArray = { Session["compcode"].ToString(), hiddenedition.Value };
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

                }

            DataGrid1.DataSource = ds;
            DataGrid1.DataBind();
        }
        else
        {
            btnsubmit.Enabled = false;
            DataGrid2.Visible = true;
            DataSet ds = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.changeexecutive save = new NewAdbooking.classesoracle.changeexecutive();

                ds = save.bindfontleading(Session["compcode"].ToString(), hiddenedition.Value);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.changeexecutive save = new NewAdbooking.Classes.changeexecutive();

                    ds = save.bindfontleading(Session["compcode"].ToString(), hiddenedition.Value);
                }
                else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
                {
                    string procedureName = "bind_fontgrid";
                    string[] parameterValueArray = { Session["compcode"].ToString(), hiddenedition.Value };
                    NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                    ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

                }
           
            string len = ds.Tables[0].Rows.Count.ToString();

            int kk = 0;
            int jj = 0;
            string flag = "";
            for (int i = 1; i < Convert.ToInt32(len); i++)
            {
                if (ds.Tables[0].Rows[i].ItemArray[2].ToString() == "" && ds.Tables[0].Rows[i].ItemArray[3].ToString() == "")
                {

                    kk++;


                    if (kk == 3)
                    {
                        flag = "A";

                    }

                }

                
            }
            if (flag == "A")
            {
                btnsubmit.Enabled = true;
                DataGrid1.DataSource = ds;
                DataGrid1.DataBind();

            }
                else
                {

                    DataGrid2.DataSource = ds;
                    DataGrid2.DataBind();
                }
            }

        
    }




    [Ajax.AjaxMethod]
    public DataSet save(string compcode, string langcode, string fontleading, string fontsize, string editioncode, string fontname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeexecutive chk = new NewAdbooking.Classes.changeexecutive();

            //   ds = chk.insertpayment(paycode, payname, compcode, userid, alias, cash);
            ds = chk.save(compcode, langcode, fontleading, fontsize, editioncode, fontname);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.changeexecutive save = new NewAdbooking.classesoracle.changeexecutive();
                ds = save.save(compcode, langcode, fontleading, fontsize, editioncode,fontname);

            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "savefontleading";
                string[] parameterValueArray = { compcode, langcode, fontleading, fontsize, editioncode, fontname };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            }

        return ds;

    }





    [Ajax.AjaxMethod]
    public DataSet update(string compcode, string langcode, string fontleading, string fontsize, string editioncode,string fontname)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.changeexecutive chk = new NewAdbooking.Classes.changeexecutive();

            //   ds = chk.insertpayment(paycode, payname, compcode, userid, alias, cash);
            ds = chk.update(compcode, langcode, fontleading, fontsize, editioncode, fontname);
        }
        else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {

                NewAdbooking.classesoracle.changeexecutive save = new NewAdbooking.classesoracle.changeexecutive();
                ds = save.update(compcode, langcode, fontleading, fontsize, editioncode,fontname);

            }
            else if (ConfigurationManager.AppSettings["ConnectionType"].ToString() == "mysql")
            {
                string procedureName = "savefontleading";
                string[] parameterValueArray = { compcode, langcode, fontleading, fontsize, editioncode, fontname };
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);

            }

        return ds;

    }







    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {


        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            string str = "chk" + j;
            string str1 = "exe" + j;
            string str2 = "exe2" + j;
            string str3 = "exe1" + j;
            string str4 = "exe3" + j;
            string str5 = "exe4" + j;

           // e.Item.Cells[5].Text = "<input type=text id= '" + str3 + "' style='height:13px;width:150px;border: 1px solid #929292;' value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[2].Text + "~~" + e.Item.Cells[3].Text + "'  )\" >";
            e.Item.Cells[5].Text = "<input type=button id= '" + str + "' style='height:24px;width:65px;font-family: Arial;font-size:xx-small;' value='Update'  onclick=\"updatefont('" + j + "')\">";
            e.Item.Cells[2].Text = "<input type=text id= '" + str1 + "' style='height:13px;width:150px;border: 1px solid #929292;' value='" + e.Item.Cells[2].Text+"'  )\" >";
            e.Item.Cells[1].Text = "<input type=text id= '" + str2 + "' style='height:13px;width:150px;border: 1px solid #929292;' value='" + e.Item.Cells[1].Text + "'  )\" >";
            e.Item.Cells[3].Text = "<input type=text id= '" + str4 + "' disabled='true' style='height:13px;width:150px;border: 1px solid #929292;' value='" + e.Item.Cells[3].Text + "'  )\" >";
            e.Item.Cells[4].Text = "<input type=text id= '" + str5 + "'  style='height:13px;width:150px;border: 1px solid #929292;' value='" + e.Item.Cells[4].Text + "'  )\" >";
            //  e.Item.Cells[6].Text = "<input    type=button value=Update  id=" + str + "    value=" + e.Item.Cells[6].Text + " onclick=\"updateexecutive112('" + e.Item.Cells[6].Text + "','this.id')\" />";

            j++;
        }
    }




}
