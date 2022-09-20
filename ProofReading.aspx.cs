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
using System.IO;
using System.Xml;
using System.Text;
using System.Xml.Schema;
using System.Diagnostics;
using System.Reflection;

public partial class ProofReading : System.Web.UI.Page
{
    int i = 0;
    DataSet dsProofLevel;
    string fileName = "ProofReadLevel.txt";
    string filecontent = "";
    string prtype = "";
    public string cap = "";
    protected void Page_Load(object sender, EventArgs e)
    {

       
        if (Request.QueryString["form"] != null)
        {
            prtype = Request.QueryString["form"].ToString();
            hiddenprtype.Value = prtype;
        }
        else
        {
            hiddenprtype.Value = "";
            prtype = "";
        }


        if (prtype == "agencyroaudit")
        {
            btnPrev.Text = "Audit";

            tit.Text = "Agency Ro Audit";
            cap = "Agency Ro Audit";

        }
        else
        {
            btnPrev.Text = "Proof";
            tit.Text = "ProofReading";
            cap = "ProofReading";

        }
        if (Session["compcode"] != null)
        {
            hiddencompcode.Value = Session["compcode"].ToString();
            hiddenuserid.Value = Session["userid"].ToString();
            hiddendateformat.Value = Session["dateformat"].ToString();
            hiddenuserhome.Value = Session["userhome"].ToString();
            hiddenrevenue.Value = Session["Revenue"].ToString();
            hiddenadmin.Value = Session["Admin"].ToString();

            hdnusername.Value = Session["Username"].ToString();
        }
        else
        {
            Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
            return;
        }
        Ajax.Utility.RegisterTypeForAjax(typeof(ProofReading));

    //*********************************For Lables***************************
        DataSet ds = new DataSet();
        ds.ReadXml(Server.MapPath("XML/ProofReading.xml"));
        lbFromDate.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
        lbToDate.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        lblcategory.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
        lblfilter.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
        AdCategoryName.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
        lblinsertiontype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
        lbluserid.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();

        if (!File.Exists(Server.MapPath("XML") + "\\" + fileName.Replace("/", "")))
        {
            FileStream fs = new FileStream(Server.MapPath("XML") + "\\" + fileName.Replace("/", ""), FileMode.Create);
            StreamWriter w = new StreamWriter(fs, System.Text.Encoding.Default);
            
            w.WriteLine("Booking Ids for proofreading first level");
            w.Flush();
            fs.Close();
        }
        else
        {
            StreamReader pk = File.OpenText(Server.MapPath("XML") + "\\" + fileName.Replace("/", ""));
            filecontent = pk.ReadToEnd();
            pk.Close();
        }
        
        if (!Page.IsPostBack)
        {
            btnPrev.Visible = false;
            //btnpub.Visible = false;
            drpuserid.Attributes.Add("onkeydown", "javascript:return binduser(event);");
            lst_user.Attributes.Add("onclick", "javascript:return filluser(event);");
            lst_user.Attributes.Add("onkeydown", "javascript:return filluser(event);");
            txtFromDate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            txtToDate.Attributes.Add("OnBlur", "javascript:return checkdate(this);");
            btnSubmit.Attributes.Add("OnClick", "javascript:return btnSubmit2();");
            btnPrev.Attributes.Add("OnClick", "javascript:return prevclick();");
            btnExit.Attributes.Add("OnClick", "javascript:return exitclick();");
            drpadvcatcode.Attributes.Add("OnChange", "javascript:return fillAdCat2();");
            drpadvsubcatcode.Attributes.Add("OnChange", "javascript:return fillcat();");
          //  btnpub.Attributes.Add("OnClick", "javascript:return pubdetail();");
            category();
            bindbranch(hiddenuserid.Value);
            bindprintcent();
        }        
    }


