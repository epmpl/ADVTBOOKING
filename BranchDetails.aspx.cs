using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Configuration;

	public partial class BranchDetails : System.Web.UI.Page
	{
        public static int numberDiv;
        public static int flag = 0;
         int j = 0;
        string show, message;
        DataSet dk1 = new DataSet();
        DataSet dk = new DataSet();
        DataRow my_row;
        string userid, comp,  branchcode;

        protected void Page_Load(object sender, System.EventArgs e)
		{
            
			Response.Expires=-1;

			if(Session["compcode"]!=null)
			{

				userid=Session["userid"].ToString();
				hiddenuserid.Value=userid;
				comp=Session["compcode"].ToString();
				hiddencomcode.Value=comp;
				hiddendateformat.Value=Session["dateformat"].ToString();
				show=Request.QueryString["show"].ToString();
                hiddenshow.Value = Request.QueryString["show"].ToString();
                hiddenDup.Value = hiddenDup.Value + txtcontactperson.Text + ",";
				//Response.Write("<script>alert('Your Session Expired Please Relogin ');</script>");
			}
			else
			{
				Response.Write("<script>alert('Your session has been Expired');window.close();</script>");
				return ;
			}
		
			show=Request.QueryString["show"].ToString();
			branchcode=Request.QueryString["branchcode"].ToString().Trim();
			hiddenbranchcode.Value=branchcode;
			Ajax.Utility.RegisterTypeForAjax(typeof(BranchDetails));

			if(branchcode !="" && branchcode !="" )
			{}
			else
			{
				Response.Write("<script>alert('You Should Enter The Branch Code First And Sub Code');window.close();</script>");
				
				return;
			}

            //******************************XML for labels****************************************
            DataSet ds1 = new DataSet();
            ds1.ReadXml(Server.MapPath("XML/BranchDetails.xml"));
            ContactPerson.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
            Designation.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
            DateOfBirth.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
            PhoneNo.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
            Extension.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
            Fax.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
            EmailID.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
            btnClear.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
            btndelete.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
            btnupdate.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
            Button1.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
            lblempcod.Text = ds1.Tables[0].Rows[0].ItemArray[11].ToString();
            //if (show == "1")
            //{
            //    Button1.Enabled = true;
            //    //btndelete.Enabled = true;
            //    txtcontactperson.Enabled = true;
            //    txtdesignation.Enabled = true;
            //    txtdob.Enabled = true;
            //    txtemailid.Enabled = true;
            //    txtext.Enabled = true;
            //    txtfaxno.Enabled = true;
            //    txtphoneno.Enabled = true;
            //    //saurabh change
            //    //         if (hiddendelsau.Value == "1")
            //    //        {
            //    btndelete.Enabled = false;
            //    //       }

            //}
            //    Button1.Enabled=true;
            //    btnupdate.Enabled=true;
            //    txtcontactperson.Enabled = true;
            //    txtdesignation.Enabled = true;
            //    txtdob.Enabled = true;
            //    txtemail.Enabled = true;
            //    txtext.Enabled = true;
            //    txtfaxno.Enabled = true;
            //    txtphoneno.Enabled = true;
            //if (show == "0")
            //{
            //    btnsubmit.Enabled = false;

            //    btndelete.Enabled = false;
            //    txtcontactperson.Enabled = false;
            //    txtdesignation.Enabled = false;
            //    txtdob.Enabled = false;
            //    txtemailid.Enabled = false;
            //    txtext.Enabled = false;
            //    txtfaxno.Enabled = false;
            //    txtphoneno.Enabled = false;
            //    hiddendelsau.Value = "0";
            //    //       }

            //}

            //if (show == "2")
            //{
            //    btnsubmit.Enabled = true;

            //    btndelete.Enabled = false;
            //    //btnsubmit.Enabled = true;
            //    //btndelete.Enabled = true;
            //    txtcontactperson.Enabled = true;
            //    txtdesignation.Enabled = true;
            //    txtdob.Enabled = true;
            //    txtemailid.Enabled = true;
            //    txtext.Enabled = true;
            //    txtfaxno.Enabled = true;
            //    txtphoneno.Enabled = true;

            //    hiddendelsau.Value = "1";

            //}


            if (show == "1")
            {
                Button1.Enabled = true;
                btnupdate.Enabled = true;
                txtcontactperson.Enabled = true;
                txtdesignation.Enabled = true;
                txtdob.Enabled = true;
                txtemail.Enabled = true;
                txtext.Enabled = true;
                txtfaxno.Enabled = true;
                txtphoneno.Enabled = true;

            }
            else if(show=="0")
            {

                txtcontactperson.Enabled = false;
                txtdesignation.Enabled = false;
                txtdob.Enabled = false;
                txtemail.Enabled = false;
                txtext.Enabled = false;
                txtfaxno.Enabled = false;
                txtphoneno.Enabled = false;
                Button1.Enabled = false;
                btnupdate.Enabled = true;
            }


			
			if(!Page.IsPostBack)
			{
				
				
				Button1.Attributes.Add("OnClick","javascript:return submitcontact();  ");
                txtdob.Attributes.Add("OnChange", "javascript:return checkdate(this);");
                btnupdate.Attributes.Add("OnClick", "javascript:return closecontact();");
                btnClear.Attributes.Add("OnClick", "javascript:return clearcontact();");
              
               	btndelete.Attributes.Add("OnClick","javascript:return deletecontact();  ");
				txtcontactperson.Attributes.Add("OnBlur","javascript:return UpperCase('txtcontactperson');");
				txtdesignation.Attributes.Add("OnBlur","javascript:return UpperCase('txtdesignation');");
				txtemail.Attributes.Add("OnBlur","javascript:return checkEmail();");
                txtemcode.Attributes.Add("onkeydown", "javascript:return F2fillempcode(event);");
                lstempcode.Attributes.Add("onkeydown", "javascript:return Clickrempcode_ret(event);");
                lstempcode.Attributes.Add("OnClick", "javascript:return Clickrempcode_ret(event);");

				//binddata("cont_person");
                if (dk.Tables.Count > 0 && Session["branchsave"] == null)
                {
                    dk1.Clear();
                    dk1.Dispose();
                    dk1 = new DataSet();

                    //dk.Clear();
                    //dk.Dispose();
                    dk = new DataSet();
                }
                if (Session["branchsave"] == null)
                {
                    DataGrid2.Visible = false;
                    divdg2.Visible = false;

                    divdg1.Visible = true;
                    DataGrid1.Visible = true;


                    binddata("cont_person");
                }
                else
                {
                    DataGrid2.Visible = true;
                    divdg2.Visible = true;

                    divdg1.Visible = false;
                    DataGrid1.Visible = false;
                    bindgrid2();
                }
			}

            //saurabh change

            if (show == "1")
            {

                Button1.Enabled = true;
                btnupdate.Enabled = true;
                txtcontactperson.Enabled = true;
                txtdesignation.Enabled = true;
                txtdob.Enabled = true;
                txtemail.Enabled = true;
                txtext.Enabled = true;
                txtfaxno.Enabled = true;
                txtphoneno.Enabled = true;
            
            btndelete.Enabled = false;
            }
            if (show == "0")
            {
                Button1.Enabled = false;

                btndelete.Enabled = false;
                
                btnupdate.Enabled = true;
                txtcontactperson.Enabled = false;
                txtdesignation.Enabled = false;
                txtdob.Enabled = false;
                txtemail.Enabled = false;
                txtext.Enabled = false;
                txtfaxno.Enabled = false;
                txtphoneno.Enabled = false;
                hiddendelsau.Value = "0";
            }
            if (show == "2")
            {
                Button1.Enabled = true;
                btndelete.Enabled = false;
                txtcontactperson.Enabled = true;
                txtdesignation.Enabled = true;
                txtdob.Enabled = true;
                txtemail.Enabled = true;
                txtext.Enabled = true;
                txtfaxno.Enabled = true;
                txtphoneno.Enabled = true;
               hiddendelsau.Value = "1";
            }

        

            //if(show=="1")
            //{
            //    Button1.Enabled=true;
            //    btnupdate.Enabled=true;
            //    txtcontactperson.Enabled = true;
            //    txtdesignation.Enabled = true;
            //    txtdob.Enabled = true;
            //    txtemail.Enabled = true;
            //    txtext.Enabled = true;
            //    txtfaxno.Enabled = true;
            //    txtphoneno.Enabled = true;

            //}
            //else
            //{

            //    txtcontactperson.Enabled = false;
            //    txtdesignation.Enabled = false;
            //    txtdob.Enabled = false;
            //    txtemail.Enabled = false;
            //    txtext.Enabled = false;
            //    txtfaxno.Enabled = false;
            //    txtphoneno.Enabled = false;
            //    Button1.Enabled = false;
            //    btnupdate.Enabled=true;

            //}
			// Put user code to initialize the page here
		}

        public void abc(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
        {


            DataSet ds = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BranchMaster databind = new NewAdbooking.Classes.BranchMaster();

                ds = databind.contactbind(branchcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());


            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BranchMaster databind = new NewAdbooking.classesoracle.BranchMaster();

                    ds = databind.contactbind(branchcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

                    
                }
                else
                {
                    NewAdbooking.classmysql.BranchMaster databind = new NewAdbooking.classmysql.BranchMaster();

                    ds = databind.contactbind(branchcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());



                    }
           
           

            
            DataView dv = new DataView();
            dv = ds.Tables[0].DefaultView;
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
			
		}
		#endregion

		[Ajax.AjaxMethod]
		private void binddata(string sortfield)
		{
            DataSet da = new DataSet();
            if(ConfigurationSettings.AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.BranchMaster databind = new NewAdbooking.Classes.BranchMaster();
     	  
			da=databind.contactbind(branchcode,Session["userid"].ToString(),Session["compcode"].ToString(),Session["dateformat"].ToString());
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BranchMaster databind = new NewAdbooking.classesoracle.BranchMaster();

                    da = databind.contactbind(branchcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

                }
                else
                {
                    NewAdbooking.classmysql.BranchMaster databind = new NewAdbooking.classmysql.BranchMaster();

                    da = databind.contactbind(branchcode, Session["userid"].ToString(), Session["compcode"].ToString(), Session["dateformat"].ToString());

                    
                }

			ViewState["SortExpression"] = sortfield; 
			ViewState["order"]="ASC";
            DataView dv = new DataView();
            dv = da.Tables[0].DefaultView;
            dv.Sort = sortfield;

            DataGrid1.DataSource = dv;
			DataGrid1.DataBind();
		}

        public void bindgrid2()
        {
            DataGrid1.Visible = false;
            DataGrid2.Visible = true;
            divdg2.Visible = true;
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
















            if (Session["branchsave"] == null)
            {
                ds_tbl.Tables.Add(mydatatable);
                DataGrid2.DataSource = ds_tbl.Tables[0];
                DataGrid2.DataBind();
            }
            else
            {
                int d;
                int g;
                DataSet dsnew = new DataSet();
                dsnew = (DataSet)Session["branchsave"];
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
                //ViewState["SortExpression"] = sortfield;
                //ViewState["order"] = "ASC";
                DataView dv = new DataView();
                dv = ds_tbl.Tables[0].DefaultView;
                // dv.Sort = sortfield;


                DataGrid2.DataSource = dv;
                DataGrid2.DataBind();
                d = 0;

            }
        }
		

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

          
		}

        [Ajax.AjaxMethod]
        public DataSet chksubmitcontact(string contactperson, string branchcde)
        {
            DataSet ds = new DataSet();

            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
            {
            NewAdbooking.Classes.BranchMaster contactup = new NewAdbooking.Classes.BranchMaster();
           
            ds = contactup.chksubmitcontact1(contactperson, branchcde);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BranchMaster contactup = new NewAdbooking.classesoracle.BranchMaster();

                    ds = contactup.chksubmitcontact1(contactperson, branchcde);

                }
                else
                {
                    NewAdbooking.classmysql.BranchMaster contactup = new NewAdbooking.classmysql.BranchMaster();

                    ds = contactup.chksubmitcontact1(contactperson, branchcde);

                }

            return ds;
        }

        [Ajax.AjaxMethod]
        public DataSet chksubmitcontactupdate(string contactperson, string branchcde)
        {
            DataSet ds = new DataSet();

            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.BranchMaster contactup = new NewAdbooking.Classes.BranchMaster();
                
                ds = contactup.chksubmitcontactupdate(contactperson, branchcde);


            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BranchMaster contactup = new NewAdbooking.classesoracle.BranchMaster();
                
                ds = contactup.chksubmitcontactupdate(contactperson, branchcde);

                }
                else
                {
                    NewAdbooking.classmysql.BranchMaster contactup = new NewAdbooking.classmysql.BranchMaster();
                
                ds = contactup.chksubmitcontactupdate(contactperson, branchcde);

                }

            return ds;
        }

		[Ajax.AjaxMethod]
		public void submitcontact(string contactperson,string txtdesignation,string txtdob,string txtphoneno,string txtext,string txtfaxno,string mail,string branchcode,string compcode,string userid,string update)
		{
            DataSet da=new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {
                NewAdbooking.Classes.BranchMaster contactup = new NewAdbooking.Classes.BranchMaster();

                da = contactup.contactupdate(contactperson, txtdob, txtdesignation, txtphoneno, txtext, txtfaxno, mail, compcode, userid, branchcode, update);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BranchMaster contactup = new NewAdbooking.classesoracle.BranchMaster();

                da = contactup.contactupdate(contactperson, txtdob, txtdesignation, txtphoneno, txtext, txtfaxno, mail, compcode, userid, branchcode, update);

                }
                else
                {
                    NewAdbooking.classmysql.BranchMaster contactup = new NewAdbooking.classmysql.BranchMaster();

                da = contactup.contactupdate(contactperson, txtdob, txtdesignation, txtphoneno, txtext, txtfaxno, mail, compcode, userid, branchcode, update);

                }
		}

		[Ajax.AjaxMethod]
		public void insertcontact(string contactperson,string txtdesignation,string txtdob,string txtphoneno,string txtext,string txtfaxno,string mail,string branchcode,string compcode,string userid)
		{

            	DataSet ds=new DataSet();
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                {
                    NewAdbooking.Classes.BranchMaster contactinsert = new NewAdbooking.Classes.BranchMaster();

                    ds = contactinsert.insertcontact(contactperson, txtdesignation, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, branchcode, compcode);
                }
                else
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                    {
                        NewAdbooking.classesoracle.BranchMaster contactinsert = new NewAdbooking.classesoracle.BranchMaster();

                    ds = contactinsert.insertcontact(contactperson, txtdesignation, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, branchcode, compcode);

                    }
                    else
                    {
                        NewAdbooking.classmysql.BranchMaster contactinsert = new NewAdbooking.classmysql.BranchMaster();

                    ds = contactinsert.insertcontact(contactperson, txtdesignation, txtdob, txtphoneno, txtext, txtfaxno, mail, userid, branchcode, compcode);

                    }
		}


		[Ajax.AjaxMethod]

		public DataSet branchcont12(string branchcode,string compcode,string userid,string hiddenccode)
		{
             	 	DataSet da=new DataSet();
                    if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
                    {
                        NewAdbooking.Classes.BranchMaster databind = new NewAdbooking.Classes.BranchMaster();

                        da = databind.contactbind12(branchcode, compcode, userid, hiddenccode);
                    }
                    else
                        if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                        {
                                      NewAdbooking.classesoracle .BranchMaster databind = new NewAdbooking.classesoracle.BranchMaster();

                        da = databind.contactbind12(branchcode, compcode, userid, hiddenccode);

                        }
                        else
                        {
                         NewAdbooking.classmysql .BranchMaster databind = new NewAdbooking.classmysql.BranchMaster();

                        da = databind.contactbind12(branchcode, compcode, userid, hiddenccode);

                        }
			return da;
		}


		[Ajax.AjaxMethod]
		public void deletecontact(string branchcode,string compcode,string userid,string hiddenccode)
		{
            DataSet da = new DataSet();
            if(ConfigurationSettings .AppSettings ["ConnectionType"].ToString ()=="sql")
            {
			 NewAdbooking.Classes.BranchMaster deletecontact = new NewAdbooking.Classes.BranchMaster();
     	 	
			da=deletecontact.contactdelete(branchcode,compcode,userid,hiddenccode);
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
                {
                    NewAdbooking.classesoracle.BranchMaster deletecontact = new NewAdbooking.classesoracle.BranchMaster();

                    da = deletecontact.contactdelete(branchcode, compcode, userid, hiddenccode);

                }
            else
                {
                    NewAdbooking.classmysql.BranchMaster deletecontact = new NewAdbooking.classmysql.BranchMaster();

                    da = deletecontact.contactdelete(branchcode, compcode, userid, hiddenccode);

                }
			
		}


        protected void Button1_Click(object sender, EventArgs e)
        {

            //         DataColumn mycolumn1;
            //DataTable mydatatable1 = new DataTable();
            //DataRow myrow1;
            //flag = 0;

            //if ((dk.Tables.Count != 0))
            //{
            //    int j;
            //    for (j = 0; j < dk.Tables[0].Rows.Count; j++)
            //    {
            //        if (txtcontactperson.Text == dk.Tables[0].Rows[j].ItemArray[0].ToString())
            //        {
            //           // message = "Executive Name has been submitted already";
            //          //  AspNetMessageBox(message);
            //            flag = 1;

            //        }
            //        else
            //        {
            //            flag = 0;
            //        }

            //    }

            //}
            //if (flag == 0)
            //{


            //    mycolumn1 = new DataColumn();
            //    mycolumn1.DataType = System.Type.GetType("System.String");
            //    mycolumn1.ColumnName = "cont_person";
            //    mydatatable1.Columns.Add(mycolumn1);

            //    mycolumn1 = new DataColumn();
            //    mycolumn1.DataType = System.Type.GetType("System.String");
            //    mycolumn1.ColumnName = "designation";
            //    mydatatable1.Columns.Add(mycolumn1);

            //    mycolumn1 = new DataColumn();
            //    mycolumn1.DataType = System.Type.GetType("System.String");
            //    mycolumn1.ColumnName = "dob";
            //    mydatatable1.Columns.Add(mycolumn1);

            //    mycolumn1 = new DataColumn();
            //    mycolumn1.DataType = System.Type.GetType("System.String");
            //    mycolumn1.ColumnName = "phone";
            //    mydatatable1.Columns.Add(mycolumn1);



            //    mycolumn1 = new DataColumn();
            //    mycolumn1.DataType = System.Type.GetType("System.String");
            //    mycolumn1.ColumnName = "extension";
            //    mydatatable1.Columns.Add(mycolumn1);


            //    mycolumn1 = new DataColumn();
            //    mycolumn1.DataType = System.Type.GetType("System.String");
            //    mycolumn1.ColumnName = "fax";
            //    mydatatable1.Columns.Add(mycolumn1);

            //    mycolumn1 = new DataColumn();
            //    mycolumn1.DataType = System.Type.GetType("System.String");
            //    mycolumn1.ColumnName = "emailid";
            //    mydatatable1.Columns.Add(mycolumn1);


            //    mycolumn1 = new DataColumn();
            //    mycolumn1.DataType = System.Type.GetType("System.String");
            //    mycolumn1.ColumnName = "cont_code";
            //    mydatatable1.Columns.Add(mycolumn1);

        









            //    myrow1 = mydatatable1.NewRow();

            //    //


            //    //  myrow1["Convertcode"] = "0";
            //    myrow1["cont_code"] = "0";


            //    myrow1["cont_person"] = txtcontactperson.Text;

            //    myrow1["designation"] = txtdesignation.Text;

            //    myrow1["dob"] = txtdob.Text;

            //    myrow1["phone"] = txtphoneno.Text;


            //    myrow1["extension"] = txtext.Text;

            //    myrow1["fax"] = txtfaxno.Text;


            //    myrow1["emailid"] = txtemail.Text;


             




            //    mydatatable1.Rows.Add(myrow1);

            //    dk.Tables.Add(mydatatable1);




            //    Session["branchsave"] = dk;

            //    ///this is for grid
            //    ///


            //    DataColumn mycolumn;
            //    DataTable mydatatable = new DataTable();
            //    DataRow myrow;

            //    mycolumn = new DataColumn();
            //    mycolumn.DataType = System.Type.GetType("System.String");
            //    mycolumn.ColumnName = "cont_person";
            //    mydatatable.Columns.Add(mycolumn);

            //    mycolumn = new DataColumn();
            //    mycolumn.DataType = System.Type.GetType("System.String");
            //    mycolumn.ColumnName = "designation";
            //    mydatatable.Columns.Add(mycolumn);

            //    mycolumn = new DataColumn();
            //    mycolumn.DataType = System.Type.GetType("System.String");
            //    mycolumn.ColumnName = "dob";
            //    mydatatable.Columns.Add(mycolumn);

            //    mycolumn = new DataColumn();
            //    mycolumn.DataType = System.Type.GetType("System.String");
            //    mycolumn.ColumnName = "phone";
            //    mydatatable.Columns.Add(mycolumn);



            //    mycolumn = new DataColumn();
            //    mycolumn.DataType = System.Type.GetType("System.String");
            //    mycolumn.ColumnName = "extension";
            //    mydatatable.Columns.Add(mycolumn);


            //    mycolumn = new DataColumn();
            //    mycolumn.DataType = System.Type.GetType("System.String");
            //    mycolumn.ColumnName = "fax";
            //    mydatatable.Columns.Add(mycolumn);

            //    mycolumn = new DataColumn();
            //    mycolumn.DataType = System.Type.GetType("System.String");
            //    mycolumn.ColumnName = "emailid";
            //    mydatatable.Columns.Add(mycolumn);


            //    mycolumn = new DataColumn();
            //    mycolumn.DataType = System.Type.GetType("System.String");
            //    mycolumn.ColumnName = "cont_code";
            //    mydatatable.Columns.Add(mycolumn);



            //    myrow = mydatatable.NewRow();
            //    myrow["cont_code"] = "0";
            //    myrow["cont_person"] = txtcontactperson.Text;
            //    myrow["designation"] = txtdesignation.Text;
            //    myrow["dob"] = txtdob.Text;
            //    myrow["phone"] = txtphoneno.Text;
            //    myrow["extension"] = txtext.Text;
            //    myrow["fax"] = txtfaxno.Text;
            //    myrow["emailid"] = txtemail.Text;
            //    txtcontactperson.Text="";
            //    txtdesignation.Text="";
            //    txtdob.Text="";
            //    txtphoneno.Text="";
            //    txtext.Text="";
            //    txtfaxno.Text="";
            //    txtemail.Text="";


             





                    
            //    mydatatable.Rows.Add(myrow);

            //    dk1.Tables.Add(mydatatable);


            //    bindgrid2();
              
            //}



        }
        protected void DataGrid1_ItemDataBound1(object sender, DataGridItemEventArgs e)
        {
            DataView dv = new DataView();

            dv = (DataView)DataGrid1.DataSource;
            DataColumnCollection dc = dv.Table.Columns;

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {


                string str = "DataGrid1__ctl_CheckBox1" + j;


                e.Item.Cells[0].Text = "<input type='checkbox' width='5px' id=" + str + " OnClick=\"javascript:return selected('" + str + "');\"  value=" + e.Item.Cells[8].Text + "  />";
                j++;
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

                        case "dob":
                            str = "Date Of Birth";
                            break;

                        case "phone":
                            str = "Phone No";
                            break;

                        case "extension":
                            str = "Ext.";
                            break;

                        case "fax":
                            str = "Fax No";
                            break;

                        case "emailid":
                            str = "Email Id";
                            break;

                        case "cont_code":
                            str = "contcode";
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
        protected void Button1_Click1(object sender, EventArgs e)
        {
            DataColumn mycolumn1;
            DataTable mydatatable1 = new DataTable();
            DataRow myrow1;
            flag = 0;

            if ((dk.Tables.Count != 0))
            {
                int j;
                for (j = 0; j < dk.Tables[0].Rows.Count; j++)
                {
                    if (txtcontactperson.Text == dk.Tables[0].Rows[j].ItemArray[0].ToString())
                    {
                        // message = "Executive Name has been submitted already";
                        //  AspNetMessageBox(message);
                        flag = 1;

                    }
                    else
                    {
                        flag = 0;
                    }

                }

            }
            if (flag == 0)
            {


                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "cont_person";
                mydatatable1.Columns.Add(mycolumn1);

                mycolumn1 = new DataColumn();
                mycolumn1.DataType = System.Type.GetType("System.String");
                mycolumn1.ColumnName = "designation";
                mydatatable1.Columns.Add(mycolumn1);

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











                myrow1 = mydatatable1.NewRow();

                //


                //  myrow1["Convertcode"] = "0";
                myrow1["cont_code"] = "0";


                myrow1["cont_person"] = txtcontactperson.Text;

                myrow1["designation"] = txtdesignation.Text;

                myrow1["dob"] = txtdob.Text;

                myrow1["phone"] = txtphoneno.Text;


                myrow1["extension"] = txtext.Text;

                myrow1["fax"] = txtfaxno.Text;


                myrow1["emailid"] = txtemail.Text;







                mydatatable1.Rows.Add(myrow1);
                if (Session["branchsave"] != null)
                {
                    DataSet dsnew = new DataSet();
                    dsnew = (DataSet)Session["branchsave"];
                    dk = dsnew;
                }

                dk.Tables.Add(mydatatable1);




                Session["branchsave"] = dk;

                ///this is for grid
                ///


                DataColumn mycolumn;
                DataTable mydatatable = new DataTable();
                DataRow myrow;

                mycolumn = new DataColumn();
                mycolumn.DataType = System.Type.GetType("System.String");
                mycolumn.ColumnName = "cont_person";
                mydatatable.Columns.Add(mycolumn);

                mycolumn = new DataColumn();
                mycolumn.DataType = System.Type.GetType("System.String");
                mycolumn.ColumnName = "designation";
                mydatatable.Columns.Add(mycolumn);

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



                myrow = mydatatable.NewRow();
                myrow["cont_code"] = "0";
                myrow["cont_person"] = txtcontactperson.Text;
                myrow["designation"] = txtdesignation.Text;
                myrow["dob"] = txtdob.Text;
                myrow["phone"] = txtphoneno.Text;
                myrow["extension"] = txtext.Text;
                myrow["fax"] = txtfaxno.Text;
                myrow["emailid"] = txtemail.Text;
                txtcontactperson.Text = "";
                txtdesignation.Text = "";
                txtdob.Text = "";
                txtphoneno.Text = "";
                txtext.Text = "";
                txtfaxno.Text = "";
                txtemail.Text = "";









                mydatatable.Rows.Add(myrow);

                dk1.Tables.Add(mydatatable);


                bindgrid2();

            }
            else
            {
                 message="This Contact Name Has Been Submitted Already.";
                AspNetMessageBox(message);
            }


        }

        protected void AspNetMessageBox(string strMessage)
        {
            //strMessage = adminResource.GetStringFromResource(strMessage);
            string strAlert = "";
            strAlert = "alert('" + strMessage + "')";
            ScriptManager.RegisterClientScriptBlock(this, typeof(BranchDetails), "ShowAlert", strAlert, true);
        }

        [Ajax.AjaxMethod]
        public DataSet empcodebind(string compcode, string empname)
        {
            //drpemcode.Items.Clear();
            DataSet ds = new DataSet();
            if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
            {

                NewAdbooking.Classes.BranchMaster name = new NewAdbooking.Classes.BranchMaster();
                ds = name.bindempcode_new(compcode, empname);
             
            }
            else
                if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "orcl")
            {
                NewAdbooking.classesoracle.BranchMaster name = new NewAdbooking.classesoracle.BranchMaster();
                ds = name.bindempcode(compcode, empname);
               
            }
                return ds;


        }

      //[Ajax.AjaxMethod]
      //  public DataSet empcodebind(string compcode, string empname)
      //  {
      //      //drpemcode.Items.Clear();
      //      DataSet ds = new DataSet();
      //      if (ConfigurationSettings.AppSettings["ConnectionType"].ToString() == "sql")
      //      {

      //          NewAdbooking.Classes.Createuser name = new NewAdbooking.Classes.Createuser();

      //          ds = name.bindempcode(compcode, empname);
      //          return ds;
      //      }
      //      else
      //      {
      //          NewAdbooking.classesoracle.Createuser name = new NewAdbooking.classesoracle.Createuser();
      //          ds = name.bindempcode(compcode, empname);
      //          return ds;
      //      }



      //  }
      

}

