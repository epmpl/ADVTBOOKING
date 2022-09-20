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
using System.Text;
using System.IO;


    public partial class contact_detail : System.Web.UI.Page
    {

        static int i = 0;
        string agencode, agencysubcode;
        string hidden, userid;

        string agencysubcod;
        string sortcon;

        public static int numberDiv;
        string comp;
        string abcd, show;

        int j = 0;
        int b = 0;
        static string gbcont_person, gbdesignation, gbrolename, gbdob, gbphone, gbextension, gbfax, gbemailid, gbmobile;
         DataSet dk1 = new DataSet();
         DataSet dk = new DataSet();
        DataRow my_row;

        static string dupName;
        
        private void Page_Load(object sender, System.EventArgs e)
        {
            // Put user code to initialize the page here

            Response.Expires = -1;
            

            if (Session["compcode"] != null)
            {

                userid = Session["userid"].ToString();
                hiddenuserid.Value = userid;
                comp = Session["compcode"].ToString();
                hiddencomcode.Value = comp;
                hiddendateformat.Value = Session["dateformat"].ToString();
                show = Request.QueryString["show"].ToString();
                hiddensaurabh.Value = show;
                //Response.Write("<script>alert('Your Session Expired Please Relogin ');</script>");
            }
            else
            {
                Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
                return;
            }

            
            //         ************************************Code Of XML File********************************
            DataSet objDataSet = new DataSet();

            objDataSet.ReadXml(Server.MapPath("XML/contactdetail.xml"));

            ContactPerson.Text = objDataSet.Tables[0].Rows[0].ItemArray[0].ToString() ;
            DateOfBirth.Text = objDataSet.Tables[0].Rows[0].ItemArray[1].ToString();
            Extension.Text = objDataSet.Tables[0].Rows[0].ItemArray[2].ToString();
            EmailID.Text = objDataSet.Tables[0].Rows[0].ItemArray[3].ToString();
            Designation.Text = objDataSet.Tables[0].Rows[0].ItemArray[4].ToString();
            Role.Text = objDataSet.Tables[0].Rows[0].ItemArray[5].ToString();
            PhoneNo.Text = objDataSet.Tables[0].Rows[0].ItemArray[6].ToString();
            FaxNo.Text = objDataSet.Tables[0].Rows[0].ItemArray[7].ToString();
            product1.Text = objDataSet.Tables[0].Rows[0].ItemArray[8].ToString();
            Button1.Text = objDataSet.Tables[0].Rows[0].ItemArray[9].ToString();
            brnClear.Text = objDataSet.Tables[0].Rows[0].ItemArray[10].ToString();
            btndelete.Text = objDataSet.Tables[0].Rows[0].ItemArray[11].ToString();
            add.Text = objDataSet.Tables[0].Rows[0].ItemArray[12].ToString();
            btnclose.Text = objDataSet.Tables[0].Rows[0].ItemArray[13].ToString();
            lblmobile.Text = objDataSet.Tables[0].Rows[0].ItemArray[14].ToString();
            lblempcod.Text = objDataSet.Tables[0].Rows[0].ItemArray[15].ToString();
            //	       ************************************************************************************		



            agencode = Request.QueryString["agecode"].ToString();
            hiddenagencycode.Value = agencode;
            agencysubcode = Request.QueryString["agencysubcode"].ToString();

            //Button1.Attributes.Add("OnClick","javascript:return validateform()");
            txtcontactperson.Attributes.Add("OnChange", "javascript:return chkcontactname('')");
            txtdesignation.Attributes.Add("OnChange", "javascript:return uppercasedesi('')");
            Ajax.Utility.RegisterTypeForAjax(typeof(contact_detail));

            hiddenagevcode.Value = Request.QueryString["agecode"].ToString();
            Session["hiddenagevcode"] = hiddenagevcode.Value;


            //hiddenuserid.Value=Session["userid"].ToString();

            hiddenagensubcode.Value = Request.QueryString["agencysubcode"].ToString();
            agencysubcod = Request.QueryString["agencysubcode"].ToString();
            txtext.Attributes.Add("OnChange", "javascript:return checkphone();");
            txtfaxno.Attributes.Add("OnChange", "javascript:return checkphone();");
            txtphoneno.Attributes.Add("OnChange", "javascript:return pholeminlength('txtphoneno');");

            txtemcode.Attributes.Add("onkeydown", "javascript:return F2fillempcode(event);");
            lstempcode.Attributes.Add("onkeydown", "javascript:return Clickrempcode_ret(event);");
            lstempcode.Attributes.Add("OnClick", "javascript:return Clickrempcode_ret(event);");
           



            if (agencode == "")
            {
                Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Agency Code');window.close();</script>");

                return;
            }


            if (agencysubcode == "")
            {
                Response.Write("<script>alert('You Should Enter The Agency Code First And Sub Agency Code');window.close();</script>");

                return;
            }

            if (show == "2")
            {
                Button1.Enabled = true;
                btndelete.Enabled = true;
                txtcontactperson .Enabled = true;
                txtdesignation.Enabled = true;
                txtdob.Enabled = true;
                txtext.Enabled = true;
                txtfaxno.Enabled = true;
                txtphoneno.Enabled = true;
                drprole.Enabled = true;
                TextBox2.Enabled = true;
                txtmobile.Enabled = true;
                add.Enabled = true;
                //btnclose.Enabled = true;
            }
            if (show == "1")
            {
                Button1.Enabled = true;
                btndelete.Enabled = false;
                txtcontactperson.Enabled = true;
                txtdesignation.Enabled = true;
                txtdob.Enabled = true;
                txtext.Enabled = true;
                txtfaxno.Enabled = true;
                txtphoneno.Enabled = true;
                drprole.Enabled = true;
                TextBox2.Enabled = true;
                txtmobile.Enabled = true;
                add.Enabled = true;
                //btnclose.Enabled = true;
            }

            if(show=="0")
            {
                Button1.Enabled = false;
                btndelete.Enabled = false;
                txtcontactperson.Enabled = false;
                txtdesignation.Enabled = false;
                txtdob.Enabled = false;
                txtext.Enabled = false;
                txtfaxno.Enabled = false;
                txtphoneno.Enabled = false;
                drprole.Enabled = false;
                TextBox2.Enabled = false;
                txtmobile.Enabled = false;
                add.Enabled = false;
                //btnclose.Enabled = false;
            }

            //if (show == "1")
            //{
            //    Button1.Enabled = true;
            //    //btnclose.Enabled = true;
            //    add.Enabled = true;
            //}
            //else
            //{
            //    Button1.Enabled = false;
            //    //btnclose.Enabled = false;
            //    add.Enabled = false;
            //}
            //			

            //Button1.Attributes.Add("OnClick","javascript:return submit();");

            //			********************************Java Script Function****************************
            if (!Page.IsPostBack)
            {
                if (dk1.Tables.Count > 0 && Session["contactdetail"]==null)
                {
                    dk.Clear();
                    dk.Dispose();
                    dk = new DataSet();

                    //dk.Clear();
                    //dk.Dispose();
                    dk1 = new DataSet();
                }

                if (Session["hiddenagevcode"] != null)
                {

                    DataGrid2.Visible = false;
                    Divgrid2.Visible = false;

                    Divgrid1.Visible = true;
                    DataGrid1.Visible = true;

                    binddata("cont_person");

                }
                else
                {

                    DataGrid2.Visible = true;
                    Divgrid2.Visible = true;

                    Divgrid1.Visible = false;
                    DataGrid1.Visible = false;


                    bindgrid1("cont_person");

                }
                if (Session["contactdetail"] != null)
                {
                    bindgrid1("cont_person");
                    hiddenDupName.Value = dupName;
                }
                else
                {
                    dupName = "";
                    hiddenDupName.Value = "";
                }

                Button1.Attributes.Add("OnClick", "javascript:return submitcontact();  ");
                txtdob.Attributes.Add("onChange", "javascript:return checkdate(this);  ");
                btnclose.Attributes.Add("OnClick", "javascript:return closeWindow();");
                btndelete.Attributes.Add("OnClick", "javascript:return deletecontact();  ");
                TextBox2.Attributes.Add("OnBlur", "javascript:return checkEmail();  ");
                add.Attributes.Add("OnClick", "javascript:return showdiv();");
                ListBox2.Attributes.Add("OnClick", "javascript:return fillproduct();");
                brnClear.Attributes.Add("OnClick", "javascript:return cleardata('cont');");
                //				if(hidden=="modify")
                //				{
                //					executebind();
                //          **********************************************************************************

                rolename();


                binddata("cont_person");
             //   addlistbox();
                //addlistbox1();
                
            }

            }

        

        #region Web Form Designer generated code
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: This call is required by the ASP.NET Web Form Designer.
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.abc);
            this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
            this.DataGrid1.SelectedIndexChanged += new System.EventHandler(this.DataGrid1_SelectedIndexChanged);
           // this.Load += new System.EventHandler(this.Page_Load);

        }
        #endregion


        [Ajax.AjaxMethod]

        private void binddata(string sortfield)
        {
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop databind = new NewAdbooking.Classes.pop();
                da = databind.contactbind(agencysubcod, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), agencode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop databind = new NewAdbooking.classesoracle.pop();
                da = databind.contactbind(agencysubcod, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), agencode);
            }
            else
            {
                NewAdbooking.classmysql.pop databind = new NewAdbooking.classmysql.pop();
                da = databind.contactbind(agencysubcod, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), agencode);
            }
          


            ViewState["SortExpression"] = sortfield;
            ViewState["order"] = "ASC";
            DataView dv = new DataView();
            dv = da.Tables[0].DefaultView;
            dv.Sort = sortfield;
            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();


            //	band();

        }


        private void bindprod(string sortfield)
        {
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop databind = new NewAdbooking.Classes.pop();
            }
            else
            {
                NewAdbooking.classmysql.pop databind = new NewAdbooking.classmysql.pop();

            }
            DataGrid1.DataSource = da;
            DataGrid1.DataBind();
        }
        //		**********************************Bind Drop Down Role*******************************

        public DataSet rolename()
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop insrolename = new NewAdbooking.Classes.pop();
                drprole.Items.Clear();
                ds = insrolename.rolename(Session["compcode"].ToString(), Session["userid"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop insrolename = new NewAdbooking.classesoracle.pop();
                drprole.Items.Clear();
                ds = insrolename.rolename(Session["compcode"].ToString(), Session["userid"].ToString());
            }
            else
            {
                NewAdbooking.classmysql.pop insrolename = new NewAdbooking.classmysql.pop();
                drprole.Items.Clear();
                ds = insrolename.rolename(Session["compcode"].ToString(), Session["userid"].ToString());
            }
            
            int i;
            ListItem li1;
            li1 = new ListItem();
            li1.Text = "--Select Role--";
            li1.Value = "0";
            li1.Selected = true;
            drprole.Items.Add(li1);

            if (ds.Tables.Count > 0)
            {
                for (i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ListItem li;
                    li = new ListItem();
                    li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();

                    drprole.Items.Add(li);
                }
            }

            return ds;
        }

        //		*************************************End******************************************



        public void band12()
        {

            btndelete.Enabled = true;
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop databind = new NewAdbooking.Classes.pop();
                da = databind.contactbind(agencysubcod, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), agencode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop databind = new NewAdbooking.classesoracle.pop();
                da = databind.contactbind(agencysubcod, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), agencode);
            }
            else
            {
                NewAdbooking.classmysql.pop databind = new NewAdbooking.classmysql.pop();
                da = databind.contactbind(agencysubcod, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), agencode);
            }
          

            //da=databind.contactbind(agencode,"A01","HT001");
            DataGrid1.DataSource = da;

            for (int i = 0; i <= DataGrid1.Items.Count - 1; i++)
            {
                CheckBox CheckBox = (CheckBox)DataGrid1.Items[i].FindControl("CheckBox1");

                if (CheckBox.Checked == true)
                {
                    txtcontactperson.Text = da.Tables[0].Rows[i].ItemArray[1].ToString();
                    txtdesignation.Text = da.Tables[0].Rows[i].ItemArray[2].ToString();
                    txtdob.Text = Convert.ToDateTime(da.Tables[0].Rows[i].ItemArray[3]).ToString("MM/dd/yyyy");
                    txtphoneno.Text = da.Tables[0].Rows[i].ItemArray[4].ToString();
                    txtfaxno.Text = da.Tables[0].Rows[i].ItemArray[6].ToString();
                    txtext.Text = da.Tables[0].Rows[i].ItemArray[5].ToString();
                    TextBox2.Text = da.Tables[0].Rows[i].ItemArray[7].ToString();
                    txtmobile.Text = da.Tables[0].Rows[i].ItemArray[8].ToString();
                    hiddenccode.Value = da.Tables[0].Rows[i].ItemArray[0].ToString(); /*use this field for cont code*/
                   
                }

            }

        }



        private void Button2_Click(object sender, System.EventArgs e)
        {
            Response.Write("<script>window.close();</script>");
        }


        public void bandDelete()
        {


            //			for (int i = 0; i <= DataGrid1.Items.Count - 1; i++)
            //			{
            CheckBox CheckBox = (CheckBox)DataGrid1.Items[i].FindControl("CheckBox1");

            if (CheckBox.Checked == true)
            {

                string update = hiddenccode.Value.ToString();
                string compcode = Session["compcode"].ToString();
                DataSet da = new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.pop deletecontact = new NewAdbooking.Classes.pop();

                    da = deletecontact.contactdelete(compcode, userid, agencode, agencysubcode, update);
                }
                else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.pop deletecontact = new NewAdbooking.classesoracle.pop();
                    da = deletecontact.contactdelete(compcode, userid, agencode, agencysubcode, update);
                }
                else
                {
                    NewAdbooking.classmysql.pop deletecontact = new NewAdbooking.classmysql.pop();
                    da = deletecontact.contactdelete(compcode, userid, agencode, agencysubcode, update);
                }
          

                //DataGrid1.DataSource=da;

            }

            //			}

        }




        //      ***************************************Submit And Insert Code Of AJAX********************************
        [Ajax.AjaxMethod]
        public void submitcontact(string contactperson, string txtdesignation, string txtdob, string txtphoneno, string txtext, string txtfaxno, string mail, string agencycode, string compcode, string agencysubcode, string userid, string update, string role,string id,string txtmobile)
        {
            //NewAdbooking.Classes.pop contactuprole = new NewAdbooking.Classes.pop();
            //DataSet dx = new DataSet();
            //dx = contactuprole.getrole();
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop contactup = new NewAdbooking.Classes.pop();

                da = contactup.contactupdate(contactperson, txtdob, txtdesignation, txtphoneno, txtext, txtfaxno, mail, compcode, userid, agencycode, agencysubcode, update, role, id,txtmobile);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop contactup = new NewAdbooking.classesoracle.pop();
                da = contactup.contactupdate(contactperson, txtdob, txtdesignation, txtphoneno, txtext, txtfaxno, mail, compcode, userid, agencycode, agencysubcode, update, role, id,txtmobile);

            }
            else
            {
                NewAdbooking.classmysql.pop contactup = new NewAdbooking.classmysql.pop();
                da = contactup.contactupdate(contactperson, txtdob, txtdesignation, txtphoneno, txtext, txtfaxno, mail, compcode, userid, agencycode, agencysubcode, update, role, id,txtmobile);
            }
          
        }



        [Ajax.AjaxMethod]
        public void insertcontact(string contactperson, string txtdesignation, string drprole, string txtdob, string txtphoneno, string txtext, string txtfaxno, string mail, string agencycode, string compcode, string agencysubcode, string userid,string id,string dateformat,string mobile)
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop contactinsert = new NewAdbooking.Classes.pop();


                ds = contactinsert.insertcontact(contactperson, txtdesignation, drprole, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, agencycode, agencysubcode, compcode, id,mobile);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop contactinsert = new NewAdbooking.classesoracle.pop();
                ds = contactinsert.insertcontact(contactperson, txtdesignation, drprole, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, agencycode, agencysubcode, compcode, id,dateformat,mobile);
            }
            else
            {
                NewAdbooking.classmysql.pop contactinsert = new NewAdbooking.classmysql.pop();
                ds = contactinsert.insertcontact(contactperson, txtdesignation, drprole, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, agencycode, agencysubcode, compcode, id,dateformat,mobile);
            }
        }

        //     *********************************************End*******************************************************

        private void btnupdate_Click(object sender, System.EventArgs e)
        {


        }



        //      ******************************************Delete Contact**********************************************
        [Ajax.AjaxMethod]
        public void deletecontact(string agecode, string compcode, string userid, string agencysubcode1, string hiddenccode)
        {
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop deletecontact = new NewAdbooking.Classes.pop();

                da = deletecontact.contactdelete(compcode, userid, agecode, agencysubcode1, hiddenccode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop deletecontact = new NewAdbooking.classesoracle.pop();
                da = deletecontact.contactdelete(compcode, userid, agecode, agencysubcode1, hiddenccode);
            }
            else
            {
                NewAdbooking.classmysql.pop deletecontact = new NewAdbooking.classmysql.pop();
                da = deletecontact.contactdelete(compcode, userid, agecode, agencysubcode1, hiddenccode);
            }

        }
        //      ******************************************END**********************************************************

        private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(contact_detail), "aa", "executemode();", true);

            DataView dv = new DataView();
            dv = (DataView)DataGrid1.DataSource;
            DataColumnCollection dc = dv.Table.Columns;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string str = "DataGrid1__ctl_CheckBox1" + j;
                string strb = "button" + b;
                string pro = e.Item.Cells[9].Text;
                string name = e.Item.Cells[1].Text;
                e.Item.Cells[0].Text = "<input type='checkbox' style=\"top:0px\" width='5px' id=" + str + "  OnClick=\"javascript:return selected('" + str + "');\"value=" + e.Item.Cells[10].Text + "  />";
                
                //e.Item.Cells[10].Text = "<input type='Label' width='15px' id=" + strb + " onmouseover=\"javascript:return productopen('" + pro + "','" + name + "','" + strb + "');\" onmouseout=\"javascript:return productclose();\" value=\"Product\" CssClass=\"buttongrid\"   />";
                e.Item.Cells[10].Text = "<table class=\"TextField\"><tr ><td width='15px' id=" + strb + " class=\"TextField\" onmouseover=\"javascript:return productopen('" + pro + "','" + name + "','" + strb + "');\" onmouseout=\"javascript:return productclose();\" value=\"Product\" CssClass=\"buttongrid\"   >Product</td></tr></table>";
                //e.Item.Cells[10].Text = "<input type='button' width='15px' id=" + strb + " onmouseover=\"javascript:return productopen(event);\" onmouseout=\"javascript:return productclose();\" value=\"Product\" CssClass=\"buttongrid\"   />";
                j++;
                b++;
                //e.Item.Cells[0].Text="<input type='checkbox' id="+e.Item.Cells[8].Text+"   value="+e.Item.Cells[8].Text+"  />";

            }


            if (e.Item.ItemType == ListItemType.Header)
            {

                if (ViewState["SortExpression"].ToString() != "")
                {
                    string str = "";
                    switch (ViewState["SortExpression"].ToString())
                    {
                        case "cont_person":
                            str = "Contact Person";
                            break;
                        case "designation":
                            str = "Designation";
                            break;

                        case "rolename":
                            str="Role";
                            break;

                        case "dob":
                            str = "Date Of Birth";
                            break;

                        case "phone":
                            str = "Phone No.";
                            break;

                        case "extension":
                            str = "Ext.";
                            break;

                        case "fax":
                            str = "Fax No.";
                            break;

                        case "emailid":
                            str = "Email Id";
                            break;
                        case "mobile":
                            str = "Mobile No.";
                            break;

                    };
                    string strd = Convert.ToString( dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                    strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                    if (strd.Length < 2)
                        strd = "0" + strd;
                    if (ViewState["order"].ToString() == "DESC")
                    {
                        //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                        //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                        //$ctl01$ctl00

                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                    }
                    else
                    {
                        //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                    }




                }
            }



        }

        private void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop databind = new NewAdbooking.Classes.pop();
                da = databind.contactbind(agencysubcod, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), agencode);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop databind = new NewAdbooking.classesoracle.pop();
                da = databind.contactbind(agencysubcod, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), agencode);
            }
            else
            {
                NewAdbooking.classmysql.pop databind = new NewAdbooking.classmysql.pop();
                da = databind.contactbind(agencysubcod, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString(), agencode);
            }
    
      

           

            DataView dv = new DataView();
            dv = da.Tables[0].DefaultView;
            if ((numberDiv % 2) == 0)
            {
                dv.Sort = e.SortExpression + " " + "ASC";
                ViewState["SortExpression"] = e.SortExpression;
                ViewState["order"] = "ASC";
            }
            else
            {
                dv.Sort = e.SortExpression + " " + "DESC";
                ViewState["SortExpression"] = e.SortExpression;
                ViewState["order"] = "DESC";
            }
            numberDiv++;



            DataGrid1.DataSource = dv;
            DataGrid1.DataBind();


        }

        [Ajax.AjaxMethod]

        public DataSet bandcontact12(string agecode, string compcode, string userid, string hiddenccode)
        {
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop databind = new NewAdbooking.Classes.pop();
                da = databind.contactbind12(agecode, userid, compcode, hiddenccode);
                return da;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop databind = new NewAdbooking.classesoracle.pop();
                da = databind.contactbind12(agecode, userid, compcode, hiddenccode);
                return da;
            }
            else
            {
                NewAdbooking.classmysql.pop databind = new NewAdbooking.classmysql.pop();
                da = databind.contactbind12(agecode, userid, compcode, hiddenccode);
                return da;

            }
           
         

            //DataSet dg=datagrid;



           

            //da=databind.contactbind(agencode,"A01","HT001");
            //dg.DataSource=da;
         

        }


        [Ajax.AjaxMethod]

        public DataSet product(string code)
        {
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop databind = new NewAdbooking.Classes.pop();

                da = databind.getpro(code);
                return da;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop databind = new NewAdbooking.classesoracle.pop();
                da = databind.getpro(code);
                return da;
            }
            else
            {
                NewAdbooking.classmysql.pop databind = new NewAdbooking.classmysql.pop();
                da = databind.getpro(code);
                return da;
            }
        }
        [Ajax.AjaxMethod]
        public DataSet productinsert(string newboxvalue, string comp, string userid, string clientcode, string newprodname, string contactperson,string agencycode,string agencysubcode)
        {
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop databind = new NewAdbooking.Classes.pop();

                da = databind.getproinsert(newboxvalue, comp, userid, clientcode, newprodname, contactperson, agencycode, agencysubcode);
                return da;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop databind = new NewAdbooking.classesoracle.pop();
                da = databind.getproinsert(newboxvalue, comp, userid, clientcode, newprodname, contactperson, agencycode, agencysubcode);
                return da;
            }
            else
            {
                NewAdbooking.classmysql.pop databind = new NewAdbooking.classmysql.pop();

                da = databind.getproinsert(newboxvalue, comp, userid, clientcode, newprodname, contactperson, agencycode, agencysubcode);
                return da;
            }
        }

       

        [Ajax.AjaxMethod]
        public DataSet checkuom(string contactperson,string comp,string userid,string agencycode,string agencysubcode)
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop check = new NewAdbooking.Classes.pop();

                ds = check.bindes(contactperson, comp, userid, agencycode, agencysubcode);
                return ds;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop check = new NewAdbooking.classesoracle.pop();
                ds = check.bindes(contactperson, comp, userid, agencycode, agencysubcode);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.pop check = new NewAdbooking.classmysql.pop();
                ds = check.bindes(contactperson, comp, userid, agencycode, agencysubcode);
                return ds;
            }
        }


        public string RenderControlToString(Control c)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htmlWriter = new HtmlTextWriter(sw);
            c.RenderControl(htmlWriter);


            return sb.ToString();
        } 

        [Ajax.AjaxMethod]

        public DataSet productname(string aftersplit)
        {
            DataSet da = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop databind = new NewAdbooking.Classes.pop();

                da = databind.getproname(aftersplit);
                return da;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop databind = new NewAdbooking.classesoracle.pop();
                da = databind.getproname(aftersplit);
                return da;
            }
            else
            {
                NewAdbooking.classmysql.pop databind = new NewAdbooking.classmysql.pop();
                da = databind.getproname(aftersplit);
                return da;
            }
        }


        [Ajax.AjaxMethod]

        public DataSet selectlistbox(string code, string compcode, string userid)
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop productlistboxbutton = new NewAdbooking.Classes.pop();

                ds = productlistboxbutton.buttonbind(compcode, userid, code);
                return ds;
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop productlistboxbutton = new NewAdbooking.classesoracle.pop();
                ds = productlistboxbutton.buttonbind(compcode, userid, code);
                return ds;
            }
            else
            {
                NewAdbooking.classmysql.pop productlistboxbutton = new NewAdbooking.classmysql.pop();

                ds = productlistboxbutton.buttonbind(compcode, userid, code);
                return ds;
            }
        }

       

        private void DataGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }


//bind list box

        public void addlistbox()
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop productlistbox = new NewAdbooking.Classes.pop();

                ds = productlistbox.clientbind(Session["compcode"].ToString(), Session["userid"].ToString());
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop productlistbox = new NewAdbooking.classesoracle.pop();
                ds = productlistbox.clientbind(Session["compcode"].ToString(), Session["userid"].ToString());
            }
            else
            {
                NewAdbooking.classmysql.pop productlistbox = new NewAdbooking.classmysql.pop();
                ds = productlistbox.clientbind(Session["compcode"].ToString(), Session["userid"].ToString());
            }

          

            ListBox2.Items.Clear();
            ListItem li1;
            ListItem li2;
            li1 = new ListItem();
            li1.Text = "--Select Client--";
            li1.Value = "0";
            li1.Selected = true;
            

            ListBox2.Items.Add(li1);

            int i;
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                ListItem li;
                li = new ListItem();
                li.Value = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Text = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                ListBox2.Items.Add(li);


            }

        }

        [Ajax.AjaxMethod]
        public DataSet addlistbox1(string compcode,string user,string clientcode,string agencycode,string agencysubcode)
        {
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.pop productlistbox = new NewAdbooking.Classes.pop();

                ds = productlistbox.productbind12(compcode, user, clientcode, agencycode, agencysubcode);

            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop productlistbox = new NewAdbooking.classesoracle.pop();
                ds = productlistbox.productbind12(compcode, user, clientcode, agencycode, agencysubcode);
            }
            else
            {
                NewAdbooking.classmysql.pop productlistbox = new NewAdbooking.classmysql.pop();
                ds = productlistbox.productbind12(compcode, user, clientcode, agencycode, agencysubcode);
            }


            return ds;
            

        }




        


        //protected void btnclose_Click(object sender, EventArgs e)
        //{
        //    Response.Write("<script>window.close();</script>");           
        //}
        [Ajax.AjaxMethod]

        public string chpro(string contactper, string agencycode, string sagencycode,string compcode,string userid)
        {
            string val = "";
            string proval = "";
            DataSet dz = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.pop getcontact = new NewAdbooking.Classes.pop();

                dz = getcontact.getthevalue(contactper, agencycode, sagencycode, compcode, userid);
            }
            else if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.pop getcontact = new NewAdbooking.classesoracle.pop();
                dz = getcontact.getthevalue(contactper, agencycode, sagencycode, compcode, userid);
            }
            else
            {
                NewAdbooking.classmysql.pop getcontact = new NewAdbooking.classmysql.pop();
                dz = getcontact.getthevalue(contactper, agencycode, sagencycode, compcode, userid);
            }
       

            for (int i = 0; i <= dz.Tables[0].Rows.Count - 1; i++)
            {
                val = dz.Tables[0].Rows[i].ItemArray[0].ToString();
                proval = val + proval;

            }
            string finalval = proval;
            return finalval;

        }

        public void bindgrid1(string sortfield)
        {
            DataGrid1.Visible = false;
            DataGrid2.Visible = true;
            Divgrid2 .Visible = true;
            DataSet ds_tbl = new DataSet();


            /////////////////////////////////////
            DataColumn mycolumn;
            DataTable mydatatable = new DataTable();

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "cont_person";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "designation";
            mydatatable.Columns.Add(mycolumn);
            // DataRow myrow;
            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "rolename";
            mydatatable.Columns.Add(mycolumn);

            // //DataColumn mycolumn;
            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "dob";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "phone";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "extension";
            mydatatable.Columns.Add(mycolumn);


            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "fax";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "emailid";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "cont_code";
            mydatatable.Columns.Add(mycolumn);

            mycolumn = new DataColumn();
            mycolumn.DataType = System.Type.GetType("System.String");
            mycolumn.ColumnName = "mobile";
            mydatatable.Columns.Add(mycolumn);

            if (Session["contactdetail"] == null)
            {
                ds_tbl.Tables.Add(mydatatable);
                DataGrid1.DataSource = ds_tbl.Tables[0];
                DataGrid1.DataBind();
            }
            else
            {
                int d;
                int g;
                DataSet dsnew = new DataSet();
                dsnew = (DataSet)Session["contactdetail"];
                if (dsnew.Tables.Count > 1)
                {
                    g = 1;
                }
                else
                {
                    g = 0;
                }

                for (d = 0; d <= dsnew.Tables.Count - 1; d++)
                {
                    //if (g == 0)
                    //{my_row = dk1.Tables[d].Rows[0]my_row = dk1.Tables[d].Rows[0]
                    my_row = dsnew.Tables[d].Rows[0];
                    //}
                    //else
                    //{
                    //     my_row = dk.Tables[dk.Tables.Count - 1].Rows[0];
                    //}



                    mydatatable.ImportRow(my_row);
                }


                ds_tbl.Tables.Add(mydatatable);
                ViewState["SortExpression"] = sortfield;
                ViewState["order"] = "ASC";
                DataView dv = new DataView();
                dv = ds_tbl.Tables[0].DefaultView;
                // dv.Sort = sortfield;


                DataGrid2.DataSource = dv;
                DataGrid2.DataBind();
                d = 0;
            }
            gbcont_person  = "";
            gbdesignation  = "";
            gbrolename  = "";
            gbdob  = "";
            gbphone  = "";
            gbextension = "";
            gbfax  = "";
            gbemailid = "";

            txtphoneno .Text = "";
            txtfaxno.Text = "";
            drprole .SelectedValue = "0";
            txtdesignation.Text = "";
            txtext .Text = "";
            txtdob .Text = "";
            TextBox2.Text = "";
            txtcontactperson.Text = "";
            txtmobile.Text = "";




        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           
        }
        //protected void prodd()
        //{
        //  hidden
        //}
        protected void Button1_Click2(object sender, EventArgs e)
        {
            DataColumn mycolumn1;
            DataTable mydatatable1 = new DataTable();
            DataRow myrow1;

            //DataColumn mycolumn;
            //DataTable mydatatable = new DataTable();
            //DataRow myrow;

            hiddenDupName.Value = hiddenDupName.Value + txtcontactperson.Text + ",";
            dupName = hiddenDupName.Value;

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "cont_person";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "designation";
            mydatatable1.Columns.Add(mycolumn1);
            // DataRow myrow;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "rolename";
            mydatatable1.Columns.Add(mycolumn1);

            // //DataColumn mycolumn1;
            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "dob";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "phone";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "extension";
            mydatatable1.Columns.Add(mycolumn1);


            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "fax";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "emailid";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "cont_code";
            mydatatable1.Columns.Add(mycolumn1);

            mycolumn1 = new DataColumn();
            mycolumn1.DataType = System.Type.GetType("System.String");
            mycolumn1.ColumnName = "mobile";
            mydatatable1.Columns.Add(mycolumn1);


            myrow1 = mydatatable1.NewRow();

            myrow1["cont_code"] = "00";

            myrow1["cont_person"] = txtcontactperson.Text;
            gbcont_person = txtcontactperson.Text;

            myrow1["designation"] = txtdesignation.Text;
            gbdesignation = txtdesignation.Text;

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                if (drprole.SelectedValue == "0")
                {
                    myrow1["rolename"] = "";
                    gbrolename = "";
                }
                else
                {
                    myrow1["rolename"] = drprole.SelectedItem.Value;
                    gbrolename = drprole.SelectedItem.Value;
                }
            }
            else
            {
                if (drprole.SelectedValue == "0")
                {
                    myrow1["rolename"] = "";
                    gbrolename = "";
                }
                else
                {
                    myrow1["rolename"] = drprole.SelectedItem.Value;
                    gbrolename = drprole.SelectedItem.Value;
                }
            }
           

            myrow1["dob"] = txtdob.Text;
            gbdob = txtdob.Text;

            myrow1["phone"] = txtphoneno.Text;
            gbphone = txtphoneno.Text;

            myrow1["extension"] = txtext.Text;
            gbextension = txtext.Text;

            myrow1["fax"] = txtfaxno.Text;
            gbfax = txtfaxno.Text;

            myrow1["emailid"] = TextBox2.Text;
            gbemailid = TextBox2.Text;

            myrow1["mobile"] = txtmobile.Text;
            gbphone = txtmobile.Text;

            mydatatable1.Rows.Add(myrow1);

            if (Session["contactdetail"] != null)
            {
                DataSet dsNew = new DataSet();
                dsNew = (DataSet)Session["contactdetail"];
                dk1 = dsNew;
            }

            dk1.Tables.Add(mydatatable1);

            Session["contactdetail"] = dk1;

            bindgrid1("cont_person");
        }
        protected void DataGrid2_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

            ScriptManager.RegisterClientScriptBlock(this, typeof(contact_detail), "aa", "newmode();", true);
            
            DataView dv = new DataView();
            dv = (DataView)DataGrid2.DataSource;
            DataColumnCollection dc = dv.Table.Columns;
            //prodd();
            

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                //string str = "DataGrid1__ctl_CheckBox1" + j;
                //ScriptManager.RegisterClientScriptBlock(
                string strb = "button" + b;
                string pro = e.Item.Cells[8].Text;
                string name = e.Item.Cells[0].Text;
