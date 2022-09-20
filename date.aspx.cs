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

public partial class date : System.Web.UI.Page
{
   string abc;
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			

			Response.Expires=-1;
			Response.Buffer=true;  
			Response.ExpiresAbsolute=DateTime.Now.AddDays(-1d); 
			Response.Expires =-1500;
			Response.CacheControl = "no-cache";




			if(Session["compcode"]!=null)
			{
				hiddencode.Value=Session["compcode"].ToString();
				hiddenuserid.Value=Session["userid"].ToString();
				hiddencompcode.Value=Session["compcode"].ToString();


			}
			else
			{
				//Response.Redirect("login.aspx");
				Response.Write("<script>window.parent.location=\"login.aspx\";</script>");
				return;
			}


			Ajax.Utility.RegisterTypeForAjax(typeof(date));
			

            

			 

			if(!Page.IsPostBack)
			{
			


				btnsubmit.Attributes.Add("OnClick","javascript:return datesave();");

				NewAdbooking.Classes.login showdate=new NewAdbooking.Classes.login();
				DataSet ds=new DataSet();
				ds=showdate.dateshow(Session["compcode"].ToString(),Session["userid"].ToString());
				if(ds.Tables[0].Rows[0].ItemArray[3]!=null && ds.Tables[0].Rows[0].ItemArray[3].ToString()!="")
				{
					drpdateformat.SelectedValue=ds.Tables[0].Rows[0].ItemArray[3].ToString();
				}
				else
				{
					drpdateformat.SelectedValue="mm/dd/yyyy";

				}

                lbagencymaster.Attributes.Add("OnClick", "javascript:return openenability();");
                bindcurr();
                bindrategroup();
				


			}
			
				
				
			
		}

		#region Web Form Designer generated code
		 protected void OnInit(EventArgs e)
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

		

//		
		 





		

		

		protected void btnsubmit_Click(object sender, System.EventArgs e)
		{
		}
		[Ajax.AjaxMethod]
//		public void updatedate(string hiddencompcode,string hiddenuserid,string datefor)
		 public void updatedate(string hiddencompcode,string hiddenuserid,string datefor,string code,string curr,string ratecode)
		{
			//string datefor=drpdateformat.SelectedValue.ToString();
			NewAdbooking.Classes.pop abc=new NewAdbooking.Classes.pop();
			DataSet dz=new DataSet();
            //dz = abc.dateupdation(hiddencompcode, hiddenuserid, datefor, code, curr, ratecode);

//			NewAdbooking.Classes.login loginsession=new NewAdbooking.Classes.login();
//			DataSet ds=new DataSet();
//			ds=loginsession.sessiondate(hiddencompcode.Value,hiddenuserid.Value);
//
//			if(ds.Tables[0].Rows.Count > 0)
//			{
//				Session["dateformat"]=ds.Tables[0].Rows[0].ItemArray[3].ToString();
//			}

		
		}

		[Ajax.AjaxMethod]
//		public DataSet submitpermission(string hiddencompcode ,string hiddenuserid,string formname)
		 public DataSet submitpermission(string hiddencompcode ,string hiddenuserid,string formname)
		{
		
			NewAdbooking.Classes.Master checkform=new NewAdbooking.Classes.Master();
			DataSet dz=new DataSet();
			dz=checkform.formpermission(hiddencompcode,hiddenuserid,formname);
			return dz;
		}

		protected void log_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("logout.aspx");
		}

    public void bindrategroup()
    {
        NewAdbooking.Classes.pop bindrate = new NewAdbooking.Classes.pop();
        DataSet dx = new DataSet();
        dx = bindrate.ratebind(Session["compcode"].ToString());

        drprategroup.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Ad Category-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drprategroup.Items.Add(li1);

        if (dx.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < dx.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = dx.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = dx.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drprategroup.Items.Add(li);
            }

        }

    }


    public void bindcurr()
    {
        NewAdbooking.Classes.Contract bindcurre = new NewAdbooking.Classes.Contract();
        DataSet ds = new DataSet();
        ds=bindcurre.currbind(Session["compcode"].ToString());

        drpcurr.Items.Clear();
        int i;
        ListItem li1;
        li1 = new ListItem();
        li1.Text = "-Select Ad Category-";
        li1.Value = "0";//objDataSet.Tables[0].Rows[i].ItemArray[0].ToString();
        li1.Selected = true;
        drpcurr.Items.Add(li1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem li;
                li = new ListItem();
                li.Text = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                li.Value = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                //state = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                drpcurr.Items.Add(li);
            }

        }


    }
		

		
	}