    public void bindprintcent()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
           // NewAdbooking.Report.classesoracle.Class1 pub_cent1 = new NewAdbooking.Report.classesoracle.Class1();
           // ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
            NewAdbooking.classesoracle.ProofReading pub_cent1 = new NewAdbooking.classesoracle.ProofReading();
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), "0", Session["userid"].ToString());
        }

        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Report.Classes.Class1 pub_cent1 = new NewAdbooking.Report.Classes.Class1();
            //ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), Session["access"].ToString(), Session["userid"].ToString());
            ds = pub_cent1.pub_cent_NEW(Session["compcode"].ToString(), "0", Session["userid"].ToString());
        }
        else
        {
            string procedureName = "Bind_PubCentName_r_Bind_PubCentName_r_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString(), Session["userid"].ToString(), "0" };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        ListItem li = new ListItem();
        li.Value = "0";
        li.Text = "Select Printing Center";
        li.Selected = true;
        dpd_printcent.Items.Add(li);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li1 = new ListItem();
            li1.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            li1.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dpd_printcent.Items.Add(li1);


        }
    }

    public void category()
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.adsubcat category = new NewAdbooking.Classes.adsubcat();
            ds = category.addcategoryname(Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.adsubcat category = new NewAdbooking.classesoracle.adsubcat();
            ds = category.addcategoryname(Session["compcode"].ToString());
        }
        else
        {
            string procedureName = "adcat_adcat_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { Session["compcode"].ToString() };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }

        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Add Category-";
        li1.Value = "0";
        li1.Selected = true;
        drpadvcatcode.Items.Add(li1);

        int i;
        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            drpadvcatcode.Items.Add(li);
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {        
        DataSet ds1 = fetchdata();
        if(ds1.Tables[0].Rows.Count >0)
            btnPrev.Visible = true;
       // btnpub.Visible = true;
        DataGrid2.DataSource = ds1.Tables[0];
        DataGrid2.DataBind();
    }

    private DataSet fetchdata()
    {

      
        string frmdate = txtFromDate.Text;
        string todate = txtToDate.Text;
        string cat = drpadvcatcode.SelectedValue; 
        string filter = drpfilter.SelectedValue;
        string cat2 = hiddencat2.Value;
        string bookingtype = drpbooktyp.SelectedValue;
        string p_bkid = bookingid.Text;
        string pextra1 = drpbranch.SelectedValue;
        //string pextra2 = "";
        string pextra2 = dpd_printcent.SelectedValue;
        string pextra3 = "";
        string pextra4 = "";
        string pextra5 = "";
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ProofReading fdata = new NewAdbooking.Classes.ProofReading();
            ds = fdata.findrec(frmdate, todate, cat, filter, Session["compcode"].ToString(), Session["dateformat"].ToString(), cat2, InsertionType.SelectedValue, bookingtype, p_bkid, pextra1, pextra2, pextra3, pextra4, pextra5, usercode.Value);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ProofReading fdata = new NewAdbooking.classesoracle.ProofReading();

            if (prtype == "agencyroaudit")
            {
                ds = fdata.findrecagency(frmdate, todate, cat, filter, Session["compcode"].ToString(), Session["dateformat"].ToString(), cat2, InsertionType.SelectedValue, bookingtype, p_bkid, pextra1, pextra2, pextra3, pextra4, pextra5, usercode.Value);
            }

            else
            {
                ds = fdata.findrec(frmdate, todate, cat, filter, Session["compcode"].ToString(), Session["dateformat"].ToString(), cat2, InsertionType.SelectedValue, bookingtype, p_bkid, pextra1, pextra2, pextra3, pextra4, pextra5, usercode.Value);
            }
        }
       else
        {
            string procedureName = "bindproofreadingforagencyaudit";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
           
            if (prtype == "agencyroaudit")
            {
                procedureName = "bindproofreadingforagencyaudit";
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), frmdate, todate, cat, filter, cat2, InsertionType.SelectedValue, bookingtype, p_bkid, usercode.Value, Session["dateformat"].ToString(), pextra1, pextra2, pextra3, pextra4, pextra5 };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }//compcode, frdate   , todate, cate , filter1 , cat2 ,p_repeat , p_booktype, p_bkid , puserid    , pdateformat, pextra1 , pextra2 , pextra3   , pextra4 , pextra5  

            else
            {
                procedureName = "bindproofreading";
                string[] parameterValueArray = new string[] { Session["compcode"].ToString(), frmdate, todate, cat, filter, cat2, InsertionType.SelectedValue, bookingtype, p_bkid, usercode.Value, Session["dateformat"].ToString(), pextra1, pextra2, pextra3, pextra4, pextra5 };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
        }

        hiddencat2.Value = "";
        return ds;
    }
    
    protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
       
        if (e.Item.ItemType == ListItemType.Header)
        {
            e.Item.Cells[7].Text = "<input type='checkbox' style='width:14px;' id='checkall' onclick=\"javascript:return selectAll();\" />";
        }
        else
       // if (e.Item.Cells[5].Text != "Preview")
        {
            string bkid = e.Item.Cells[1].Text;
            string filename = e.Item.Cells[6].Text;
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.ProofReading fdata = new NewAdbooking.Classes.ProofReading();
                ds = fdata.findprec(bkid,filename);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.ProofReading fdata = new NewAdbooking.classesoracle.ProofReading();
                ds = fdata.findprec(bkid, filename);
            }
            else
            {
                string procedureName = "websp_proorec";
                NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
                string[] parameterValueArray = new string[] { bkid, filename };
                ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            }
            string str = "chk" + i;
           // string str11 = "chkpub" + i;
           // e.Item.Cells[0].Text = "<a style=\"cursor:hand;color:blue\"  onClick=\"openbooking1('" + bkid + "')\">" + bkid + "</a>";
           // e.Item.Cells[5].Text = "<input type=button value=Preview onclick=\"openprev('" + bkid + "','" + e.Item.Cells[6].Text + "','" + e.Item.Cells[3].Text+ "')\" >";
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "Y")
                {
                    // e.Item.Cells[4].Text = "<input type='checkbox' disabled id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
                    //e.Item.Cells[4].Text = "<input type='checkbox'  id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
                    //e.Item.Cells[5].Text = "<input type=button value=Preview onclick=\"openprev('" + bkid + "','" + e.Item.Cells[6].Text + "','" + e.Item.Cells[3].Text + "','DIS')\" >";
                    e.Item.Cells[7].Text = "<input type='checkbox' style='width:15px;' disabled='disabled' id=" + str + "   value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[6].Text + "'  />";
                    e.Item.Cells[8].Text = "<input type=button value=Preview onclick=\"openprev('" + bkid + "','" + e.Item.Cells[9].Text + "','" + e.Item.Cells[6].Text + "','DIS','" + e.Item.Cells[13].Text + "','" + e.Item.Cells[15].Text + "')\" >";
                    e.Item.Cells[9].Text = "<input type=button value=Details onclick=\"datepack('" + bkid + "','" + e.Item.Cells[10].Text + "','" + e.Item.Cells[6].Text + "','DIS')\" >";
                    //e.Item.Cells[10].Text = "<input type=checkbox style='width:15px;' id=" + str11 + "   value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[3].Text + "'>";
                }
                else
                {
                    if (e.Item.Cells[6].Text == "" || e.Item.Cells[6].Text == " " || e.Item.Cells[6].Text == "&nbsp;")
                        //                        e.Item.Cells[4].Text = "<input type='checkbox' disabled id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
                        e.Item.Cells[7].Text = "<input type='checkbox' style='width:15px;' id=" + str + "   value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[6].Text + "'  />";

                    else if (filecontent.Contains(bkid))
                    {
                        e.Item.Cells[7].Text = "<input type='checkbox' disabled='disabled' checked='true' style='width:15px;' id=" + str + "   value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[6].Text + "'  />";
                        e.Item.Cells[8].Text = "<input type=button value=Preview onclick=\"openprev('" + bkid + "','" + e.Item.Cells[9].Text + "','" + e.Item.Cells[6].Text + "','','" + e.Item.Cells[13].Text + "','" + e.Item.Cells[15].Text + "')\" >";
                        e.Item.Cells[9].Text = "<input type=button value=Details onclick=\"datepack('" + bkid + "','" + e.Item.Cells[10].Text + "','" + e.Item.Cells[6].Text + "','DIS')\" >";
                       // e.Item.Cells[10].Text = "<input type=checkbox style='width:15px;' id=" + str11 + "   value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[3].Text + "' >";
                    }
                    else
                    {
                        e.Item.Cells[7].Text = "<input type='checkbox' style='width:15px;' id=" + str + "   value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[6].Text + "'  />";
                        e.Item.Cells[8].Text = "<input type=button value=Preview onclick=\"openprev('" + bkid + "','" + e.Item.Cells[9].Text + "','" + e.Item.Cells[6].Text + "','','" + e.Item.Cells[13].Text + "','" + e.Item.Cells[15].Text + "')\" >";
                        e.Item.Cells[9].Text = "<input type=button value=Details onclick=\"datepack('" + bkid + "','" + e.Item.Cells[10].Text + "','" + e.Item.Cells[6].Text + "','DIS')\" >";
                     //   e.Item.Cells[10].Text = "<input type=checkbox style='width:15px;' id=" + str11 + "   value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[3].Text + "'>";
                    }
                }
            }
            else
            {
                if (e.Item.Cells[6].Text == "" || e.Item.Cells[6].Text == " " || e.Item.Cells[6].Text == "&nbsp;")
//                    e.Item.Cells[4].Text = "<input type='checkbox' disabled id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
                    e.Item.Cells[7].Text = "<input type='checkbox'style='width:15px;'  id=" + str + "   value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[7].Text + "'  />";
                else
                    e.Item.Cells[7].Text = "<input type='checkbox' style='width:15px;' id=" + str + "   value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[6].Text + "'  />";
                e.Item.Cells[8].Text = "<input type=button value=Preview onclick=\"openprev('" + bkid + "','" + e.Item.Cells[9].Text + "','" + e.Item.Cells[6].Text + "','','" + e.Item.Cells[13].Text + "','" + e.Item.Cells[15].Text + "')\" >";
                e.Item.Cells[9].Text = "<input type=button value=Details onclick=\"datepack('" + bkid + "','" + e.Item.Cells[10].Text + "','" + e.Item.Cells[6].Text + "','DIS')\" >";
              //  e.Item.Cells[10].Text = "<input type=checkbox style='width:15px;' id=" + str11 + "   value='" + e.Item.Cells[1].Text + "~" + e.Item.Cells[3].Text + "'>";
            }
            i++;
        }
    }

    //******************************
    //protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
    //{
    //    if (e.Item.ItemType == ListItemType.Header)
    //    {
    //        e.Item.Cells[4].Text = "<input type='checkbox' id='checkall' onclick=\"javascript:return selectAll();\" />";
    //    }
    //    else
    //    // if (e.Item.Cells[5].Text != "Preview")
    //    {
    //        string bkid = e.Item.Cells[0].Text;
    //        string filename = e.Item.Cells[3].Text;
    //        DataSet ds = new DataSet();
    //        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
    //        {
    //            NewAdbooking.Classes.ProofReading fdata = new NewAdbooking.Classes.ProofReading();
    //            ds = fdata.findprec(bkid, filename);
    //        }
    //        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
    //        {
    //            //NewAdbooking.classesoracle.ProofReading fdata = new NewAdbooking.classesoracle.ProofReading();
    //            //ds = fdata.findprec(bkid, filename);
    //        }
    //        else
    //        {
    //            //NewAdbooking.classmysql.logview logdata = new NewAdbooking.classmysql.logview();
    //            //ds = logdata.addvalue(compcode,tabname,trxtype,username,date1);
    //        }
    //        string str = "chk" + i;
    //        // e.Item.Cells[0].Text = "<a style=\"cursor:hand;color:blue\"  onClick=\"openbooking1('" + bkid + "')\">" + bkid + "</a>";
    //        // e.Item.Cells[5].Text = "<input type=button value=Preview onclick=\"openprev('" + bkid + "','" + e.Item.Cells[6].Text + "','" + e.Item.Cells[3].Text+ "')\" >";
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "Y")
    //            {
    //                // e.Item.Cells[4].Text = "<input type='checkbox' disabled id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
    //                e.Item.Cells[4].Text = "<input type='checkbox'  id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
    //                e.Item.Cells[5].Text = "<input type=button value=Preview onclick=\"openprev('" + bkid + "','" + e.Item.Cells[6].Text + "','" + e.Item.Cells[3].Text + "','DIS')\" >";
    //            }
    //            else
    //            {
    //                if (e.Item.Cells[3].Text == "" || e.Item.Cells[3].Text == " " || e.Item.Cells[3].Text == "&nbsp;")
    //                    //                        e.Item.Cells[4].Text = "<input type='checkbox' disabled id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
    //                    e.Item.Cells[4].Text = "<input type='checkbox'  id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
    //                else
    //                    e.Item.Cells[4].Text = "<input type='checkbox' id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
    //                e.Item.Cells[5].Text = "<input type=button value=Preview onclick=\"openprev('" + bkid + "','" + e.Item.Cells[6].Text + "','" + e.Item.Cells[3].Text + "','')\" >";
    //            }
    //        }
    //        else
    //        {
    //            if (e.Item.Cells[3].Text == "" || e.Item.Cells[3].Text == " " || e.Item.Cells[3].Text == "&nbsp;")
    //                //                    e.Item.Cells[4].Text = "<input type='checkbox' disabled id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
    //                e.Item.Cells[4].Text = "<input type='checkbox'  id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
    //            else
    //                e.Item.Cells[4].Text = "<input type='checkbox' id=" + str + "   value='" + e.Item.Cells[0].Text + "~" + e.Item.Cells[3].Text + "'  />";
    //            e.Item.Cells[5].Text = "<input type=button value=Preview onclick=\"openprev('" + bkid + "','" + e.Item.Cells[6].Text + "','" + e.Item.Cells[3].Text + "','')\" >";
    //        }
    //        i++;
    //    }
    //}
    //***********************
    protected void DataGrid2_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {

    }
   // [Ajax.AjaxMethod(Ajax.HttpSessionStateRequirement.Read)]
    [Ajax.AjaxMethod]
    public DataSet fillCat2(string cat1, string compcode)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.AdCat4 category = new NewAdbooking.Classes.AdCat4();
            ds = category.addcategoryname2(cat1, Session["compcode"].ToString());
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.AdCat4 category = new NewAdbooking.classesoracle.AdCat4();
            ds = category.addcategoryname2(cat1, compcode);
        }
        else
        {
            string procedureName = "advsubcategory_advsubcategory_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { cat1, compcode };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds;
    }