//                e.Item.Cells[0].Text = "<input type='checkbox' style=\"top:0px\" width='5px' id=" + str + "  OnClick=\"javascript:return selected('" + str + "');\"value=" + e.Item.Cells[9].Text + "  />";

                //e.Item.Cells[10].Text = "<input type='Label' width='15px' id=" + strb + " onmouseover=\"javascript:return productopen('" + pro + "','" + name + "','" + strb + "');\" onmouseout=\"javascript:return productclose();\" value=\"Product\" CssClass=\"buttongrid\"   />";
                e.Item.Cells[9].Text = "<table class=\"TextField\"><tr ><td width='15px' id=" + strb + " class=\"TextField\" onmouseover=\"javascript:return productopen('" + pro + "','" + name + "','" + strb + "');\" onmouseout=\"javascript:return productclose();\" value=\"Product\" CssClass=\"buttongrid\"   >Product</td></tr></table>";
                //e.Item.Cells[10].Text = "<input type='button' width='15px' id=" + strb + " onmouseover=\"javascript:return productopen(event);\" onmouseout=\"javascript:return productclose();\" value=\"Product\" CssClass=\"buttongrid\"   />";
                j++;
                b++;
                //e.Item.Cells[0].Text="<input type='checkbox' id="+e.Item.Cells[8].Text+"   value="+e.Item.Cells[8].Text+"  />";

            }


            if (e.Item.ItemType == ListItemType.Header)
            {

                if (ViewState["SortExpression"].ToString() != "")
                {
                    string str = "";
                    switch (ViewState["SortExpression"].ToString())
                    {
                        case "cont_person":
                            str = "Contact Person";
                            break;
                        case "designation":
                            str = "Designation";
                            break;

                        case "rolename":
                            str = "Role";
                            break;

                        case "dob":
                            str = "Date Of Birth";
                            break;

                        case "phone":
                            str = "Phone No.";
                            break;

                        case "extension":
                            str = "Ext.";
                            break;

                        case "fax":
                            str = "Fax No.";
                            break;

                        case "emailid":
                            str = "Email Id";
                            break;
                        case "mobile":
                            str = "Mobile No.";
                            break;

                    };
                    string strd = Convert.ToString(dc.IndexOf(dc[ViewState["SortExpression"].ToString()]));
                    strd = Convert.ToString(Convert.ToInt32(strd) - 1);
                    if (strd.Length < 2)
                        strd = "0" + strd;
                    if (ViewState["order"].ToString() == "DESC")
                    {
                        //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                        //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+ str +"<img  src=\"images\\movenext2.gif\" border=0></a>";
                        //$ctl01$ctl00

                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')  \">" + str + "<img  src=\"images\\movenext2.gif\" border=0></a>";

                    }
                    else
                    {
                        //e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])].Text= "<a href=\"javascript:__doPostBack('DataGrid1$_ctl1$_ctl"+dc.IndexOf(dc[ViewState["SortExpression"].ToString ()])+"','')\">"+str+"<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                        e.Item.Cells[dc.IndexOf(dc[ViewState["SortExpression"].ToString()])].Text = "<a Class='dtGridHd12' href=\"javascript:__doPostBack('DataGrid1$ctl01$ctl" + strd + "','')   \">" + str + "<img  src=\"images\\moveprevious2.gif\" border=0></a>";
                    }




                }
            }
        }
        protected void add_Click(object sender, EventArgs e)
        {

        }


        [Ajax.AjaxMethod]
        public DataSet empcodebind(string compcode, string empname)
        {
            //drpemcode.Items.Clear();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.BranchMaster name = new NewAdbooking.Classes.BranchMaster();

                ds = name.bindempcode(compcode, empname);
                return ds;
            }
            else
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BranchMaster name = new NewAdbooking.classesoracle.BranchMaster();
                ds = name.bindempcode(compcode, empname);

            }
            return ds;


        }
}

		
	