[Ajax.AjaxMethod]
    //		public DataSet distselect(string compcode,string userid,string statcode,string distcode)
    public DataSet proofad(string bookid,string filename,string prtype,string username)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.ProofReading select = new NewAdbooking.Classes.ProofReading();
            ds = select.selecproof(bookid, filename);
            return ds;
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.ProofReading select = new NewAdbooking.classesoracle.ProofReading();
                if (prtype != "agencyroaudit")
                {
                    ds = select.selecproof(bookid, filename);
                }
                else
                {
                    NewAdbooking.classesoracle.Booking_Audit1 up = new NewAdbooking.classesoracle.Booking_Audit1();
                    ds = up.update1(bookid, username);
                }
                return ds;
            }
            else
            {
            string procedureName = "websp_proofad";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { bookid, filename };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            return ds;
            }
            }    
    [Ajax.AjaxMethod]
    public DataSet datepack(string frmdate, string todate, string cat, string filter, string compcode, string dateformat, string cat2, string InsertionType, string bookingtype, string p_bkid, string pextra1, string pextra2, string pextra3, string pextra4, string pextra5, string userid)
    {
        DataSet ds = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.ProofReading fdata = new NewAdbooking.classesoracle.ProofReading();
            ds = fdata.findrec(frmdate, todate, cat, filter, compcode, dateformat, cat2, InsertionType, bookingtype, p_bkid, pextra1, pextra2, pextra3, pextra4, pextra5, userid);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql") 
        {
            NewAdbooking.Classes.ProofReading fdata = new NewAdbooking.Classes.ProofReading();
            ds = fdata.findrec(frmdate, todate, cat, filter, compcode, dateformat, cat2, InsertionType, bookingtype, p_bkid, pextra1, pextra2, pextra3, pextra4, pextra5, userid);           
        }
        else
            {
                string procedureName = "bindproofreading";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { frmdate, todate, cat, filter, compcode, dateformat, cat2, InsertionType, bookingtype, p_bkid, pextra1, pextra2, pextra3, pextra4, pextra5, userid };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
            return ds;
            }
        return ds;
    }

    [Ajax.AjaxMethod]
    public DataSet UserBind(string compcode, string userid, string userhome, string revenue, string admin,string name)
    {
        DataSet ds1 = new DataSet();
        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.Classes.pop MastPrev = new NewAdbooking.Classes.pop();
            ds1 = MastPrev.MastPrevDisp_user(compcode, userid, userhome, revenue, revenue, name);
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.classesoracle.pop MastPrev = new NewAdbooking.classesoracle.pop();
            ds1 = MastPrev.MastPrevDisp_user(compcode, userid, userhome, revenue, revenue, name);
        }
        else
        {
            string procedureName = "WESP_MODULTUSER_wesp_wesp_modultuser_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { compcode, userid, userhome, revenue, revenue, name };
            ds1 = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        return ds1;
    }
    public void bindbranch(string userid)
    {

        DataSet ds = new DataSet();

        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
        {
            NewAdbooking.BillingClass.Classes.publish_audit bind = new NewAdbooking.BillingClass.Classes.publish_audit();
            ds = bind.bindbranch();
        }
        else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
        {
            NewAdbooking.BillingClass.classesoracle.session_billing bind = new NewAdbooking.BillingClass.classesoracle.session_billing();
            ds = bind.bindbranch_userwise(userid);
        }
        else
        {
            string procedureName = "bind_branch_branchwise_bind_branch_branchwise_p";
            NewAdbooking.classmysql.CommonClass obj = new NewAdbooking.classmysql.CommonClass();
            string[] parameterValueArray = new string[] { userid };
            ds = obj.DynamicBindProcedure(procedureName, parameterValueArray);
        }
        int i;
        ListItem li1;

        li1 = new ListItem();
        drpbranch.Items.Clear();
        //li1.Text = "-Select Branch-";
        li1.Text = "--Select Branch--";
        li1.Value = "0";
        li1.Selected = true;
        drpbranch.Items.Add(li1);

        for (i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ListItem li;
            li = new ListItem();
            li.Value = ds.Tables[0].Rows[i]["BRANCH_CODE"].ToString();
            li.Text = ds.Tables[0].Rows[i]["Branch_Name"].ToString();
            drpbranch.Items.Add(li);


        }

    }


    
    protected void btnPrev_Click(object sender, EventArgs e)
    {
        btnSubmit_Click(sender, e);
    }
}
